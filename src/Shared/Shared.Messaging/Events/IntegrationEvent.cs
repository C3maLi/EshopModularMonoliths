namespace Shared.Messaging.Events;

public record IntegrationEvent
{
    public Guid EventId => Guid.NewGuid();
    public DateTime OccurredOn => DateTime.Now;
    public string eventType => GetType().AssemblyQualifiedName;

}
