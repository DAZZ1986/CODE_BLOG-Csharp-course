using System;

namespace CODE_BLOG__8._2__OOP_
{
    public class Doctor : Person
    {
        // Наследование
        void m()
        {
            var d = new Doctor();
            d.money = 12M;         // доступ к money есть тк это класс насоледник и у переменной модиф. доступа protected.
        }




        // Полиморфизм
        public string Specialization;



    }
}
