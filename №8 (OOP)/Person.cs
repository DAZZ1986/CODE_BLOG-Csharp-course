using System;
using System.Collections.Generic;
using System.Text;

namespace CODE_BLOG
{
    public class Person
    {
        // Инкапсуляция
        /*
        public - доступно всем и везде для любого класса.
        internal - открытый в пределах данного проекта.
        protected - доступ только внутри данного класса и его наследников. (по родственным связям)
        private - доступ только конкретно этому классу, не наследникам и никому другому.
        */

        public string firtsName;
        public string lastName;

        // Наследование 
        protected decimal money;   // только внутри данного класса и его наследников.

    }



}
