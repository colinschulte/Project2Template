using MeramecNetFlixProject.Business_Objects;
using MeramecNetFlixProject.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeramecNetFlixProject.UI
{
    public partial class RentalSearchForm : Form
    {
        class Global
        {
            public static int memberID;
        }
        public RentalSearchForm(int memberID)
        {
            InitializeComponent();
            Global.memberID = memberID;
            Member currentMember = MemberDB.GetMember(memberID);
            lblName.Text = "Hello " + currentMember.firstname;
            List<Movie> myMovieList = MovieDB.GetMovies();
            List<PictureBox> pixBoxes = new List<PictureBox>();
            pixBoxes.Add(pictureBox7);
            pixBoxes.Add(pictureBox8);
            pixBoxes.Add(pictureBox9);
            pixBoxes.Add(pictureBox10);
            imageList1.ImageSize = new Size(32, 32);
            for(int i = 0; i < pixBoxes.Count; i++)
            {
                pixBoxes[i].Load(myMovieList[i].image);
            }
            //foreach (Movie movie in myMovieList)
            //{
            //    pictureBox1.Load(movie.image);
            //    var newImage = Image.FromFile(@"C:\Users\pezhe\OneDrive\Documents\College Classes\C# II\In-Class Demos\Week 10\Project2Template_v2Fall2016\Project2Template\MeramecNetFlixProject\Resources\stlcc-icon-dark-blue.png");
            //    pictureBox1.Image = newImage;
            //    imageList1.Images.Add(newImage);
            //}
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            List<Movie> myMovieList = MovieDB.GetMovies();
            new RentalDetailsForm(Global.memberID, myMovieList[0].movie_number).Show();
        }
    }
}
