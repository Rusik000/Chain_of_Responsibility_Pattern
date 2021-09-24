using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Models;

namespace WpfApp1.Chain_of_Responsibility_Pattern
{
    public class Chain_Responsibility
    {
        interface IChain
        {
            IChain NextChain { get; set; }
            void SetNextChain(IChain chain);

            void User_if_else(User user);

        }     
        class Order_Chain : IChain
        {
            public IChain NextChain { get; set; }

            public void SetNextChain(IChain chain)
            {
                NextChain = chain;
            }

            public void User_if_else(User user)
            {

                string data = File.ReadAllText($"../../User.json");

                if (user.StepsofChain == "Order Chain" && !string.IsNullOrEmpty(user.FullName) && !string.IsNullOrEmpty(user.Password))
                {

                    NextChain.User_if_else(user);

                }

                else
                {
                    //NextChain.User_if_else(user);
                    MessageBox.Show($"Can not order", "Third Chain", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }


        class SingIn_Chain : IChain
        {
            public IChain NextChain { get; set; }

            public void SetNextChain(IChain chain)
            {
                NextChain = chain;
            }

            public void User_if_else(User user)
            {
                string data = File.ReadAllText($"../../User.json");
                if (user.StepsofChain == "SingIn Chain" && !string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
                {
                    NextChain.User_if_else(user);
                }
                else
                {
                    // NextChain.User_if_else(user);
                    MessageBox.Show($"Can not sing in", "Second Chain", MessageBoxButton.OK, MessageBoxImage.Warning);

                }

            }
        }



        class SingUp_Chain : IChain
        {
            public IChain NextChain { get; set; }


            public void SetNextChain(IChain chain)
            {
                NextChain = chain;
            }

            public void User_if_else(User user)
            {
                string data = File.ReadAllText($"../../User.json");
                if (user.StepsofChain == "SingUp Chain" && user.FullName != string.Empty && user.Username != string.Empty && user.Password != string.Empty )
                {
                    NextChain.User_if_else(user);
                }
                if (user.StepsofChain == "SingUp Chain" && (user.FullName == string.Empty || user.Username == string.Empty || user.Password == string.Empty))
                {
                    //  NextChain.User_if_else(user);
                    MessageBox.Show($"Can not sing up", "First Chain", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
