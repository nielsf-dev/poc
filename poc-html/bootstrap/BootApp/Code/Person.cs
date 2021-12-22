using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BootApp.Code
{
    public class Person
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}