using DependencyInjectionStarter.Library;
using System;
using System.Collections.Generic;

namespace DependencyInjectionStarter
{
    class Program
    {
        /** Testing 123 */
        static void Main()
        {
            BandLocater bandLocater = new BandLocater();
            List<IIinstrument> Instruments = new List<IIinstrument>();

            //Instruments.Add(new Guitar());
            //Instruments.Add(new Guitar());
            //Instruments.Add(new BassGuitar());
            //Instruments.Add(new Vocal());
            //Instruments.Add(new Drums());

            //var Metallica = new RockBand(Instruments);
            //Metallica.DoSoundCheck();

            //Instruments.Clear();

            //Instruments.Add(new Guitar());
            //Instruments.Add(new BassGuitar());
            //Instruments.Add(new Vocal());
            //Instruments.Add(new Drums());
            //Instruments.Add(new Keyboard());

            //var Coldplay = new RockBand(Instruments);
            //Coldplay.DoSoundCheck();

            bandLocater.DefaultRockband.DoSoundCheck();

            Console.ReadLine();
        }
    }
}
