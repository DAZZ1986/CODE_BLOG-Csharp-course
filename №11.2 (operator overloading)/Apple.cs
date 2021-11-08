using System;

namespace CODE_BLOG__11._2__operator_overloading_
{
    public class Apple : Product
    {   // Если мы наследуемся от класса с пользовательским конструктором, но в наследнике должен быть конструктор с таким же 
        // набором параметров.
        // тут ситуация следующая - мы при создании экземпляра Apple этой строкой " : base(name, calorie, volume)" передали 
        // параметры в конструктор базового класса, и в базовом конструкторе делаем проверку данных от пользователя эксепшонами.
        public Apple(string name, int calorie, int volume) : base(name, calorie, volume)  //через ключевоке слово base мы
             //вызываемконструктор базового класса. Тоесть сначала данные попали в аргументы конструктора наследника, далее из
             //конструктора наследника данные попали в аргументы вызова конструктора базового класса : base(name, calorie, volume).
        {

        }


        // Это статический метод - он не относится к конкретному экземпляру класса, а является общим для всех экземпляров класса.
        // Как следствие в методе Main этот метод вызывается не через экземпляр класса, а через имя самого класса!
        public static Apple Add(Apple apple1, Apple apple2)  // метод складывает показатели двух яблок и возвращает 3 экземпляр
        {
            int calories = (int)Math.Round(((apple1.Calorie + apple2.Calorie) / 2.0));
            var volume = apple1.Volume + apple2.Volume;
            Apple apple = new Apple("Яблоко", calories, volume);
            return apple;
        }

        // тут переопределяем знак сложения и теперь сможем складывать 2 яблока просто через знак "+".
        // operator+ всегда должен быть public и static.
        // Мы можем перегружать арифметич. операторы: +, -, *, /, %.  Логические опрераторы: ==, !=, >, <, <=, >=.  Унарные ++, --.
        // Определять нужно парами, если определяешь сравнение ==, то ты должен определить и не равенство !=  итд.
        // Мы не можем определять оператор присвоения "=", и знак проверки на null "?".
        public static Apple operator+ (Apple apple1, Apple apple2)  // метод складывает показатели двух яблок и возвращает 3 экземпляр
        {
            int calories = (int)Math.Round(((apple1.Calorie + apple2.Calorie) / 2.0));
            var volume = apple1.Volume + apple2.Volume;
            Apple apple = new Apple("Яблоко", calories, volume);  // тут мы создаем новый экземпляр класса, и его возвращаем
            return apple;
        }
        // немного перегрузим этот метод "operator+ " - не обязательно в методе складывать два одинаковых объекта
        public static Apple operator +(Apple apple1, int volume)
        {
            var apple = new Apple(apple1.Name, apple1.Calorie, apple1.Volume + volume);  // тут мы создаем новый экземпляр класса,
            return apple;                                                                // и его возвращаем
        }


        // переопределим операторы сравнения, они возвращают bool значение. 
        // если методы переопределения закомментировать, то будет сравнивать объекты по адресам в памяти и будет false, false.
        public static bool operator ==(Apple apple1, Apple apple2)
        {   
            return apple1.Name == apple2.Name;   // сравниваем Имена 
        }
        public static bool operator !=(Apple apple1, Apple apple2)
        {
            return apple1.Name == apple2.Name;   // сравниваем Имена
        }
        // для того чтобы правиольно переопределить сравнение, то нужно еще переопределить Equals и GetHashCode
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
