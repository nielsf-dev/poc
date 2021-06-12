﻿using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace EntityFramework.MyModel
{
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int PersoonId { get; set; }

        public virtual Persoon Persoon { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}