using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public sealed class SimpleRule : IRule
    {


        // return Cells which have changed their state in this evolution
        // Rule is only responsible for assessing the evolution.It does not change the state.
        public IEnumerable<Cell> Evolve(Grid PlayField)
        {

            List<Cell> EvolvedCells = new List<Cell>();

            foreach (Cell cell in PlayField.GetCellsEnumerator)
            {
                if (EvolveCell(cell, PlayField))
                {
                    EvolvedCells.Add(cell);
                }
            }

            return EvolvedCells;


        }



        bool EvolveCell(Cell cell, Grid PlayField)
        {
            if (cell.isAlive)
            {
                return EvolveAliveCell(cell, PlayField);
            }

            else
            {
                return EvolveDeadCell(cell, PlayField);
            }


        }



        bool EvolveAliveCell(Cell cell, Grid PlayField)
        {
            int aliveCount = GetAliveNeighborsCount(cell, PlayField);

            if (aliveCount < 2 || aliveCount > 3) return true; else return false; //Alive Cell: less than 2 alive Neighbors or More than 3 alive Neighbors ,alive cell becomes dead(changes state)

        }

        bool EvolveDeadCell(Cell cell, Grid PlayField)
        {
            int aliveCount = GetAliveNeighborsCount(cell, PlayField);

            if (aliveCount > 2) return true; else return false; //Dead Cell: more than 3 alive Neighbors ,dead cell becomes alive (changes state)

        }

        int GetAliveNeighborsCount(Cell cell, Grid PlayField)
        {

            int aliveCount = 0;


            aliveCount += IsCellAlive(PlayField.GetCell(cell.Row, cell.Col - 1)) ? 1 : 0;
            aliveCount += IsCellAlive(PlayField.GetCell(cell.Row, cell.Col + 1)) ? 1 : 0;
            aliveCount += IsCellAlive(PlayField.GetCell(cell.Row - 1, cell.Col)) ? 1 : 0;
            aliveCount += IsCellAlive(PlayField.GetCell(cell.Row - 1, cell.Col - 1)) ? 1 : 0;
            aliveCount += IsCellAlive(PlayField.GetCell(cell.Row - 1, cell.Col + 1)) ? 1 : 0;
            aliveCount += IsCellAlive(PlayField.GetCell(cell.Row + 1, cell.Col)) ? 1 : 0;
            aliveCount += IsCellAlive(PlayField.GetCell(cell.Row + 1, cell.Col - 1)) ? 1 : 0;
            aliveCount += IsCellAlive(PlayField.GetCell(cell.Row + 1, cell.Col + 1)) ? 1 : 0;
            return aliveCount;

        }


        bool IsCellAlive(Cell cell)
        {
            if (cell == null)
            {

                return false;
            }

            else
            {

                return cell.isAlive;
            }

        }









    }

}
