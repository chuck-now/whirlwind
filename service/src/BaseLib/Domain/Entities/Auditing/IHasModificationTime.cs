using System;

namespace BaseLib.Domain.Entities.Auditing
{
    /// <summary>
    /// IHasModificationTime
    /// </summary>
    public interface IHasModificationTime
    {
        DateTime? LastModificationTime { get; set; }
    }
}