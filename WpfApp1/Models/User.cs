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
        public User(string stepsofChain, string fullName, string username)
        {
            StepsofChain = stepsofChain;
            FullName = fullName;
            Username = username;
        }

        public string StepsofChain { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }


        public override string ToString()
        {
            return $"{FullName}";
        }

    }
}
