using System;

namespace ConfiguratorOfPassengerTrains
{
    public class Ticket : Direction
    {
        public int TicketSelling()
        {
            var random = new Random();
            CountOfPassengers = random.Next(0, 361);
            return CountOfPassengers;
        }
    }
}