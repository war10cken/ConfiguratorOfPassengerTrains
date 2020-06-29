using System;
using System.Collections.Generic;

namespace ConfiguratorOfPassengerTrains
{
    public class Train 
    {
        private readonly List<Wagon> _train = new List<Wagon>();
        
        
        public void CreateTrain()
        {
            var random = new Random();
            var station = new Station();
            var direction = station.GetDirection();
            bool isCreatedWagons = true;

            while (isCreatedWagons)
            {
                if (direction.CountOfPassengers != 0)
                {
                    int countPassengerInWagon = random.Next(1, direction.CountOfPassengers + 1);
                    var wagon = new Wagon(countPassengerInWagon);
                    _train.Add(wagon);
                    direction.SetCountOfPassenger(wagon);
                }
                else
                {
                    Console.WriteLine("Пассажиры сели на свои места.");
                    isCreatedWagons = false;
                }
            }
        }

        public void SendOnTheTrainOnTheWay()
        {
            
        }

       
    }
}