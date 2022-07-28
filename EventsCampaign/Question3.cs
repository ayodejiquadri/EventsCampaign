using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsCampaign
{
    /// <summary>
    /// Case of expensive request. Makes use of caching
    /// </summary>
    public class Question3
    {
        /// <summary>
        /// Cache for storing api response in memory
        /// </summary>
        private static Dictionary<DateTime, int> _apiResponseCache = new Dictionary<DateTime, int>();

        public static void Run(Customer customer, List<Event> events) 
        {
            var eventAndDistanceMapping = new Dictionary<Event, int>();

            foreach (var theEvent in events)
            {
                int distance = 0;
                if (_apiResponseCache.ContainsKey(theEvent.EventDate)) //expensive call, so we check the cache
                {
                    distance = _apiResponseCache[theEvent.EventDate];
                }
                else
                {
                    distance = GetDistance(customer.BirthDay, theEvent.EventDate); 
                    _apiResponseCache.Add(theEvent.EventDate, distance); // save response in cache for next time.
                }
                eventAndDistanceMapping.Add(theEvent, distance);
            }

            var closestEvents = eventAndDistanceMapping
                .OrderBy(kvp => kvp.Value)
                .Take(5)
                .Select(kvp => kvp.Key);
            
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