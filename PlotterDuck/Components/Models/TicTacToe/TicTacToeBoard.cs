using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterDuck.Components.Models.TicTacToe
{
	public enum TTTBoxState { Empty, X, O }

    internal class TicTacToeBoard
    {
		public TTTBoxState[] BoardState;

		public TicTacToeBoard()
        {
			BoardState = new TTTBoxState[9];
		}

		public void SetBox(int index, bool player)
		{
			if (player)
			{
				SetBox(index, TTTBoxState.X);
			}
			else
			{
				SetBox(index, TTTBoxState.O);
			}
		} 

		void SetBox(int index, TTTBoxState state)
		{
			BoardState[index] = state;
		}

		public void Reset()
		{
			for(int i = 0; i < 9; i++)
			{
				BoardState[i] = TTTBoxState.Empty;
			}
		}
	}
}
