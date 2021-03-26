﻿using Spese.Handler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spese.Approvazione
{
    class OperationalManager : HandlerAstratto
    {
        public override string Handle(int spesa)
        {
            if (spesa > 400 && spesa <= 1000)
            {
                return $"Un operational manager ha approvato la spesa di {spesa} euro";
            }
            return base.Handle(spesa);
        }
    }
}
