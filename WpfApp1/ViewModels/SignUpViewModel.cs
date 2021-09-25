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
    public class SignUpViewModel : BaseViewModel
    {

        public UserControl1 SingUp { get; set; }

        public ObservableCollection<User> User_List1 = new ObservableCollection<User>();



        private User _user;
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }



        public string[] code = new string[11];

        public bool singupclick = false;

        public UserControl1 SignUpWindow { get; set; }

        public RelayCommand MouseEnterFullname { get; set; }
        public RelayCommand MouseLeaveFullname { get; set; }
        public RelayCommand MouseEnterUsername { get; set; }
        public RelayCommand MouseLeaveUsername { get; set; }
        public RelayCommand MouseEnterPassword { get; set; }
        public RelayCommand MouseLeavePassword { get; set; }
        public RelayCommand SingUpComplateCommand { get; set; }

        string stepsofChain = "SingUp Chain";
        public SignUpViewModel()
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


            MouseEnterFullname = new RelayCommand((sender) =>
             {
                 MouseEnter_Fullname();

             });

            MouseLeaveFullname = new RelayCommand((sender) =>
            {
                MouseLeave_Fullname();

            });


            SingUpComplateCommand = new RelayCommand((e) =>
            {
                User user = new User()
                {
                    FullName = SignUpWindow.FullnameTxtBx.Text,
                    Username = SignUpWindow.UsernameTxtBx.Text,
                    Password = SignUpWindow.PasswordTxtBx.Text,
                    StepsofChain = stepsofChain

                };

                User_List1.Add(user);
                Serialize(User_List1);

                if (SignUpWindow.UsernameTxtBx.Text != string.Empty && SignUpWindow.PasswordTxtBx.Text != string.Empty)
                {
                    IChain chain = new SingUp_Chain();
                    IChain chain2 = new SingIn_Chain();
                    IChain chain3 = new Order_Chain();

                    chain.SetNextChain(chain2);
                    chain2.SetNextChain(chain3);

                    User User = new User(SignUpWindow.FullnameTxtBx.Text, SignUpWindow.UsernameTxtBx.Text, SignUpWindow.PasswordTxtBx.Text, stepsofChain);
                    chain.User_if_else(User);
                }

                MessageBox.Show("Your information is added");
            });
        }

        private void MouseEnter_Fullname()
        {
            if (SignUpWindow.FullnameTxtBx.Text == "Full Name")
            {
                SignUpWindow.FullnameTxtBx.Text = null;



                Color color1 = new Color();
                color1 = Color.FromArgb(255, 37, 191, 191);

                SignUpWindow.FullnameTxtBx.Foreground = new SolidColorBrush(color1);
            }
        }

        private void MouseLeave_Fullname()
        {
            if (SignUpWindow.FullnameTxtBx.Text == "")
            {

                Color color2 = new Color();
                color2 = Color.FromArgb(255, 110, 127, 128);

                SignUpWindow.FullnameTxtBx.Text = "Full Name";
                SignUpWindow.FullnameTxtBx.Foreground = new SolidColorBrush(color2);
            }
        }

        private void MouseEnter_Username()
        {
            if (SignUpWindow.UsernameTxtBx.Text == "Username")
            {
                SignUpWindow.UsernameTxtBx.Text = null;



                Color color1 = new Color();
                color1 = Color.FromArgb(255, 37, 191, 191);

                SignUpWindow.UsernameTxtBx.Foreground = new SolidColorBrush(color1);
            }
        }

        private void MouseLeave_Username()
        {
            if (SignUpWindow.UsernameTxtBx.Text == "")
            {

                Color color2 = new Color();
                color2 = Color.FromArgb(255, 110, 127, 128);

                SignUpWindow.UsernameTxtBx.Text = "Username";
                SignUpWindow.UsernameTxtBx.Foreground = new SolidColorBrush(color2);
            }
        }

        private void MouseEnter_Password()
        {
            if (SignUpWindow.PasswordTxtBx.Text == "Password")
            {
                SignUpWindow.PasswordTxtBx.Text = null;



                Color color1 = new Color();
                color1 = Color.FromArgb(255, 37, 191, 191);

                SignUpWindow.PasswordTxtBx.Foreground = new SolidColorBrush(color1);
            }
        }

        private void MouseLeave_Password()
        {
            if (SignUpWindow.PasswordTxtBx.Text == "")
            {
                Color color2 = new Color();
                color2 = Color.FromArgb(255, 110, 127, 128);
                SignUpWindow.PasswordTxtBx.Text = "Password";
                SignUpWindow.PasswordTxtBx.Foreground = new SolidColorBrush(color2);
            }
        }



        private void Serialize(ObservableCollection<User> userData)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter("User.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, userData);
                }
            }
        }







    }
}

