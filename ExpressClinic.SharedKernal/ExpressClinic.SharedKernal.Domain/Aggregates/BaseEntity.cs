using ExpressClinic.SharedKernal.Domain.Events.DomainEvents;

namespace ExpressClinic.SharedKernal.Domain.Aggregates
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
