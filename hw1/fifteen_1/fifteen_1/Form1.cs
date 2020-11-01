using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fifteen_1
{
    public partial class Form1 : Form
    {
        Button[,] fifteen_button = new Button[4, 4];
        int width_button = 80, height_button = 80;
        public void Shuffle()
        {
            int[,] fifteen = new int[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    fifteen[i, j] = i * 4 + j + 1;
            }

            for (int i = 3; i >= 0; i--)
            {
            Random numbers_random = new Random();
                for (int j = 3; j >= 0; j--)
                {
                    int RND1 = numbers_random.Next(i);
                    int RND2 = numbers_random.Next(j);
                    if (RND1 == 3 && RND2 == 3 || i == 3 && j == 3)
                        continue;
                    int temp = fifteen[i, j];
                    fifteen[i, j] = fifteen[RND1, RND2];
                    fifteen[RND1, RND2] = temp;
                }
            }

            Random color_random = new Random();
            int number; 

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    number = i * 4 + j + 1;
                    fifteen_button[i, j] = new Button();
                    fifteen_button[i, j].Name = "button" + number.ToString();
                    fifteen_button[i, j].Font = new Font("Microsoft Sans Serif", 15, FontStyle.Regular);
                    fifteen_button[i, j].Width = width_button;
                    fifteen_button[i, j].Height = height_button;
                    fifteen_button[i, j].Left = 1 + j % 4 * width_button;
                    fifteen_button[i, j].Top = 50 + i * height_button;
                    fifteen_button[i, j].TabIndex = j + 4 * i;
                    fifteen_button[i, j].Click += new System.EventHandler(Button_Click);
                    this.Controls.Add(fifteen_button[i, j]);

                    fifteen_button[i, j].Text = Convert.ToString(fifteen[i, j]);
                    fifteen_button[i, j].BackColor = Color.FromArgb(
                         color_random.Next(0, 255), color_random.Next(0, 255), color_random.Next(0, 255));
                }
            }
            fifteen_button[3, 3].Text = "";
            fifteen_button[3, 3].Visible = false;
        }
        public Form1()
        {
            InitializeComponent();
            Shuffle();
            Button new_game = new Button();
            new_game.Name = "new_game";
            new_game.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Regular);
            new_game.Width = width_button * 4 ;
            new_game.Height = 50;
            new_game.Left = 1;
            new_game.Click += new System.EventHandler(New_Game_Click);
            this.Controls.Add(new_game);

            new_game.Text = "New Game";
            new_game.BackColor = Color.FromArgb(255, 255, 255);
        }
        public void EmptyButton(Button second, Button first)
        {
            if (first.Text == "")
            {
                first.BackColor = second.BackColor;
                first.Text = second.Text;
                second.Text = "";
                first.Visible = true;
                second.Visible = false;
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button thisButton = sender as Button;
            switch (thisButton.Name)
            {
                case "button1":
                    EmptyButton(fifteen_button[0, 0], fifteen_button[0, 1]);
                    EmptyButton(fifteen_button[0, 0], fifteen_button[1, 0]);
                    SolutionChecker();
                    break;
                case "button2":
                    EmptyButton(fifteen_button[0, 1], fifteen_button[0, 0]);
                    EmptyButton(fifteen_button[0, 1], fifteen_button[0, 2]);
                    EmptyButton(fifteen_button[0, 1], fifteen_button[1, 1]);
                    SolutionChecker();
                    break;
                case "button3":
                    EmptyButton(fifteen_button[0, 2], fifteen_button[0, 1]);
                    EmptyButton(fifteen_button[0, 2], fifteen_button[0, 3]);
                    EmptyButton(fifteen_button[0, 2], fifteen_button[1, 2]);
                    SolutionChecker();
                    break;
                case "button4":
                    EmptyButton(fifteen_button[0, 3], fifteen_button[0, 2]);
                    EmptyButton(fifteen_button[0, 3], fifteen_button[1, 3]);
                    SolutionChecker();
                    break;
                case "button5":
                    EmptyButton(fifteen_button[1, 0], fifteen_button[0, 0]);
                    EmptyButton(fifteen_button[1, 0], fifteen_button[1, 1]);
                    EmptyButton(fifteen_button[1, 0], fifteen_button[2, 0]);
                    SolutionChecker();
                    break;
                case "button6":
                    EmptyButton(fifteen_button[1, 1], fifteen_button[0, 1]);
                    EmptyButton(fifteen_button[1, 1], fifteen_button[1, 0]);
                    EmptyButton(fifteen_button[1, 1], fifteen_button[2, 1]);
                    EmptyButton(fifteen_button[1, 1], fifteen_button[1, 2]);
                    SolutionChecker();
                    break;
                case "button7":
                    EmptyButton(fifteen_button[1, 2], fifteen_button[0, 2]);
                    EmptyButton(fifteen_button[1, 2], fifteen_button[1, 1]);
                    EmptyButton(fifteen_button[1, 2], fifteen_button[1, 3]);
                    EmptyButton(fifteen_button[1, 2], fifteen_button[2, 2]);
                    SolutionChecker();
                    break;
                case "button8":
                    EmptyButton(fifteen_button[1, 3], fifteen_button[0, 3]);
                    EmptyButton(fifteen_button[1, 3], fifteen_button[1, 2]);
                    EmptyButton(fifteen_button[1, 3], fifteen_button[2, 3]);
                    SolutionChecker();
                    break;
                case "button9":
                    EmptyButton(fifteen_button[2, 0], fifteen_button[1, 0]);
                    EmptyButton(fifteen_button[2, 0], fifteen_button[2, 1]);
                    EmptyButton(fifteen_button[2, 0], fifteen_button[3, 0]);
                    SolutionChecker();
                    break;
                case "button10":
                    EmptyButton(fifteen_button[2, 1], fifteen_button[1, 1]);
                    EmptyButton(fifteen_button[2, 1], fifteen_button[2, 0]);
                    EmptyButton(fifteen_button[2, 1], fifteen_button[2, 2]);
                    EmptyButton(fifteen_button[2, 1], fifteen_button[3, 1]);
                    SolutionChecker();
                    break;
                case "button11":
                    EmptyButton(fifteen_button[2, 2], fifteen_button[1, 2]);
                    EmptyButton(fifteen_button[2, 2], fifteen_button[2, 1]);
                    EmptyButton(fifteen_button[2, 2], fifteen_button[2, 3]);
                    EmptyButton(fifteen_button[2, 2], fifteen_button[3, 2]);
                    SolutionChecker();
                    break;
                case "button12":
                    EmptyButton(fifteen_button[2, 3], fifteen_button[1, 3]);
                    EmptyButton(fifteen_button[2, 3], fifteen_button[2, 2]);
                    EmptyButton(fifteen_button[2, 3], fifteen_button[3, 3]);
                    SolutionChecker();
                    break;
                case "button13":
                    EmptyButton(fifteen_button[3, 0], fifteen_button[2, 0]);
                    EmptyButton(fifteen_button[3, 0], fifteen_button[3, 1]);
                    SolutionChecker();
                    break;
                case "button14":
                    EmptyButton(fifteen_button[3, 1], fifteen_button[2, 1]);
                    EmptyButton(fifteen_button[3, 1], fifteen_button[3, 0]);
                    EmptyButton(fifteen_button[3, 1], fifteen_button[3, 2]);
                    SolutionChecker();
                    break;
                case "button15":
                    EmptyButton(fifteen_button[3, 2], fifteen_button[2, 2]);
                    EmptyButton(fifteen_button[3, 2], fifteen_button[3, 1]);
                    EmptyButton(fifteen_button[3, 2], fifteen_button[3, 3]);
                    SolutionChecker();
                    break;
                case "button16":
                    EmptyButton(fifteen_button[3, 3], fifteen_button[2, 3]);
                    EmptyButton(fifteen_button[3, 3], fifteen_button[3, 2]);
                    SolutionChecker();
                    break;
            }
        }
        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            DialogResult iExit = MessageBox.Show("Are you sure?", "Fifteen Game",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (iExit == DialogResult.No)
                e.Cancel = true;
        }
        public void SolutionChecker()
        {
            if (fifteen_button[0, 0].Text == "1" && fifteen_button[0, 1].Text == "2" && fifteen_button[0, 2].Text == "3" && fifteen_button[0, 3].Text == "4" &&
                 fifteen_button[1, 0].Text == "5" && fifteen_button[1, 1].Text == "6" && fifteen_button[1, 2].Text == "7" && fifteen_button[1, 3].Text == "8" &&
                fifteen_button[2, 0].Text == "9" && fifteen_button[2, 1].Text == "10" && fifteen_button[2, 2].Text == "11" && fifteen_button[2, 3].Text == "12" &&
                fifteen_button[3, 0].Text == "13" && fifteen_button[3, 1].Text == "14" && fifteen_button[3, 2].Text == "15")
            {
                DialogResult gameOver = MessageBox.Show("New Game?", "Game Over!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (gameOver == DialogResult.Yes)
                    Shuffle();
                if (gameOver == DialogResult.No)
                    Application.Exit();
            }
        }
        private void New_Game_Click(object sender, EventArgs e)
        {
            Shuffle();
            this.Refresh();
            this.Hide();
            Form1 newGame = new Form1();
            newGame.Show();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            int count = 1;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    fifteen_button[i, j].Text = Convert.ToString(count);
                    count++;
                }
            }
        }
    }
}