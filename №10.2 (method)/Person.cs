using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_BLOG__10._2__method_
{
    class Person
    {
        public string SecondName { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Person(string secondname, string name)   // конструктор - это единственный метод который ничего не возвращает и имеет имя класса.
        { 
            SecondName = secondname;
            Name = name;

            X = 0;
            Y = 0;
        }


        // пример метода 2 (с конструктором и классом Person)
        public string Run() 
        {
            var rnd = new Random();
            X += rnd.Next(-2, 2);
            Y += rnd.Next(-2, 2);
            
            return $"{Name} ({X}), ({Y})";
        }

        // перегрузка
        public string Run(int x, int y)
        {
            X += x;
            Y += y;
            return $"{Name} ({X}), ({Y})";
        }
        public string Run(int x)
        {
            X += x;
            return $"{Name} ({X}), ({Y})";
        }
        public string Run(double y)  
        {   
            Y += (int)y;
            return $"{Name} ({X}), ({Y})";
        }

        // перемищение на ту позицию куда нам нужно
        public string RunToPosition(int x, int y)
        {
            X += x;
            Y += y;

            return $"{Name} ({X}), ({Y})";
        }








    }
}
