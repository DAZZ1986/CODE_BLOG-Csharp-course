using System;

namespace CODE_BLOG__9._2__class__constructor__property_
{
    public class Person
    {

        public Person(string firstName, string surname, int age)
        {
            if (age < 0 || age > 150)
            {
                throw new ArgumentException();
            }
            Name = firstName;
            SurName = surname;
        }

        // Свойство -  по своей сути - это параметры, значения для экземпляра класса.
        private string _name;    // поля без модификатора доступа по умолчанию выставляются как private. Тут написали явно privat для читабельности кода.
        public string Name {
            get { return _name; }    // получение переменной
            protected set { _name = value; }   // запись переменной возможна только из этого класса и классов наследников из-за
                                               // модификатора доступа protected
        }


        private string _surname;
        public string SurName   // свойства нужны, чтобы не делать запись напрямую, а делать доп. проверки от дурака перед записью.
        {
            get     // получение переменной
            {
                return _surname; 
            }
            set     // запись переменной
            {
                if (string.IsNullOrWhiteSpace(value))   // IsNullOrWhiteSpace это специальный метод который проверяет переменную ну пустоту или null
                {
                    throw new ArgumentNullException("Name can't be empty OR null");
                }
                _surname = value;
            }
        }


        public string FullName
        {
            get   // вычисляемые свойства
            {
                return Name + " " + SurName;
            }
        }


        public string ShortName
        {
            get 
            {
                return $"{SurName} {Name.Substring(0, 1)}.";    // это интерполяцию строк за чет знака $ перед ковычками
                // return "Короткое имя: " + SurName + Name.Substring(0, 1) + " !";  // это конкатинация строк
                // интерполяция на много удобнее нежели чем конкатинация! Если будет 2 return то отработает только первый.
            }
        }



    }
}
