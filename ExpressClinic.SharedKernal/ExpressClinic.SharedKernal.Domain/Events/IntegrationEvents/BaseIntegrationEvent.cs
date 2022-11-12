using MediatR;

namespace ExpressClinic.SharedKernal.Domain.Events.IntegrationEvents
{
    public abstract class BaseIntegrationEvent: IRequest
    {
        public DateTimeOffset OccuredOn { get; protected set; } = DateTimeOffset.UtcNow;
        string? EventType { get; }
    }
}
