using System;

namespace ConfiguratorOfPassengerTrains
{
    public class Ticket
    {
        public void TicketSelling()
        {
            Direction direction = new Direction();
            var random = new Random();
            direction.SetCountOfPassenger(random);
        }
    }
}