using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBADraft
{
    public partial class Form1 : Form
    {
        //class level string variables so I dont have to type out whole things
        string boardpath = @"C:\Users\matth\Documents\OOP Semester1\NBADraft\CollegeDraftBoard.txt";
        string teampath1 = @"C:\Users\matth\Documents\OOP Semester1\NBADraft\Team1.txt";
        string teampath2 = @"C:\Users\matth\Documents\OOP Semester1\NBADraft\Team2.txt";

        //class level lists
        List<string> availablePlayers = new List<string>();
        List<string> teamOne = new List<string>();
        List<string> teamTwo = new List<string>();

        bool draftturn = true;


        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
          
           StreamReader sr = new StreamReader(boardpath);
           
            using (sr)
            {
                do
                {
                    availablePlayers.Add(sr.ReadLine());
                } while (!sr.EndOfStream);
            }

            updatePlayers();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            if(draftturn == true)
            {
                string player = comboBox1.Text;
                comboBox1.Text = "";
                teamOne.Add(player);
                availablePlayers.Remove(player);
                updatePlayers();
                StreamWriter sw1 = new StreamWriter(teampath1, true);
                sw1.WriteLine(player);
                sw1.Flush();
                sw1.Close();
                textBox1.Text = "";
                for (int i = 0; i < teamOne.Count; i++)
                {
                    textBox1.Text += teamOne[i] + Environment.NewLine;
                }
                draftturn = false;
            }

            else 
            {
                string player = comboBox1.Text;
                comboBox1.Text = "";
                teamTwo.Add(player);
                availablePlayers.Remove(player);
                updatePlayers();
                StreamWriter sw2 = new StreamWriter(teampath2, true);
                sw2.WriteLine(player);
                sw2.Flush();
                sw2.Close();
                textBox2.Text = "";
                for(int i = 0; i < teamTwo.Count; i++)
                {
                    textBox2.Text += teamTwo[i] + Environment.NewLine;
                }
                draftturn = true;
            }
        }

        public void updatePlayers()
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < availablePlayers.Count(); i++)
            {
                comboBox1.Items.Add(availablePlayers[i]);
            }
        }
    }
}
