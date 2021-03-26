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
            foreach (var item in contenutoFile)
            {
                string[] contenuto = item.Split(';');
                spese.Add(Convert.ToInt32(contenuto[3]));
            }

            List<int> speseApprovate = Chain(spese);

            //Devo prendere la categoria di ogni spesa
            Dictionary<int, string> speseCategoria = new Dictionary<int, string>();

            foreach (var item in contenutoFile)
            {
                string[] contenuto = item.Split(';');
                //Se la spesa è stata approvata salvo la categoria
                if(speseApprovate.Contains(Convert.ToInt32(contenuto[3])))
                {
                    speseCategoria.Add(Convert.ToInt32(contenuto[3]), contenuto[1]);
                }
            }

            //Chiamo la factory per calcolare il rimborso
            List<(int, string, double)> rimborsi = FactoryFolder.Factory.FactorySpese(speseCategoria);

            using (StreamWriter file = File.CreateText(@"C:\Users\carlotta.colla\Desktop\Week1\spese_elaborate.txt"))
            {
                foreach (var item in contenutoFile)
                {
                    string[] contenuto = item.Split(';');
                    if (speseApprovate.Contains(Convert.ToInt32(contenuto[3])))
                    {
                        
                        file.WriteLine($"{contenuto[0]};{contenuto[1]};{contenuto[2]};APPROVATA;;;");
                    }
                    else
                    {
                        file.WriteLine($"{contenuto[0]};{contenuto[1]};{contenuto[2]};RESPINTA;-;-;");
                    }
                        
                }
                
               
            }
        }

        public static List<int> Chain(List<int> spese)
        {
            //Spese che sono state approvate
            List<int> speseApprovate = new List<int>();
            //Costruisco gli oggetti della catena
            var manager = new Manager();
            var operational = new OperationalManager();
            var ceo = new Ceo();

            //Concateno gli anelli
            manager.Next(operational).Next(ceo);

            //Gli passo le spese per approvarle
            foreach (var spesa in spese)
            {
                var approvata = manager.Handle(spesa);

                if(approvata != null)
                {
                    //Se qualcuno la riesce a gestire stampa il risultato
                    Console.WriteLine(approvata);
                    speseApprovate.Add(spesa);
                }
                else
                {
                    Console.WriteLine($"Nessuno può approvare una spesa di {spesa} euro");
                }

                
            }

            //Ritorna le spese approvate
            return speseApprovate;
        }
    }


}
