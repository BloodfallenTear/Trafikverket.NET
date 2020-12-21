using System;

namespace TrafikverketSharp.Exceptions
{
    /// <summary>
    /// Internt serverfel. <para/>
    /// More details can be found in <see href="https://github.com/BloodfallenTear/TrafikverketSharp/blob/2.0.0/docs.md#felmeddelanden">docs.md</see>
    /// </summary>
    public sealed class InternalServerErrorException : Exception
    {
        internal InternalServerErrorException(String message) : base(message) { }
    }
}
