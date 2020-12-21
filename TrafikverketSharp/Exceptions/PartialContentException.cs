using System;

namespace TrafikverketSharp.Exceptions
{
    /// <summary>
    /// Svaret är för stort. Maximalt tillåten datamängd kommer at returneras följt av ERROR som meddelar att svaret inte är komplett. <para/>
    /// More details can be found in <see href="https://github.com/BloodfallenTear/TrafikverketSharp/blob/2.0.0/docs.md#felmeddelanden">docs.md</see>
    /// </summary>
    public sealed class PartialContentException : Exception
    {
        internal PartialContentException(String message) : base(message) { }
    }
}
