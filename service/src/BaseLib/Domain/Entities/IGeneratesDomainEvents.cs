using BaseLib.Event.Bus;
using System.Collections.Generic;

namespace BaseLib.Domain.Entities
{
    /// <summary>
    /// IGeneratesDomainEvents
    /// </summary>
    public interface IGeneratesDomainEvents
    {
        ICollection<IEventData> DomainEvents { get; }
    }
}