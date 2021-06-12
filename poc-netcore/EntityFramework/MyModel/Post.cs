﻿namespace EntityFramework.MyModel
{
    public class Post
    {
        public int Id { get; set; }

        public string Contents { get; set; }

        public virtual Blog Blog { get; set; }

        public int BlogId { get; set; }
    }
}