using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CODE_BLOG_Индексаторы__Indexer__и_Итераторы__yield_._Интерфейс_IEnumerable
{
    class Parking : IEnumerable
    {
        private List<Car> _cars = new List<Car>();  // создали список

        private const int MAX_CARS = 100;   // ограничим кол-во парковочных мест на парковке
        public int CountCar => _cars.Count; // это быстрое свойство, которое предоставляет доступ к какому то закрытому полю класса, при
                                            // этом доступ только на чтение. Не нужно писать геттер и сеттер, а так будет достаточно.
        public string Name { get; set; }    // это 



        // Объявляем индексатор
        // Можно делать индексатор только для чтения, только get, можем задавать модиф. доступа для get и set, вообщем все как с обычными свойствами.
        // СИГНАТУРА  -  модификатор_доступа тип this[тип_аргумента индекс]
        public Car this[string number]
        {
            get // нужно получить авто по его номеру, как в методе GoOut()
            {
                Car car = _cars.FirstOrDefault(c => c.Number == number);   // тут берем первый авто у которого совпал рег. номер
                return car;
            }
        }

        // ДАЛЕЕ Перегрузка индексаторов - они должны отличаться принимаемыми аргументами, либо их кол-вом, либо их типами.
        // в данном случае мы с парковки из конкретной позиции можем авто выдернуть и в это место поставить другую
        public Car this[int position]
        {
            get
            {
                if (position < _cars.Count)
                {
                    return _cars[position];
                }

                return null;
            }
            set
            {
                if (position < _cars.Count)
                {
                    _cars[position] = value;    // тут происходит замена автомобиля из конкретной позиции
                }
            }
        }




        // метод добавления авто на парковку
        public int Add(Car car)
        {
            // проверяем входные параметры
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car is null");
            }
            if (_cars.Count < MAX_CARS) // тут добавляем авто на парковку если кол-во авто на парковке менее 100
            {
                _cars.Add(car);
                return _cars.Count - 1;    // теперь будем возвращать индекс добавленного авто
            }

            return -1;
        }


        // метод выпуска авто с парковки, выпускать будем по их номеру
        public void GoOut(string number)
        {
            if (string.IsNullOrWhiteSpace(number))  // тут проверяем чтобы номер авто существовал, а не был передан null или пустота
            {
                throw new ArgumentNullException(nameof(number), "Number is null or empty.");
            }

            // теперь нам нужно из коллекции получить авто по его номеру
            Car car = _cars.FirstOrDefault(c => c.Number == number);   // тут берем первый авто у которого совпал рег. номер,
                                                                       // предпологается, что парковочные номера будут уникальны.
            if (car != null)    // проверяем на null
            {
                _cars.Remove(car);  // удаляем авто с парковки/с листа List<Car> _cars.
            }
        }




        // ДАЛЕЕ как получить машины обращаясь к парковке не через индексатор, а с помощью foreach
        // Этот интерфейс имеет всего один метод GetEnumerator() - специальный объект который позволяет переберать эл.коллекций.
        // Как его реализовывать, для этого нужно создать свой собственный класс ParkingEnumerator
        /*
        public IEnumerator<Car> GetEnumerator()
        {
            return _cars.GetEnumerator();
        }
        */
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cars.GetEnumerator();
        }
        






        // |||||ДАЛЕЕ Итераторы (yield) - мы можем самостоятельно быстро реализовывать наши коллекции
        // тут мы реализовали перечисление вместо всей реализации класса ParkingEnumerator со всеми его методами. Как происходит генерация
        // при первом обращении мы получим первый элемент, это будет 0 (0+0), потом 1 (0+1) итд, по сути фибоначи(сложение с предыдущим),
        // и при этом мы будем получать не по одному элементу, а сразу коллекцию, на выходе будет набор всех этих чисел фибонначи, которые
        // мы здесь объявили.
        public IEnumerator GetEnumerator()
        {
            // возвращаемся к нашим автомобилям, мы можем возвращать авто, Н/П: опред марки итд можем сами контролировать.
            foreach (var item in _cars)
            {
                yield return item; // теперь мы возвращаем авто
            }
        }

        public IEnumerable GetNames()
        {
            foreach (var item in _cars)
            {
                yield return item.Name; // теперь мы возвращаем не авто, а только имена авто
            }
        }


    }










    // IEnumerable - просто возвращает IEnumerator.
    // IEnumerator - это интерфейс который возвращает нам коллекцию.
    // IEterator - это переборщик этой коллекции.
    public class ParkingEnumerator : IEnumerator    // эти 3 методо и позволяют работать с перечислениями, это указательна текущий
                                                    // эл.коллекции.
    {
        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }






}
