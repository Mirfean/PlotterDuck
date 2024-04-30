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

		public int? GetBestMove(int botLevel)
        {
            //Check for win
            List<int> winningMove = All1toWin(TTTBoxState.O);
            List<int> movesToBlock = All1toWin(TTTBoxState.X);
			
            //Best bot
			if (winningMove.Count > 0)
			{
				var bestMove = from move in winningMove
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

            //Random move by level
            int? result;
            if(botLevel <= 1)
            {
				result = GetRandomAvailable();
			}
            else
            {
                result = GetBestAvailableFromList(new int[] { 0, 2, 4, 6, 8 });
            }
            if(result != null)
            {
                return result;
            }
            else
            {
                result = GetBestAvailableFromList(new int[] { 1, 3, 5, 7 });
            }
            return result;
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

        private int? GetBestAvailableFromList(int[] considered)
        {
			int[] available = considered.Where(x => Board.Boardstates[x] == TTTBoxState.Empty).ToArray();
			if (available.Contains(4))
            {
                return 4;
            }

            available.Where(x => x % 2 == 0).ToArray();
            Random rnd = new Random();
            if(available.Length > 0)
			    return available[rnd.Next(0, available.Length)];
            else 
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
