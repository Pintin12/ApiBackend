using MediatR;

namespace Domain.Primitivies
{
    public record DomainEvent(Guid Id) : INotification;
}
