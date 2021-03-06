using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Models;

namespace WpfApp1.Chain_of_Responsibility_Pattern
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


        public int count { get; set; } = 0;
        public void SetNextChain(IChain chain)
        {
            NextChain = chain;
        }

        public void User_if_else(User user)
        {

            try
            {
                string data = File.ReadAllText($"../../User.json");
                if (user.StepsofChain == "Order Chain")
                {
                    Thread.Sleep(1000);
                    MessageBox.Show($"You can choose Order", "Thanks", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"Can not order", "Third Chain", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Your information may be null");
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
            try
            {

                string data = File.ReadAllText($"../../User.json");
                if (user.StepsofChain == "SingIn Chain" && !string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
                {
                    user.StepsofChain = null;
                    user.StepsofChain = "Order Chain";
                    NextChain.User_if_else(user);
                }
                else
                {
                    MessageBox.Show($"Can not sign in", "Second Chain", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Your information may be null");
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
            try
            {
                string data = File.ReadAllText($"../../User.json");
                if (user.StepsofChain == "SingUp Chain" && user.FullName != string.Empty && user.Username != string.Empty && user.Password != string.Empty)
                {
                    NextChain.User_if_else(user);
                }
                if (user.StepsofChain == "SingUp Chain" && (user.FullName == string.Empty || user.Username == string.Empty || user.Password == string.Empty))
                {
                    MessageBox.Show($"Can not sign up", "First Chain", MessageBoxButton.OK, MessageBoxImage.Warning);

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Your information may be null");
            }
        }
    }
}

