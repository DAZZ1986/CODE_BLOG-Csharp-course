using System;

namespace CODE_BLOG__12
{
    // мы можем передавать не один анонимный тип, а сколько нам потребуется. Так же учитываем последовательность типов при создании
    // экземпляра класса. НП: var pp = new Product<decimal, int>("Банан", 10.1M, 1100); Тут decimal первый в очереди в типах класса
    // <decimal, int> и по сути первый в аргументах класса ("Банан", 10.1M, 1100).
    
    // мы можем задать определенные ограничения на наш шаблон.
    public class Product
    {
        public string Name { get; set; }
        public int Volume { get; set; }
        public int Energy { get; set; }


        public Product(string name, int volume, int energy)
        {
            // TODO: проверить входные параметры
            Name = name;
            Volume = volume;
            Energy = energy;
            //Energy = default(T);  // тут мы можем установить значение по умолчанию, тк этот параметр мы в конструктор не передаем.
        }


    
    }
}
