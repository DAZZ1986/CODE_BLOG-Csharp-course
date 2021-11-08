using System;
using System.Runtime.Serialization;

namespace CODE_BLOG__26_Сериализация__serialization__объектов_и_работа_с_XML_и_JSON
{
    [DataContract]  //при работе с json тут нужно подключить атрибут [DataContract] и ниже над каждым полем [DataMember].
    public class Student
    {
        [DataMember]    //при работе с json тут нужно каждое поле отмечать атрибутом [DataMember] чтобы его сериализовать.
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        public Group Group { get; set; }    // тут сделали связь между классами


        public Student(string name, int age)
        {
            // проверка входных параметров
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return Name;
        }





    }
}
