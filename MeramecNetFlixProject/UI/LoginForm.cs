using MeramecNetFlixProject.Business_Objects;
using MeramecNetFlixProject.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeramecNetFlixProject.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!(ValidateUI(BtnSubmit)))
            {
                return;
            }

            Member currentMember;
            try
            {                   
                currentMember = MemberDB.LoginMember(txtUsername.Text, txtPassword.Text);
                if (currentMember != null)
                {
                    new RentalSearchForm(currentMember.member_number).Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login failed, username and/or password incorrect", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
            
        }
        private bool ValidateUI(Button myButton)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Please enter a username.");
                isValid = false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Please enter a password.");
                isValid = false;
            }
            return isValid;
        }
    }
}
