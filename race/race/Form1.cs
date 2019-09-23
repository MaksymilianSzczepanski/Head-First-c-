using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace race
{
    public partial class Form1 : Form
    {
        Greyhound[] GreyhoundArray = new Greyhound[4];
        Guy[] GuyArray = new Guy[3];
        Random randomize = new Random();

       
        public Form1()
        {
            InitializeComponent();
            GreyhoundArray[0] = new Greyhound()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox2.Width,
                MyRandom = randomize
            };
            GreyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox3.Width,
                MyRandom = randomize
            };
            GreyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox4.Width,
                MyRandom = randomize
            };
            GreyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = pictureBox5,
                StartingPosition = pictureBox5.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox5.Width,
                MyRandom = randomize
            };

            GuyArray[0] = new Guy() { Name = "Janek", Cash = 50, MyRadioButton = JanekRadioButton, MyLabel = JanekLabel };
            GuyArray[1] = new Guy() { Name = "Bartek", Cash = 75, MyRadioButton = BartekRadioButton, MyLabel = BartekLabel };
            GuyArray[2] = new Guy() { Name = "Arek", Cash = 45, MyRadioButton = ArekRadioButton, MyLabel = ArekLabel, };

            minimumBetLabel.Text = "Minimalny zakład: " + numericUpDown1.Minimum + " zł";

            foreach (Guy guy in GuyArray)
            {
                guy.UpdateLabels();
            }

            numericUpDown2.Maximum = GreyhoundArray.Length;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        public void restGreyhound()
        {
            for (int i = 0; i < GreyhoundArray.Length; i++)
            {
                GreyhoundArray[i].TakeStartingPosition();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int winningDog = 0;
            for (int i = 0; i < GreyhoundArray.Length; i++)
            {
                if (GreyhoundArray[i].Run())
                {
                    winningDog = i + 1;
                    timer1.Stop();
                    MessageBox.Show("Mamy zwycięzce" + (i+1) + " pies");
                    foreach (Guy guy in GuyArray)
                    {
                        if (guy.MyBet != null)
                        {
                            guy.Collect(winningDog);
                            guy.MyBet = null;
                            guy.UpdateLabels();
                        }
                    }
                    restGreyhound();
                    button1.Enabled = true;
                    break;
                }
            }
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();

            button1.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int chaketGuy = 0;

            if (JanekRadioButton.Checked)
                chaketGuy = 0;
            else if (BartekRadioButton.Checked)
                chaketGuy = 1;
            else
                chaketGuy = 2;
            GuyArray[chaketGuy].PlaceBet((int) numericUpDown1.Value, (int) numericUpDown2.Value);
            GuyArray[chaketGuy].UpdateLabels();
        }

        private void JanekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = GuyArray[0].Name;
        }

        private void BartekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = GuyArray[1].Name;
        }

        private void ArekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = GuyArray[2].Name;
        }
    }
}
