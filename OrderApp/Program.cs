using QuoterApp;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;

namespace OrderApp
{
    internal class Program
    {


        static void Main(string[] args)
        {
            var _random = new Random();
            for (int i = 0; i < 5; i++)
            {
                var order = new MarketOrder
                {
                    InstrumentId = Utils.RandomString(10),
                    Price = Math.Round((_random.NextDouble() * 1000), 3),
                    Quantity = _random.Next(1, 1000)
                };

                Utils.Publish(order);
                Console.WriteLine("InstrumenId: {0}; Price: {1}; Quantity: {2}", order.InstrumentId, order.Price, order.Quantity);
                Thread.Sleep(5000);

            }



        }
    }
}
