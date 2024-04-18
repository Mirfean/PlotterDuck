using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterDuck.Components.Models.TicTacToe
{
	public class Bot_TTT
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		[NotNull]
		public string botName { get; set; }
		public int playerWins { get; set; }
		public int enemyWins { get; set; }
		public int strenght { get; set; }

		public Bot_TTT(string? botName, int strenght = 0, int playerWins = 0, int enemyWins = 0)
		{
			if(botName is null) 
				this.botName = "Bot";
			else
				this.botName = botName;
			
			this.playerWins = playerWins;
			this.enemyWins = enemyWins;
			this.strenght = strenght;
		}

		public Bot_TTT()
		{
			this.botName = "Bot";
			this.playerWins = 0;
			this.enemyWins = 0;
			this.strenght = 0;
		}
	}
}
