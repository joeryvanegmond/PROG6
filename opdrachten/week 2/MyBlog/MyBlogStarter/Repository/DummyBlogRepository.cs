using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlogStarter.ViewModels;

namespace MyBlogStarter.Repository
{
    public class DummyBlogRepository : IBlogRepository
    {

        private List<BlogVM> Blogs;

        public DummyBlogRepository() 
        {
            Blogs = new List<BlogVM>();

            Blogs.Add(new BlogVM()
            {
                Title = "A WPF Tutorial",
                Author = "Stijn Smulders",
                TimeStamp = DateTime.Now
            });

            Blogs.Add(new BlogVM()
            {
                Title = "A DI Tutorial",
                Author = "Stijn Smulders",
                TimeStamp = DateTime.Now
            });

            Blogs.Add(new BlogVM()
            {
                Title = "How to basic",
                Author = "Wilfred",
                TimeStamp = DateTime.Now
            });
        }

        public void AddBlog(BlogVM blog)
        {
            Blogs.Add(blog);
        }

        public void DeleteBlog(BlogVM blog)
        {
            var removable = Blogs.Where(b => b.Title.Equals(blog)).First();
            Blogs.Remove(removable);
        }

        public List<BlogVM> GetBlogs()
        {
            return Blogs;
        }
    }
}
