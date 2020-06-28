using System;
using System.Collections.Generic;
using System.Threading;

namespace ConfiguratorOfPassengerTrains
{
    public class MenuForManagementTrain
    {
        public void ShowMenu()
        {
            var direction = new Direction();
            
            bool isWorks = true;
            
            while (isWorks)
            {
                if(!direction.CheckIsDirectionEmpty())
                    direction.WriteDirection();
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
                            direction.EnterDirection();
                            break;
                        case 2:
                            var buyTicket = new Ticket();
                            buyTicket.TicketSelling(direction);
                            break;
                        case 3:
                            var createTrain = new Train();
                            createTrain.CreateTrain(direction);
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
    }
}