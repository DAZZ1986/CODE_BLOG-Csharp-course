using System.Data.Entity;
using System;

namespace CODE_BLOG__19__SQL__Entity_Framework_
{
    public class MyDbContext : DbContext    //лучше DbContext не делать публичным
    {
        public MyDbContext() : base("DBConnectionString") //нам нужен конструктор, мы реализуем обращение к базовуму конструктору, в которую
                                              //мы передаем будущую строку подключения. Нам нужно указать строку подключения. Тоесть наша
                                              //настоящая БД где то находится, где то хранится приложение и между ними нужно сделать связь.
                                              //Есть определенный адрес по которому мы можем найти нашу БД.
        {

        }

        // Таким образом мы сможем получить сразу всю таблицу.
        public DbSet<Group> Groups { get; set; }
        public DbSet<Song> Songs { get; set; }


    }
}
