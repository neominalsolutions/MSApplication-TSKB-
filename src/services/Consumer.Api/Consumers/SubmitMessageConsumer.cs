using MassTransit;
using Messaging.Models;

namespace Consumer.Api.Consumers
{
  public class SubmitMessageConsumer : IConsumer<SubmitMessage>
  {
    private readonly IPublishEndpoint publishEndpoint;

    public SubmitMessageConsumer(IPublishEndpoint publishEndpoint)
    {
      this.publishEndpoint = publishEndpoint;
    }

    public async Task Consume(ConsumeContext<SubmitMessage> context)
    {
      Console.WriteLine(context.Message.message);

      var @event = new MessageSubmitted(Guid.NewGuid().ToString(), context.Message.message);

      // Fanout exchange olarak çalışıcak, broadcast yapacak.Dinliyen herbir consumer evente erişebilir.
     await this.publishEndpoint.Publish(@event);

      await Task.CompletedTask;
    }
  }
}
