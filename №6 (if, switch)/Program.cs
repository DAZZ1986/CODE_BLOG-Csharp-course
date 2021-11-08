using System;

namespace CODE_BLOGE__6__if__switch_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Условный оператор (if, switch) в C# - Учим Шарп #6

            // оператор if else
            // <, <=, >, >=, ==, !=.
            // логические операторы &&, ||, !.  Так же логические операторы &&, || имеют приоритет.
            // Логическое "И"-&& это умножение, логическое "или"-|| это сложение и выполняются они как в математике, сначала умножение потом сложение.
            bool b = 3 < 5;
            if (b && b != false)
            {
                // путь 1
                Console.WriteLine(true);
            }
            else if(b == false)
            {
                // путь 2
                Console.WriteLine(false);
            } 
            else
            {
                // путь 3
                Console.WriteLine("Никогда не сбудится:)");
            }
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||");




            // оператор switch - применение когда нужно подвязать на конкретные значения
            /* СИНТАКСИС:
            switch(переменная) //тип переменной которая подается на вход, должен совпадать с типом переменных значений 1, 2 default.
            {                  // после превого оператора break мы выходим из switch'а.
                case значение1:
                    // код с действиями
                    break;
                case значение2:
                    // код с действиями
                    break;
                default:        // default не обязательный оператор
                    // код с действиями
                    break;
            }
            */

            Console.WriteLine("Нажмите Y или N:");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "y":   // тип значения case должен совпадать с типом selection.
                case "Y":
                    Console.WriteLine("Вы нажали букву Y");
                    break;
                case "n":
                case "N":
                    Console.WriteLine("Вы нажали букву N");
                    break;
                default:   // default не обязательный оператор
                    Console.WriteLine("Вы нажали неизвестную букву");
                    break;
            }
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||");


            // оператор быстрой проверки
            // ? - это по сути if и далее первое значение true, после двоеточия второе значение false.
            Console.WriteLine("Введите число от 1 до 10:");
            int input = int.Parse(Console.ReadLine());
            var s = input == 10 ? "Yes" : "No";
            Console.WriteLine(s);
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||");




            // оператор goto - это оператор безусловного перехода на метку. (не рекомендуется к использованию тк делает ПО запутанным)



            Console.WriteLine("|||||||||||||||||||||||||||||||||||||");



        }
    }
}
