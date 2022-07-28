using System;
using System.Collections.Generic;

namespace EventsCampaign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var events = GetEvents();
            var customer = GetCustomer();

            //Question1.Run(customer, events);
            //Question2.Run(customer, events);
            //Question3.Run(customer, events);
            //Question4.Run(customer, events);
            Question5.Run(customer, events);

            Console.ReadKey();
        }

        private static List<Event> GetEvents()
        {
            return new List<Event>
            {
                new Event{ Name = "Phantom of the Opera", City = "New York", EventDate = new DateTime(2022, 12, 21), Price = 100},
                new Event{ Name = "Metallica", City = "Los Angeles", EventDate = new DateTime(2022, 12, 14), Price = 25},
                new Event{ Name = "Metallica", City = "New York", EventDate = new DateTime(2023, 6, 21), Price = 50},
                new Event{ Name = "Metallica", City = "Boston", EventDate = new DateTime(2023, 3, 13), Price = 150},
                new Event{ Name = "LadyGaGa", City = "New York", EventDate = new DateTime(2023, 5, 21), Price = 80},
                new Event{ Name = "LadyGaGa", City = "Boston", EventDate = new DateTime(2023, 7, 21), Price = 100},
                new Event{ Name = "LadyGaGa", City = "Chicago", EventDate = new DateTime(2023, 7, 21), Price = 30},
                new Event{ Name = "LadyGaGa", City = "San Francisco", EventDate = new DateTime(2022, 10, 21), Price = 120},
                new Event{ Name = "LadyGaGa", City = "Washington", EventDate = new DateTime(2023, 6, 20), Price = 60}
            };
        }

        private static Customer GetCustomer()
        {
            return new Customer { Name = "John Smith", City = "New York", BirthDay = new DateTime(2022, 10, 20) };
        }
    }
}