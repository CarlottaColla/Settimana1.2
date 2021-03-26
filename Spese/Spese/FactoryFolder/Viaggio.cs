using System;
using System.Collections.Generic;
using System.Text;

namespace Spese.FactoryFolder
{
    class Viaggio : IRimborso
    {
        public double RimborsaSpesa(int spesa)
        {
            //Rimborsa il 100% + 50 euro
            Console.WriteLine($"Rimborso viaggio di {spesa + 50} euro su una spesa di {spesa}");
            return (double)spesa + 50;
        }
    }
}
