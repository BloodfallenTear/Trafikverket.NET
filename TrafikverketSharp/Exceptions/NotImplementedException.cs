using System;

namespace TrafikverketSharp.Exceptions
{
    /// <summary>
    /// Servern stödjer inte en funktion som efterfrågades av klienten. <para/>
    /// More details can be found in <see href="https://github.com/BloodfallenTear/TrafikverketSharp/blob/2.0.0/docs.md#felmeddelanden">docs.md</see>
    /// </summary>
    public sealed class NotImplementedException : Exception
    {
        internal NotImplementedException(String message) : base(message) { }
    }
}
