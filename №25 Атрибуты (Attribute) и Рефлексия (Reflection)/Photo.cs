using System;

namespace CODE_BLOG__25_Атрибуты__Attribute__и_Рефлексия__Reflection_
{
    //указали наш собственный атрибут для класса Photo. Имя атрибута указали без постфикса Attribute, достаточно написать Geo и
    [Geo(1000, 2000)] //среда разработки поймет что речь об атрибуте GeoAttribute. И в скобках указываем наши доп. параметры. 
    public class Photo
    {
        [Geo(10, 20)]
        public string Name { get; set; }
        
        public string Path { get; set; }

        public Photo(string name)
        {
            //проверка входных параметров
            Name = name;
        }








    }
}
