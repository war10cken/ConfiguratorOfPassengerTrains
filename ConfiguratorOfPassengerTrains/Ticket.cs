using System;

namespace ConfiguratorOfPassengerTrains
{
    public class Ticket
    {
        public void TicketSelling(Direction direction)
        {
            var random = new Random();
            direction.SetCountOfPassenger(random);
            Console.WriteLine("Билеты успешно проданы.");
        }
    }
}