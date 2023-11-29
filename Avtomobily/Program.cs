using Avtomobil;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Avtomobil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Avto> cars = new List<Avto>();
            Avto car;
            Console.WriteLine("> Доброго времени суток.");
            while (true)
            {
                Console.WriteLine("> Общее меню:\n1 - Выбрать новый автомобиль; 2 - Выбрать обкатанный автомобиль.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string? vybor1 = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (vybor1 == "1")
                {
                    cars.Add(new Avto());
                }
                else if (vybor1 == "2")
                {
                    foreach (Avto a in cars)
                    {
                        Console.WriteLine("Введите номер автомобиля: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        string? s = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        if (s == a.Nom)
                        {
                            car = a;
                            car.Menu2(cars);
                        }
                    }
                }
            }
        }
    }
}