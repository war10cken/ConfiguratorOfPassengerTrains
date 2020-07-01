using System;
using System.Collections.Generic;

namespace ConfiguratorOfPassengerTrains
{
    public class Train : Station
    {
        private readonly List<Wagon> _train = new List<Wagon>();

        public Train(List<Direction> directions)
        {
            _directions = directions;
        }
        
        public bool CreateTrain()
        {
            var random = new Random();

            while (_directions[0].CountOfPassengers > 0)
            {
                if (_directions[0].CountOfPassengers != 0)
                {
                    int countPassengerInWagon = random.Next(1, _directions[0].CountOfPassengers + 1);
                    var wagon = new Wagon(countPassengerInWagon);
                    _train.Add(wagon);
                    _directions[0].SetCountOfPassenger(wagon);
                }
            }
            
            _directions.Clear();
            return true;
        }

        public void SendOnTheTrainOnTheWay()
        {
            _train.Clear();
            Console.WriteLine("Поезд отправлен. \nВы можете создать новый путь.");
        }
    }
}