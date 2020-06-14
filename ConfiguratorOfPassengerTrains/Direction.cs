using System;

namespace ConfiguratorOfPassengerTrains
{
    public class Direction
    {
        private            float  _travelTime       { get; set; }
        private            string NameOfDirection   { get; set; }
        protected          int    NumberOfTrain     { get; set; }
        //FIXME: Исправить internal
        protected internal int    CountOfPassengers { get; set; }


        public Direction()
        {
            NameOfDirection   = null;
            _travelTime       = 0;
            CountOfPassengers = 0;
        }

        public void WriteDirection()
        {
            Console.Write($"Название пути: {NameOfDirection} " +
                          $"\nВремя в пути: {_travelTime:0} часов " +
                          $"\nНомер поезда: №{NumberOfTrain} " +
                          $"\nКол-во пассажиров: {CountOfPassengers}");
            Console.WriteLine();
        }

        public void EnterDirection()
        {
            var random = new Random();
            NumberOfTrain = random.Next(0, 99999);

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

                NameOfDirection = $"{startStation} - {endStation}";

                Console.Write("Введите время в пути(в минутах): ");
                if (float.TryParse(Console.ReadLine(), out var result))
                {
                    _travelTime        = result / 60;
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