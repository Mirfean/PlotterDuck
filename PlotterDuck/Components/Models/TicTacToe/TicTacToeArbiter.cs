using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterDuck.Components.Models.TicTacToe
{
    internal class TicTacToeArbiter
    {
        public TicTacToeBoard Board { get; set; }
        public readonly List<string> WinningPositions = new List<string>
        {
            "012", "345", "678", "036", "147", "258", "048", "246"
        };

        public TicTacToeArbiter()
        {
			Board = new TicTacToeBoard();
		}
        
        public bool CheckWin(bool player)
        {
            if(player)
            {
				return false;
			}
            else
            {
				return false;
			}
            
        }

        public int GetBestMove()
        {
			return 0;
		}
    }
}
