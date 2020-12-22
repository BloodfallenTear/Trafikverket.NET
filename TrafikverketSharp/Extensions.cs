﻿using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TrafikverketSharp.Exceptions;

namespace TrafikverketSharp
{
    internal static class Extensions
    {
        internal static Boolean TrySend(this HttpClient httpClient, out HttpResponseMessage response, out Exception exception, HttpRequestMessage request)
        {
            var ex = default(Exception);
            for (Byte i = 0; i < 10; i++)
            {
                try
                {
                    response = httpClient.SendAsync(request.Clone()).ConfigureAwait(false).GetAwaiter().GetResult();
                    exception = null;

                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                        case HttpStatusCode.Accepted:
                            break;
                        case HttpStatusCode.PartialContent:
                            exception = new PartialContentException("The server returned a 206 Partial Content.");
                            return false;
                        case HttpStatusCode.BadRequest:
                            exception = new BadRequestException("The server returned a 400 Bad Request.");
                            return false;
                        case HttpStatusCode.Unauthorized:
                            exception = new UnauthorizedException("The server returned a 401 Unauthorized.");
                            return false;
                        case HttpStatusCode.InternalServerError:
                            exception = new InternalServerErrorException("The server returned a 500 Internal Server Error.");
                            return false;
                        case HttpStatusCode.NotImplemented:
                            exception = new Exceptions.NotImplementedException("The server returned a 501 Not Implemented.");
                            return false;
                    }

                    return true;
                }
                catch (Exception e) { ex = e; Task.Delay(5000).ConfigureAwait(false).GetAwaiter().GetResult(); }
            }

            response = null;
            exception = ex;
            return false;
        }

        internal static HttpRequestMessage Clone(this HttpRequestMessage request)
        {
            var clone = new HttpRequestMessage(request.Method, request.RequestUri)
            {
                Content = request.Content.Clone(),
                Version = request.Version
            };
            foreach (var prop in request.Properties)
                clone.Properties.Add(prop);
            foreach (var header in request.Headers)
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);

            return clone;
        }

        internal static HttpContent Clone(this HttpContent content)
        {
            if (content == null)
                return null;

            var ms = new MemoryStream();
            content.CopyToAsync(ms).Wait();
            ms.Position = 0;

            var clone = new StreamContent(ms);
            foreach (var header in content.Headers)
                clone.Headers.Add(header.Key, header.Value);

            return clone;
        }

        internal static String ReadAsString(this HttpContent httpContent) => httpContent.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
    }
}