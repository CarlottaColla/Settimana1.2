using System;
using System.Collections.Generic;
using System.Text;

namespace Spese.FactoryFolder
{
    class Vitto : IRimborso
    {
        public double RimborsaSpesa(int spesa)
        {
            //Rimborsa il 70%
            Console.WriteLine($"Rimborso vitto di {spesa * 70 / 100} euro su una spesa di {spesa}");
            return (double)spesa * 70 / 100;
        }
    }
}
