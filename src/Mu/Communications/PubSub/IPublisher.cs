namespace Mu.Communications.PubSub;

using Mu.Communications.Messaging;

public interface IPublisher
{
    Task Publish(CancellationToken cancellationToken, params IEnumerable<Event> events);
}