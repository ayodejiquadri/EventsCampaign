using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsCampaign
{
    /// <summary>
    /// Case of finding events in the customer's city
    /// </summary>
    public class Question1
    {
        public static void Run(Customer customer, List<Event> events) 
        {
            var matchingEvents = events.Where(e => e.City.Equals(customer.City, StringComparison.InvariantCultureIgnoreCase));
            foreach (var theEvent in matchingEvents)
            {
                AddEmail(customer, theEvent);
            }
        }

        private static void AddEmail(Customer customer, Event theEvent) 
        {
            Console.WriteLine("Customer: {0}, Event: {1}", customer.Name, theEvent.Name);
        }
    }
}