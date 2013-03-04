using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.ConsoleDisplay
{
    static class PlayManager
    {

        static int Rows = 5;
        static int Cols = 5;
        static bool AutoMode = true;
        static int Iteration = 10;
        static string AliveCells = "0,0|1,1|2,2|2,3|3,4";
        static Host host;


        public static void Init()
        {
            Console.Write("\n>");
            string Input = Console.ReadLine();
            if (Input.Trim().ToUpper() == "START")
            {
                PlayGame();
            }

            else if (Input.Trim().ToUpper() == "/HELP")
            {
                PrintHelp();
                Init();

            }

            else
            {
                ProcessInput(Input);
                Init();


            }

        }

        static void PlayGame()
        {
            GameConfig config = new GameConfig(Rows, Cols, AliveCells);
            IDisplayService displayService = new ConsoleDisplayService();
            IRule rule = new SimpleRule();

            try
            {
                host = new Host(config, rule, displayService);

            }
            catch (ArgumentException)
            {

                Console.WriteLine("\n Error in Configuration!!!");
                Init();

            }

            if (AutoMode)
            {
                for (int i = 0; i < Iteration; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    System.Threading.Thread.Sleep(2000);
                    host.Evolve();


                }
                Init();
            }
            else
            {
                while (Console.ReadLine() == "")
                {
                    host.Evolve();
                }
            }

        }
        
        static bool ProcessInput(string input)
        {
            bool error = false;

            foreach (string inp in input.Split('/'))
            {

                if (inp != string.Empty)
                {
                    switch (inp.Substring(0, 1).ToUpper())
                    {
                        case "R":

                            if (!int.TryParse(GetCommandValue(inp), out Rows))
                            {
                                Console.WriteLine("Invalid Input for Row.Please press /? for Options");
                                error = true;
                            }
                            break;

                        case "C":
                            if (!int.TryParse(GetCommandValue(inp), out Cols))
                            {
                                Console.WriteLine("Invalid Input for Col.Please press /? for Options");
                                error = true;
                            }
                            break;


                        case "A":
                            if (!int.TryParse(GetCommandValue(inp), out Iteration))
                            {
                                Console.WriteLine("Invalid Input for Auto Mode.Please press /? for Options");
                                error = true;
                            }

                            else
                            {
                                AutoMode = Iteration == 0 ? false : true;
                            }
                            break;

                        case "I":

                            if (!ValidateInitialAliveCells(GetCommandValue(inp)))
                            {
                                Console.WriteLine("Invalid Input for Alive Cells.Please press /? for Options");
                                error = true;
                            }
                            break;


                        case "?":

                            PrintOptions();
                            break;
                        default:
                            Console.WriteLine("Unrecognized Input .Please press /? for Options");
                            error = true;
                            break;
                    }
                }



            }
            return error;

        }

        private static bool ValidateInitialAliveCells(string aliveCells)
        {
            foreach (string alivecell in aliveCells.Split('|'))
            {
                string[] cellinfo = alivecell.Split(',');
                int row, col;

                if (cellinfo.Length != 2) return false;

                if (!int.TryParse(cellinfo[0], out row)) return false;

                if (!int.TryParse(cellinfo[1], out col)) return false;

                if (row < 0 || row > Rows - 1 || col < 0 || col > Cols) return false;




            }

            return true;
        }

        private static void PrintOptions()
        {
            Console.WriteLine("/Help -- Help \n");
            Console.WriteLine("/I [AliveCells] --Specify startup Alive Cells. Please provide in the  Format: <row>,<col> | <row>,<col>\n");
            Console.WriteLine("/R [Rows]-- Specify Grid Row Size \n");
            Console.WriteLine("/C [Columns]-- Specify Grid Col Size \n");
            Console.WriteLine("/A [Iteration]-- Specify Iteration for Auto Mode. 0 for Manual Mode \n");


        }

        static string GetCommandValue(string input)
        {
            return input.Substring(1).Trim();

        }


        public static void PrintHelp()
        {
            Console.WriteLine("************************Welcome to Game of Life************************ \n");
            Console.WriteLine("Game is based on following Rules \n");
            Console.WriteLine("Game starts with initial configuration of Alive cells \n");
            Console.WriteLine("On every evolution Cell become live or dead :");
            Console.WriteLine("If Cell is alive and if it has less than two Neighbors ,it dies of loneliness");
            Console.WriteLine("If Cell is alive and if it has more than three alive Neighbors ,it dies of over population");
            Console.WriteLine("If Cell is dead and if it has three or more Neighbors  then it becomes alive");
            Console.WriteLine("\nYou Can Play the game in Auto Mode or Manual Mode");
            Console.WriteLine("\n/? for Options");
            Console.WriteLine("\nPlease type START to play the game");
            Console.WriteLine("\n*********************************************************************** \n");

        }
    }
}
