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

        private int GetStatesSum(TTTBoxState wantedState, string line)
        {
            int result = 0;
            for(int i = 0; i < line.Length; i++)
            {
				if (Board.Boardstates[Int32.Parse(line[i].ToString())] == wantedState)
                {
                    result++;
                }
			}
            return result;
        }
        
        public bool CheckWin(bool player)
        {
            if(player)
            {
				return CheckLines(TTTBoxState.X);
			}
            else
            {
				return CheckLines(TTTBoxState.O);
			}
            
        }

        private bool CheckLines(TTTBoxState state)
        {
            foreach(var position in WinningPositions)
            {
                if (GetStatesSum(state, position) == 3)
                {
					return true;
				}
			}
            return false;
        }

		#region BOT

		public int? GetBestMove()
        {
            //Check for win
            List<int> bestMoves = All1toWin(TTTBoxState.O);
            List<int> movesToBlock = All1toWin(TTTBoxState.X);
			//Best bot
			if (bestMoves.Count > 0)
			{
				var bestMove = from move in bestMoves
							   orderby move
							   select move;
                return bestMove.First();
			}
            //Block player
            if(movesToBlock.Count > 0)
            {
                var bestMove = from move in movesToBlock
							   orderby move
							   select move;
				return bestMove.First();
            }

            int? result = GetRandomAvailable();
            if(result != null)
            {
                return result;
            }
            return null;
		}

		private int? GetRandomAvailable()
		{
            if(Board.Boardstates.All(x => x != TTTBoxState.Empty))
            {
				return null;
			}
            int result;
			Random random = new Random();
            for(int exit = 0; exit < 100; exit++)
            {
                result = random.Next(0, 9);
				if (Board.Boardstates[result] == TTTBoxState.Empty)
				{
					return result;
				}
			}
            return null;
		}

		List<int> All1toWin(TTTBoxState state = TTTBoxState.O)
        {
            List<int> all = new List<int>();

            foreach (var position in WinningPositions)
            {
                if(GetStatesSum(state, position) == 2)
                {
                    foreach(var i in position)
                    {
                        if (Board.Boardstates[Int32.Parse(i.ToString())] == TTTBoxState.Empty)
                        {
							all.Add(Int32.Parse(i.ToString()));
						}
					}
                }
            }
            return all;
        }

		#endregion
	}




}
