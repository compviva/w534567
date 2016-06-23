using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeck_tic_toe
{
    public partial class Tic_tak_Toe : Form
    {
        bool turn = true; //true = X true; false = Y turn
        int turn_count = 0;

        public Tic_tak_Toe()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Create By Vitalii", "Tic Tak Toe About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            turn_count++;

            checkForWinner();
        }

        private void checkForWinner()
        {
            bool there_is_a_winner = false;

            //horezontel checks
            if ((A11.Text == A22.Text) && (A22.Text == A33.Text) && (!A11.Enabled))
                there_is_a_winner = true;
            else if ((B11.Text == B22.Text) && (B22.Text == B33.Text) && (!B11.Enabled))
                there_is_a_winner = true;
            else if ((C11.Text == C22.Text) && (C22.Text == C33.Text) && (!C11.Enabled))
                there_is_a_winner = true;

            //verical checks
            if ((A11.Text == B11.Text) && (B11.Text == C11.Text) && (!A11.Enabled))
                there_is_a_winner = true;
            else if ((A22.Text == B22.Text) && (B22.Text == C22.Text) && (!A22.Enabled))
                there_is_a_winner = true;
            else if ((A33.Text == B33.Text) && (B33.Text == C33.Text) && (!A33.Enabled))
                there_is_a_winner = true;

            //diaganal checks

            else if ((A11.Text == B22.Text) && (B22.Text == C33.Text) && (!A11.Enabled))
                there_is_a_winner = true;
            else if ((A33.Text == B22.Text) && (B22.Text == C11.Text) && (!C11.Enabled))
                there_is_a_winner = true;


            if (there_is_a_winner)
            {
                disableButtons();

                String winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";

                MessageBox.Show(winner + " Wins!", "YAy!");
            }  // end if 
            else
            {
                if (turn_count == 9)
                    MessageBox.Show("Draw!", "Bummer!");

            }



        }//koniec sprawdzanie wygrawania

        private void disableButtons()
        {
            try
            {

                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }///end try
            }
            catch { }
        }

        private void newGamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            try
            {

                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }//end foreach
            }//end try
            catch { }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Create By Vitalii Smetaniak, Marcin Poździk, Maksym Lukianets", "Tic Tak Toe About");
            about ab = new about();
            ab.Show();
            this.Hide();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Tic_tak_Toe",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question)
             == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void Tic_tak_Toe_Load(object sender, EventArgs e)
        {

        }

    }
    }