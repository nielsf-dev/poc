using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EntityFramework.MyModel
{
    public class Persoon
    {
        public int Id { get; protected set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Occupation { get; set; }

        protected Persoon()
        {
        }

        public Persoon(string name, int age, string occupation)
        {
            Name = name;
            Age = age;
            Occupation = occupation;
        }

        public delegate void doLogging(string logText);

        public void FunctionCallingDelegate(doLogging logFunction)
        {
            logFunction.Invoke("my pima");
            logFunction("maPima2");
        }

        public void actionFunction(Action<string> otherFunctionAction)
        {
            otherFunctionAction("Yolooo");
        }

        public void functionFunction(Func<string,string> funky)
        {
            var resser = funky("upperme");
            Debug.WriteLine(resser);
        }

        public void add(Func<int, int, int> dikGaanFunc)
        {
            var res = dikGaanFunc(1, 2);
            Debug.WriteLine(res);
        }
    }
}