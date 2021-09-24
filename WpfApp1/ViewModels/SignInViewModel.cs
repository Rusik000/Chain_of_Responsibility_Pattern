using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfApp1.Command;

namespace WpfApp1.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public SignIn SignWindow { get; set; }

        public RelayCommand MouseEnterUsername { get; set; }

        public RelayCommand MouseLeaveUsername { get; set; }
        public RelayCommand MouseEnterPassword { get; set; }
        public RelayCommand MouseLeavePassword { get; set; }

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



    }
}
