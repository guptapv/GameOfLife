using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
   public interface IRule
    {
         IEnumerable<Cell> Evolve(Grid PlayField);
       
    }

  

    
}
