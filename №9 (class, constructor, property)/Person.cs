using System;

namespace CODE_BLOG__9
{
    public class Person
    {

        public Person(string secondName, string name, int age) 
        {
            if (age < 0 || age > 150)
            {
                throw new ArgumentException();
            }
            Name = name;
            Surname = secondName;
        }



        private string _name;
        public string Name
        {   
            get { return _name; } 
            set { _name = value; } 
        }

        private string _surName;
        public string Surname
        {
            get
            {
                return _surName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name can't be empty OR null");
                }
                _surName = value;
            }
        }


        public string FullName
        {
            get  // вычисляемые свойства
            {
                return Name + " " + Surname;
            }

        }

        public string ShortName
        {
            get 
            {
                return $"{Surname} {Name.Substring(0, 1)}.";
            }
        }






    }


}
