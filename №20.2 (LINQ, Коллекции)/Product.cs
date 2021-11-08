

using System;

namespace CODE_BLOG__20._2__LINQ__Коллекции_
{
    class Product
    {
        public string Name { get; set; }
        public int Energy { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Energy}";
        }


    }
}
