using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RundeService.Model;
using RundeService.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RundeService
{
    public class Subscribe
    {

        private static readonly RundeContext _context;

        public Subscribe(RundeContext context)
        {
            _context = context;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                SubscribeDelete(channel);
                SubscribeRunde(channel);
            }
        }

        static void SubscribeRunde(IModel channel)
        {
            channel.ExchangeDeclare(exchange: "Runde", type: "fanout");

            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName,
                              exchange: "Runde",
                              routingKey: "");


            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);

                Runde item = Newtonsoft.Json.JsonConvert.DeserializeObject<Runde>(message);
                
                //tilføj item til context.runder
                _context.Runder.Add(item);
                //vent på det er gemt
                _context.SaveChangesAsync();
            };
            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);

            /*
            channel.QueueDeclare(queue: "Opret",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);*/
            /*
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };
            channel.BasicConsume(queue: "Opret",
                                 autoAck: true,
                                 consumer: consumer);*/

            Console.WriteLine(" Opret subscribe kør ");
            Console.ReadLine();


        }
        static void SubscribeDelete(IModel channel)
        {
            channel.ExchangeDeclare(exchange: "Delete", type: "fanout");

            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName,
                              exchange: "Delete",
                              routingKey: "");


            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var id = Encoding.UTF8.GetString(body);

                var runde = _context.Runder.Find(id);
                _context.Runder.Remove(runde);
            };
            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);

            /*
            channel.QueueDeclare(queue: "Opret",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);*/
            /*
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };
            channel.BasicConsume(queue: "Opret",
                                 autoAck: true,
                                 consumer: consumer);*/

            Console.WriteLine(" Delete subscribe kør ");



        }
    }
}
