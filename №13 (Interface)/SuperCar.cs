using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CODE_BLOG__13
{
    class SuperCar : BMWSeven//, LadaSeven, ICar, IEnumerable<int>, IEnumerable
    {   // тут мы можем унаследоваться от 1 класса и нескольких интерфейсов, но мы не можем унаследоваться от нескольких классов.
        // поэтому класс LadaSeven подсвечен ошибкой. Почему так сделано, если мы наследуем класс, то мы берем реализацию этого класса.
        // Н/П: Если мы наследуемся от класса BMWSeven, с уже реализованными методами, то мы получаем реализованные методы с определенным
        // поведением внутри нашего класса наследника SuperCar, так вот это поведение не всегда может подходить, поэтому нельзя
        // наследоваться от нескольких классов. Так как может придти два совершенно различных поведения, которые не будут корректно
        // между собой работать. А если мы реализуем интерфейс, то вся реализация будет только внутри этого класса.

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        /*
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        */






    }
}
