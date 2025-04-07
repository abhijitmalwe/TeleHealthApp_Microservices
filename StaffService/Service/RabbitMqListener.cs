using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using StaffService.Entities;

public class RabbitMqListener : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public RabbitMqListener(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };

        // Loop to maintain connection even if it drops
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var connection = await factory.CreateConnectionAsync();
                using var channel = await connection.CreateChannelAsync();

                await channel.QueueDeclareAsync(queue: "MicroserviceTest", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.ReceivedAsync += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    
                    var Staff = JsonSerializer.Deserialize<Staff>(message);

                    if (Staff != null)
                    {
                      
                        using (var scope = _serviceProvider.CreateScope())
                        {
                           
                        }
                    }
                };

                await channel.BasicConsumeAsync(queue: "MicroserviceTest", autoAck: true, consumer: consumer);

                // Wait until the stopping token is canceled before trying to reconnect
                await Task.Delay(Timeout.Infinite, stoppingToken);
            }
            catch (Exception ex)
            {
                // Handle the exception, possibly log it and try reconnecting
                // You may want to use a delay or exponential backoff to avoid hammering the RabbitMQ server
                await Task.Delay(5000, stoppingToken); // Retry after 5 seconds
            }
        }
    }
}
