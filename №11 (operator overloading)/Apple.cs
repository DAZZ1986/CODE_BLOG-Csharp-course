using System;

namespace CODE_BLOG__11
{
    public class Apple : Product
    {
        // тут ситуация следующая - мы при создании экземпляра Apple этой строкой " : base(name, calorie, volume)" передали 
        // параметры в конструктор базового класса, и в базовом конструкторе делаем проверку данных от пользователя эксепшонами.
        public Apple(string name, int calorie, int volume) : base(name, calorie, volume)  // конструктор
        {

        }


        // Это статический метод - он не относится к конкретному экземпляру класса, а является общим для всех экземпляров класса.
        // Как следствие в методе Main этот метод вызывается не через экземпляр класса, а через имя самого класса!
        public static Apple Add(Apple ap1, Apple ap2)  // сам по себе метод складывает показатели двух яблок и возвращает 3 экземпляр
        { 
            var calories = (int)Math.Round(((ap1.Calorie + ap2.Calorie) / 2.0));
            var volume = ap1.Volume + ap2.Volume;
            var apple = new Apple("Яблоко", calories, volume);
            return apple;
        }

        // тут переопределяем знак сложения и теперь сможем складывать 2 яблока просто через знак "+".
        // мы можем перегружать арифметич. операторы: +, -, *, /, %.  Логические опрераторы: ==, !=, >, <, <=, >=.  Унарные ++, --.
        // определять нужно парами, если определяешь сравнение ==, то ты должен определить и не равенство !=  итд.
        // Мы не можем определять опратор присвоения "=", и знак проверки на null "?".
        public static Apple operator+ (Apple ap1, Apple ap2)   // сам по себе метод складывает показатели двух яблок и возвращает 3 экземпляр
        {
            var calories = (int)Math.Round(((ap1.Calorie + ap2.Calorie) / 2.0));
            var volume = ap1.Volume + ap2.Volume;
            var apple = new Apple("Яблоко", calories, volume);  // тут мы создаем новый экземпляр класса, и его возвращаем
            return apple;
        }
        // немного перегрузим этот метод "operator+ " - не обязательно в методе складывать два одинаковых объекта
        public static Apple operator+ (Apple ap1, int volume)
        {
            var apple = new Apple(ap1.Name, ap1.Calorie, ap1.Volume + volume);  // тут мы создаем новый экземпляр класса, и его возвращаем
            return apple;
        }


        // переопределим операторы сравнения, они возвращают bool значение.
        public static bool operator== (Apple ap1, Apple ap2)
        {
            return ap1.Name == ap2.Name;
        }
        public static bool operator!= (Apple ap1, Apple ap2)
        {
            return ap1.Name == ap2.Name;
        }



    }
}
