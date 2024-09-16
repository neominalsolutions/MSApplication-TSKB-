using MassTransit;
using Messaging.Models;

namespace Consumer.Api.Consumers
{
  public class MessageSubmittedConsumer : IConsumer<MessageSubmitted>
  {
    public async Task Consume(ConsumeContext<MessageSubmitted> context)
    {

      Console.WriteLine("Consumer Message Submitted");

      await Task.CompletedTask;
    }
  }
}
