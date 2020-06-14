using System;

namespace ConfiguratorOfPassengerTrains
{
    public class Direction
    {
        private string _nameOfDirection { get; set; }
        private float _travelTime { get; set; }
        private int _numberOfTrain { get; set; }

        public Direction(string nameOfDirection, float travelTime, int numberOfTrain)
        {
            if (!string.IsNullOrWhiteSpace(nameOfDirection))
                _nameOfDirection = nameOfDirection;
            else
                Console.WriteLine("Вы не ввели имя пути!");

            if (travelTime > 0)
                _travelTime = travelTime;
            else
                Console.WriteLine("Время не может быть отрицательным!");
            
            _numberOfTrain = numberOfTrain;
        }

        public void WriteDirection() => Console.WriteLine($"{_nameOfDirection} \n{_travelTime}");

        public void EnterDirection()
        {
            var isEnterInformation = true;
            while (isEnterInformation)
            {
                Console.Write("Введите имя отправной станции: ");
                var startStation = Console.ReadLine();
                Console.Write("Введите имя конечной станции: ");
                var endStation = Console.ReadLine();
                _nameOfDirection = $"{startStation} - {endStation}";

                Console.Write("Введите время в пути(в минутах): ");
                if (float.TryParse(Console.ReadLine(), out var result))
                {
                    _travelTime = result / 60;
                    isEnterInformation = false;
                }
                else
                {
                    Console.WriteLine("Вы ввели не число!");
                }
            }
        }
    }
}