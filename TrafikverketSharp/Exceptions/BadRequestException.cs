using System;

namespace TrafikverketSharp.Exceptions
{
    /// <summary>
    /// Thrown when a malformed request is sent. <para/>
    /// More details can be found in <see href="https://github.com/BloodfallenTear/TrafikverketSharp/blob/2.0.0/docs.md#felmeddelanden">docs.md</see>
    /// </summary>
    public sealed class BadRequestException : Exception
    {
        internal BadRequestException(String message) : base(message) { }
    }
}
