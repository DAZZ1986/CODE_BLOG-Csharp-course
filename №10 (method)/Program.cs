using System;

namespace CODE_BLOG__10
{
    class Program
    {
        static void Main(string[] args)
        {
            // Методы C# (Method C#) классов - Учим Шарп #10
            /*синтаксис метода
            модификатор_доступа, тип_возвращ_значения имя_метода(тип_аргумента имя_аргумента)
            {
                тело_метода;
            }

            static - если это метод, то он который будет относиться ко всему классу в целом, а не к конкретному экземпляру.
            Если это переменная, то это общая переменная, которая будет доступна всем экземплярам класса одноврименно. 
            Со статикой нужно быть максимально аккуратным! Чаще методы объявляются не статические, внутри наших собственных классов.
            */

            var hi = PrintHello("Ivan", 24);
            Console.WriteLine(hi);

            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||");


            Person person1 = new Person("Ivanov", "Ivan");
            var person2 = new Person("Petrov", "Petr");

            for (int i = 0; i < 4; i++)
            {
                var position1 = person1.Run();
                Console.WriteLine(position1);

                string position2 = person2.Run();
                Console.WriteLine(position2);

                Console.WriteLine(person1.Run(1, 2));   // вызом метода с перегрузкой
                Console.WriteLine(person1.Run(person2));   // вызом метода с перегрузкой
            }

            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||");


            // рекурсия
            int a= Factorial(5);
            Console.WriteLine(a);

        }


        public static int PrintHello(string name, int age)
        {
            Console.WriteLine($"Privet, {name}. Vam {age} let.");
            return 2;
        }


        // рекурсия
        public static int Factorial(int value)  // это умножение чисел до целевой цифры. НП: факториал 5=120, это 1*2*3*4*5=120
        {
            if (value <=1)
            {
                return 1;
            } 
            else
            {
                return value * Factorial(value - 1);
            }
        }


    }
}
