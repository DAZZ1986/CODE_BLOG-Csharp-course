using System;

namespace CODE_BLOG__12._2_Generic_Шаблон__база_
{
    // Мы можем передавать не один анонимный тип, а сколько нам потребуется.
    public class Product<T, TT>
    {
        public string Name { get; set; }
        public T Type { get; set; }
        public TT Energy { get; set; }

        public Product(string name, T type, TT energy)
        {
            Name = name;
            Type = type;
            Energy = energy;
        }





    }
}
