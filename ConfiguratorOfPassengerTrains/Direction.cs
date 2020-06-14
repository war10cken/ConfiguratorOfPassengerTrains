using System;

namespace ConfiguratorOfPassengerTrains
{
    public class Direction
    {
        private string _nameOfDirection { get; set; }
        private float _travelTime { get; set; }
        private int _numberOfTrain { get; set; }

        public Direction()
        {
            var random = new Random();
            _numberOfTrain = random.Next(0, 99999);
            _nameOfDirection = null;
            _travelTime = 0;
        }

        public void WriteDirection() =>
            Console.WriteLine($"Название пути: {_nameOfDirection} " +
                              $"\nВремя в пути: {_travelTime:0.00} часов " +
                              $"\nНомер поезда: №{_numberOfTrain}");

        public void EnterDirection()
        {
            var isEnterInformation = true;
            while (isEnterInformation)
            {
                Console.Write("Введите имя отправной станции: ");
                var startStation = Console.ReadLine();
                Console.Write("Введите имя конечной станции: ");
                var endStation = Console.ReadLine();
                if (startStation == endStation || string.IsNullOrWhiteSpace(startStation) ||
                    string.IsNullOrWhiteSpace(endStation)) 
                {
                    Console.WriteLine("Названия путей не могу совпадать или быть пустыми!");
                    continue;
                }
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
            Console.Clear();
        }
    }
}