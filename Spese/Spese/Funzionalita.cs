using Spese.Approvazione;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Spese
{
    public class Funzionalita
    {
        public static void ApprovaSpese(List<string> contenutoFile)
        {
            List<int> spese = new List<int>();
            using (StreamWriter file = File.CreateText(@"C:\Users\carlotta.colla\Desktop\Week1\spese_elaborate.txt"))
            {
                foreach (var item in contenutoFile)
                {
                    string[] contenuto = item.Split(';');
                    string approvata = Chain(Convert.ToInt32(contenuto[3]));
                    double rimborso = 0;
                    if (approvata != "RESPINTA" && approvata.Substring(0, 9) == "APPROVATA")
                    {
                        rimborso = FactoryFolder.Factory.FactorySpese(Convert.ToInt32(contenuto[3]), contenuto[2]);
                        file.WriteLine($"{contenuto[0]};{contenuto[1]};{contenuto[2]};APPROVATA;{approvata.Substring(8)};{rimborso};");
                    }
                    else
                    {
                        file.WriteLine($"{contenuto[0]};{contenuto[1]};{contenuto[2]};RESPINTA;-;-;");
                    }
                }
            }

        }

        public static string Chain(int spesa)
        {
            //Costruisco gli oggetti della catena
            var manager = new Manager();
            var operational = new OperationalManager();
            var ceo = new Ceo();

            //Concateno gli anelli
            manager.Next(operational).Next(ceo);

            //Gli passo le spese per approvarle
                var approvata = manager.Handle(spesa);

                if(approvata != null)
                {
                    //Se qualcuno la riesce a gestire stampa il risultato
                    Console.WriteLine(approvata);
                    return approvata;
                }
                else
                {
                    Console.WriteLine($"Nessuno può approvare una spesa di {spesa} euro");
                    return "RESPINTA";
                }

                
            
        }
    }


}
