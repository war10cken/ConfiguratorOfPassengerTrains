using System;

namespace ConfiguratorOfPassengerTrains
{
    public class Direction
    {
        public DateTime TravelTime { get; }
        public string NameOfDirection { get; }
        public int NumberOfTrain { get; }
        public int CountOfPassengers { get; private set; }

        public Direction(string nameOfDirection, DateTime travelTime, int countOfPassengers, int numberOfTrain)
        {
            NameOfDirection = nameOfDirection;
            TravelTime = travelTime;
            CountOfPassengers = countOfPassengers;
            NumberOfTrain = numberOfTrain;
        }

        public void SetCountOfPassenger(Random random)
        { 
            CountOfPassengers = random.Next(0, 361);
        }

        public void SetCountOfPassenger(Wagon wagon)
        {
            CountOfPassengers -= wagon.WagonCapacity;
        }
        
    }
}