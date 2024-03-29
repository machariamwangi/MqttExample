﻿using RabbitMQ.Client;
using System;

namespace RabbitMQConsumerTopicExchange
{
    class Program
    {
        private const string UName = "guest";

        private const string Pwd = "guest";

        private const string HName = "localhost";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
         



            ConnectionFactory connectionFactory = new ConnectionFactory

            {

                HostName = HName,

                UserName = UName,

                Password = Pwd,

            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            // accept only one unack-ed message at a time

            // uint prefetchSize, ushort prefetchCount, bool global

            channel.BasicQos(0, 1, false);

            MessageReceiver messageReceiver = new MessageReceiver(channel);

            channel.BasicConsume("topic.bombay.queue", false, messageReceiver);

            Console.ReadLine();

        }
    
    }
}
