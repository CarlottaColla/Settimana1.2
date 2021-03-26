using System;
using System.Collections.Generic;
using System.Text;

namespace Spese.Handler
{
    interface IHandlerChain
    {
        //Dice chi è l'anello successivo
        IHandlerChain Next(IHandlerChain next);

        //Implementa la risposta se la richiesta è per lui
        //Li differenzio in base all'importo della spesa (double)
        string Handle(int spesa);
    }
}
