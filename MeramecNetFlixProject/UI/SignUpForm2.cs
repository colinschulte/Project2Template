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
    public partial class SignUpForm2 : Form
    {
        public SignUpForm2()
        {
            InitializeComponent();
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!(validateUI(btnSubmit)))
            {
                return;
            }

            try
            {
                Member newMember = new Member();
                newMember.member_status = "A";
                int newMemberNumber = 1;
                bool isValidKey = true;
                while (isValidKey == true)
                {
                    Member testMember = MemberDB.GetMember(newMemberNumber);
                    if (testMember == null)
                    {
                        isValidKey = false;
                    }
                    else
                    {
                        newMemberNumber++;
                    }
                }
                newMember.member_number = newMemberNumber;
                newMember.firstname = SignUpForm.newMemberFirstName;
                newMember.lastname = SignUpForm.newMemberLastName;
                newMember.email = SignUpForm.newMemberEmail;
                newMember.cell_phone = SignUpForm.newMemberCellPhone;
                newMember.zipcode = SignUpForm.newMemberZipCode;
                newMember.joindate = DateTime.Now;
                newMember.username = txtUsername.Text.Trim();
                newMember.password = txtPassword.Text.Trim();
                bool status = MemberDB.AddMember(newMember);
                if (status) //returns true
                {
                    MessageBox.Show("Sign Up Successful, Welcome " + newMember.firstname + "!", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new RentalSearchForm(newMember.member_number).Show();
                }
                else //returns false
                {
                    MessageBox.Show("Member was not added to the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool validateUI(Button myButton)
        {
            bool isValid = true;
            
            if(txtUsername.Text.Trim() == null || txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a Username", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isValid = false;
            }
                char[] symbols = "!@#$%^&*".ToCharArray();
            //if password field is not empty
            if (txtPassword.Text.Trim() != null)
            {
                //starts with a letter or number
                if (char.IsLetterOrDigit(txtPassword.Text[0]))
                {
                    //is between 8 and 64 chars
                    if(txtPassword.Text.Length >= 8 && txtPassword.Text.Length <=64)
                    {
                        //has upper and lowercase letters
                        if(txtPassword.Text.Any(char.IsUpper) && txtPassword.Text.Any(char.IsLower))
                        {
                            //has numbers
                            if (txtPassword.Text.Any(char.IsDigit))
                            {
                                //has symbols                               
                                if (txtPassword.Text.IndexOfAny(symbols) != -1)
                                {
                                    //matches verifypassword box
                                    if(txtPassword.Text.Trim() == txtVerifyPass.Text.Trim())
                                    {

                                    }
                                    else
                                    {
                                        MessageBox.Show("Please enter a valid password", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        isValid = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Password must contain at least one of these symbols ! @ # $ % ^ & *", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    isValid = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Passwprd must contain at least one number", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                isValid = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Password must contain both upper and lowercase letters", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            isValid = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password must be between 8 and 64 characters long", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isValid = false;
                    }
                }
                else
                {
                    MessageBox.Show("Password must start with a letter or number", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid password", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isValid = false;
            }

            return isValid;
        }
    }
}
