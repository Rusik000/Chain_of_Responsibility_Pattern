using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : UserControl
    {
        public SignIn()
        {
            InitializeComponent();
            
        }      

        private void UsernameTxtBx_MouseEnter(object sender, MouseEventArgs e)
        {

            if (UsernameTxtBx.Text == "Username")
            {
                UsernameTxtBx.Text = null;
                Color color1 = new Color();
                color1 = Color.FromArgb(255, 37, 191, 191);

                UsernameTxtBx.Foreground = new SolidColorBrush(color1);
            }
        }

        private void UsernameTxtBx_MouseLeave(object sender, MouseEventArgs e)
        {

            if (UsernameTxtBx.Text == "")
            {

                Color color2 = new Color();
                color2 = Color.FromArgb(255, 110, 127, 128);

                UsernameTxtBx.Text = "Username";
                UsernameTxtBx.Foreground = new SolidColorBrush(color2);
            }
        }

        private void PasswordTxtBx_MouseEnter(object sender, MouseEventArgs e)
        {
            if (PasswordTxtBx.Text == "Password")
            {
                PasswordTxtBx.Text = null;



                Color color1 = new Color();
                color1 = Color.FromArgb(255, 37, 191, 191);

                PasswordTxtBx.Foreground = new SolidColorBrush(color1);
            }
        }

        private void PasswordTxtBx_MouseLeave(object sender, MouseEventArgs e)
        {
            if (PasswordTxtBx.Text == "")
            {

                Color color2 = new Color();
                color2 = Color.FromArgb(255, 110, 127, 128);

                PasswordTxtBx.Text = "Password";
                PasswordTxtBx.Foreground = new SolidColorBrush(color2);
            }
        }
    }
}
