using System;
using System.Collections.Generic;
using System.Linq;

namespace CODE_BLOG__20._2__LINQ__Коллекции_
{
    class Program
    {
        static void Main(string[] args)
        {
            // LINQ и работа с коллекциями в C# - Учим Шарп #20

            // У LINQ есть 2 формы записи: 1) стандартная и 2) форма которая выглядит в виде методов расширений.

            // Методы расширений - это методы которые добавляются поверх класса, без создания наследника и он не содержится внутри класса.
            // Тоесть есть класс, а сверху к нему приляпали метод, и он класса расширяет функционал класса. По сути это синтаксический сахар.
            // Просто в качестве одного из аргументов, он принимает сам объект класса.


            List<int> collection = new List<int>();
            for(int i = 0; i < 10; i++)
            {
                collection.Add(i);
            }

            // 1. Стандартная форма записи, мы хотим получить из коллекции только элементы менее 5.
            var result = from item in collection
                         where item < 5 //тут добавляем условие. Eсли используем where, то оно всегда возвращает коллекцию либо null.
                         select item;   // если мы пишем select item - это значит что мы хотим вернуть тот же тип который у нас есть,
                         //select item.Energy;  //а если мы пишем select item.Energy; то мы просим вернуть коллекцию типа int, тк свойство
                                                //Energy типа int. Тоесть командой select мы задаем тот тип, который будет возвращен.

            Console.WriteLine("result");
            foreach (int item in result)
            {
                Console.WriteLine(item);
            }

            // 2. Запишем по 2 форме записи - с методами расширений (в выпадающем списке методов, будут методы со стрелочкой, это означает,
            // что это не радной метод класс, а приляпаный метод расширения.)
            var result2 = collection.Where(item => item < 5)  //расшифровка записи Where(item => item < 5) - где item такой что, item < 5 и
                                    .Where(item => item % 2 == 0)    //далее выбираем только четные(которые делятся на 2),
                                    .OrderByDescending(item => item);//далее OrderByDescending упорядочиваем в противоположном направлении.
                                                           //Плюс методов расширений в том что, они сразу же возвращают элемент и мы можем
                                                           //продолжить работу, а так же мы можем продолжить колбасу условий разделенную
                                                           //точками. На выходе мы имеем коллекцию IEnumerable.
            Console.WriteLine("result2");
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            // Как мы видим в 1 форме записи LINQ кода меньше и поэтому они более популярны в использовании, чем LINQ с помощью методов
            // расширений.








            Console.WriteLine("|||||||ДАЛЕЕ усложним работу и сделаем дополнительный класс Product");
            // ДАЛЕЕ усложним работу и сделаем дополнительный класс Product.
            // Делаем коллекцию типа Product

            List<Product> collection2 = new List<Product>();
            var rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                var product = new Product()
                {
                    Name = "Продукт №" + i,
                    Energy = rnd.Next(10, 500)
                };
                collection2.Add(product);
            }

            var result4 = from item in collection2
                          where item.Energy < 100 || item.Energy > 400   // тут добавляем условие
                          select item;  // тут говорим какой тип нам будет возвращен. Можем указать и так item.Energy и вернется int

            var result5 = collection2.Where(item => item.Energy < 2000 || item.Energy > 8000);

            // делаем вывод
            Console.WriteLine("result4");
            foreach (var item in result4)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("result5");
            foreach (var item in result5)
            {
                Console.WriteLine(item);
            }







            Console.WriteLine("||||||ДАЛЕЕ Делаем операцию SELECT - это преобразование одного типа в другой");
            // ДАЛЕЕ Делаем операцию SELECT - это преобразование одного типа в другой. (это операция из LINQ библиотеки)
            // сейчас сделаем из списка продуктов, сделаем список целых чисел оставив только Energy

            // Делаем коллекцию в виде простого списка List
            var productsCollect = new List<Product>(0);

            for (int i = 0; i < 10; i++)
            {
                var product10 = new Product()
                {
                    Name = "Продукт " + i,
                    Energy = rnd.Next(10, 12)
                };
                productsCollect.Add(product10);
            }

