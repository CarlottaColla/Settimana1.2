using System;
using System.Collections.Generic;
using System.Text;

namespace Spese.FactoryFolder
{
    class Altro : IRimborso
    {
        public double RimborsaSpesa(int spesa)
        {
            //Rimborsa il 10%
            Console.WriteLine($"Rimborso altro di {spesa * 10 / 100} euro su una spesa di {spesa}");
            return (double)spesa * 10 / 100;
        }
    }
}
