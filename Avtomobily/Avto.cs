using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Avtomobil
{
    internal class Avto
    {
        private string? nom; //Номер машины
        private float bak; //Объём бака
        private float ras; //Расход топлива
        private int speed; //Скорость
        private double top; //Текущее количество бензина
        private double probeg; //Пробег
        private double kilometragh; //На сколько километров хватит топлива
        private double rasst; //Расстояние
        private int koordinataX; //Координата X
        private int koordinataY; //Координата Y
        public string? Nom { get { return nom; } }
        public Avto() { Menu(); }

        public void Info() //Информация об автомобиле
        {
            Console.WriteLine("Номер машины (А000АА):");
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.nom = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            this.bak = 55;
            Console.WriteLine("Расход топлива (на 100 км):");
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.ras = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            this.speed = 0;
            this.top = 0;
            this.probeg = 0;
            this.kilometragh = 0;
            this.rasst = 0;
            int[] you = new int[11] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; //Прописываю координаты
            Random iks = new Random();
            var x = iks.Next(0, 11);
            koordinataX = you[x];
            int[] you2 = new int[11] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; //Прописываю координаты
            Random igrik = new Random();
            var y = igrik.Next(0, 11);
            koordinataY = you2[y];
            Menu();
        }
        public void Stop() //Торможение
        {
            speed = 0;
            rasst = 0;
            Out();
            Ezda();
            Menu();
        }
        public void Razgon() //Разгон
        {
            if (top >= 10)
            {
                speed += 10;
                Out();
                Ezda();
                Menu();
            }
            else if (top <= 10)
            {
                Console.WriteLine("! Бак пуст !");
                Console.WriteLine($"! Требуется заправка !");
                Menu();
            }
            else if (top == 0)
            {
                Console.WriteLine("! Бак пуст !");
                Console.WriteLine($"! Требуется заправка !");
                Menu();
            }
        }
        public double Zapravka() //Заправка
        {

            Console.WriteLine($"Сколько литров Вы бы хотели заправить в бак? (ОБЪЁМ ВАШЕГО БАКА: {bak}, СЕЙЧАС УРОВЕНЬ ТОПЛИВА: {top}).");
            Console.ForegroundColor = ConsoleColor.Cyan;
            double zap = Convert.ToDouble(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            if ((top + zap) <= bak) //Условие на случай переполнения бака
            {
                top += zap;
                Console.WriteLine($"Бак заправлен. Сейчас: {top} литров.");
                speed += 10;
                Menu();
            }
            else
            {
                Console.WriteLine("! Бак полон !");
                Menu();
            }
            return top;

        }
        public void Ezda() //Вводим новую переменную расстояние "S"
        {
            if (speed > 0)
            {
                if (top >= 10)
                {
                    top -= ras;
                    probeg += 100;
                    rasst += 100;
                    if (koordinataX < 10)
                    {
                        koordinataX += 1;
                    }
                    if (koordinataX == 10)
                    {
                        koordinataX = 10;
                        koordinataY += 1;
                    }
                    if ((koordinataY == 10) && (koordinataX < 10))
                    {
                        koordinataY = 10;
                        koordinataX += 1;
                    }
                    if ((koordinataX == 10) && (koordinataY == 10))
                    {
                        koordinataX = 0;
                        koordinataY = 0;
                    }
                }
                else if (top <= 10)
                {
                    Console.WriteLine("! Бак пуст !");
                    Console.WriteLine($"! Требуется заправка !");
                }
                else if (top == 0)
                {
                    top = 0;
                    probeg = 0;
                    rasst = 0;
                }
            }

                //rasst = probeg;
                double kilometragh = (top / ras) * 100; //На сколько километров хватит бензина
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("Пройдено:     Пробег:      Остаток топлива:      Километраж при текущем уровне бензина в баке: ");
                Console.WriteLine($"\n{rasst}             {probeg}            {top}                     {kilometragh}");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine($"Вы преодалели расстояние в {probeg} километров.");
            Menu();


        }
        public void Out()
        {
            Console.WriteLine($"Номер авто: {nom} \nОбъём бака: {bak} \nУровень топлива сейчас: {top} \nРасход топлива (на 100 км): {ras} \nВаша скорость: {speed} \nВаши координаты: ({koordinataX}, {koordinataY})");
        }
        public void Menu()
        {
            Console.WriteLine("> Бортовое меню:\n1 - Изменить текущую информацию по машине; 2 - Текущая информация по машине; 3 - Разогнаться; 4 - Тормозить; 5 - Заправиться; 6 - Выход в меню автомобилей.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? vybor2 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            switch (vybor2)
            {
                case "1":
                    Info();
                    break;
                case "2":
                    Out();
                    Ezda();
                    break;
                case "3":
                    Razgon();
                    break;
                case "4":
                    Stop();
                    break;
                case "5":
                    Zapravka();
                    break;
                case "6":
                    Console.WriteLine("");
                    break;
            }
        }
        public void Avaria(Avto pas)
        {
            if (pas.koordinataX == this.koordinataX && pas.koordinataY == this.koordinataY)
            {
                Console.WriteLine("! АВАРИЯ !");
            }
        }
    }
}

