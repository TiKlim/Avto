using Avtomobil;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace ConsoleApp4
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
                Console.WriteLine("> Общее меню:\n1 - Создать новый объект; 2 - Выбрать существующий объект.");
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
                            car.Out();
                            car.Ezda();
                            car.Menu();
                        }
                    }
                }
            }
        }
    }
}

