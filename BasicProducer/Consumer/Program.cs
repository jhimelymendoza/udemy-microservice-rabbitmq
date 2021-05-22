using System;
using System.Net.Http;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var chanel = connection.CreateModel())
                {
                    chanel.QueueDeclare("BasicQueueName", false, false, false, null);
                    var consumer = new EventingBasicConsumer(chanel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body.ToArray());
                        Console.WriteLine($"Mensaje recibido {message}");

                    };

                    chanel.BasicConsume("BasicQueueName", true, consumer);
                    Console.WriteLine("Presione enter para salir");
                    Console.ReadLine();
                }
            }
          
        }
    }
}
