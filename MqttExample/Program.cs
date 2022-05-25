using RabbitMQ.Client;
using System;
using System.Threading.Tasks;

namespace MqttExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string UserName = "guest";
            string Password = "guest";
            string HostName = "localhost";

            //Main entry point to the RabbitMQ .NET AMQP client
            var connectionFactory = new RabbitMQ.Client.ConnectionFactory()
            {
                UserName = UserName,
                Password = Password,
                HostName = HostName
            };

            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();

            Console.WriteLine("Creating Exchange");
            // Create Exchange
            model.ExchangeDeclare("demoExchange", ExchangeType.Direct);

            //create QUEUE
            Console.WriteLine("Creating Queue");
            model.QueueDeclare("demoqueue", true, false, false, null);

            //Bind Queue to exchange
            Console.WriteLine("Creating Binding");
            model.QueueBind("demoqueue", "demoExchange", "directexchange_key");

            Console.ReadLine();

        }
    }
}
