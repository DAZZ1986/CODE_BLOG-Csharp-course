using System;


namespace CODE_BLOG__13
{
    class BMWSeven : ICar
    {
        public int Move(int distance)
        {
            return distance / 100;
        }




        public void Create()  // это последовательное наследование интерфейса от интерфейса, тоесть это реализация метода интерфейса 
        {                     // IObject так как интерфейс ICar наследник интерфейса IObject.
            throw new NotImplementedException();
        }






    }
}
