using System;
using System.Data.Entity;

namespace CODE_BLOG__19._2__SQL__Entity_Framework_
{
    public class MyDbContext : DbContext   //лучше DbContext не делать публичным
    {

        public MyDbContext() : base("DbConnectionString3Entity") // нам нужно указать строку подключения, тк нам нужно создать связь
                                                                 // между настоящей БД и приложением, тк они находятся в разных местах.
        {

        }

        // Таким образом мы сможем получить сразу всю таблицу.
        public DbSet<Group> Groupss { get; set; }
        public DbSet<Song> Songss { get; set; }
    }
}
