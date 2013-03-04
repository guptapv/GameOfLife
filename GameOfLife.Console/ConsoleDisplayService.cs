using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.ConsoleDisplay
{
   // This will render the game in console.Similarly implementation can be provided for other surfaces....
    public class ConsoleDisplayService:IDisplayService
    {

        public void Display(Grid PlayField)
        {
            for (int i = 0; i < PlayField.Rows; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < PlayField.Cols; j++)
                {

                    Console.Write(PlayField.GetCell(i, j).isAlive ? "1" : "0");
                }

            }
        }
    }
}
