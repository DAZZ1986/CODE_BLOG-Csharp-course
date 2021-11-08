using System;

namespace CODE_BLOG__14__Exception_
{
    class MyOwnExeption : Exception // наследуемся от базового класса Exception, но наследоваться можно от разных исключений, не только
                                    // от базового.
    {
        public MyOwnExeption() : base("Это мое исключение.")    // конструктор 1
        {
                               // тут нужно определить наше исключение
        }

        public MyOwnExeption(string messege) : base (messege)   // конструктор 2
        {

        }

    }
}
