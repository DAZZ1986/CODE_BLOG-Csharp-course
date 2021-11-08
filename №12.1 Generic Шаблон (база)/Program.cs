using System;
using System.Collections.Generic;

namespace CODE_BLOG__12__база_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Обобщения или шаблоны(Generic) в C# - Учим Шарп #12
            // Шаблоны (<T> template ) - это переменная для типа переменных. Говоря проще, везде пишем в типе переменной "T", тоесть
            // обобщенный тип переменной, тоесть мы пока не знаем какой тип нам нужен будет в последствии и потом указываем к
            // примеру тип "int" и везде где был тип "T" прописывается "int".
            // Обобщения используем, тогда, когда тебе понадобится тип данных не на этапе проектирования класса, а на этапе его использования.

            // В примере pp видно, что в тип продукта T Type упала цифра 10 это энерг ценность, а в энерг.
            // ценность TT Energy упал тип Фрукт, а должно быть наоборот как в первом примере - это говорит о том что, в какой
            // последовательности аргументы передашь, так они и передадутся. Тоесть нужно следить за порядком передачи.
            var p = new Product<string, decimal>("Яблоко", "Фрукт", 10.1M); // тут string "Фрукт" упал в первый аргумент T type,
                                                                            // а decimal упал во второй аргументт TT energy.
            var pp = new Product<int, string>("Банан", 10, "Фрукт"); // тут int 10 упал в первый аргумент T type, а string упал
                                                                     // во второй аргумент TT energy.

            Console.WriteLine($"Name={p.Name}, Type={p.Type}, Energy={p.Energy}");
            Console.WriteLine($"Name={pp.Name}, Type={pp.Type}, Energy={pp.Energy}");




            var list = new List<int>();
            var map = new Dictionary<int, string>();
            map.Add(5, "Five");





            }
        }
    }
