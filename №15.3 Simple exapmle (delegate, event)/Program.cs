using System;

namespace Test
{
    class Program
    {
        // пример с делегатом
        public delegate void MyDelegate();  // создали простой делегат как пример



        static void Main(string[] args)
        {
            // пример с делегатом
            MyDelegate myDelegate = Method1;  // объявили делегат и добавили в него метод
            myDelegate += Method4;            // добавили ещё 1 метод в делегат
            myDelegate();




            // пример с событием
            // создаем человека
            Person person = new Person {
                Name = "Vasy"
            };

            // подписываемся на событие
            person.GoToSleep += Person_GoToSleep; //одно событие может содержать в себе несколько обработчиков.
            person.GoToSleep += Person_GoToSleep2;//тут мы подписали метод обработчик на событие. Тут после написания равно, нам
                                                 //интеллисенс предложит нам создать обработчик события автоматом, жмем
                                                 //Tab и внизу видим обработчик события private static void Person_GoToSleep()
                                                 //Этот обработчик события создан по сигнатуре того делегата в котором мы его
                                                 //объявили public event Action GoToSleep;. Тоесть созданный метод/обработчик
                                                 //события Person_GoToSleep() соответствует сигнатуре делегата Action(он void  
                                                 //и у него нет параметров).
            person.DoWork += Pers_DoWork;       // тут подписываемся на второе событие DoWork. значек в виде молнии, это событие.

            person.TakeTime(DateTime.Parse("9.24.2021 21:13:01")); // вызвали метод, а из метода вызвали событие, а событие ушло в метод 
            person.TakeTime(DateTime.Parse("9.24.2021 4:13:01"));  // обработчик события.





            /* Содердание:
                ДЕЛЕГАТЫ (это переменная для методов)
                Создали делегат public delegate void MyDelegate(); и доб. в него методы.
                    MyDelegate myDelegate = Method1;  // объявили делегат и добавили в него метод
                    myDelegate += Method4;            // добавили ещё 1 метод в делегат
                    myDelegate();
            
                СОБЫТИЯ (это оповещение, генерируем события и в другом месте на них можем реагировать)
                Пошаговая цепь:
                1. Создаем класс Person и в нем создаем событие, public event Action GoToSleep;, и создаем метод TakeTime() и
                в методе вызываем событие GoToSleep?.Invoke();, на данное событие у нас подписано 2 метода обработчика.
                2. Теперь подписываемся на событие person.GoToSleep += Person_GoToSleep; person.GoToSleep += Person_GoToSleep2;
                теперь у события GoToSleep 2 метода обработчика Person_GoToSleep и Person_GoToSleep2.
                3. Теперь если код дойдет до вызова события GoToSleep?.Invoke(); мы попадем во все методы обработчики данного события
                и каждый метод обработает событие по своему.

            */
        }


        // метод обработчик события 1
        private static void Person_GoToSleep()
        {
            Console.WriteLine("Person go to sleep!");
        }
        // метод обработчик события 2
        private static void Person_GoToSleep2()
        {
            Console.WriteLine("Person go to sleep2!");
        }

        // метод обработчик события 3
        private static void Pers_DoWork(object sender, EventArgs e)
        {
            if (sender is Person)
            {
                Console.WriteLine($"{((Person)sender).Name} working work!");
            }
        }




        // пример с делегатом - для нашего делегата примера MyDelegate() -тут совпадают по сигнатуре 1 и 4 методы
        public static void Method1()
        {
            Console.WriteLine("Method1");
        }
        public static int Method2(int a)
        {
            Console.WriteLine("Method2");
            return a;
        }
        public static void Method3(int i, int j)
        {
            Console.WriteLine($"Method3 {i}, {j}");
        }
        public static void Method4()
        {
            Console.WriteLine("Method4");
        }

    }
}
