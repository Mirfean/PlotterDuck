using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using Firebase.Auth.Providers;

namespace PlotterDuck.Components.Models.Firebase
{
    public class FirebaseAuthService
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;
        public FirebaseAuthService()
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyA9z_SEEU6m-pFW9mplFcYhWEzKkxCtB3E",
                AuthDomain = "plotterduck.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider()
            }
            };

            _firebaseAuthClient = new FirebaseAuthClient(config);
        }
        public async Task<string?> SignUp(string email, string password)
        {
            var userCredentials = await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(email, password);
            return userCredentials is null ? null : await userCredentials.User.GetIdTokenAsync();
        }
        public async Task<string?> Login(string email, string password)
        {
            var userCredentials = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(email, password);
            return userCredentials is null ? null : await userCredentials.User.GetIdTokenAsync();
        }

        public void SignOut() => _firebaseAuthClient.SignOut();
    }
}
