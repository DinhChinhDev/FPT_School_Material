using BusinessObject.Models;
using BusinessObject.Repository;
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
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowManagerMembers.xaml
    /// </summary>
    public partial class WindowManagerMembers : Window
    {
        IMemberRepository memberRepository;
        bool checkAdmin;
        public WindowManagerMembers(IMemberRepository repository)
        {
            InitializeComponent();
            memberRepository = repository;
        }

        public void LoadMemberList()
        {
            lvMembers.ItemsSource = memberRepository.GetMembers();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            insertMemberWindow insertMemberWindow = new insertMemberWindow(memberRepository,this);
            insertMemberWindow.Show();
        }

        private bool blankInput()
        {
            if (txtMemberId.Text.Length < 1 || txtCompanyName.Text.Length < 1 || txtCity.Text.Length < 1
                || txtCountry.Text.Length < 1 || txtPassword.Text.Length < 1 || txtEmail.Text.Length < 1) return false;
            return true;
        }
        private Member GetMemberObjects()
        {
            Member member = null;
            try
            {
                member = new Member
                {
                    MemberId = int.Parse(txtMemberId.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Member");
            }

            return member;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (!blankInput())
                {
                    MessageBox.Show("Blank input", "Update Member");
                    return;
                }
                Member member = GetMemberObjects();
                UpdateMemberWindow updateMemberWindow = new UpdateMemberWindow(memberRepository, this,member);
                updateMemberWindow.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Member");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!blankInput())
                {
                    MessageBox.Show("Blank input", "Insert Member");
                    return;
                }
                var myContextDB = new PRN221_As01Context();

                Member member = GetMemberObjects();
                List<Order> orders = new List<Order>();
                orders = myContextDB.Orders.Where(item => item.MemberId == member.MemberId).ToList();
                if (orders.Count != 0)
                {
                    MessageBox.Show($"{member.Email} had order , can't delete member", "Delete Member");
                }
                else
                {
                    memberRepository.DeleteMember(member);
                    this.LoadMemberList();
                    MessageBox.Show($"{member.Email} deleted successfully ", "Delete Member");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Member");
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var lstMember = memberRepository.GetMembers().ToList();
            var memberId = String.IsNullOrEmpty(txtMemberId.Text) == true ? "" : txtMemberId.Text;
            var email = String.IsNullOrEmpty(txtEmail.Text) == true ? "" : txtEmail.Text;
            var company = String.IsNullOrEmpty(txtCompanyName.Text) == true ? "" : txtCompanyName.Text;
            var city = String.IsNullOrEmpty(txtCity.Text) == true ? "" : txtCity.Text;
            var country = String.IsNullOrEmpty(txtCountry.Text) == true ? "" : txtCountry.Text;

            lstMember = lstMember.Where(x => x.Email.ToLower().Contains(email.ToLower())
               && x.CompanyName.ToLower().Contains(company.ToLower())
               && x.City.ToLower().Contains(city.ToLower())
               && x.Country.ToLower().Contains(country.ToLower())
               ).ToList();
            lvMembers.ItemsSource = lstMember;
        }



        private void btnMember_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(memberRepository);
            mainWindow.Show();
            this.Close();
        }


        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            IOrderRepository orderRepository = new OrderRepository();
            var managerOrderWindow = new ManagerOrderWindow(orderRepository);
            managerOrderWindow.Show();
            this.Close();
            managerOrderWindow.LoadOrderList();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            IProductRepository productRepository = new ProductRepository();
            var windowProducts = new ManagerProductWindow(productRepository);
            windowProducts.Show();
            this.Close();
            windowProducts.LoadProductList();
        }




    }
}
