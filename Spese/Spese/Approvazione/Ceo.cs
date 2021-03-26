using Spese.Handler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spese.Approvazione
{
    class Ceo : HandlerAstratto
    {
        public override string Handle(int spesa)
        {
            if (spesa > 1000 && spesa <= 2500)
            {
                return $"Un CEO ha approvato la spesa di {spesa} euro";
            }
            return base.Handle(spesa);
        }
    }
}
