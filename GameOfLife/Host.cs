using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    //Entry Point for Game
    public sealed class Host
    {
       public IRule Rule { get; private set; }
       public IDisplayService DisplayService {get;private set;}
       public GameConfig config { get; private set; }
       public Grid PlayField { get; private set; }

       public Host(GameConfig config,IRule Rule,IDisplayService DisplayService)
       {

           Util.CheckNull(config, Rule, DisplayService);
           this.Rule = Rule;
           this.DisplayService = DisplayService;
           this.PlayField = new Grid(config);
           DisplayService.Display(PlayField);
       }

       public Host(Grid PlayField, IRule Rule, IDisplayService DisplayService)
       {
           Util.CheckNull(PlayField, Rule, DisplayService);
           this.Rule = Rule;
           this.DisplayService = DisplayService;
           this.PlayField = PlayField;
       }



       public void Evolve()
       {
          IEnumerable<Cell> EvolvedCells= Rule.Evolve(PlayField);
          this.PlayField.UpdateCells(EvolvedCells);
          this.DisplayService.Display(this.PlayField);
       
       }




    }
}
