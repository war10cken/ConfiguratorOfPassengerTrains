using System;
using System.Collections.Generic;

namespace ConfiguratorOfPassengerTrains
{
    public class Ticket : Station
    {
        public bool IsSold { get; private set; }

        public Ticket(List<Direction> directions)
        {
            _directions = directions;
        }
        public void TicketSelling()
        {
            var random = new Random();
            var direction = _directions[0];
            
           
            direction.SetCountOfPassenger(random);
            IsSold = true;
            
            Console.WriteLine("Билеты успешно проданы.");
        }

    }
}