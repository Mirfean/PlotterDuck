using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlotterDuck.Components.Models.Firebase
{
    internal class AuthData
    {
        public required string email { get; set; }
        public required string password { get; set; }
        public string confirmPassword { get; set; }

        public AuthData()
        {
            email = "";
            password = "";
            confirmPassword = "";
        }

        public AuthData(string _email, string _password)
        {
            this.email = _email;
            this.password = _password;
            this.confirmPassword = "";
        }

        public AuthData(string email, string password, string confirmPassword)
        {
            this.email = email;
            this.password = password;
            this.confirmPassword = confirmPassword;
        }
    }
}
