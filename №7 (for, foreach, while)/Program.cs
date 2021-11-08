using System;
using System.Collections.Generic;

namespace CODE_BLOG__7__for__foreach__while_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Циклы C# (for, foreach, while) - Учим Шарп #7
            // continue;   // код идущий после команды continue пропускается в текущей итерации цикла(тоесть цикл прыгает на след. итерацию)
            // break;      // как только мы попадаем на команду break у нас сразу же завершается работа во всем цикле

            // цикл for
            /* СИНТАКСИС
            for(итератор; условие; приращение)
            {
                
            }
            */
            /*
            var list = new List<int>();
            for (int i = 0; i < 10; i += 2)
            {
                list.Add(i);
            }

            for (var i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||");
            */

            // вложенные циклы for - заполнение и вывод двумерного массива
            int arrLenght = 2;
            int arrLenght2 = 3;
            int[,] arr = new int[2,3];
            Random rnd = new Random();
            for (int i = 0; i < arrLenght; i++)
            {
                for (int j = 0; j < arrLenght2; j++)
                {
                    arr[i, j] = rnd.Next(0, 100);
                }
            }

            for (int i = 0; i < arrLenght; i++)
            {
                for (int j = 0; j < arrLenght2; j++)
                {
                    Console.WriteLine(arr[i,j]);
                }
            }










            // циклы while, do while

            /* СИНТАКСИС while
            while(условие)  // до тех пор пока условие истино, оно будет выполняться
            {
                
            }
            */
            /*
            var list2 = new List<string>();
            while (list2.Count < 5)
            {
                list2.Add(Console.ReadLine());
            }

            var i2 = 0;
            while (i2 < list2.Count)
            {
                Console.WriteLine(list2[i2]);
                i2++;
            }
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||");
            */


            /* СИНТАКСИС do while
            do    // тут условие в любом случае выполнит блок кода do хотябы 1 раз и потом будет проверять условие while(условие).
            {

            } while(условие);
            */
            /*
            var i3 = 110;
            do
            {
                Console.WriteLine("i3 < 10");
                i3++;
            }
            while (i3 < 10);
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||");
            */





            // цикл foreach - удобно использовать для коллекции
            /* СИНТАКСИС
            foreach(тип_элемента item in коллекция)
            {
                Console.WriteLine($"Элемент коллекции {item}");
            }
            */
            /*
            List<int> listik = new List<int> { 1,2,3,4,5,6 };
            foreach (int item in listik)
            {
                // continue;   // код идущий после команды continue пропускается в текущей итерации цикла(тоесть цикл прыгает на след. итерацию)
                // break;      // как только мы попадаем на команду break у нас сразу же завершается работа во всем цикле
                Console.WriteLine($"Элемент коллекции: {item}");
            }
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||");
            */






        }
    }
}
