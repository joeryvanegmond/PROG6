using System;
using System.Collections.Generic;

namespace DependencyInjectionStarter.Library
{
    public class RockBand
    {
        private Guitar guitar = new Guitar();
        private BassGuitar bassGuitar = new BassGuitar();
        private Drums drums = new Drums();
        private Vocal vocal = new Vocal();

        private List<IIinstrument> _Instruments;

        public RockBand(List<IIinstrument> instruments) 
        {
            _Instruments = instruments;
        }    

        public void DoSoundCheck()
        {
            _Instruments.ForEach(i => Console.WriteLine(i.UseInstrument()));
        }
    }
}
