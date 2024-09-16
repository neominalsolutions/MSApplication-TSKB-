using MassTransit;
using Messaging.Models;

namespace Notification.Api.Consumers
{
  public class MessageSubmittedConsumer : IConsumer<MessageSubmitted>
  {
    public async Task Consume(ConsumeContext<MessageSubmitted> context)
    {

      Console.WriteLine("Notification Message Submitted");

      await Task.CompletedTask;
    }
  }
}
