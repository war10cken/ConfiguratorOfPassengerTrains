using System;
using System.Collections.Generic;

namespace ConfiguratorOfPassengerTrains
{
    public class Train 
    {
        private List<Wagon> _train = new List<Wagon>();
        
        public void CreateTrain(Direction direction)
        {
            var random = new Random();
            int countOfPassengerInWagon = random.Next(1, direction.CountOfPassengers);
            
            //TODO: доделать создание поезда
            
            for (int i = 0; i < direction.CountOfPassengers; i++)
            {
                _train.Add(new Wagon(countOfPassengerInWagon));
            }
        }
    }
}