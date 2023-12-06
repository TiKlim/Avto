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
            Console.WriteLine("> Доброго времени суток.");
            Avto.Menu3(cars);
        }
    }
}