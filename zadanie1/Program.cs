using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania3
{
    public enum Food
    {
        Fish,
        Mouse,
        Feed
    }

    public class Cat
    {
        public int SatietyLevel { get; private set; }

        public void EatSomething(Food viewFood)
        {
            switch (viewFood)
            {
                case Food.Fish:
                    SatietyLevel += 10;
                    break;
                case Food.Mouse:
                    SatietyLevel += 5;
                    break;
                case Food.Feed:
                    SatietyLevel += 3;
                    break;
                default:
                    Console.WriteLine("Неверный вид еды");
                    break;
            }

            Console.WriteLine($"Кошка поела {viewFood}. Уровень сытости: {SatietyLevel}");
        }
    }

    class Program
    {
        static void Main()
        {
            Cat cat = new Cat();

            cat.EatSomething(Food.Fish);
            cat.EatSomething(Food.Mouse);
            cat.EatSomething(Food.Feed);
            cat.EatSomething((Food)42);

            Console.ReadLine();
        }
    }

}