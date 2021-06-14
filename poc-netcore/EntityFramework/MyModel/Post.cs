using Microsoft.Extensions.Logging;

namespace EntityFramework.MyModel
{
    /// <summary>
    /// Een post in een blog.
    /// </summary>
    public class Post
    {
        private static readonly ILogger<Post> log = LoggerFactory.CreateLogger<Post>();

        public int Id { get; private set; }

        /// <summary>
        /// De inhoud.
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// Het blog waar de post in zit.
        /// </summary>
        public virtual Blog Blog { get; private set; }
        public int BlogId { get; private set; }

        protected Post()
        {
        }

        public Post(string contents, int blogId)
        {
            Contents = contents;
            BlogId = blogId;
        }

        public Post(string contents, Blog blog)
        {
            Contents = contents;
            Blog = blog;
            BlogId = blog.Id;
        }

        /// <summary>
        /// Of het een cool blog betreft
        /// </summary>
        public bool IsCoolBlog()
        {
            log.LogInformation("Domain functionality");
            return Blog.Title == "Cool";
        }
    }
}