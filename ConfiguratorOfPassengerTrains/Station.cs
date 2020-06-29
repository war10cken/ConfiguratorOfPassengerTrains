using System;
using System.Collections.Generic;
using System.Threading;

namespace ConfiguratorOfPassengerTrains
{
    public class Station
    {
        public List<Direction> Directions { get; } = new List<Direction>();

        public void ShowMenu()
        {
            bool isWorks = true;
            
            while (isWorks)
            {
                if(!CheckIsDirectionEmpty())
                   WriteDirection();
                else
                    Console.WriteLine("Путь ещё не создан.");

                Console.WriteLine();
                
                WriteMenuItems();

                Console.Write("Ваш выбор: ");
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    switch (result)
                    {
                        case 1:
                            EnterDirection();
                            break;
                        case 2:
                            var buyTicket = new Ticket();
                            buyTicket.TicketSelling();
                            break;
                        case 3:
                            var createTrain = new Train();
                            createTrain.CreateTrain();
                            break;
                        case 4:
                            //Send a train
                            break;
                        case 5:
                            isWorks = false;
                            break;
                    }

                    Thread.Sleep(1500);
                    Console.Clear();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы ввели не цифру или не существующий пункт меню");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        private void WriteMenuItems()
        {
            int numberOfItem = 1;
            var menuItemNames = new List<string>
            {
                "Создать направление",
                "Продать билеты",
                "Сформировать поезд",
                "Отправить поезд",
                "Выход"
            };
            
            Console.WriteLine("Выберите пунк меню: ");
            foreach (var menuItemName in menuItemNames)
            {
                Console.WriteLine($"{numberOfItem} - {menuItemName}");
                numberOfItem++;
            }
        }

        private void EnterDirection()
        {
            string nameOfDirection;
            var travelTime = new DateTime();
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

                nameOfDirection = $"{startStation} - {endStation}";
                
                Console.Write("Введите время в пути(в минутах): ");
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    travelTime = SetTravelTime(result, travelTime);
                    isEnterInformation = false;
                }
                else
                {
                    Console.WriteLine("Вы ввели не число!");
                }
                
                
                var random = new Random();
                
                Directions?.Add(new Direction(nameOfDirection, travelTime, 0, random.Next(0, 99999)));
            }

            Console.Clear();
        }

        private bool CheckIsDirectionEmpty()
        {
            return Directions.Count == 0;
        }
        
        private DateTime SetTravelTime(int result, DateTime travelTime)
        {
            int hour = 0;
            while (result > 60)
            {
                result -= 60;
                hour++;
            }
            travelTime = travelTime.AddHours(hour);
            travelTime = travelTime.AddMinutes(result);
            return travelTime;
        }

        public Direction GetDirection()
        {
            return Directions[0];
        }

        private void WriteDirection()
        {
            foreach (var direction in Directions)
            {
                Console.Write($"Название пути: {direction.NameOfDirection} " +
                              $"\nВремя в пути: {direction.TravelTime.Hour:0} часа(-ов) {direction.TravelTime.Minute:00} минуты" +
                              $"\nНомер поезда: №{direction.NumberOfTrain} " +
                              $"\nКол-во пассажиров: {direction.CountOfPassengers}");
            }
            Console.WriteLine();
        }
    }
}