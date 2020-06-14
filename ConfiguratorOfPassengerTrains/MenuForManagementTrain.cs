using System;
using System.Collections.Generic;
using System.Threading;

namespace ConfiguratorOfPassengerTrains
{
    public class MenuForManagementTrain : Direction
    {
        public void WriteMenu()
        {
            var menuItemNames = new List<string>
            {
                "Создать направление",
                "Продать билеты",
                "Сформировать поезд",
                "Отправить поезд",
                "Выход"
            };
            var direction = new Direction();
            var buyTicket = new Ticket();


            var isWorks = true;
            while (isWorks)
            {
                var numberOfItem = 1;
                
                direction.WriteDirection();
                Console.WriteLine();
                Console.WriteLine("Выберите пунк меню: ");
                foreach (var menuItemName in menuItemNames)
                {
                    Console.WriteLine($"{numberOfItem} - {menuItemName}");
                    numberOfItem++;
                }

                Console.Write("Ваш выбор: ");
                if (int.TryParse(Console.ReadLine(), out var result))
                {
                    switch (result)
                    {
                        case 1:
                            direction.EnterDirection();
                            break;
                        case 2:
                            direction.CountOfPassengers = buyTicket.TicketSelling();
                            break;
                        case 3:
                            //Create a train
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
    }
}