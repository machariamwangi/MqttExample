using System;

namespace RequestRabbitMQTopicExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Topicmessages topicmessages = new Topicmessages();

            topicmessages.SendMessage();

            Console.ReadLine();
        }
    }
}
