using System;

namespace BaseLib.Timing
{
    /// <summary>
    /// DisableDateTimeNormalizationAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class DisableDateTimeNormalizationAttribute : Attribute
    {
    }
}