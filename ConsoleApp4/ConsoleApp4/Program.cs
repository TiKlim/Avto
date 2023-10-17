using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Введите номер авто: ");
            string a = Console.ReadLine();
            Console.WriteLine("Введите объём бака: ");
            float b = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите расход топлива (на 100 км): ");
            float c = float.Parse(Console.ReadLine());*/
            
            Avto car = new Avto();
            //car.Info(a, b, c);
            car.Info("О854ГО", 55, 10, 80);
            car.Ezda(10000);
            car.Out();
        }
    }
}
