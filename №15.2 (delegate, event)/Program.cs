using System;

namespace CODE_BLOG__15__delegate__event_
{
    public delegate void MyDelegate();  // создали глобальный делегат


    class Program
    {
        #region Delegate
        // Делегаты Delegate
        public delegate int MyTestDelegate(int a, string b, bool c);  // мой делегат для теста
        public delegate int ValueDelegate(int i);  // создали делегат внутри класса
        //public delegate void Action(); //шаблонный делегат, он полностью совпадает по сигнатуре с делегатом public delegate void MyDelegate();
                                         //И для того чтобы постоянно не создавать/писать public delegate void Action(), можно в коде сразу
                                         //обявлять делегат, Н/П: Action actionDelegat1 = Method1;. И тогда в верхней части класса не нужно
                                         //писать public delegate void Action(), это за нас сделает компилятор при компиляции, а по факту мы
                                         //прям сразу в коде пишем Action actionDelegat1 = Method1; и этого достаточно и метод естественно
                                         //должен быть готов. Это по сути синтаксический сахар.
        //public delegate int Action(int i, int j); //эта запись полностью соответствует Action<int> actionDelegat2 = Method2(58);, это
                                         //синтаксический сахар, поэтому в коде можно сразу писать Action<int> actionDelegat2 = Method2(58);.

        //public delegate bool Predicate<T>(T value);  // это предикат в развернутом виде
        //public delegate bool Predicate(int value);   // это копия записи - Predicate<int> predicate;
        
        public delegate int Func(string value);// это Func в развернутом виде и это копия записи - Func<string, int> func;
        #endregion


        #region Event
        public event MyDelegate Event1; // создали событие и объявили шаблон как должен выглядеть обработчик этого события. На это событие
                                        // сможет отреагировать только такой метод, который соответствует этому делегату MyDelegate.
                                        // И теперь мы можем генерировать эти события в другом месте и на них реагировать.
        public event Action EventAction; // создали второе событие для наглядности
        #endregion



