using BusinessObject.Models;
using BusinessObject.Repository;
using Microsoft.Extensions.Configuration;
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

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IMemberRepository memberRepository = new MemberRepository();

        public MainWindow(IMemberRepository repository)
        {
            InitializeComponent();
            memberRepository = repository;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            string adminEmail = config["Admin:Email"];
            string adminPassword = config["Admin:Password"];
            bool checkAdmin = false;
            string user = email.Text;
            string password = pass.Password;
            if (user.Equals(adminEmail) && password.Equals(adminPassword))
            {
                checkAdmin = true;
                var windowMembers = new WindowManagerMembers(memberRepository);
                windowMembers.Show();
                this.Close();
                windowMembers.LoadMemberList();
            }
            else
            {
                OrderRepository orderRepository = new OrderRepository();
                MemberRepository mr = new MemberRepository();
                Member member = mr.GetMemberByUserPass(user, password);
                if (member != null)
                {
                    var managerOrderCustomerWindow = new ManagerOrderCustomerWindow(orderRepository, member);
                    managerOrderCustomerWindow.Show();
                    this.Close();
                    managerOrderCustomerWindow.LoadOrderList();
                }
                else
                {
                    MessageBox.Show("Login Fail");
                }
            }
            
        }
    }
}
