using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionStarter.Library
{
    public class Keyboard : IIinstrument
    {
        public string UseInstrument()
        {
            return "ping pong pong ping";
        }
    }
}
