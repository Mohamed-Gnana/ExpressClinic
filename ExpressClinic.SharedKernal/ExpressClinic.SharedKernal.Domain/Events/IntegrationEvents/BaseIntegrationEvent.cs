using MediatR;

namespace ExpressClinic.SharedKernal.Domain.Events.IntegrationEvents
{
    public abstract class BaseIntegrationEvent: INotification
    {
        public DateTimeOffset OccuredOn { get; protected set; } = DateTimeOffset.UtcNow;
        string? EventType { get; }
    }
}
