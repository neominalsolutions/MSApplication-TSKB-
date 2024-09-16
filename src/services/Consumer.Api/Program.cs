using Consumer.Api.Consumers;
using MassTransit;
using Messaging.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(config =>
{
  config.AddConsumer<SubmitMessageConsumer>(); // Command
  config.AddConsumer<MessageSubmittedConsumer>(); // Message


  config.UsingRabbitMq((context, config) =>
  {
    config.Host(builder.Configuration.GetConnectionString("RabbitMqConn"));

    
      // Event için bu tanýmlaama doðru fakat command yada message gönderimi yaptýðýmýzda ilgili queue tanýmý yapmalýyýz. Direct Extanchage kullandýðýmýz için.
      //e.ConfigureConsumer<SubmitMessageConsumer>(context);

      config.ReceiveEndpoint(RabbitMqEndPoints.SubmitMessageQueue, e => { 
        e.ConfigureConsumer<SubmitMessageConsumer>(context);
      });

       // kuyruk olmadan yönetir.
       config.ReceiveEndpoint(e => e.ConfigureConsumer<MessageSubmittedConsumer>(context));



  });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
