using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SpilService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpilService
{
    public class Subscribe : BackgroundService
    {


        public Subscribe()
        {
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                SqlQueryInsert queryInsert = new SqlQueryInsert();   
                SubscribeDelete(channel,queryInsert);
                SubscribeRunde(channel,queryInsert);
                await Task.Delay(1);
                while (true) { }
            }
        }

        void SubscribeRunde(IModel channel, SqlQueryInsert queryInsert)
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
                queryInsert.RunderInsert(item);    
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



        }
        void SubscribeDelete(IModel channel, SqlQueryInsert queryInsert)
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
                Runde item = Newtonsoft.Json.JsonConvert.DeserializeObject<Runde>(message);
                queryInsert.RunderDelete(item);

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

        }
        }
