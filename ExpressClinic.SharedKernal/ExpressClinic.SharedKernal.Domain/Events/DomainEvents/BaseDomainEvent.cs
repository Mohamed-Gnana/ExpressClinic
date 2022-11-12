using MediatR;

namespace ExpressClinic.SharedKernal.Domain.Events.DomainEvents
{
    public abstract class BaseDomainEvent: IRequest
    {
        public DateTimeOffset OccuredOn { get; protected set; } = DateTimeOffset.UtcNow;
    }
}
