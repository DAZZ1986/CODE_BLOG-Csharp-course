using System;


namespace CODE_BLOG__13
{
    class LadaSeven : ICar, IDisposable // если мы указали что класс LadaSeven реализует интерфейс ICar, то внутри класса
                                        // обязательно должна быть реализация этого метода!!!
    {
        public void Dispose()   // это реализация заглушка от интерфейса IDisposable
        {
            throw new NotImplementedException();
        }

        public int Move(int distance)      // тут делаем реализацию метода с интерфейса ICar
        {
            return distance / 40;
        }



        public void Create()  // это последовательное наследование интерфейса от интерфейса, тоесть это реализация метода интерфейса 
        {                     // IObject так как интерфейс ICar наследник интерфейса IObject.
            throw new NotImplementedException();
        }




    }
}
