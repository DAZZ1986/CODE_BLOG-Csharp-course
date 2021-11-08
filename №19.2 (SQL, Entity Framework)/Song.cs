using System;

namespace CODE_BLOG__19._2__SQL__Entity_Framework_
{
    public class Song
    {
        // Создали модель для данного класса.
        public int Id { get; set; }
        public string Name { get; set; }   // в БД Name может быть nullable
        public int GroupId { get; set; }   // в БД GroupId может быть nullable

        // сейчас у нас нет связи между таблицами, тоесть нет целостности данных, теперь нам нужно дописать код так, чтобы entityframework
        // понял, что эти 2 таблицы/класса между собой связаны.


        // Делаем по сути связи 2 таблиц Group-Id, Song-GroupId (связь между колонками Id и GroupId)
        // ключевое слово virtual означает что метод может быть переопределен.
        public virtual Group Group { get; set; }    // делаем так же как в классе Group - это особенность работы Entity, он будет автоматом
                                                    // подставлять свойства. 

    }
}
