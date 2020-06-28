using System;

namespace ConfiguratorOfPassengerTrains
{
    public class Direction
    {
        private float _travelTimeHours { get; set; }
        private float _travelTimeMinutes { get; set; }
        private string NameOfDirection { get; set; }

        protected int NumberOfTrain { get; set; }
        
        public int CountOfPassengers { get; private set; }


        public Direction()
        {
            NameOfDirection = null;
            _travelTimeHours = 0;
            CountOfPassengers = 0;
        }

        public void WriteDirection()
        {
            Console.Write($"Название пути: {NameOfDirection} " +
                          $"\nВремя в пути: {_travelTimeHours:0} часа(-ов) {_travelTimeMinutes:00} минуты" +
                          $"\nНомер поезда: №{NumberOfTrain} " +
                          $"\nКол-во пассажиров: {CountOfPassengers}");
            Console.WriteLine();
        }

        public void EnterDirection()
        {
            var random = new Random();
            NumberOfTrain = random.Next(0, 99999);

            bool isEnterInformation = true;
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
                    int hour = 0;
                    while (result > 60)
                    {
                        result -= 60;
                        _travelTimeHours = ++hour;
                    }

                    _travelTimeMinutes = result;
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
    }
}