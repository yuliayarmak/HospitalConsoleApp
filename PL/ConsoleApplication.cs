using BLL;
using BLL.IServices;
using DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class ConsoleApplication
    {
        private readonly ConsoleService service;

        public ConsoleApplication()
        {
            service = new ConsoleService();
        }

        public void Execute()
        {
            Console.Write("Starting . . . ");
            service.invokeDatabase();
            Console.Clear();
            string choise;
            do
            {

                Console.Write("[1] - Записати хворого на прийом\n" +
                                  "[2] - Зареєструвати хворого\n" +
                                  "[3] - Знайти лікаря\n" +
                                  "[4] - Знайти хворого\n" +
                                  "[0] - Вихід\n" +
                                  "Введіть Ваш вибір: ");
                choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {
                    case "1":
                        service.logPatient();
                        break;
                    case "2":
                        try
                        {
                            service.registerPatient();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "3":
                        service.findDoctors();
                        break;
                    case "4":
                        service.findPatients();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Некоректний пункт меню!");
                        break;
                }
            } while (true);
        }
    }
}
