using DependencyInjectionStarter.Library;
using System;

namespace DependencyInjectionStarter
{
    class Program
    {
        /** Testing 123 */
        static void Main()
        {
            var rockBand = new RockBand();
            rockBand.DoSoundCheck();
            Console.ReadLine();
        }
    }
}
