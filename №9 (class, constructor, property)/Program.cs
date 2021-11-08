using System;

namespace CODE_BLOG__9
{
    class Program
    {
        static void Main(string[] args)
        {
            // Классы (class), конструкторы (constructor) и свойства (property) в C# - Учим Шарп #9
            int age = Convert.ToInt32(Console.ReadLine());
            Person p = new Person("Igor", "Kozlovich", age);
            p.Name = "Vasy";
            p.Surname = "Kozlov";

            Console.WriteLine(p.Name + " " + p.Surname);
            Console.WriteLine(p.FullName);
            Console.WriteLine(p.ShortName);


        }
    }
}
