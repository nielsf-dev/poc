using Microsoft.Extensions.Logging;

namespace EntityFramework.MyModel
{
    public class Post
    {
        private static readonly ILogger<Post> logger = LoggerFactory.CreateLogger<Post>();

        public int Id { get; set; }

        public string Contents { get; set; }

        public virtual Blog Blog { get; set; }

        protected Post()
        {
        }

        public Post(string contents, Blog blog)
        {
            Contents = contents;
            Blog = blog;
        }

        public bool IsCoolBlog()
        {
            logger.LogInformation("Domain functionality");
            return Blog.Title == "Cool";
        }
    }
}