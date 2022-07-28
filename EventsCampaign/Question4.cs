using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsCampaign
{
    /// <summary>
    /// Case of failing api. Makes use of try catch
    /// </summary>
    public class Question4
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
                    try
                    {
                        distance = GetDistance(customer.BirthDay, theEvent.EventDate);
                    }
                    catch (Exception ex)  //handle case of API failing, so the whole process never fails
                    {
                        Console.WriteLine("Error calling GetDistance Api: {0}", ex.Message);
                        continue;
                    }
                    _apiResponseCache.Add(theEvent.EventDate, distance); // save response in cache for next time.
                }
                eventAndDistanceMapping.Add(theEvent, distance);
            }

            IEnumerable<Event> closestEvents = null;
            if (eventAndDistanceMapping.Count == 0) // if the API was down and we got no response. We take the first 5 events
            {
                closestEvents = events.Take(5);
            }
            else 
            {
                closestEvents = eventAndDistanceMapping
                    .OrderBy(kvp => kvp.Value)
                    .Take(5)
                    .Select(kvp => kvp.Key);
            }
            
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
            throw new  Exception("API Down!"); // Simulate api downtime
        }
    }
}