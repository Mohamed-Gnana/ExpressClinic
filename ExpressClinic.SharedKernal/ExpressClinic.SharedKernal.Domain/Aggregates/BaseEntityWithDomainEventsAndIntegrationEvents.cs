using ExpressClinic.SharedKernal.Domain.Events.IntegrationEvents;

namespace ExpressClinic.SharedKernal.Domain.Aggregates
{
    public class BaseEntityWithDomainEventsAndIntegrationEvents<TId>: BaseEntityWithDomainEvents<TId>
    {
        public List<BaseIntegrationEvent> IntegrationEvents = new List<BaseIntegrationEvent>();
    }
}
