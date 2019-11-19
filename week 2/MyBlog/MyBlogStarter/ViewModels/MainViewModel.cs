using MyBlogStarter.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogStarter.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<BlogVM> Blogs { get; set; }

        public MainViewModel(IBlogRepository blogRepo)
        {
            this.Blogs = new ObservableCollection<BlogVM>(blogRepo.GetBlogs());
        }
    }
}
