using System;

namespace TrafikverketSharp.Exceptions
{
    /// <summary>
    /// Misslyckad autentisering. <para/>
    /// More details can be found in <see href="https://github.com/BloodfallenTear/TrafikverketSharp/blob/2.0.0/docs.md#felmeddelanden">docs.md</see>
    /// </summary>
    public sealed class UnauthorizedException : Exception
    {
        internal UnauthorizedException(String message) : base(message) { }
    }
}
