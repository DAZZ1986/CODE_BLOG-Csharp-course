

namespace CODE_BLOG__20__LINQ__Коллекции_
{
    class Product
    {
        public string Name { get; set; }
        public int Energy { get; set; }

        public override string ToString()
        {
            return $"{Name}, ({Energy})";
        }

    }
}
