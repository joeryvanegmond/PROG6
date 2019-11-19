using MyBlogStarter.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogStarter.ViewModels
{
    public class NinjectServiceLocator
    {
         private Ninject.StandardKernel _Kernel;

        public NinjectServiceLocator()
        {
            ///Iets met een kernel?
            _Kernel = new Ninject.StandardKernel();
            _Kernel.Bind<IBlogRepository>().To<DummyBlogRepository>().InSingletonScope();
            _Kernel.Bind<MainViewModel>().ToSelf().InSingletonScope();

        }

        public MainViewModel Main
        {
            get
            {
                //Dit kan natuurlijk een stuk beter
                return _Kernel.Get<MainViewModel>();
            }
        }
    }
}
