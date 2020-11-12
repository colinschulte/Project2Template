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

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //UI Validation TBI
            int genreID = Convert.ToInt32(txtID.Text.Trim());
            try
            {
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
                MessageBox.Show(ex.Message);            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //UI Validation TBI
            List<Genre> myGenreList = new List<Genre>();
            myGenreList = GenreDB.GetGenres();
            dataGridView1.DataSource = myGenreList;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}
