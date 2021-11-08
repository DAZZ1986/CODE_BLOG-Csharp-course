using System;

namespace CODE_BLOG__10
{
    public class Person
    {

        public string SecondName { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Person(string secondName, string name) // Конструктор это по сути метод - но только без возвращаемого значения, тк он ничего никогда не возвращает.
        {
            Name = name;
            SecondName = secondName;

            X = 0;
            Y = 0;
        }

        public string Run() 
        {
            var rnd = new Random();
            X += rnd.Next(-2, 2);
            Y += rnd.Next(-2, 2);
            
            return $"{Name} ({X},{Y})";
        }


        // Перегрузка методово - отлдичаются сигнатурами.

        public string Run(int x, int y)  // тут мы олтправляем человека не на рандомные координаты, а в конкрентное место.
        {
            X += x;
            Y += y;
            return $" {Name } ({X}, {Y})";
        }
        public string Run(int x) 
        {
            X += x;
            return $" {Name } ({X}, {Y})";
        }
        public string Run(double y) 
        {
            return $" {Name } ({X}, {Y})";
        }
        public string Run(Person obj)  
        {
            return $" {Name } ({X}, {Y})";
        }

        // Рекурсия - это когда метод вызывает сам себя. Обязательное условие рекурсии - это из нее должен быть вызов её. (тоесть саму себя)




    }


}
