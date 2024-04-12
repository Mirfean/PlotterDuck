using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterDuck.Components.Models
{
    public class CharacterService
    {
        private const string FirebaseDatabaseUrl = "https://plotterduck-default-rtdb.europe-west1.firebasedatabase.app/";
        private readonly FirebaseClient firebase;

        public CharacterService()
        {
            firebase = new FirebaseClient(FirebaseDatabaseUrl);
        }

        public async Task<List<Character>> GetCharacters2()
        {
			var characters = await firebase.Child("Characters").OnceAsync<Character>();

			var charactersList = new List<Character>();
			foreach (var firebaseObject in characters)
			{
				charactersList.Add(firebaseObject.Object);
			}
			return charactersList;
		}

        public async Task<List<Character>> GetCharacters()
        {
            var characters = await firebase.Child("Characters").OnceAsListAsync<Character>();

			var charactersList = new List<Character>();
			foreach (var firebaseObject in characters)
			{
				charactersList.Add(firebaseObject.Object);
			}
			return charactersList;
		}

        public async Task AddCharacter(Character character)
        {
            await firebase.Child("Characters").PostAsync(character);
        }
    }
}
