using System;
using System.Collections.Generic;
using System.Linq;
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
        private int koordinataXa; //Координата X
        private int koordinataYa; //Координата Y
        private int koordinataXb; //Координата X
        private int koordinataYb; //Координата Y
        private double dist; //Дистанция
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Данные сохранены.");
            Console.ForegroundColor = ConsoleColor.White;
            Menu();
        }
        public void Info2()
        {
            Console.WriteLine("'Моя поездка'");
            Console.WriteLine("Введите координаты Вашего путешествия:");
            Console.WriteLine("Начало пути: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.koordinataXa = Convert.ToInt32(Console.ReadLine());
            this.koordinataYa = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Конец пути: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.koordinataXb = Convert.ToInt32(Console.ReadLine());
            this.koordinataYb = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            this.dist = Math.Sqrt(((koordinataXa - koordinataXb) * 2) + ((koordinataYa - koordinataYb) * 2));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Данные сохранены.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Ваша цель поездки: {dist}. Счастливого пути!");
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
            double kilometragh = (top / ras) * 100; //На сколько километров хватит бензина
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("Пройдено:     Пробег:      Остаток топлива:      Километраж при текущем уровне бензина в баке: ");
            Console.WriteLine($"\n{rasst}             {probeg}            {top}                     {kilometragh}");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine($"Ваша цель поездки: {dist} километров.");
            Menu();
        }
        public void Out()
        {
            Console.WriteLine($"Номер авто: {nom} \nОбъём бака: {bak} \nУровень топлива сейчас: {top} \nРасход топлива (на 100 км): {ras} \nВаша скорость: {speed}");
        }
        public void Menu()
        {
            Console.WriteLine("> Бортовое меню:\n1 - Внести информацию по машине; 2 - Изменить Вашу цель поездки; 3 - Разогнаться; 4 - Тормозить; 5 - Заправиться; 6 - Выход в меню автомобилей.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? vybor2 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            switch (vybor2)
            {
                case "1":
                    Info();
                    break;
                case "2":
                    Info2();
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
        /*public void Avaria(Avto pas)
        {
            if (pas.koordinataX == this.koordinataX && pas.koordinataY == this.koordinataY)
            {
                Console.WriteLine("! АВАРИЯ !");
            }
        }*/
    }
}
