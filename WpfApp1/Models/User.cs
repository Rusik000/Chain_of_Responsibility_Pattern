using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class User
    {
        public User()
        {

        }

        public User(string stepsofChain)
        {
            StepsofChain = stepsofChain;
        }

        public User(string username, string stepsofChain, string password)
        {
            Username = username;
            StepsofChain = stepsofChain;
            Password = password;
        }

        public User(string fullName, string username, string stepsofChain, string password)
        {
            FullName = fullName;
            Username = username;
            StepsofChain = stepsofChain;
            Password = password;
        }

        public string FullName { get; set; }
        public string Username { get; set; }


        public string StepsofChain { get; set; }


        public string Password { get; set; }


        public override string ToString()
        {
            return $"{FullName}";
        }

    }
}
