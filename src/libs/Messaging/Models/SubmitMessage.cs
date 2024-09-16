using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Models
{
  public record SubmitMessage(string message);

  internal record SubmitMessage2
  {
    public string Message { get; init; }

    //public SubmitMessage2()
    //{
    //  SubmitMessage sm = new(message: "Ali");
    //  sm.message = "can";
    //}
    
  }
}
