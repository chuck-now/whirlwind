using System.Collections.Generic;

namespace BaseLib.Services
{
    /// <summary>
    /// IAvoidDuplicateCrossCuttingConcerns
    /// </summary>
    public interface IAvoidDuplicateCrossCuttingConcerns
    {
        List<string> AppliedCrossCuttingConcerns { get; }
    }
}