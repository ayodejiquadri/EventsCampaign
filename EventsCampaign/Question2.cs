using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsCampaign
{
    /// <summary>
    /// Case of getting the 5 closest events
    /// </summary>
    public class Question2
    {
        public static void Run(Customer customer, List<Event> events) 
        {
            var eventAndDistanceMapping = new Dictionary<Event, int>();

            foreach (var theEvent in events)
            {
                var distance = GetDistance(customer.BirthDay, theEvent.EventDate);
                eventAndDistanceMapping.Add(theEvent, distance);
            }

            var closestEvents = eventAndDistanceMapping
                .OrderBy(kvp => kvp.Value)
                .Select(kvp => kvp.Key)
                .Take(5);
            
            foreach (var theEvent in closestEvents)
            {
                AddEmail(customer, theEvent);
            }
        }

        private static void AddEmail(Customer customer, Event theEvent) 
        {
            Console.WriteLine("Customer: {0}, Event: {1}, City: {2}", customer.Name, theEvent.Name, theEvent.City);
        }

        /// <summary>
        /// Returns the days difference between the customer's birthday and the event date
        /// </summary>
        /// <param name="customerDob">Customer's date of birth</param>
        /// <param name="theEventDate">The event date</param>
        /// <returns>The days difference</returns>
        private static int GetDistance(DateTime customerDob, DateTime theEventDate)
        { 
            var dayDifference = (theEventDate - customerDob).Days;
            return dayDifference;
        }
    }
}