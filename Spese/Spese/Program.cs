using Spese.Handler;
using System;
using System.IO;

namespace Spese
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creo il fileSystemWatcher
            FileSystemWatcher fileSystem = new FileSystemWatcher();
            //Gli assegno il path
            fileSystem.Path = @"C:\Users\carlotta.colla\Desktop\Week1";
            //Deve guaradre solo il file che si chiama Spese.txt
            fileSystem.Filter = "Spese.txt";
            //Filtri per le notifiche
            //Quando mandare la notifica? Quando succede uno di questi eventi
            fileSystem.NotifyFilter = NotifyFilters.LastWrite |
                NotifyFilters.LastAccess |
                NotifyFilters.FileName |
                NotifyFilters.DirectoryName;
            //Abilito le notifiche
            fileSystem.EnableRaisingEvents = true;
            //Deve gestire la creazione del file
            fileSystem.Created += HandlerSpese.HandlerSpeseTxt;

            //Devo restare in attesa, altrimenti l'applicazione si chiude subito
            Console.ReadKey();

        }
    }
}
