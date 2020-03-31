using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOEF.Controllers;
using BOEF.Models;
using BOEF.Models.ViewModels;
using BOEF.Repository;
using BOEF.Repository.Interfaces;
using Ninject;

namespace BOEF
{
    public class RepositoryLocator
    {
        private static Lazy<RepositoryLocator> _repositories = new Lazy<RepositoryLocator>(() => new RepositoryLocator());
        private IKernel _kernel;
        private BOEFEntities _db;

        #region Properties
        public static RepositoryLocator Repositories
        {
            get
            {
                return _repositories.Value;
            }
        }
        #endregion

        #region Constructor
        public RepositoryLocator()
        {
            _kernel = new StandardKernel();
            _db = new BOEFEntities();
            _kernel.Bind<IBeestRepository>().To<BeestRepository>().InSingletonScope().WithConstructorArgument("db", _db);
            _kernel.Bind<IBeestTypeRepository>().To<BeestTypeRepository>().InSingletonScope().WithConstructorArgument("db", _db);
            _kernel.Bind<IAccessoiresRepository>().To<AccessoiresRepository>().InSingletonScope().WithConstructorArgument("db", _db);
            _kernel.Bind<IBoekingRepository>().To<BoekingRepository>().InSingletonScope().WithConstructorArgument("db", _db);
            _kernel.Bind<ICustomerRepository>().To<CustomerRepository>().InSingletonScope().WithConstructorArgument("db", _db);
        }
        #endregion

        #region Methods
        public IBeestRepository BeestRepository
        {
            get
            {
                return _kernel.Get<IBeestRepository>();
            }
        }


        public IBeestTypeRepository BeestTypeRepository
        {
            get
            {
                return _kernel.Get<IBeestTypeRepository>();
            }
        }

        public IAccessoiresRepository AccessoiresRepository
        {
            get
            {
                return _kernel.Get<IAccessoiresRepository>();
            }
        }

        public IBoekingRepository BoekingRepository
        {
            get
            {
                return _kernel.Get<IBoekingRepository>();
            }
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                return _kernel.Get<ICustomerRepository>();
            }
        }

        #endregion

    }
}