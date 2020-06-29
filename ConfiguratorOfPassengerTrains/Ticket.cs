using System;

namespace ConfiguratorOfPassengerTrains
{
    public class Ticket
    {
        public bool IsSold { get; private set; }
        public void TicketSelling()
        {
            var random = new Random();
            var station = new Station();
            try
            {
                var s = station.Directions[0];
                var direction = station.GetDirection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Data);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }
           
            // direction.SetCountOfPassenger(random);
            IsSold = true;
            
            Console.WriteLine("Билеты успешно проданы.");
        }

        
    }
}