using System;

namespace CODE_BLOG__26_Сериализация__serialization__объектов_и_работа_с_XML_и_JSON
{
    [Serializable] //тут мы добавили атрибут, они нужны как доп. защита, чтобы мы сериализовали только те классы которые отмечены
                   //атрибутом, теперь класс Group можно Сериализовать .Если мы попытаемся сериализовать, класс который не отмечен
                   //атрибутом, то мы получим исключение.
    public class Group
    {
        [NonSerialized]
        private readonly Random rnd = new Random(DateTime.Now.Millisecond);

        private int privateint;

        public int Number { get; set; }

        public string Name { get; set; }


        public Group()
        {
            Number = rnd.Next(1, 10);
            Name = "Группа " + rnd;
        }

        public Group(int number, string name)
        {
            // Проверка входных данных
            Number = number;
            Name = name;
        }

        public void SetPrivate(int i)
        {
            privateint = i;
        }

        public int GetPrivate()
        {
            return privateint;
        }


        public override string ToString()
        {
            return Name;
        }

    }
}
