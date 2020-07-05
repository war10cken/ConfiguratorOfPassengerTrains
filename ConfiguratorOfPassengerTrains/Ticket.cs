using System;
using System.Collections.Generic;

namespace ConfiguratorOfPassengerTrains
{
    public class Ticket : Station
    {
        public Ticket(List<Direction> directions)
        {
            _directions = directions;
        }
        public void TicketSelling()
        {
            if (_directions.Count == 0)
            {
                Console.WriteLine("Вы не создали направление.");
                return;
            }
            
            var random = new Random();

            _directions[0].SetCountOfPassenger(random);

            Console.WriteLine();
            Console.WriteLine($"Успешно продано {_directions[0].CountOfPassengers} билетов");
        }

    }
}