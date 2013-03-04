using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
   public class GameConfig
    {
      public int Rows { get;private set; }
      public int Cols { get; private set; }
      public string AliveCells { get; private set; }

      public GameConfig(int Rows,int Cols,string AliveCells)
      {
          this.Rows = Rows;
          this.Cols = Cols;
          this.AliveCells = AliveCells;
      }






    }
}
