using MyBlogStarter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogStarter
{
    public interface IBlogRepository
    {
        List<BlogVM> GetBlogs();

        void AddBlog(BlogVM blog);

        void DeleteBlog(BlogVM blog);

    }
}
