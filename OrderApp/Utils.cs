using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace OrderApp
{
    public static class Utils
    {
        private static Random random = new Random();

        private static readonly ConnectionFactory factory;

        static Utils()
        {
            factory = new ConnectionFactory { HostName = "localhost" };
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void Publish(MarketOrder order)
        {
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.ExchangeDeclare(exchange: "x-market", 
                                    type: ExchangeType.Direct, 
                                    durable: true
                                    );

            var json = JsonConvert.SerializeObject(order);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(
                exchange: "x-market",
                routingKey: "oil",
                basicProperties: null,
                body: body);

        }




    }
}

