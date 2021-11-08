using System;

namespace CODE_BLOG__28_Сборка_мусора__Garbage_Collection__GC_
{
    class MyClass: IDisposable  //для ручного уничтожения класса
    {


        public MyClass()    //это конструтор
        {

        }
        ~MyClass()   //это деструтор - метод который вызываться в тот момент, когда экземпляр класса будет уничтожаться
        {

        }



        public void Dispose()  //для ручного уничтожения класса
        {
            GC.Collect();
        }


    }
}
