using System;
using System.Collections.Generic;
using System.Text;

namespace CODE_BLOG
{
    class Doctor : Person
    {
        // Наследование 
        void m() 
        {
            var d = new Doctor();
            d.money = 72431421412341;   // тут доступ есть тк protected
        }


        // Прлиморфизм
        public string Specialication;



    }
}
