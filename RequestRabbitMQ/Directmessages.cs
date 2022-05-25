using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestRabbitMQ
{
   public class Directmessages
    {
        private const string UName = "guest";

        private const string PWD = "guest";

        private const string HName = "localhost";

        public void SendMessage()

        {

            //Main entry point to the RabbitMQ .NET AMQP client

            var connectionFactory = new ConnectionFactory()

            {

                UserName = UName,

                Password = PWD,

                HostName = HName

            };

            var connection = connectionFactory.CreateConnection();

            var model = connection.CreateModel();

            var properties = model.CreateBasicProperties();

            properties.Persistent = false;

            byte[] messagebuffer = Encoding.Default.GetBytes("Direct Message");

            model.BasicPublish("request.exchange", "directexchange_key", properties, messagebuffer);

            Console.WriteLine("Message Sent");

        }
    }
}
