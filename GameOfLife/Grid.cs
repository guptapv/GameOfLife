using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
   public class Grid
    {
       public int Rows { get; private set; }
       public int Cols { get; private set; }
       Dictionary<string, Cell> Cells;
       private GameConfig config;


       public Grid()
       {
          
       }

       public Grid(GameConfig config)
       {
           Util.CheckNull(config);
           this.config = config;
           if (!Init(config))
           {
               throw new ArgumentException("Initialization Parameters are wrong.");
           }
       }
       public Cell GetCell(int row, int col)
       {
           if (row >=0 && col>=0 && row < Rows  && col < Cols )
           {
               return Cells[GetCellKey(row, col)];
           }

           else
           {
               return null;
           }
       }

       string GetCellKey(int row, int col)
       {
           return "R" + row + "C" + col;
       
       }


       private  bool Init(GameConfig gameConfig)
       {
           Util.CheckNull(gameConfig);
           CreateCells(gameConfig.Rows, gameConfig.Cols);
           foreach (string alivecell in gameConfig.AliveCells.Split('|'))
           {
               string[] cellinfo = alivecell.Split(',');
               int row, col;

               if (cellinfo.Length != 2) return false;

               if (!int.TryParse(cellinfo[0], out row)) return false;

               if (!int.TryParse(cellinfo[1], out col)) return false;

               if (row < 0 || row > gameConfig.Rows - 1 || col < 0 || col > gameConfig.Cols-1) return false;

               this.GetCell(row, col).isAlive = true;



           }

           return true;
       }



       void CreateCells(int rows, int cols)
       {
           this.Cells = new Dictionary<string, Cell>();

           for (int i = 0; i < rows; i++)
           {
               for (int j = 0; j < cols; j++)
               {

                   Cell cell = new Cell(i, j);
                   this.Cells.Add(GetCellKey(i, j), cell);

               }
               
           }

           this.Rows = rows;
           this.Cols = cols;
       
       }




       public IEnumerable<Cell> GetCellsEnumerator
       {
           get
           {
               return this.Cells.Values.AsEnumerable<Cell>();
           }
       }

       public void UpdateCells(IEnumerable<Cell> EvolvedCells)
       {
           Util.CheckNull(EvolvedCells);
           foreach (var cell in EvolvedCells) //Though here this cell instance is same as in grid but we cant assume that.
                                             //  So getting the cell reference again instead of directly modifying the cells from the input list
           {

               var eveolvedCell = this.GetCell(cell.Row, cell.Col);
               eveolvedCell.isAlive = !eveolvedCell.isAlive;

           }
       }

    
    }
}
