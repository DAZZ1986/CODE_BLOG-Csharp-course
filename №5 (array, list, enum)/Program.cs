using System;
using System.Collections.Generic;

namespace CODE_BLOG__5__array__list__enum_
{
    class Program
    {


        // создаем Enum (перечисления) - это НЕ коллекция, это просто красивые имена для переменных, объединенных в группы.
        /* Перечисления представляют набор логически связанных констант.
        Каждому элементу перечисления присваивается целочисленное значение, по умолчанию первый элемент будет иметь значение 0, 
        второй - 1 и так далее. Мы можем также явным образом указать значения элементов, либо указав значение первого элемента 10 
        и далее значение второго элемента выставится 11 и так далее.
        СИНТАКСИС:
        модификтор_доступа enum имя : тип
        {
            имя1 = значение1,
            имя2 = значение2,
        }
        */
        enum Days
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday,
            Saturday,
            Sunday
        }

        public enum Response
        {
            OK = 200,
            Forbidden = 403,
            NotFound = 404,
            InternalServerError = 500,
            BadGateway = 502
        }
        public enum Direction
        {
            North, //0
            South, //1
            East, //2
            West, //3
            None //4
        }

        static void Main(string[] args)
        {
            // Коллекции C#: массивы (array) и списки (list). Перечисления (enum) - Учим Шарп #5

            // одномерный массив
            int[] array = new int[10];  // создали пустой массив из 10 элементов
            array[0] = 10;
            array[9] = 5;
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||");

            // трехмерный массив
            int[,,] array3d = new int[10, 10, 10];
            array3d[0, 0, 0] = 21;
            array3d[9, 9, 9] = 12;
            Console.WriteLine(array3d[9,9,9]);
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||");

            // создаем Лист
            List<int> listik = new List<int>();
            listik.Add(0);
            listik.Add(1);
            listik.Add(22);
            Console.WriteLine(listik[2]);   // вывод эл. листа по индексу
            foreach (int item in listik)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||");

            // создаем Лист - второй вариант инициализации
            List<int> loost = new List<int>
            {
                1,2,3,4,5,6,7,8,9,101111
            };
            foreach (int item in loost)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||");







            // создаем Enum (перечисления) - это НЕ коллекция, это просто красивые имена для переменных, объединенных в группы.
            //Console.WriteLine(Days.Friday);
            foreach (Direction item in Enum.GetValues(typeof(Days)))
            {
                Console.WriteLine($"{(int)item} - {item}");
            }
            //Console.WriteLine(Response.Forbidden);
            foreach (Direction item in Enum.GetValues(typeof(Response)))
            {
                Console.WriteLine($"{(int)item} - {item}");
            }
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||");



            // ПРИМЕР применения Enum
            //Выводим все значения из Direction
            foreach (Direction item in Enum.GetValues(typeof(Direction)))
            {
                Console.WriteLine($"{(int)item} - {item}");
            }

            //Такая проверка намного проще читается, чем если бы использовались просто числа
            int c = Convert.ToInt32(Console.ReadLine());
            int y = 0;
            int x = 0;
            switch ((Direction)c)
            {
                case Direction.North:
                    y++;
                    break;

                case Direction.South:
                    y--;
                    break;

                case Direction.East:
                    x++;
                    break;

                case Direction.West:
                    x--;
                    break;
            }


        }
    }
}
