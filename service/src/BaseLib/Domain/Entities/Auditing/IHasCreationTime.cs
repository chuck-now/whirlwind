using System;

namespace BaseLib.Domain.Entities.Auditing
{
    /// <summary>
    /// IHasCreationTime
    /// </summary>
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; set; }
    }
}