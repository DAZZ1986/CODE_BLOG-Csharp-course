using System;


namespace CODE_BLOG__15__delegate__event_
{
    class Person
    {
        public event Action GoToSleep;  // у данного события делегат Action, и при создании обработчика Pers_GoToSleep, он создается на
                                        // основании сигнатуры делегата Action, тоесть void и без параметров. Зачастую такая сигнатура
                                        // делегата не используется, тк зачастую нужно передавать аргументы.
        public event EventHandler DoWork;  // чаще всего используется этот шаблон делегата
        public string Name { get; set; }




        public void TakeTime(DateTime now)
        {
            if (now.Hour <= 8)  // тут укладываем спать нашего человека если до 8:00 утра.
            {
                GoToSleep?.Invoke();
            }
            else
            {
                DoWork?.Invoke(this, null);  //на это событие могут подписаться несколько подписчиков/обработчиков, и все они
                                             //по своему будут обрабатывать этот событие.
            }
        }







    }
}
