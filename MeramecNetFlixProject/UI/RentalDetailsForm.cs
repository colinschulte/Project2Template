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
    public partial class RentalDetailsForm : Form
    {
        public RentalDetailsForm(int memberID, int movieID)
        {
            InitializeComponent();
            Member currentMember = MemberDB.GetMember(memberID);
            Movie currentMovie = MovieDB.GetMovie(movieID);
            label1.Text = "Hello " + currentMember.firstname;
            lblTitle.Text = currentMovie.movie_title;
            lblRating.Text = currentMovie.movie_rating;
            lblYear.Text = currentMovie.movie_year_made.ToString();
            richTextBox1.Text = currentMovie.description;
            //axWindowsMediaPlayer1.URL = currentMovie.trailer;
            //this.BackgroundImage = ;
            string html = "<html><head>";
            html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
            html += "<iframe id='video' src= " + currentMovie.trailer + " width='400' height='200' frameborder='0' allowfullscreen></iframe>";
            html += "</body></html>";
            webBrowser1.DocumentText = string.Format(html);
            //webBrowser1.Url = new Uri(currentMovie.trailer);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            //TODO Add Rental to Database
            Rental newRental = new Rental();
            newRental.movie_number = ;
            newRental.member_number = ;
            newRental.media_purchase_date = ;
        }

        private void btnTrailer_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
