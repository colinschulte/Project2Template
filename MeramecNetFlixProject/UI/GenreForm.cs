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
    public partial class GenreForm : Form
    {
        public GenreForm()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!(validateUI(btnAdd)))
            {
                return;
            }

            try
            {
                Genre myGenre = new Genre();
                myGenre.id = txtID.Text.Trim();
                myGenre.name = txtName.Text.Trim();

                bool status = GenreDB.AddGenre(myGenre);
                if (status) //returns true
                {
                    MessageBox.Show("Genre added to the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Automatically refresh the data grid
                    this.btnBrowse_Click(null, null);
                }
                else //returns false
                {
                    MessageBox.Show("Genre was not added to the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Automatically refresh the data grid
                    this.btnBrowse_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!(validateUI(btnFind)))
            {
                return;
            }

            try
            {
                int genreID = Convert.ToInt32(txtID.Text.Trim());             
                Genre objGenre = GenreDB.GetGenre(genreID);
                if (objGenre != null)
                {
                    txtName.Text = objGenre.name;
                    txtID.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show($"Genre ID(txtID.Text) not found in database.", "MeremacNetflix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (!(validateUI(btnBrowse)))
            {
                return;
            }

            try
            {
                List<Genre> myGenreList = new List<Genre>();
                myGenreList = GenreDB.GetGenres();
                dataGridView1.DataSource = myGenreList;
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
                Genre myGenre = new Genre();
                myGenre.id = txtID.Text.Trim();
                myGenre.name = txtName.Text.Trim();

                bool status = GenreDB.UpdateGenre(myGenre);
                if (status) //returns true
                {
                    MessageBox.Show("Genre ID has been updated in the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Automatically refresh the data grid
                    this.btnBrowse_Click(null, null);
                }
                else //returns false
                {
                    MessageBox.Show("Genre ID was not update in the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Genre myGenre = new Genre();
                myGenre.id = txtID.Text.Trim();
                myGenre.name = txtName.Text.Trim();

                bool status = GenreDB.DeleteGenre(myGenre);
                if (status) //returns true
                {
                    MessageBox.Show("Genre ID has been deleted from the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Automatically refresh the data grid
                    this.btnBrowse_Click(null, null);

                }
                else //returns false
                {
                    MessageBox.Show("Genre ID was not deleted from the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //Only validate the Genre ID field for finding or deleting a record
            if (myButton.Name.Equals("btnFind") || myButton.Name.Equals("btnDelete"))
            {
                if (string.IsNullOrEmpty(txtID.Text.Trim()))
                {
                    MessageBox.Show("Please enter a genre id.");
                    txtID.Focus();
                    isValid = false;
                }
            }
            else //Validate both the Genre ID and Name for adding or updating a record
            {
                if (string.IsNullOrEmpty(txtID.Text.Trim()))
                {
                    MessageBox.Show("Please enter a genre id.");
                    txtID.Focus();
                    isValid = false;
                }
                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    MessageBox.Show("Please enter a genre name.");
                    txtName.Focus();
                    isValid = false;
                }
            }
            return isValid;
        }
        private void clearUI()
        {
            txtID.Text = String.Empty;
            txtID.ReadOnly = false;
            txtName.Text = String.Empty;
            dataGridView1.DataSource = null;
        }
        private void GenreForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("In order to run this demo, please update your SQL Server connection string in the GenreDB Data Access Layer GetConnectionString method.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
