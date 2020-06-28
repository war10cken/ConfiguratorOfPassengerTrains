using System;

namespace ConfiguratorOfPassengerTrains
{
    public class Direction
    {
        private float _travelTimeHours { get; set; }
        private float _travelTimeMinutes { get; set; }
        private string _nameOfDirection { get; set; }
        private int _numberOfTrain { get; }
        public int CountOfPassengers { get; private set; }

        public Direction()
        {
            var random = new Random();
            _nameOfDirection = null;
            _travelTimeHours = 0;
            CountOfPassengers = 0;
            _numberOfTrain = random.Next(0, 99999);
        }

        public void WriteDirection()
        {
            Console.Write($"Название пути: {_nameOfDirection} " +
                          $"\nВремя в пути: {_travelTimeHours:0} часа(-ов) {_travelTimeMinutes:00} минуты" +
                          $"\nНомер поезда: №{_numberOfTrain} " +
                          $"\nКол-во пассажиров: {CountOfPassengers}");
            Console.WriteLine();
        }

        public void EnterDirection()
        {
            bool isEnterInformation = true;
            
            while (isEnterInformation)
            {
                Console.Clear();
                
                Console.Write("Введите имя отправной станции: ");
                string startStation = Console.ReadLine();
                Console.Write("Введите имя конечной станции: ");
                string endStation = Console.ReadLine();
                
                if (startStation == endStation)
                {
                    Console.WriteLine("Названия путей не могу совпадать.");
                    continue;
                }
                
                if (string.IsNullOrWhiteSpace(startStation) || string.IsNullOrWhiteSpace(endStation))
                {
                    Console.WriteLine("Названия путей не могу быть пустыми.");
                    continue;
                }
                
                _nameOfDirection = $"{startStation} - {endStation}";

                Console.Write("Введите время в пути(в минутах): ");
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    SetTravelTime(result);
                    isEnterInformation = false;
                }
                else
                {
                    Console.WriteLine("Вы ввели не число!");
                }
            }

            Console.Clear();
        }

        
        public void SetCountOfPassenger(Random random)
        {
            CountOfPassengers = random.Next(0, 361);
        }

        public bool CheckIsDirectionEmpty()
        {
            return string.IsNullOrEmpty(_nameOfDirection);
        }

        private void SetTravelTime(int result)
        {
            int hour = 0;
            while (result > 60)
            {
                result -= 60;
                _travelTimeHours = ++hour;
            }

            _travelTimeMinutes = result;
        }
        
    }
}