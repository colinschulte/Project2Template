using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeramecNetFlixProject.Business_Objects;

namespace MeramecNetFlixProject.UI
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        public static string newMemberFirstName = "";
        public static string newMemberLastName = "";
        public static string newMemberEmail = "";
        public static string newMemberCellPhone = "";
        public static string newMemberZipCode = "";

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!(validateUI(btnSubmit)))
            {
                return;
            }

            try
            {
                newMemberFirstName = txtFirstName.Text;
                newMemberLastName = txtLastName.Text;
                newMemberEmail = txtEmail.Text;
                newMemberCellPhone = txtPhone.Text;
                newMemberZipCode = txtZipCode.Text;
                new SignUpForm2().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            new WelcomeForm().Show();
            this.Hide();
        }

        private bool validateUI(Button myButton)
        {
            bool isValid = true;
            //TODO setup validation for signup
            return isValid;
        }
    }
}
