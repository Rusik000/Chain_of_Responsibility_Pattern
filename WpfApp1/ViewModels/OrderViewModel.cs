using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfApp1.Chain_of_Responsibility_Pattern;
using WpfApp1.Command;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public Order OrderWindow { get; set; }


        public SignIn SignInWindow { get; set; }
        public RelayCommand SelecetItem { get; set; }


        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged(); }
        }


        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<User> newUsers { get; set; }



        string stepsofChain = "Order Chain";
        public OrderViewModel()
        {
            Products = new ObservableCollection<Product>()
            {

            new Product()
            {
                Name = "Cola",
                Company = "Coca-Cola",
                Price = 3.60,
                ImagePath = "../Images/Cola.JPG"
            },

            new Product
            {
                Name = "Cipsi",
                Company = "Lays",
                Price = 2.20,
                ImagePath = "../Images/Lays.JPG"
            },

            new Product
            {
                Name = "Bizon",
                Company = "Bizon",
                Price = 1.20,
                ImagePath = "../Images/Bizon.JPG"
            },

           new Product
            {
                Name = "Snickers",
                Company = "Mars, Incorporated",
                Price = 1.60,
                ImagePath = "../Images/Snickers.JPG"
            }
        };


            SelecetItem = new RelayCommand((sender) =>
            {
                Users = Deserialize();
                IChain chain = new SingUp_Chain();
                IChain chain2 = new SingIn_Chain();
                IChain chain3 = new Order_Chain();

                chain.SetNextChain(chain2);
                chain2.SetNextChain(chain3);


                User User = new User(stepsofChain);
                chain3.User_if_else(User);
                MessageBox.Show("Your Order is accepted", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Information);

            });
        }


        public ObservableCollection<User> Deserialize()
        {

            var serializer = new JsonSerializer();

            using (var sr = new StreamReader("User.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    newUsers = serializer.Deserialize<ObservableCollection<User>>(jr);
                }
            }

            return newUsers;
        }

    }
}
