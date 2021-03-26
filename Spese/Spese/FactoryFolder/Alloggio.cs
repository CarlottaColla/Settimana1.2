using System;
using System.Collections.Generic;
using System.Text;

namespace Spese.FactoryFolder
{
    class Alloggio : IRimborso
    {
        public double RimborsaSpesa(int spesa)
        {
            //rimborsa il 100%
            Console.WriteLine($"Rimborso alloggio di {spesa} euro su una spesa di {spesa}");
            return (double)spesa;
        }
    }
}
