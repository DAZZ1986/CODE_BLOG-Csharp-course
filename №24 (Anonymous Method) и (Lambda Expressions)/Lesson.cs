using System;

namespace CODE_BLOG__24__Anonymous_Method__и__Lambda_Expressions_
{
    class Lesson
    {
        public string Name { get; }
        public DateTime Begin { get; private set; }

        public event EventHandler<DateTime> Started;



        public Lesson(string name)  // конструктор
        {
            // проверка входных аргументов
            Name = name;
        }



        public void Start() // создаем метод
        {
            Begin = DateTime.Now;
            Started?.Invoke(this, Begin);
        }

        public override string ToString()
        {
            return Name;
        }


    }
}
