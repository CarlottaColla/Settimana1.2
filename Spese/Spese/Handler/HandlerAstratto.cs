using System;
using System.Collections.Generic;
using System.Text;

namespace Spese.Handler
{
    abstract class HandlerAstratto : IHandlerChain
    {
        //Implementa l'interfaccia e viene ereditato dalle classi concrete

        //Salva l'anello successo in un campo privato
        private IHandlerChain NextHandler;

        //è marcata virtual perchè ogni classe implementa la propria risposta alla richiesta,
        //Se la richiesta non è la sua usa questo comportamento di base per passarla all'anello successivo
        public virtual string Handle(int spesa)
        {
            //Se non è l'ultimo anello della catena allora lo passa al successivo
            if(this.NextHandler != null)
            {
                return this.NextHandler.Handle(spesa);
            }
            else
            {
                //Se non c'è nessun anello successivo ritorna null;
                return null; 
            }
        }

        public IHandlerChain Next(IHandlerChain next)
        {
            NextHandler = next;
            return next;
        }
    }
}
