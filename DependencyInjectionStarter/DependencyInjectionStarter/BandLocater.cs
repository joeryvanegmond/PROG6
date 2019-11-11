using DependencyInjectionStarter.Library;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionStarter
{
    public class BandLocater
    {
        private StandardKernel _kernel;

        public BandLocater() 
        {
            _kernel = new StandardKernel();
            _kernel.Bind<RockBand>().ToSelf().InSingletonScope();
            _kernel.Bind<IIinstrument>().To<Guitar>();
            _kernel.Bind<IIinstrument>().To<Vocal>();
            _kernel.Bind<IIinstrument>().To<BassGuitar>();
            _kernel.Bind<IIinstrument>().To<Drums>();
        }

        public RockBand DefaultRockband
        {
            get 
            {
                return _kernel.Get<RockBand>(); 
            } 
        }

    }
}
