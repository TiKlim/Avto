using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Avto
    {
        private string nom; //Номер машины
        private float bak; //Объём бака
        private float ras; //Расход топлива
        private int speed; //Скорость
        private double top; //Текущее количество бензина
        private double probeg; //Пробег
        private double kilometragh; //На сколько километров хватит топлива
        private double rasst; //Расстояние

        public void Info(string nom, float bak, float ras, int speed) //Информация об автомобиле
        {
            this.nom = nom;
            this.bak = bak;
            this.ras = ras;
            this.speed = speed;
            this.top = 0;
            this.probeg = 0;
            this.kilometragh = 0;
            this.rasst = 0;
        }

        public void Stop(int speed) //Торможение
        {
            speed = 0;
            ras = 0;
        }

        public void Razgon(int speed) //Разгон
        {
            speed += 10;
            ras += 10;
        }
        




        public double Zapravka() //Заправка
        {

            Console.WriteLine($"Сколько литров Вы бы хотели заправить в бак? (ОБЪЁМ ВАШЕГО БАКА: {bak}).");
            double zap = Convert.ToDouble(Console.ReadLine());

            if ((top + zap) <= bak) //Условие на случай переполнения бака
            {
                top += zap;
                Console.WriteLine($"Бак заправлен. Сейчас: {top} литров.");

            }
            else
            {
                Console.WriteLine("! Бак полон !");
            }
            return top;
            
        }

        public void Ezda(double S) //Вводим новую переменную расстояние "S"
        {
            while (probeg <= S)
            {
                if (top < ras)
                {
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                    Console.WriteLine($"! Требуется заправка !");
                    this.Zapravka();
                    

                }
                top -= ras;
                probeg += 100;
                rasst = probeg;
                if (top < 0)
                {
                    Console.WriteLine("! Бак пуст !");
                    return;
                }
                double kilometragh = (top / ras) * 100; //На сколько километров хватит бензина
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("Пройдено:       Пробег:        Остаток топлива:   Километраж при текущем уровне бензина в баке: ");
                Console.WriteLine($"\n{rasst}             {probeg}            {top}                 {kilometragh}");
            }
 

        }


        public void Out()
        {
            Console.WriteLine($"Номер авто: {nom} \nОбъём бака: {bak} \nРасход топлива (на 100 км): {ras}");
        }
    }
}
