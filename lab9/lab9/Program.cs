using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public static class StrUpgrade
    {
        public static Func<string, string> StrFunc;
        public static Action<string> action;

        private static string AddDot(string str)//добавить точку
        {
            str += ".";
            return str;
        }
        private static void SubString(string str)//выделить 1 слово
        {
            Console.WriteLine(str.Substring(0, 5));
        }
        private static string RemoveDoubleSpaces(string str)//заменить 2 пробел
        {

            return str.Replace("  ", "_");
        }
        private static string ToUpperCase(string str)//капсы
        {

            return str.ToUpper();
        }
        private static string RemoveCom(string str)//удалить запятые
        {
            return str.Replace(",", " ");
        }
        public static void Upgrade(string str)
        {

            StrFunc = RemoveCom;
            StrFunc?.Invoke(str);
            Console.WriteLine(StrFunc(str));
            StrFunc += ToUpperCase;
            StrFunc?.Invoke(str);
            Console.WriteLine(StrFunc(str));
            StrFunc += RemoveDoubleSpaces;
            StrFunc?.Invoke(str);
            Console.WriteLine(StrFunc(str));
            StrFunc += AddDot;
            StrFunc?.Invoke(str);
            Console.WriteLine(StrFunc(str));
            action = SubString;
            action?.Invoke(str);
        }
    }
    class Boss
    {
        public static int Age;
        static bool OnOff = false;
        static int person_power = 220;
        static int tech_power = 500;
        public static int techvolt;
        public static int persVolt;
        public int Techvolt
        {
            get
            {
                return techvolt;
            }
            set
            {
                if (value > 0)
                {
                    techvolt = value;
                }
            }
        }
        public delegate void Technic(string str);
        public event Technic Upgrade;
        public event Technic TurnOn;
        public Boss(int age)
        {
            Age = age;
        }
        public void On()
        {
            OnOff = true;
            Upgrade?.Invoke("Техника включена");
        }
        public void Add(int vlt)
        {
            if (OnOff == true)
            {
                techvolt += vlt;
                persVolt += vlt;

                if (techvolt < tech_power)
                {
                    TurnOn?.Invoke($"Мощность увеличина на {vlt}");
                    TurnOn?.Invoke($"(В настоящий момент мощность техники {techvolt})");

                }
                else
                {
                    Console.WriteLine("Техника сломалась");
                }
                if (persVolt < person_power)
                {
                    TurnOn?.Invoke($"(В настоящий момент мощность человека {persVolt})");
                }
                else
                {
                    Console.WriteLine("Человек сломался");
                }

            }
            else
            {
                Console.WriteLine("Вы не включили технику");
            }

        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Proga,  oop,  laba, done";
            Console.WriteLine(str);
            StrUpgrade.Upgrade(str);
            Boss boss1 = new Boss(18);
            Boss boss2 = new Boss(25);
            boss1.Upgrade += st => Console.WriteLine(st);
            boss1.TurnOn += st => Console.WriteLine(st);
            boss2.Upgrade += st => Console.WriteLine(st);
            boss2.TurnOn += st => Console.WriteLine(st);
            boss1.Techvolt = 100;//пока не включили технику
            boss1.Add(70);
            boss1.On();//после включения
            boss1.Techvolt = 100;
            boss1.Add(70);
            boss2.On();//после включения
            boss2.Techvolt = 90;
            boss2.Add(400);
            Console.ReadLine();
        }
    }
}
