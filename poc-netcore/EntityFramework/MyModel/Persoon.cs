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
    }
}