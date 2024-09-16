using MassTransit;
using Messaging.EndPoints;
using Messaging.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Producer.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PublisherController : ControllerBase
  {
    private readonly ISendEndpointProvider sendEndpointProvider;
   

    public PublisherController(ISendEndpointProvider sendEndpointProvider)
    {
      this.sendEndpointProvider = sendEndpointProvider;
    }

    [HttpPost]
    public async Task<IActionResult> Send()
    {
      var uri = new Uri($"queue:{RabbitMqEndPoints.SubmitMessageQueue}");

    var endpoint = await sendEndpointProvider.GetSendEndpoint(uri); // submitMessageQueue consumer bu key bilmesi lazım.

      // Command oldu
      SubmitMessage @message = new(message:"Test");
       endpoint.Send(message);
      
      return Ok();
    }



  }
}
