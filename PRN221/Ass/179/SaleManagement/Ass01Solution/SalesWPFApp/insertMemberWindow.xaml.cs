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
    /// Interaction logic for insertMemberWindow.xaml
    /// </summary>
    public partial class insertMemberWindow : Window
    {
        IMemberRepository memberRepository;
        WindowManagerMembers windowManagerMembers;
        public insertMemberWindow(IMemberRepository repository,WindowManagerMembers wmm)
        {
            InitializeComponent();
            memberRepository = repository;
            windowManagerMembers = wmm;
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

        private bool blankInput()
        {
            if (txtMemberId.Text.Length < 1 || txtCompanyName.Text.Length < 1 || txtCity.Text.Length < 1
                || txtCountry.Text.Length < 1 || txtPassword.Text.Length < 1 || txtEmail.Text.Length < 1 ) return false;
            return true;
        }

        

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                

                if (!blankInput())
                {
                    MessageBox.Show("Blank input", "Insert Member");
                    return;
                }
                Member member = GetMemberObjects();
                memberRepository.InsertMember(member);
                this.Close();
                windowManagerMembers.LoadMemberList();
                MessageBox.Show($"{member.Email} inserted successfully ", "Insert car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert car");
            }
        }
    }
}
