using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Spese.FactoryFolder
{
    public class Factory
    {
        public static double FactorySpese(int spesa, string descrizione)
        {
            IRimborso rimborso = null;

            List<(int, string, double)> ritorna = new List<(int, string, double)>();

                if (descrizione.Equals("Viaggio"))
                {
                    rimborso = new Viaggio();
                    
                }
                else if (descrizione.Equals("Alloggio"))
                {
                    rimborso = new Alloggio();
                    
                }
                else if (descrizione.Equals("Altro"))
                {
                    rimborso = new Altro();
                    
                }
                else if (descrizione.Equals("Vitto"))
                {
                    rimborso = new Vitto();
                   
                }
                else
                {
                    Console.WriteLine("Descrizione sbagliata");
                    return 0;
                }

                return rimborso.RimborsaSpesa(spesa);            
        }
    }
}