            var selectCollection = productsCollect.Select(product => product.Energy);//тут взяли продукты, вытащили энерг.ценность и положили
                                                                                     //в новую коллекцию и так наполнили новую коллекцию.
            Console.WriteLine("Коллекция с энергетическими ценностями продуктов:");
            foreach (var item in selectCollection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||");





            // ДАЛЕЕ мы можем упорядочить нашу коллекцию по возрастанию при помощи команды - orderby item.Energy
            Console.WriteLine("Упорядочили через orderby");
            var result6 = from item in collection2
                          where item.Energy < 2000 || item.Energy > 8000   // тут добавляем условие
                          orderby item.Energy
                          select item;

            foreach (var item in result6)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||");

            Console.WriteLine("Упорядочили через OrderBy");
            var orderbyCollection = productsCollect.OrderBy(product => product.Energy) // тут упорядочили по энерг ценности
                                                    .ThenByDescending(product => product.Name); //после ценности, тут упорядочилди по имени

            foreach (var item in orderbyCollection)
            {
                Console.WriteLine(item);
            }






            Console.WriteLine("||||||ДАЛЕЕ Группировка - разбиение нашей коллекции на группы. (это можно сделать и через SQL и через LINQ)");
            // ДАЛЕЕ Группировка - разбиение нашей коллекции на группы. (это можно сделать и через SQL и через LINQ)
            var productsCollect2 = new List<Product>(0);

            for (int i = 0; i < 10; i++)
            {
                var product10 = new Product()
                {
                    Name = "Продукт " + i,
                    Energy = rnd.Next(10, 15)
                };
                productsCollect2.Add(product10);
            }

            var groupbyCollection = productsCollect2.GroupBy(product => product.Energy);
            // И после команды GroupBy, нам возвращает не IEnumerable коллекцию, а возвращает группированый элемент. Это так называемый
            // "Список с висюльками" - это означает что у нас есть список и за каждым элементом списка закреплена коллекция. И для вывода
            // нам нужно перебирать его с помощью цикла.

            foreach (var keyitem15 in groupbyCollection) //тут элемент item это пара, в котрой первый элемент является ключем, а второй
            {                                            //является коллекцией этого ключа. Ключ типа int, а коллекция типа <Product>.
                Console.WriteLine($"Key: {keyitem15.Key}");
                foreach (var item in keyitem15)
                {
                    Console.WriteLine($" \t{item}");
                }
                Console.WriteLine();
            }
            // Тоесть тут нам на вывод сформировались группы с одинаковой энергетической ценностью, тк мы прописали команду
            // GroupBy(product => product.Energy); и ключ группы имеет тип int и равен энерг.ценности данной группы, поэтому у нас в группах
            // одинаковое кол-во эхнерг.ценности у всех продуктов. Короче сделали группы по энерг.ценности!





            Console.WriteLine("|||||ДАЛЕЕ делаем операцию Реверс - переворот в обратном порядке");
            // ДАЛЕЕ делаем операцию Реверс - переворот в обратном порядке

            Console.WriteLine("Вывод коллекции ДО реверса");
            foreach (var item in productsCollect2)
            {
                Console.WriteLine(item);
            }

            productsCollect2.Reverse();     //тут переворачиваем список и он таким останется навсегда.

            Console.WriteLine("Вывод коллекции ПОСЛЕ реверса");
            foreach (var item in productsCollect2)
            {
                Console.WriteLine(item);
            }





            Console.WriteLine("|||||||ДАЛЕЕ 2 частые операции All и Any");
            // ДАЛЕЕ 2 частые операции All и Any - они возвращают уже не элемент коллекции, а возвращают уже bool значение.
            // All - возвращает true, если соответственным условиям соответствуют все элементы коллекции. Н/П: если у всех продуктов энерг.
            // ценность будет равна 10, то вернет true.
            // Any - если хотя бы один элемент коллекции соответствует условию, то нам вернется true.
            Console.WriteLine("All и Any");

            var all = productsCollect2.All(item => item.Energy == 10);
            Console.WriteLine(all);
            var any = productsCollect2.Any(item => item.Energy == 10);
            Console.WriteLine(any);





            Console.WriteLine("|||||||ДАЛЕЕ операция Contains (содержит)");
            // ДАЛЕЕ операция Contains (содержит) - проверяет вхождение элемента в коллекцию. 
            Console.WriteLine("Contains");
            var contains = productsCollect2.Contains(productsCollect2[5]); // тут выведится true, тк этот элемент принадлежит этой коллекции.
            Console.WriteLine(contains);

            var prod = new Product(); // тут созхдали продукт не из коллекции и теперь должно быть false, тк эл. в коллекции такого нет.
            var contains2 = productsCollect2.Contains(prod);
            Console.WriteLine(contains2);







            // ДАЛЕЕ операция distinct(Union) - позволяет нам делать коллекцию из уникальных элементов удаляя все дублирующие элементы.
            // Н/П: если у нас в коллекции будут значения 1, 2, 3, 1, 2, 3 - то на выходе мы получим 1, 2, 3.

            Console.WriteLine("||||ДАЛЕЕ операции со множествами (объединение, вычитание, перисечение)");
            // ДАЛЕЕ операции со множествами (объединение, вычитание, перисечение)
            // Объединение Union
            var array = new int[] { 1, 2, 3, 4 };
            var array2 = new int[] { 3, 4, 5, 6 };

            Console.WriteLine("Вывод простого списка");
            foreach (var item in array)         // тут делаем вывод до объединения
            {
                Console.WriteLine(item);
            }

            var union = array.Union(array2);    // тут делаем объединение и сразу он делает по умолчанию distinct(удаляет дубли в коллеции)
            Console.WriteLine("Вывод объединенного списка");
            foreach (var item in union)
            {
                Console.WriteLine(item);
            }





            Console.WriteLine("||||||ДАЛЕЕ операция Intersect - выводит повторяющиеся элементы");
            // ДАЛЕЕ операция Intersect - выводит дублирующиеся/повторяющиеся элементы в двух коллекциях.
            var intersect = array.Intersect(array2);
            Console.WriteLine("Вывод Intersect");
            foreach (var item in intersect)
            {
                Console.WriteLine(item);
            }





            Console.WriteLine("||||||ДАЛЕЕ операция Except - выводит те элементы которые есть в первой коллекции");
            // ДАЛЕЕ операция Except - выводит те элементы которые есть в первой коллекции/множестве, но нет во второй. (тоесть уникальные
            // значения первого множества). Тоесть мы из первого множества, вычли второе множество. И так же можем сделать наоборот, из
            // второго множества вычесть первое, просто поменяв местами имена множеств в коде - array2.Except(array);
            var except = array.Except(array2);
            Console.WriteLine("Вывод Except");
            foreach (var item in except)
            {
                Console.WriteLine(item);
            }







            Console.WriteLine("||||||ДАЛЕЕ агрегатная операция - можем подсчитать сумму");
            // ДАЛЕЕ агрегатная операция - можем подсчитать сумму
            var sum = array.Sum();
            var min = productsCollect2.Min(p => p.Energy);  // тут мы выбрали бы минимальный продукт по энергетической ценности
            var max = productsCollect2.Max(p => p.Energy);

            // так же мы можем задавать произвольные агрегатные функции с помощью метода aggregate
            var aggregate = array.Aggregate((x, y) => x * y);   // так мы получим когда каждый элемент будет умножаться друг на друга последовательно

            Console.WriteLine(sum);
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(aggregate);







            Console.WriteLine("||||||ДАЛЕЕ если мы хотим взять сумму ни всех элементов массива");
            // ДАЛЕЕ если мы хотим взять сумму ни всех элементов массива, а мы хотим пропустить первый элемент и далее взять два следующих
            Console.WriteLine("агрегатная операция Skip");  // Skip - мы задаем сколько элементов нам нужно пропустить
            var sum2 = array.Skip(1).Sum(); //в данном случае у нас будет взят ни весь массив { 1, 2, 3, 4 }, а все элементы кроме первого. 
            var sum3 = array2.Skip(2).Sum();//в данном случае у нас будет взят ни весь массив { 3, 4, 5, 6 }, а все элементы кроме первых двух. 
            Console.WriteLine(sum2);
            Console.WriteLine(sum3);

            Console.WriteLine("агрегатная операция Take");  // Take - мы задаем сколько элементов нам нужно взять
            var sum4 = array.Skip(1).Take(2).Sum(); //массив { 1, 2, 3, 4 }, тут мы пропустили первый элемент и суммировали 2 последующих.
            Console.WriteLine(sum4);








            Console.WriteLine("||||||ДАЛЕЕ если мы хотим взять из всей коллекции 1 элемент - это мы можем сделать 4 способами");
            // ДАЛЕЕ если мы хотим взять из всей коллекции 1 элемент - это мы можем сделать 4 способами.
            foreach (int item in array2) // выведем массив для наглядности
            {
                Console.WriteLine(item);
            }

            // First() - берет из коллекции первый элемент, но если коллекция пуста, словим эксепшон, чтобы не ловить эксепшон, нужно
            // FirstOrDefault() использовать, тогда при пустой коллекции, подставит значение по умолчанию для данного типа.
            var first = array2.FirstOrDefault();    // если where нам возвращают коллекцию, пустую или с 1 элементом не важно, но коллекцию
                                                    // то вот эти операции First(), Last() нам возвращают конкретный элемент.
            var last = array2.Last(); // тоже самое и с Last.
            Console.WriteLine($"first {first}");
            Console.WriteLine($"last {last}");
            // Если в вашем приложении ожидаемо должно, что то быть то берем First, Last, а если непонятно то FirstOrDefault, LastOrDefault.

            Console.WriteLine($"productsCollect3");
            var productsCollect3 = new List<Product>(); //создали коллекцию для наглядности
            for (int i = 0; i < 10; i++)
            {
                var product1 = new Product()
                {
                    Name = "Продукт " + i,
                    Energy = rnd.Next(10, 12)
                };
                productsCollect3.Add(product1);
            }

            foreach (Product item in productsCollect3) //выведем коллекцию для наглядности
            {
                Console.WriteLine($"Name: {item.Name}, Energy: {item.Energy}");
            }

            // First - берем первый элемент у которого энергетическая ценность будет равна 10.
            Product first2 = productsCollect3.First(p => p.Energy == 10);// тут мы из всей коллекции берем первый элемент у которого
                                                                       // энергетическая ценность будет равна 10. Их может быть
                                                                       // несколько с ценностью в 10, но мы возьмем первый.
                                                                       // var single = productsCollect3.Single(p => p.Energy == 10);  
                                                                       // отличие от операции First(p => p.Energy == 10) в том, что
                                                                       // операция single требует чтобы этот эл. был единственным. И 
                                                                       // если в коллекции будет два элемента с энерг. ценностью 10, то
                                                                       // мы получим эксепшон, в то время как First() просто берет первый
                                                                       // попавшийся элемент без риска эксепшона.
            Console.WriteLine($"First эл. с энер.ц. равен 10 {first2}");

            /*
            // Single - операция single требует чтобы этот эл. был единственным, тк если их в коллекции будет 2, мы словим эксепшон.
            Product single = productsCollect3.Single(p => p.Energy == 10);
            Console.WriteLine($"Single эл. с энер.ц. равен 10 {single}");
            */






            
            Console.WriteLine("|||||||ДАЛЕЕ операция ElementAt - это получение элемента по индексу");
            // ДАЛЕЕ операция ElementAt - это получение элемента по индексу. 
            Product elementAt = productsCollect3.ElementAt(5);
            Console.WriteLine(elementAt);
            



        }
    }
}