        static void Main(string[] args)
        {
            // Делегаты (delegate) и события (event) в C# - Учим Шарп #15

            #region Delegate
            /*
                // Делегаты (delegate) и события (event) в C# - Учим Шарп #15
                // Делегат - это по сути переменная НЕ для какого то значения, а переменная для методов. Если точнее - это коллекция
                // методов (в ней может находиться как много так и один метод). Это по сути контейнер, куда мы можем напихать однотипных
                // и различных методов с одинаковой сигнатурой и обращаться к этой группе методов вместе. Если говорить правильно, что 
                // такое делегат то - это Указатель на метод.
                

                // Вообще сигнатура метода это его название и аргументы которые он принимает, но в данном случае мы используем слово
                // "Сигнатура", но подразумеваем тип возвращаемого значения метода и параметры(их кол-во и тип) и не обращаем внимание на
                // имя метода.
                // СИГНАТУРА ДЕЛЕГАТА - public delegate тип_возвращаемого_значения имя_делегата(тип_параметра имя_параметра)
                // ПРИМЕР сигнатуры метода "void" и "(int i)"
                    void Method(int i)
                    {
                    }
                    void Method2(int jojo)
                    {
                    }
                // Это два одинаковых по сигнатуре метода, потому что у них: 1. одинаковое возвращаемое значение void; 
                                                                             2. одинаковое кол-во параметров; 
                                                                             3. одинаковый тип параметров.
                // ВАЖНО!
                // Объявление вот такой сигнатуры и является делигатом! Тоесть когда мы объявляем делигат, мы объявляем сигнатуру метода,
                // которую может принимать этот делегат! Н/П: если объявляем делегат public delegate void Method(int i) и как следствие 
                // туда мы можем положить любой метод который соответствует данной сигнатуре public void Method1().
                
                // Нюансы:
                // -Сигнатура делегата должна быть равна сигнатуре метода.(тип возвращаемого значения метода и параметры(их кол-во и тип))
                // -Методы вызываются по очереди как были добавлены.
                // -Внутрь одного делегата может быть добавлен один и тот же метод несколько раз.
                // -Объявление делегата - мы можем объявлять в пределах класса, и можем объявлять за пределами класса глобально.
                // -Если у нас будет внутри делегата несколько методов и если каждый метод будет возвращать значение, нам будет 
                                                                               // возвращено только одно значение от последнего метода.
                // - Обязательное правило при обращении к делегату - если объявлен делегат, но метод ему не присвоен, и если я 
                // присваивал на следующей строке, то вылетала ошибка! ПРИМЕР ниже:
                // MyTestDelegate myTestDelegate;
                // myTestDelegate += MyTestMethod; - тут вылетит ошибка "Use of unassigned local variable"
                // поэтому перед вызовом делегата нужно проверить его на null, это можно сделать записью вида
                                                                                        // myTestDelegate?.Invoke(12, "DAZZ13", false);

            */



            Console.WriteLine("||||||||||мой тест на делегате");

            // мой тест на делегате - // public delegate int MyTestDelegate(int a, string b, bool c);  // мой делегат для теста
            MyTestDelegate myTestDelegate = MyTestMethod;
            myTestDelegate?.Invoke(12, "DAZZ13", false); // правильный вызов делегата с проверкой на null. (тут мы проверяем что в
                                                         // делегате есть хотябы 1 метод, если есть, то будет вызов, если нет, то будет
                                                         // проигнорированно, исключения не произойдет, программа просто пойдет дальше)
            myTestDelegate(12, "DAZZ13", false);         // НЕ правильный вызов делегата БЕЗ проверки на null



            Console.WriteLine("||||||||||Первый способ создания и вызова делегата");

            // Первый способ создания и вызова делегата (создаем делегат и добавляем метод)
            MyDelegate myDelegate = Method1;  // объявили делегат и добавили метод
            myDelegate += Method4;            // добавили ещё 1 метод в делегат
            myDelegate(); // вызвали как метод. тут мы дергаем делегат, а делегат вызывает все методы которые в себе содержит.



            Console.WriteLine("|||||||||||Второй способ создания и вызова делегата");

            // Второй способ создания и вызова делегата (создаем делегат и добавляем метод)
            MyDelegate myDelegate2 = new MyDelegate(Method4); // по сути это как вызов конструктора, но в качестве параметров, передаем методы.
            myDelegate2 += Method4;  // добавили метод
            myDelegate2 -= Method4;  // удалили метод
            myDelegate2.Invoke();    // вызвали через встроенный метод Invoke



            Console.WriteLine("|||||||||||можем складывать/объединять делегаты между собой");

            // можем складывать/объединять делегаты между собой
            MyDelegate myDelegate3 = myDelegate + myDelegate2;  // можем складывать/объединять делегаты между собой
            myDelegate3.Invoke();    // вызвали через встроенный метод Invoke



            Console.WriteLine("|||||||||ДАЛЕЕ Рассматриваем как работать с делегатами с аргументами");

            // ДАЛЕЕ Рассматриваем как работать с делегатами с аргументами
            // public delegate int ValueDelegate(int i);    // создали делегат внутри класса
            ValueDelegate valueDelegate = new ValueDelegate(MethodValue); // добавили метод
            valueDelegate += MethodValue;                    // добавили метод
            valueDelegate += MethodValue;                    // добавили метод
            valueDelegate += MethodValue;                    // добавили метод
            valueDelegate += MethodValue;                    // добавили метод
            valueDelegate((new Random()).Next(10, 50));      // случайное число полученно здесь будет передано во все эти методы.
                                                             // если у нас будет внутри делегата несколько методов (как в этом примере)
                                                             // и если каждый метод будет возвращать значение, нам будет возвращено
                                                             // только одно значение от последнего метода.
            ValueDelegate valueDelegate2 = new ValueDelegate(MethodValue);
            valueDelegate2(132);                // простой пример с возвратом int



            Console.WriteLine("|||||||||ДАЛЕЕ Шаблонные делегаты");

            // ДАЛЕЕ Шаблонные делегаты
            // 1. Action - это заготовка когда тип void и нет параметров. Action может быть перегружен, он не возвращает никакого значения,
            // но может принимать от 0 до 16 аргументов.
            Action actionDelegat1 = Method1;  // объявили шаблонный делегат
            actionDelegat1();                 
                                              
            // если создаем Action с аргументами то нужно указать его тип - <int, int>
            Action<int, int> actionDelegat2 = Method3;
            actionDelegat2(10, 12);

            // 2. Predicate - этот шаблонный делегат который возвращает bool значение и обязательно принимает только 1 аргумент.
            // ниже шаблонная запись эквивалентна не шаблонной записи - public delegate bool Predicate(int value);
            Predicate<int> predicateDelegate = PredicMethod;
            predicateDelegate(12);

            // 3. Func - это шаблонный делегат function, который ДОЛЖЕН возвращать хотя бы 1 значение и может принимать, а может и нет от 1 до 16 аргументов.
            Func<int, bool, string> func = FuncMethod;  //эта шаблонная запись эквивалентна не шаблонной записи - public delegate string Func(int i, bool s);
            // РАСШИФРОВКА СИГНАТУРЫ ШАБЛОННЫХ ДЕЛЕГАТОВ Func !!
            // "Func<int, bool," - это тип параметров делегата и метода.
            // "Func string>" - это тип возвращаемого значения делегата, тк он задается ПОСЛЕДНИМ !!!!!!!!!!!
            func(12, false);

            // ПРИМЕРЫ 
            Func func2;      //эта запись равна - public delegate void Func(); - это по сути Action тк нет аргументов.
            Func<int> func3; //эта запись равна - public delegate int Func(); - тк тип один, значит он становится возвращаемым значением.
            Func<int, bool, string> func4; //эта запись равна - public delegate string Func(int i, bool s); - тут последний тип string
                                           //значит он становится возвращаемым значением делегата и метода, а int и bool это аргументы
                                           //делегата и метода.

            #endregion




            Console.WriteLine("|||||||||ДАЛЕЕ Event");
            #region Event
            /*
                Событие - это когда, что то происходит в системе, у нас идет вызов оповещения, отправка сообщения всем заинтересованным
                методам, объектам. Создать событие - можно с помощью развернутого, сокращенного или шаблонного делегата. 
                СИГНАТУРА: public event имя_делегата имя_события; Н/П: public event MyDelegate MyEvent;
                Н/П: У нас есть кнопка, когда мы на нее нажимаем у нас происходит событие, и обработчики которые подписаны на это событие
                будут об этом оповещены и могут далее как либо обработать это событие по своему.
                Н/П 2: По всей школе звенит звонок о завершении занятия, но разные учителя это событие обработают по разному, кто то сразу
                отпустит после звонка, кто то задержит. Событие происходит и каждый обработчик события волен реагировать по своему на это
                событие.
            */

            // Создали человека, создали метод, теперь нам нужно подписаться на событие.
            Person pers = new Person();
            pers.Name = "Vasy";
            pers.GoToSleep += Pers_GoToSleep; // тут подписываемся на событие, интеллисенс выводит иконку молнии у событий.
            pers.DoWork += Pers_DoWork;       // тут подписываемся на второе событие DoWork

            pers.TakeTime(DateTime.Parse("9.24.2021 21:13:01"));    // вызвали метод, а из метода вызвали событие 
            pers.TakeTime(DateTime.Parse("9.24.2021 4:13:01"));


            // пример передачи метода в качестве аргумента, 
            Console.WriteLine(Sum(5, 5, Calc1)); // тут вызов метода Sum, и внутрь метода передаем другой метод Calc1 как аргумент, а 
            Console.WriteLine(Sum(5, 5, Calc2)); // принимать этот метод будет делегат в качестве параметра.




            #endregion

        }








