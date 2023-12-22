using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Avtomobil
{
    internal class AvtoBus : Avto
    {
        protected double otsihdosih;
        protected int ostanovky;
        protected int mesta;
        public string? Nom { get { return nom; } }
        public AvtoBus() { Menu(cars); }

        /*public static void Suda(List<AvtoBus> bus)
        {
            bus.Add(new AvtoBus());
        }*/

        protected override void Info(List<Avto> cars)
        {
            Console.WriteLine("> Номер машины (А000АА):");
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.nom = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            this.bak = 60;
            Console.WriteLine("> Расход топлива (на 100 км):");
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.ras = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            if (ras >= (55 / 2))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ваш расход топлива катастрофически велик!");
                Console.ForegroundColor = ConsoleColor.White;
                Info(cars);
            }
            Console.WriteLine("> Вместительность:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.mesta = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            this.speed = 0;
            this.top = 0;
            this.probeg = 0;
            this.kilometragh = 0;
            this.rasst = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Данные сохранены.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        protected override void Menu(List<Avto> cars)
        {
            Console.WriteLine("> Бортовое меню:\n1 - Внести информацию по машине; 2 - Выход в меню автомобилей.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? vybor2 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            switch (vybor2)
            {
                case "1":
                    Info(cars); break;
                case "2":
                    Menu3(cars); break;
            }
        }
        protected override void Menu2(List<Avto> cars)
        {

            Console.WriteLine("> Бортовое меню:\n1 - Изменить Ваш маршрут; 2 - Разогнаться; 3 - Тормозить; 4 - Заправиться; 5 - Выход в меню автомобилей; 6 - Авария.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? vybor2 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            switch (vybor2)
            {
                case "1":
                    Info2(cars); break;
                case "2":
                    Razgon(cars); break;
                case "3":
                    Stop(cars); break;
                case "4":
                    Zapravka(cars); break;
                case "5":
                    Menu3(cars); break;
                case "6":
                    Avaria(cars); break;
            }
        }
        protected override void Info2(List<Avto> cars)
        {
            if (dist > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("! МАРШРУТ УЖЕ ЗАДАН !");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("> Желаете обнулить? (да/нет)");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string? yesno = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                switch (yesno)
                {
                    case "да":
                        dist = 0;
                        break;
                    case "нет":
                        Console.WriteLine("");
                        break;
                }
                Menu2(cars);
            }
            if (dist == 0)
            {
                speed = 0;
                Console.WriteLine("'МАРШРУТ'");
                Console.WriteLine("> Введите координаты Вашего маршрута: ");
                Console.WriteLine("> Начало пути: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                this.koordinataXa = Convert.ToInt32(Console.ReadLine());
                this.koordinataYa = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("> Конец пути: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                this.koordinataXb = Convert.ToInt32(Console.ReadLine());
                this.koordinataYb = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("> Количество остановок на маршруте: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                this.ostanovky = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                this.dist = Math.Round(Math.Sqrt(((koordinataXb - koordinataXa) * (koordinataXb - koordinataXa)) + ((koordinataYb - koordinataYa) * (koordinataYb - koordinataYa))));
                this.otsihdosih = Math.Round(dist / ostanovky);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Данные сохранены.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Ваш маршрут: {dist}. \nОстановок: {ostanovky}. \nСчастливого пути!");
                this.rasst = 0;
                Menu2(cars);
            }
        }
        protected override void Stop(List<Avto> cars)
        {
            speed = 0;
            Out();
            Ezda(cars);
            Menu2(cars);
        }
        protected override void Razgon(List<Avto> cars)
        {
            if (dist == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("! Маршрут не задан !");
                Console.ForegroundColor = ConsoleColor.White;
                Menu2(cars);
            }
            else if (dist > 0)
            {
                if (top > 0)
                {
                    speed += 10;
                    Out();
                    Ezda(cars);
                    Menu2(cars);
                }
                else if (top == 0)
                {
                    rasst = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!      Бак пуст      !");
                    Console.WriteLine($"! Требуется заправка !");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("> Заправиться? (да/нет)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string? zap = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (zap)
                    {
                        case "да":
                            Zapravka(cars); break;
                        case "нет":
                            Stop(cars); break;
                    }
                }
                else if (top < 0)
                {
                    //rasst = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!      Бак пуст      !");
                    Console.WriteLine($"! Требуется заправка !");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("> Заправиться? (да/нет)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string? zap = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (zap)
                    {
                        case "да":
                            Zapravka(cars); break;
                        case "нет":
                            Stop(cars); break;
                    }
                }
            }
            if (rasst >= ostanovky * otsihdosih)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("! Маршрут не задан !");
                Console.ForegroundColor = ConsoleColor.White;
                Menu2(cars);
            }
        }
        protected override void Ezda(List<Avto> cars)
        {
            if (speed > 0) //Если машина в принципе поехала
            {
                if (top > 0)
                {
                    top -= ras;
                    probeg += 100;
                    rasst += 100;
                }
                else if ((top - ras) < 0 & speed > 0)
                {
                    probeg -= 100;
                    rasst -= 100;
                    probeg += kilometragh;
                    rasst += kilometragh;
                    top = 0;
                }
                else if ((top - ras) < 0 & speed == 0)
                {
                    probeg -= 100;
                    rasst -= 100;
                    probeg += kilometragh;
                    rasst += kilometragh;
                    top = 0;
                }
                else if (top == 0)
                {
                    //rasst = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!      Бак пуст      !");
                    Console.WriteLine($"! Требуется заправка !");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("> Заправиться? (да/нет)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string? zap = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (zap)
                    {
                        case "да":
                            Zapravka(cars); break;
                        case "нет":
                            Stop(cars); break;
                    }
                }
            }
            /*if (speed == 50)
            {
                speed = 50;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("! ЭТО МАКСИМАЛЬНО ДОПУСТИМАЯ СКОРОСТЬ !");
                Console.ForegroundColor = ConsoleColor.White;
                //Out();
                //Ezda(cars);
                Menu2(cars);
            }*/
            if (rasst >= dist & dist != 0) //Для маршрута
            {
                double v = dist - (rasst - 100);
                top = (v * ras) / 100;
                probeg += v - 100;
                speed = 0;
                rasst = 0;
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("КОНЕЧНАЯ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Едем обратно.");
                Console.WriteLine("");
            }
            if (top < 2 && rasst < dist && rasst != 0)
            {
                probeg += kilometragh - 100;
                rasst += kilometragh - 100;
                top = 0;
                speed = 0;
            }
            if (rasst >= (2 * dist) & dist != 0) //Для маршрута
            {
                double v = (2 * dist) - (rasst - 100);
                top = (v * ras) / 100;
                probeg += v - 100;
                speed = 0;
                rasst = 0;
                dist = 0;
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("АВТОБУС ПРИБЫЛ НА КОНЕЧНУЮ ОСТАНОВКУ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                //Stop(cars);
            }
            if (top < 2 && rasst < (2 * dist) && rasst != 0)
            {
                probeg += kilometragh - 100;
                rasst += kilometragh - 100;
                top = 0;
                speed = 0;
            }
            if (rasst >= otsihdosih & otsihdosih != 0) //Для маршрута
            {
                double v = otsihdosih - (rasst - 100);
                top = (v * ras)/10;
                probeg += v - 100;
                rasst += v - 100;
                /*probeg -= 100;
                rasst -= 100;
                probeg += kilometragh;
                rasst += kilometragh;
                top = 0;*/
                rasst = 0;
                speed = 0;
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ОСТАНОВКА");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Stop(cars);
            }
            if (probeg >= dist)
            {
                speed = 0;
                rasst = 0;
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("КОНЕЧНАЯ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Едем обратно.");
                Console.WriteLine("");
                //Stop(cars);
            }
            /*if (top < 0 & speed > 0)
            {
                probeg -= 100;
                rasst -= 100;
                probeg += kilometragh;
                rasst += kilometragh;
                top = 0;
            }*/
            kilometragh = Math.Round((top / ras) * 100); //На сколько километров хватит бензина
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("Пройдено:     Пробег:      Остаток топлива:      Километраж при текущем уровне бензина в баке:    Скорость:");
            Console.WriteLine($"\n{rasst}             {probeg}            {top}                     {kilometragh}                                            {speed}");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine($"Ваша цель поездки: {dist} километров.");
            if (top == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!      Бак пуст      !");
                Console.WriteLine($"! Требуется заправка !");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("> Заправиться? (да/нет)");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string? zap = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                switch (zap)
                {
                    case "да":
                        Zapravka(cars); break;
                    case "нет":
                        Stop(cars); break;
                }
            }
            else
            {
                Menu2(cars);
            }
        }
    }
}