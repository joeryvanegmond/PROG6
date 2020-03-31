using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlogStarter.ViewModels;

namespace MyBlogStarter.Repository
{
    class EntityBlogRepository : IBlogRepository
    {


        public EntityBlogRepository() 
        {
            
        }

        public void AddBlog(BlogVM blog)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlog(BlogVM blog)
        {
            throw new NotImplementedException();
        }

        public List<BlogVM> GetBlogs()
        {
            throw new NotImplementedException();
        }
    }
}
