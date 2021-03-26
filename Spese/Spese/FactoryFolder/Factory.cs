using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Spese.FactoryFolder
{
    public class Factory
    {
        public static List<(int, string, double)> FactorySpese(Dictionary<int,string> speseDescrizione)
        {
            IRimborso rimborso = null;

            List<(int, string, double)> ritorna = new List<(int, string, double)>();

            int spesa = 0;
            foreach (var descrizione in speseDescrizione)
            {
                if (descrizione.Value.Equals("Viaggio"))
                {
                    rimborso = new Viaggio();
                    spesa = descrizione.Key;
                }
                else if (descrizione.Value.Equals("Alloggio"))
                {
                    rimborso = new Alloggio();
                    spesa = descrizione.Key;
                }
                else if (descrizione.Value.Equals("Altro"))
                {
                    rimborso = new Altro();
                    spesa = descrizione.Key;
                }
                else if (descrizione.Value.Equals("Vitto"))
                {
                    rimborso = new Vitto();
                    spesa = descrizione.Key;
                }
                else
                {
                    Console.WriteLine("Descrizione sbagliata");
                    return null;
                }

                double soldiRimborsati = rimborso.RimborsaSpesa(spesa);
                ritorna.Add((descrizione.Key, descrizione.Value, soldiRimborsati));

            }
            return ritorna;

            
        }
    }
}
