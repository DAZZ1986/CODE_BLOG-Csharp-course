using System;
using System.Collections;
using System.Linq;

namespace CODE_BLOG__21_Методы_расширения__Extension_Method_
{   // статический класс
    public static class Helper  // для создания методы расширения мы должны использовать статический класс и знать пространство имен
                                // namespace CODE_BLOG__21_Методы_расширения__Extension_Method_  тк методы расширения действуют только
                                // в том пространстве имен, в котором они объявлены. Если пространство имен у нас будет отличаться, то 
                                // для того чтобы метод расширения был доступен, нам нужно подключить через using то пространство имен,
                                // в котором метод расширения был объявлен.
    {
        // публичный статический метод РАСШИРЕНИЯ
        public static bool IsEvenEx(this int i)  //отличие метода расширения от обычных, то что, для первого параметра используется
                                                 //ключевое слово this. С помощью this, указываем к какому типу(int) этот метод
                                                 //расширения будет относиться. Тоесть этот метод расшир. появится для всех переменных
                                                 //типа int, у которых подключено наше пространство имен.
        {
            return i % 2 == 0;
        }

        /*
        // СИГНАТУРЫ методов РАСШИРЕНИЯ
        //   - Имя метода
        //   - Типы параметров
        //   - Кол-во параметров
        //* Если у нас будет подобное совпадение по сигнатуре, то будет вызываться НИ метод расширения, а СТАНДАРТНЫЙ метод, тоесть
        // внутренний метод класса.
        // проверка сигнатур, ниже 2 примера чсто они не пересекаются между собой
        public static bool IsEvenEx(this decimal i) // другой тип
        {
            return i % 2 == 0;
        }
        public static bool IsEvenEx(this decimal i, int j) // разное кол-во параметров
        {
            return i % 2 == 0;
        }
        */



        // |||||ДАЛЕЕ проверяем делится ли число без остатка
        public static bool IsDevidedBy(this int i, int j)
        {
            return i % j == 0;
        }


        // |||||ДАЛЕЕ в качестве аргумента мы можем использовать интерфейс
        // таким образом мы сделали возможность обращение к любому классу реализующему IEnumerable
        public static string ConvertToString(this IEnumerable collection)
        {
            string result = "";

            foreach (var item in collection)
            {
                result += item.ToString() + ",\r\n";
            }
            return result;
        }

        // |||||ДАЛЕЕ в качестве аргумента мы можем использовать объект road
        public static Road CreateRandomRoad(this Road road, int min, int max)
        {
            var rnd = new Random(Guid.NewGuid().ToByteArray().Sum(x => x));
            road.Number = "M " + rnd.Next(1, 100);
            road.Lenght = rnd.Next(min, max);
            return road;
        }



    }
}
