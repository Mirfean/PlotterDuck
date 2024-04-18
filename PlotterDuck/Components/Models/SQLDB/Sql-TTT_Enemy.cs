using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin.Auth.Multitenancy;
using PlotterDuck.Components.Models.TicTacToe;
using SQLite;

namespace PlotterDuck.Components.Models.SQLDB
{
	internal class Sql_TTT_Enemy
	{
		SQLiteAsyncConnection ConnectedDB;

		string TABLE_NAME = "TTT_Enemy";

		#region Table Columns
		string BOTNAME = "BotName";
		string PLAYERWINS = "PlayerWins";
		string ENEMYWINS = "EnemyWins";
		string STRENGHT = "Strenght";
		#endregion

		async Task StartDatabase()
		{
			ConnectedDB = new SQLiteAsyncConnection(SQL_CONSTANTS.DatabasePath, SQL_CONSTANTS.Flags);
			var result = await ConnectedDB.CreateTableAsync<Bot_TTT>();
		}


		public async Task<List<Bot_TTT>> GetEnemies()
		{
			await StartDatabase();
			return await ConnectedDB.Table<Bot_TTT>().ToListAsync();
		}

		public async Task<List<Bot_TTT>> GetNamedBots()
		{
			await StartDatabase();
			return await ConnectedDB.Table<Bot_TTT>().Where(t => t.botName != null).ToListAsync();

			// Possible alternative
			//return await connection.QueryAsync<Bot_TTT>("SELECT * FROM [TTT_Enemy] WHERE botname is not null");
		}

		public async Task<int> SaveBotAsync(Bot_TTT bot)
		{
			await StartDatabase();
			if (bot.ID != 0)
			{
				return await ConnectedDB.UpdateAsync(bot);
			}
			else
			{
				return await ConnectedDB.InsertAsync(bot);
			}
		}

		public async Task<int> DeleteBotAsync(Bot_TTT bot)
		{
			await StartDatabase();
			return await ConnectedDB.DeleteAsync(bot);
		}

		public AsyncTableQuery<T> TableAsync<T>() where T : new()
		{
			return ConnectedDB.Table<T>();
		}


		//TODO: Make method to add enemy to database
		public bool AddEnemy(string enemyName, int strenght = 0, int playerScore = 0, int enemyScore = 0)
		{
			
			string query = $"INSERT INTO TTT_Enemy ({BOTNAME}, {PLAYERWINS}, {ENEMYWINS}, {STRENGHT}) " +
				"VALUES (@BotName, @PlayerWins, @EnemyWins, @Strenght)";
			/*
						connection.Open();

						using (SqlCommand command = new SqlCommand(query, connection))
						{
							command.Parameters.AddWithValue("@BotName", enemyName);
							command.Parameters.AddWithValue("@PlayerWins", playerScore);
							command.Parameters.AddWithValue("@EnemyWins", enemyScore);
							command.Parameters.AddWithValue("@Strenght", strenght);



							if(command.ExecuteNonQuery() > 0)
							{
								return true;
							}
							else
							{
								return false;
							}
						}*/
			return false;
		}
		
	}
}
