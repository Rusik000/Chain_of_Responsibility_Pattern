using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Command;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        public MainWindow MainWindow { get; set; }

        public RelayCommand PassToSignIn { get; set; }
        public RelayCommand PassToSignUp { get; set; }

        public RelayCommand PassToOrder { get; set; }


        private User _user;
        public User User
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(); }
        }


        public AppViewModel()
        {
            PassToSignIn = new RelayCommand((sender) =>
            {
                SignIn signIn = new SignIn();


                if (MainWindow.MyGrid.Children.Count != 0)
                {
                    MainWindow.MyGrid.Children.RemoveAt(MainWindow.MyGrid.Children.Count - 1);
                }

                MainWindow.MyGrid.Children.Add(signIn);

            });
            PassToSignUp = new RelayCommand((sender) =>
            {
                UserControl1 signUp = new UserControl1();


                if (MainWindow.MyGrid.Children.Count != 0)
                {
                    MainWindow.MyGrid.Children.RemoveAt(MainWindow.MyGrid.Children.Count - 1);
                }

                MainWindow.MyGrid.Children.Add(signUp);

            });
        }


    }

}



