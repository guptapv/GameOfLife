using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    //This Inteface will be used for rendering the game surface
    public  interface IDisplayService
    {

      void Display(Grid PlayField);
    }


}
