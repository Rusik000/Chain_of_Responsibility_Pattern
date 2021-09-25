using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WpfApp1.Chain_of_Responsibility_Pattern;
using WpfApp1.Command;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {


        public SignIn SignWindow { get; set; }


        public RelayCommand MouseEnterUsername { get; set; }

        public RelayCommand MouseLeaveUsername { get; set; }
        public RelayCommand MouseEnterPassword { get; set; }
        public RelayCommand MouseLeavePassword { get; set; }

        public RelayCommand SigInCompleted { get; set; }

        public ObservableCollection<User> new_User_List = new ObservableCollection<User>();

        public ObservableCollection<User> _User_List { get; set; }
        public ObservableCollection<User> User_List
        {
            get { return _User_List; }
            set { _User_List = value; }
        }

        string stepsofChain = "SingIn Chain";
        public SignInViewModel()
        {
            MouseEnterUsername = new RelayCommand((sender) =>
            {
                MouseEnter_Username();

            });

            MouseLeaveUsername = new RelayCommand((sender) =>
            {
                MouseLeave_Username();

            });

            MouseEnterPassword = new RelayCommand((sender) =>
            {
                MouseEnter_Password();
            });

            MouseLeavePassword = new RelayCommand((sender) =>
            {
                MouseLeave_Password();

            });


            SigInCompleted = new RelayCommand((sender) =>
            {
                User_List = Deserialize();
                if (User_List != null)
                {

                    foreach (var users in User_List)
                    {

                        if (SignWindow.UsernameTxtBx.Text == users.Username && SignWindow.PasswordTxtBx.Text == users.Password)
                        {
                            MessageBox.Show($"Welcome {users.FullName}");

                        }
                    }

                }
                else
                {
                    MessageBox.Show("Sorry you don't have account  ");
                }

                if (User_List != null)
                {



                    IChain chain = new SingUp_Chain();
                    IChain chain2 = new SingIn_Chain();
                    IChain chain3 = new Order_Chain();

                    chain.SetNextChain(chain2);
                    chain2.SetNextChain(chain3);


                    foreach (var users in User_List)
                    {

                        if (SignWindow.UsernameTxtBx.Text == users.Username && SignWindow.PasswordTxtBx.Text == users.Password)
                        {
                            User User = new User(users.Username, stepsofChain, users.Password);
                            chain2.User_if_else(User);
                        }
                    }


                }
            });

        }


        public void MouseEnter_Username()
        {
            if (SignWindow.UsernameTxtBx.Text == "Username")
            {
                SignWindow.UsernameTxtBx.Text = null;
                Color color1 = new Color();
                color1 = Color.FromArgb(255, 37, 191, 191);

                SignWindow.UsernameTxtBx.Foreground = new SolidColorBrush(color1);
            }
        }

        public void MouseLeave_Username()
        {
            if (SignWindow.UsernameTxtBx.Text == "")
            {

                Color color2 = new Color();
                color2 = Color.FromArgb(255, 110, 127, 128);

                SignWindow.UsernameTxtBx.Text = "Username";
                SignWindow.UsernameTxtBx.Foreground = new SolidColorBrush(color2);
            }
        }


        public void MouseEnter_Password()
        {
            if (SignWindow.PasswordTxtBx.Text == "Password")
            {
                SignWindow.PasswordTxtBx.Text = null;



                Color color1 = new Color();
                color1 = Color.FromArgb(255, 37, 191, 191);

                SignWindow.PasswordTxtBx.Foreground = new SolidColorBrush(color1);
            }
        }

        public void MouseLeave_Password()
        {
            if (SignWindow.PasswordTxtBx.Text == "")
            {

                Color color2 = new Color();
                color2 = Color.FromArgb(255, 110, 127, 128);

                SignWindow.PasswordTxtBx.Text = "Password";
                SignWindow.PasswordTxtBx.Foreground = new SolidColorBrush(color2);
            }
        }


        public ObservableCollection<User> Deserialize()
        {

            var serializer = new JsonSerializer();

            using (var sr = new StreamReader("User.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    new_User_List = serializer.Deserialize<ObservableCollection<User>>(jr);
                }
            }

            return new_User_List;
        }
    }
}
