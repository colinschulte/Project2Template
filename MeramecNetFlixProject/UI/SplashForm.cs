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
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
            
        }
        private void SplashForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            new WelcomeForm().Show();
            this.Hide();
        }
    }
}
