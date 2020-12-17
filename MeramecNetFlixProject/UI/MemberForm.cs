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
using MeramecNetFlixProject.Data_Access_Layer;

namespace MeramecNetFlixProject.UI
{
    public partial class MemberForm : Form
    {
        public MemberForm()
        {
            InitializeComponent();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!(validateUI(btnAdd)))
            {
                return;
            }

            try
            {
                Member myMember = new Member();
                if(radioButton1.Checked)
                {
                    myMember.member_status = "A";
                }
                if (radioButton2.Checked)
                {
                    myMember.member_status = "I";
                }
                myMember.member_number = Convert.ToInt32(txtMemberNumber.Text.Trim());
                myMember.joindate = Convert.ToDateTime(txtJoinDate.Text.Trim());
                myMember.firstname = txtFirstName.Text.Trim();
                myMember.lastname = txtLastName.Text.Trim();
                myMember.zipcode = txtZipCode.Text.Trim();
                myMember.cell_phone = txtCellPhone.Text.Trim();
                myMember.username = txtUsername.Text.Trim();
                myMember.password = txtPassword.Text.Trim();
                myMember.email = txtEmail.Text.Trim();

                bool status = MemberDB.AddMember(myMember);
                if (status) //returns true
                {
                    MessageBox.Show("Member added to the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Automatically refresh the data grid
                    this.btnBrowse_Click(null, null);
                }
                else //returns false
                {
                    MessageBox.Show("Member was not added to the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Automatically refresh the data grid
                    this.btnBrowse_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                List<Member> myMemberList = new List<Member>();
                myMemberList = MemberDB.GetMembers();
                dataGridView1.DataSource = myMemberList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!(validateUI(btnUpdate)))
            {
                return;
            }

            try
            {
                Member myMember = new Member();
                if (radioButton1.Checked)
                {
                    myMember.member_status = "A";
                }
                if (radioButton2.Checked)
                {
                    myMember.member_status = "I";
                }
                myMember.member_number = Convert.ToInt32(txtMemberNumber.Text.Trim());
                myMember.joindate = Convert.ToDateTime(txtJoinDate.Text.Trim());
                myMember.firstname = txtFirstName.Text.Trim();
                myMember.lastname = txtLastName.Text.Trim();
                myMember.zipcode = txtZipCode.Text.Trim();
                myMember.cell_phone = txtCellPhone.Text.Trim();
                myMember.username = txtUsername.Text.Trim();
                myMember.password = txtPassword.Text.Trim();
                myMember.email = txtEmail.Text.Trim();

                bool status = MemberDB.UpdateMember(myMember);
                if (status) //returns true
                {
                    MessageBox.Show("Member has been updated in the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Automatically refresh the data grid
                    this.btnBrowse_Click(null, null);
                }
                else //returns false
                {
                    MessageBox.Show("Member was not updated in the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!(validateUI(btnDelete)))
            {
                return;
            }

            try
            {
                Member myMember = new Member();
                myMember.member_status = "A";
                myMember.member_number = Convert.ToInt32(txtMemberNumber.Text.Trim());
                myMember.joindate = Convert.ToDateTime(txtJoinDate.Text.Trim());
                myMember.firstname = txtFirstName.Text.Trim();
                myMember.lastname = txtLastName.Text.Trim();
                myMember.zipcode = txtZipCode.Text.Trim();
                myMember.cell_phone = txtCellPhone.Text.Trim();
                myMember.username = txtUsername.Text.Trim();
                myMember.password = txtPassword.Text.Trim();
                myMember.email = txtEmail.Text.Trim();

                bool status = MemberDB.DeleteMember(myMember);
                if (status) //returns true
                {
                    MessageBox.Show("Member ID has been deleted from the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Automatically refresh the data grid
                    this.btnBrowse_Click(null, null);

                }
                else //returns false
                {
                    MessageBox.Show("Member ID was not deleted from the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearUI();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUI(Button myButton)
        {
            bool isValid = true;
            //Only validate the Member ID field for finding or deleting a record
            if (myButton.Name.Equals("btnFind") || myButton.Name.Equals("btnDelete"))
            {
                if (string.IsNullOrEmpty(txtMemberNumber.Text.Trim()))
                {
                    MessageBox.Show("Please enter a Member id.");
                    txtMemberNumber.Focus();
                    isValid = false;
                }
            }
            else //Validate all fields for adding or updating a record
            {
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    MessageBox.Show("Please select a member status.");
                    txtFirstName.Focus();
                    isValid = false;
                }
                if (string.IsNullOrEmpty(txtMemberNumber.Text.Trim()))
                {
                    MessageBox.Show("Please enter a member id.");
                    txtMemberNumber.Focus();
                    isValid = false;
                }
                if (string.IsNullOrEmpty(txtJoinDate.Text.Trim()))
                {
                    MessageBox.Show("Please enter a join date.");
                    txtFirstName.Focus();
                    isValid = false;
                }
                if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
                {
                    MessageBox.Show("Please enter a first name.");
                    txtFirstName.Focus();
                    isValid = false;
                }
                if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
                {
                    MessageBox.Show("Please enter a last name.");
                    txtFirstName.Focus();
                    isValid = false;
                }
                if (string.IsNullOrEmpty(txtZipCode.Text.Trim()))
                {
                    MessageBox.Show("Please enter a zip code.");
                    txtFirstName.Focus();
                    isValid = false;
                }
                if (string.IsNullOrEmpty(txtCellPhone.Text.Trim()))
                {
                    MessageBox.Show("Please enter a phone number.");
                    txtFirstName.Focus();
                    isValid = false;
                }
                if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
                {
                    MessageBox.Show("Please enter a username.");
                    txtFirstName.Focus();
                    isValid = false;
                }
                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    MessageBox.Show("Please enter a password.");
                    txtFirstName.Focus();
                    isValid = false;
                }
                if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Please enter an email address.");
                    txtFirstName.Focus();
                    isValid = false;
                }             
            }
            return isValid;
        }
        private void clearUI()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtMemberNumber.Text = "";
            txtMemberNumber.ReadOnly = false;
            txtJoinDate.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtZipCode.Text = "";
            txtCellPhone.Text = "";
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            dataGridView1.DataSource = null;
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if(dataGridView1.SelectedRows[0].Cells[0].Value.ToString() == "A")
                {
                    radioButton1.Checked = true;
                }
                if (dataGridView1.SelectedRows[0].Cells[0].Value.ToString() == "I")
                {
                    radioButton2.Checked = true;
                }
                txtMemberNumber.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtJoinDate.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtFirstName.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtLastName.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txtZipCode.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txtCellPhone.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                txtUsername.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                txtPassword.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                if (dataGridView1.SelectedRows[0].Cells[9].Value != null)
                {
                    txtEmail.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                }
                else
                {
                    txtEmail.Text = "";
                }
            }
        }
    }
}
