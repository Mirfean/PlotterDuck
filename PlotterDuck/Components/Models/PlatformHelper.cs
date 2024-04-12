using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace PlotterDuck.Components.Models
{
	public static class PlatformHelper
	{
		public static string getPersonal()
		{
			return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
		}

		public static async Task LoadAuthFile()
		{
			using var stream = await FileSystem.OpenAppPackageFileAsync("plotterduck-firebase-adminsdk.json");
			using var reader = new StreamReader(stream);

			var contents = reader.ReadToEnd();
		}

		public static bool IsWindows()
		{
			return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
		}

		public static bool IsAndroid()
		{
			return Environment.GetEnvironmentVariable("ANDROID_ROOT") != null;
		}

		public static string getCredentials()
		{
			if (IsWindows())
			{
				return "P:\\Projects\\.Net\\PlotterDuck\\PlotterDuck\\Resources\\Raw\\plotterduck-firebase-adminsdk.json";
			}
			else if (IsAndroid())
			{
				//Not working	
				string documentsPath = FileSystem.AppDataDirectory;
				string filePath = Path.Combine(documentsPath, "Resources", "plotterduck-firebase-adminsdk.json");
				return filePath;
			}
			else
			{
				throw new PlatformNotSupportedException("Platform not supported");
			}
		}


	}

}
