using System;
using System.Collections.Generic;

namespace CODE_BLOG__19._2__SQL__Entity_Framework_
{
    class Program
    {
        static void Main(string[] args)
        {
            // SQL базы данных и Entity Framework в C# - Учим Шарп #19


            // Далее начинаем работать уже с БД. Первое что нужно сделать, это создать context, грубо говоря подключение.
            using (var context = new MyDbContext())         // подключение к БД автоматически закрывается за счет using блока.
            {
                var group = new Group()
                {
                    Name = "Rammstein",
                    Year = 1994
                };
                Group group2 = new Group()
                {
                    Name = "Linkin park",
                };

                context.Groupss.Add(group);
                context.Groupss.Add(group2);

                context.SaveChanges(); // теперь все изменения из локального хранилища утекут в настоящую БД.


                //Console.WriteLine($"id: {group3.Id}, name: {group3.Name}, year: {group3.Year}");


                // теперь добавляем песни, делаем коллекциями, так правильно.
                List<Song> songs = new List<Song>()
                {
                    new Song() { Name = "In the end", GroupId = group2.Id},
                    new Song() { Name = "Numb", GroupId = group2.Id},
                    new Song() { Name = "Mutter", GroupId = group.Id},
                };

                // теперь нужно сохранить наши песни в БД
                context.Songss.AddRange(songs);
                context.SaveChanges();


                // выведем коллекцию песен
                foreach (var item in songs)
                {
                    Console.WriteLine($"Song name: {item.Name}, Group mame: {item.Group.Name}");
                }

                // делаем запрос, выведим группы
                Console.WriteLine($"id: {group.Id}, name: {group.Name}, year: {group.Year}");

                Console.ReadLine();
            }





            // последнее на сегодня - МИГРАЦИИ - когда мы хотим изменить структуру БД, Н/П: для класса Group добавить поле Type.
            // public string Type { get; set; }    // тут мы добавили в нашем коде НОВОЕ поле в таблицу в БД, тоесть теперь нужно
            // обновить структуру БД. И если мы сейчас запустим приложение мы получим исключение, тк поля в коде и колонки в БД 
            // не синхронизированны.
            // НУЖНО СДЕЛАТЬ СИНХРОНИЗАЦИЮ - при помощи МИГРАЦИЙ, для этого нужно зайти во View - Other windows - Packedge Manager
            // Console - вообще это диспетчер для работы с пакетами NuGet, но тут можно выполнять миграции при помощи Entity Framework.
            // Эта комнда делается один раз для проекта и потом ее повторять не нужно - это разрешение миграции enable-migrations, 
            // данная команда делала не корректную миграцию, тк по идее мы должны вызывать данную команду при создании проекта.
            // В итоге точечно добавили новое поле в миграцию командой add-migration AddGroupType и файл с описанием БД был создан
            // с именем 202109291318056_AddGroupType.Designer. По сути это как коммит в системе миграций, и далее нам нужно ввести
            // команду update-database




        }
    }
}
