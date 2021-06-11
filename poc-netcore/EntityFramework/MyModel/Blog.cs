using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace EntityFramework.MyModel
{
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int PersoonId { get; set; }

        public Persoon Persoon { get; set; }

        public List<Post> Posts { get; set; }
    }
}