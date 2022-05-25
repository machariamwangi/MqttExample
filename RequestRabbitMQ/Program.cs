using System;

namespace RequestRabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Directmessages directmessages = new Directmessages();

            directmessages.SendMessage();

            Console.ReadLine();
        }
    }
}
