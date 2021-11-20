﻿namespace BootApp.Code
{
    public class Person
    {
        public int ID { get; protected set; }

        public string Name { get; set; }
        public int Age { get; set; }

        protected Person()
        {
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}