        #region Delegate
        // мой тест на делегате dazzDelegate - public delegate int MyTestDelegate(int a, string b, bool c);
        public static int MyTestMethod(int a, string b, bool c)
        {
            Console.WriteLine("MyTestDelegate");
            return 0;
        }



        // тут совпадают по сигнатуре 1 и 4 методы
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




        // метод для делегата с параметрами
        public static int MethodValue(int i)
        {
            Console.WriteLine(i);
            return i;
        }


        // 2. метод для Predicate 
        public static bool PredicMethod(int i)
        {
            Console.WriteLine("Predicate");
            return false;
        }

        // 3. метод для Func - топовый пример, тк тип возвращаемого значения шаблонного делегата указывается в конце
                                            // Func<int, string> func;, а все что в начале это аргументы/параметры, делегата и метода.
        public static string FuncMethod(int a, bool s)
        {
            Console.WriteLine("FuncMethod");
            return "0";
        }
        #endregion




        #region Event
        private static void Pers_GoToSleep()  // тут vs2019 создала обработчик события соответствующий тому делегату, который
                                              // есть у этого события.
        {
            Console.WriteLine("Person go to sleep!");
        }

        private static void Pers_DoWork(object sender, EventArgs e)  // создали обработчик события 
        {
            if (sender is Person)
            {
                Console.WriteLine($"{((Person)sender).Name} working work!");
            }
        }


        // пример использования делегата в качестве параметра
        public static int Sum(int a, int b, Func<int, int, int> calc)
        {
            return calc (a, b);
        }
        // теперь создаем метод который будет соответствовать этий сигнатуре Func<int, int, int> (выше в методе делегат)
        private static int Calc1(int i, int j)
        {
            return i + j;
        }
        private static int Calc2(int i, int j)
        {
            return i * j;
        }
        #endregion



    }
}
