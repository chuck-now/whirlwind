using System;

namespace BaseLib.Domain.Entities.Auditing
{
    /// <summary>
    /// IHasDeletionTime
    /// </summary>
    public interface IHasDeletionTime : ISoftDelete
    {
        DateTime? DeletionTime { get; set; }
    }
}