using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConfiguratorOfPassengerTrains
{
    public class Train : Station
    {
        private List<Wagon> _wagons = new List<Wagon>();
        private int officeWagons = 2;


        public Train(List<Direction> directions)
        {
            _directions = directions;
        }
        
        public bool CreateTrain()
        {
            var random = new Random();

            _wagons.Insert(0, new Wagon(0));
            
            while (_directions[0].CountOfPassengers > 0)
            {
                if (_directions[0].CountOfPassengers != 0)
                {
                    int countPassengerInWagon = random.Next(1, _directions[0].CountOfPassengers + 1);
                    var wagon = new Wagon(countPassengerInWagon);
                    _wagons.Add(wagon);
                    _directions[0].SetCountOfPassenger(wagon);
                }
            }
            
            _wagons.Insert(_wagons.Count, new Wagon(0));
            
            _directions.Clear();
            return true;
        }

        public void SendOnTheTrainOnTheWay()
        {
            Console.WriteLine($"Поезд в составе {_wagons.Count} вагонов отправился в путь. \nВы можете создать новый путь.");
            Thread.Sleep(2000);
            _wagons.Clear();
        }

        public int GetCountOfWagonsWithPassenger()
        {
            int countWagonsWithPassenger = 0;
            
            while (officeWagons > 0)
            {
                foreach (var wagon in _wagons)
                {
                    if (wagon.WagonCapacity != 0)
                        countWagonsWithPassenger++;
                    else
                        officeWagons--;
                }
            }

            return countWagonsWithPassenger;
        }

        public int GetCountOfOfficeWagons() => officeWagons;
    }
}