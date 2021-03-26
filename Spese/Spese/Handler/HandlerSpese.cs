using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Spese.Handler
{
    public static class HandlerSpese
    {
        public static void HandlerSpeseTxt(object sender, FileSystemEventArgs fileSystem)
        {
            Console.WriteLine("Entrato in handler");
            //Questa funzione viene chiamata quando viene creato il file Spese.txt
            //Leggo i dati al suo interno
            using(StreamReader reader = File.OpenText(fileSystem.FullPath))
            {
                List<string> contenuto = new List<string>();
                string line;

                while((line = reader.ReadLine()) != null)
                {
                    contenuto.Add(line);
                    Console.WriteLine(line);
                }

                Console.WriteLine("Fine");
                reader.Close();

                Funzionalita.ApprovaSpese(contenuto);
                
            }
        }
    }
}
