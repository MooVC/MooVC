namespace Mu.Communications.PubSub;

using Microsoft.Extensions.Hosting;
using Mu.Communications.Messaging;

public interface ISubscriber
    : IHostedService
{
    event EventHandler<Event> Received;
}