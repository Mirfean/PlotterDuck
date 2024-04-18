using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterDuck.Components.Models.SQLDB
{
	internal class SQL_CONSTANTS
	{
		public const string DatabaseFilename = "PlotterDuckDB.db";
		public const string DatabaseDictionary = "Database";
		public const string HARDCODED_DATABASE_PATH = "P:\\Projects\\.Net\\PlotterDuck\\PlotterDuck\\wwwroot\\Database";

		public const SQLite.SQLiteOpenFlags Flags =
			// open the database in read/write mode
			SQLite.SQLiteOpenFlags.ReadWrite |
			// create the database if it doesn't exist
			SQLite.SQLiteOpenFlags.Create |
			// enable multi-threaded database access
			SQLite.SQLiteOpenFlags.SharedCache;

		public static string DatabasePath =>
			@Path.Combine(HARDCODED_DATABASE_PATH, DatabaseFilename);
	}
}
