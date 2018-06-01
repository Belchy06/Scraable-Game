using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class frmSettings : Form
    {
         public frmSettings()
        {
            InitializeComponent();
            Dictionary.loadDictionary();
            frmGame.numberOfPlayers = 1;
            lblPlayers.Text = string.Format("Number of players: {0}", frmGame.numberOfPlayers);
        }


        private void btnMorePlayers_Click(object sender, EventArgs e)
        {
            if(frmGame.numberOfPlayers < 4)
            {
                frmGame.numberOfPlayers += 1;
                lblPlayers.Text = string.Format("Number of players: {0}", frmGame.numberOfPlayers);
            }          
        }

        private void btnLessPlayers_Click(object sender, EventArgs e)
        {
            if (frmGame.numberOfPlayers > 1)
            {
                frmGame.numberOfPlayers -= 1;
                lblPlayers.Text = string.Format("Number of players: {0}", frmGame.numberOfPlayers);
            } 
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGame frmGame = new frmGame();
            frmGame.Show();
        }
    }
}
