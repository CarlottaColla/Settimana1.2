using Spese.Handler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spese.Approvazione
{
    class Manager : HandlerAstratto
    {
        public override string Handle(int spesa)
        {
            if(spesa > 0 && spesa <= 400)
            {
                return $"Un manager ha approvato la spesa di {spesa} euro";
            }
            return base.Handle(spesa);
        }
    }
}
