using RabbitMQ.Client;
using System;

namespace RabbitMQConsumer
{
    class Program
    {
        private const string UserName = "guest";

        private const string Password = "guest";

        private const string HostName = "localhost";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ConnectionFactory connectionFactory = new ConnectionFactory

            {

                HostName = HostName,

                UserName = UserName,

                Password = Password,

            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();



            // accept only one unack-ed message at a time

            // uint prefetchSize, ushort prefetchCount, bool global



            channel.BasicQos(0, 1, false);

            MessageReceiver messageReceiver = new MessageReceiver(channel);

            //basic consume
            //channel.BasicConsume("demoqueue", false, messageReceiver);

            //Direct exchange
            channel.BasicConsume("request.queue", false, messageReceiver);

            Console.ReadLine();
        }
    }
}
