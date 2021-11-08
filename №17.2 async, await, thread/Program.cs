using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CODE_BLOG__17._2_async__await__thread
{
    class Program
    {
        static void Main(string[] args)
        {
            #region thread
            /*
            // Многопоточность - создаем потоки тред.
            // При запуске у нас работают 3 потока одноврименно, тоесть многопоточно.(не асинхронно)
            // Это доп. поток без параметров.
            Thread thread1 = new Thread(new ThreadStart(DoWork1));
            thread1.Start();

            // Это доп. поток с параметром.
            Thread thread2 = new Thread(new ParameterizedThreadStart(DoWork2)); //ParameterizedThreadStart используем когда в методе DoWork2 ЕСТЬ аргументы, и в качестве аргумента он может принимать только тип object
            thread2.Start(int.MaxValue);


            // Это основной поток в методе Main
            int j = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                j++;
                if (j % 10000 == 0)
                {
                    Console.WriteLine("Main");
                }
            }
            // И у нас в консоли одновременный вывод с 3 потоков DoWork2, DoWork, Main, кто успел перехватить вывод тот и вывел.
            */
            #endregion



            #region async/await
            /*
            // Для того чтобы метод мог использоваться как асинхронный, он должен возвращать либо тип Task либо Task<T> либо void.
            // Мы делаем асинхронный метод обертку DoWorkAsync над методом DoWork3. 

            // До вызова асинхронного метода начинаем
            Console.WriteLine("Begin main");
            // Вызываем наш асинхронный метод синхронно.
            DoWorkAsync(20); //от метода Main идет основной поток, после того как основной поток дошел до метода DoWorkAsync(), в методе
                           //вызывался доп. поток, а основной поток идет далее по методу Main(). Но если бы мы указали команду await то
                           //основной поток ждал бы завершения метода DoWorkAsync(), но есть нюанс мы можем использовать оператор await
                           //только в асинхронных методах, а метод Main() асинхронным быть не может. Тоесть мы можем делать await но не на
                           //Main методе.

            Console.WriteLine("Continue Main");

            // Это основной поток в методе Main
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main");
            }
            Console.WriteLine("End Main");

            // Цикл жизни - идет основной поток по методу Main, далее мы заходим в асинхронный метод DoWorkAsync(), там ключем await
            // создается новый поток, запускаем его методом Run() и далее доп. поток идет в метод DoWork3() и доп. поток пока не закончит
            // выполнять метод DoWork3(), он не выполнит след. строку Console.WriteLine("End async");. Тоесть наш доп. поток
            // ныряет в DoWork3() и пока его не завершит, далее по методу DoWorkAsync() не пойдет, но при этом наш основной потом метода
            // Main идет далее без остановки. Итого у нас 2 потока, главный от метода Main и доп. поток.

            // Вся фишка в том что пока не завершится метод DoWork3(), строку Console.WriteLine("End async"); мы не увидим.
            */
            #endregion



            #region Test App
            /*
            // Представим себе приложение для сохрание в файл большого набора данных и мы не хотим чтобы форма грузилась, поэтому делаем
            // асинхронно. Соответственно как мы делаем это синхронно - мы пишем метод.
            
            // ЭТО СИНХРОННОЕ ИСПОЛНЕНИЕ, когда консоль будет висеть тк основной поток будет заблокирован.
            // Представим себе приложение для сохрание в файл большого набора данных и мы не хотим чтобы форма грузилась, поэтому делаем
            // асинхронно. Соответственно как мы делаем это синхронно - мы пишем метод.
            var result = SaveFile("Text.txt"); // запуская метод, у нас блокируется главный поток, пока вычисляется строка, пока
                                               // записывается файл и после этого в конце нам выдается результат.
            var input = Console.ReadLine();    // тут мы, как открывается консоль пытаемся что то печатать, но текст не появляется, тк
                                               // управление перехвачено и консоль грузится/ждет пока запишется файл и потом весь текст вываливается.
            Console.WriteLine(result);         
            */

            
            // ЭТО АСИНХРОННОЕ ИСПОЛНЕНИЕ, когда консоль будет НЕ висеть тк основной поток НЕ будет заблокирован.
            var result2 = SaveFileAsync("Text2.txt"); // запуская метод, у нас НЕ блокируется главный поток
            var input2 = Console.ReadLine();          // и в консоли должно печататься сразу
            Console.WriteLine(result2.Result);   // тут мы получили результат результата, тк этот метод SaveFileAsync у нас возвращает
                                                 // не просто bool, а Task<bool>.
            Console.ReadLine();
            
            #endregion


        }




        #region locker
        public static object locker = new object(); //создали объект синхронизации locker и ниже просто обернули участок кода в команду lock.
        #endregion



        #region Test App и locker
        // ТЕПЕРЬ МЫ ДЕЛАЕМ АСИНХРОННО - делаем асинхронную обертку для метода SaveFile()
        static async Task<bool> SaveFileAsync(string path)
        {
            var result = await Task<bool>.Run(() => SaveFile(path));// тут мы ожидаем результат выполнения метода  SaveFile() и после
            return result;                                          // возвращаем результат в Main, но при этом основной поток в Main
                                                                    // не блокируется и консоль у нас должна работать.
        }


        // СЕЙЧАС ЭТО СДЕЛАНО СИНХРОННО
        static bool SaveFile(string path)
        {
            lock (locker)   // командой lock - заблокировали участок кода, чтобы к данному участку кода одновременно мог
                            // обратиться только 1 поток и после его завершения только потом мог обратиться следующий поток.
            {
                var rnd = new Random();
                string text = "";
                for (int i = 0; i < 40000; i++)
                {
                    text += rnd.Next();
                }
            }
            using (var sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.WriteLine();
            }

            return true;
        }
        #endregion




        #region async/await
        // Task - делаем асинхронный метод абертку DoWorkAsync над методом DoWork3. После ключа await мы делаем вызов метода Task.Run(() => DoWork3());
        static async Task DoWorkAsync(int max)
        {
            Console.WriteLine("Begin async");
            await Task.Run(() => DoWork3(max)); //команда await говорит о том что нужно ждать завершения выполнения этой задачи Task.Run(() => DoWork3());
            Console.WriteLine("End async");
        }

        static void DoWork3(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("DoWork 3");
            }
        }
        #endregion




        #region thread
        static void DoWork1()
        {
            int j = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                j++;
                if (j % 10000 == 0)
                {
                    Console.WriteLine("DoWork 0");
                }
            }
        }

        static void DoWork2(object max)
        {
            int j = 0;
            for (int i = 0; i < (int)max; i++)  // мы делаем приведение к int тк в качестве параметра тут передается тап object
            {
                j++;
                if (j % 10000 == 0)
                {
                    Console.WriteLine("DoWork 2");
                }
            }
        }
        #endregion









    }
}
