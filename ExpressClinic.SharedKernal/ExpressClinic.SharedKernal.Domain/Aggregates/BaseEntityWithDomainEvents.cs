using ExpressClinic.SharedKernal.Domain.Events.DomainEvents;

namespace ExpressClinic.SharedKernal.Domain.Aggregates
{
    public class BaseEntityWithDomainEvents<TId>: BaseEntity<TId>
    {
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
