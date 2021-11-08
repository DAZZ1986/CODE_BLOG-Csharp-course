using System;

namespace CODE_BLOG__9._2__class__constructor__property_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Классы (class), конструкторы (constructor) и свойства (property) в C# - Учим Шарп #9

            int age = Convert.ToInt32(Console.ReadLine());
            Person p1 = new Person("Ivan", "Smolov", age); 

            Console.WriteLine(p1.Name);
            Console.WriteLine(p1.SurName);
            Console.WriteLine(p1.FullName);
            Console.WriteLine(p1.ShortName);


            // Свойство - по своей сути - это параметры, значения для экземпляра класса.

            // Конструктор - это специальный метод, который инициализирует экземпляр класса при его создании.
            // Важно всегда в конструкторе проверять входящие аргументы, как у нас в классе Person - if (age < 0 || age > 150).



        }
    }
}
