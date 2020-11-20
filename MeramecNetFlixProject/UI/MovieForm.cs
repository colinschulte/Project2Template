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
    public partial class MovieForm : Form
    {
        public MovieForm()
        {
            InitializeComponent();
            cmbGenre.DataSource = GenreDB.GetGenres();
            cmbGenre.DisplayMember = "name";
            cmbGenre.SelectedIndex = -1;
            cmbGenre.Text = "--Select--";
            cmbMovieRating.Text = "--Select--";
            cmbRentalDuration.Text = "--Select--";
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!(validateUI(btnAdd)))
            {
                return;
            }

            try
            {
                Movie myMovie = new Movie();
                myMovie.movie_number = Convert.ToInt32(txtMovieNumber.Text.Trim());
                myMovie.movie_title = txtMovieTitle.Text.Trim();
                myMovie.description = rtbDescription.Text.Trim();
                myMovie.movie_year_made = Convert.ToInt32(txtMovieYearMade.Text.Trim());
                myMovie.genre_id = cmbGenre.SelectedIndex;
                myMovie.movie_rating = cmbMovieRating.Text.Trim();
                myMovie.image = txtImage.Text.Trim();
                myMovie.rental_duration = cmbRentalDuration.SelectedIndex;
                myMovie.trailer = txtTrailer.Text.Trim();

                bool status = MovieDB.AddMovie(myMovie);
                if (status) //returns true
                {
                    MessageBox.Show("Movie added to the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Automatically refresh the data grid
                    this.btnBrowse_Click(null, null);
                }
                else //returns false
                {
                    MessageBox.Show("Movie was not added to the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                int movieID = Convert.ToInt32(txtMovieNumber.Text.Trim());             
                Movie objMovie = MovieDB.GetMovie(movieID);
                if (objMovie != null)
                {
                    txtMovieTitle.Text = objMovie.movie_title;
                    txtMovieNumber.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show($"Movie ID " + txtMovieNumber.Text + "  not found in database.", "MeremacNetflix", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                List<Movie> myMovieList = new List<Movie>();
                myMovieList = MovieDB.GetMovies();
                dataGridView1.DataSource = myMovieList;
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
                Movie myMovie = new Movie();
                myMovie.movie_number = Convert.ToInt32(txtMovieNumber.Text.Trim());
                myMovie.movie_title = txtMovieTitle.Text.Trim();
                myMovie.description = rtbDescription.Text.Trim();
                myMovie.movie_year_made = Convert.ToInt32(txtMovieYearMade.Text.Trim());
                myMovie.genre_id = cmbGenre.SelectedIndex;
                myMovie.movie_rating = cmbMovieRating.Text.Trim();
                myMovie.image = txtImage.Text.Trim();
                myMovie.rental_duration = cmbRentalDuration.SelectedIndex;
                myMovie.trailer = txtTrailer.Text.Trim();

                bool status = MovieDB.UpdateMovie(myMovie);
                if (status) //returns true
                {
                    MessageBox.Show("Movie ID has been updated in the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Automatically refresh the data grid
                    this.btnBrowse_Click(null, null);
                }
                else //returns false
                {
                    MessageBox.Show("Movie ID was not update in the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Movie myMovie = new Movie();
                myMovie.movie_number = Convert.ToInt32(txtMovieNumber.Text.Trim());
                myMovie.movie_title = txtMovieTitle.Text.Trim();
                myMovie.description = rtbDescription.Text.Trim();
                myMovie.movie_year_made = Convert.ToInt32(txtMovieYearMade.Text.Trim());
                myMovie.genre_id = cmbGenre.SelectedIndex;
                myMovie.movie_rating = cmbMovieRating.Text.Trim();
                myMovie.image = txtImage.Text.Trim();
                myMovie.rental_duration = cmbRentalDuration.SelectedIndex;
                myMovie.trailer = txtTrailer.Text.Trim();

                bool status = MovieDB.DeleteMovie(myMovie);
                if (status) //returns true
                {
                    MessageBox.Show("Movie ID has been deleted from the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Automatically refresh the data grid
                    this.btnBrowse_Click(null, null);

                }
                else //returns false
                {
                    MessageBox.Show("Movie ID was not deleted from the database.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //Only validate the Movie ID field for finding or deleting a record
            if (myButton.Name.Equals("btnFind") || myButton.Name.Equals("btnDelete"))
            {
                if (string.IsNullOrEmpty(txtMovieNumber.Text.Trim()))
                {
                    MessageBox.Show("Please enter a Movie id.");
                    txtMovieNumber.Focus();
                    isValid = false;
                }
            }
            else //Validate both the Movie ID and Name for adding or updating a record
            {
                if (string.IsNullOrEmpty(txtMovieNumber.Text.Trim()))
                {
                    MessageBox.Show("Please enter a Movie id.");
                    txtMovieNumber.Focus();
                    isValid = false;
                }
                if (string.IsNullOrEmpty(txtMovieTitle.Text.Trim()))
                {
                    MessageBox.Show("Please enter a Movie name.");
                    txtMovieTitle.Focus();
                    isValid = false;
                }
            }
            return isValid;
        }
        private void clearUI()
        {
            txtMovieNumber.Text = String.Empty;
            txtMovieNumber.ReadOnly = false;
            txtMovieTitle.Text = String.Empty;
            rtbDescription.Text = "";
            txtMovieYearMade.Text = "";
            cmbGenre.SelectedIndex = -1;
            cmbGenre.Text = "--Select--";
            cmbMovieRating.SelectedIndex = -1;
            cmbMovieRating.Text = "--Select--";
            txtImage.Text = "";
            cmbRentalDuration.SelectedIndex = -1;
            cmbRentalDuration.Text = "--Select--";
            txtTrailer.Text = "";
            dataGridView1.DataSource = null;
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtMovieNumber.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtMovieTitle.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                rtbDescription.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtMovieYearMade.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                cmbGenre.SelectedIndex = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value);
                //TODO: get movie rating working
                cmbMovieRating.SelectedItem = dataGridView1.SelectedRows[0].Cells[5].Value;
                if (dataGridView1.SelectedRows[0].Cells[6].Value != null)
                {
                    txtImage.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                }
                else
                {
                    txtImage.Text = "";
                }
                if (dataGridView1.SelectedRows[0].Cells[7].Value != null)
                {
                    cmbRentalDuration.SelectedIndex = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[7].Value);
                }
                else
                {
                    cmbRentalDuration.SelectedIndex = -1;
                }
                if (dataGridView1.SelectedRows[0].Cells[8].Value != null)
                {
                    txtTrailer.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                }
                else
                {
                    txtTrailer.Text = "";
                }
            }
        }
        private void MovieForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("In order to run this demo, please update your SQL Server connection string in the MovieDB Data Access Layer GetConnectionString method.", "MeramecNetFlix", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
