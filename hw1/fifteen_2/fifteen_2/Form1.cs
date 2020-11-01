using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fifteen_2
{
    public partial class Form1 : Form
    {
        Button[] fifteen_button = new Button[15];
        int width_button = 80, height_button = 80;
        Button curr_button;
        int counter = 0, locationX, locationY;
        bool is_press = false;
        public void Shuffle()
        {
            int[] fifteen = new int[15];
            for (int i = 0; i < 15; i++)
                fifteen[i] = i + 1;

            Random numbers_random = new Random();
            for (int i = 14; i >= 0; i--)
            {
                int RND1 = numbers_random.Next(i);
                int temp = fifteen[i];
                fifteen[i] = fifteen[RND1];
                fifteen[RND1] = temp;
            }

            Random color_random = new Random();
            int xp = -1, yp= -1;

            for (int i = 0; i < 15; i++)
            {
                xp++;
                if (i % 4 == 0)
                {
                    xp = 0;
                    yp++;
                }
                fifteen_button[i] = new Button();
                fifteen_button[i].Name = "button" +  i.ToString();
                fifteen_button[i].Font = new Font("Microsoft Sans Serif", 25, FontStyle.Regular);
                fifteen_button[i].Width = width_button;
                fifteen_button[i].Height = height_button;
                fifteen_button[i].Left = 1 + xp % 4 * width_button;
                fifteen_button[i].Top = 50 + yp * height_button;
                fifteen_button[i].TabIndex = 4 * i;
                fifteen_button[i].Click += new EventHandler(Button_Click);
                this.Controls.Add(fifteen_button[i]);

                fifteen_button[i].Text = Convert.ToString(fifteen[i]);
                fifteen_button[i].BackColor = Color.FromArgb(
                     color_random.Next(0, 256), color_random.Next(0, 256), color_random.Next(0, 256));
            }
        }
        public Form1()
        {
            InitializeComponent();
            Shuffle();

            Button new_game = new Button();
            new_game.Name = "new_game";
            new_game.Font = new Font("Times New Roman", 13, FontStyle.Regular);
            new_game.Width = width_button * 4;
            new_game.Height = 50;
            new_game.Left = 1;
            new_game.Click += new System.EventHandler(New_Game_Click);
            this.Controls.Add(new_game);

            new_game.Text = "New Game";
            new_game.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            new_game.BackColor = Color.FromArgb(255, 255, 255);
        }
        private void Button_Click(object sender, EventArgs e)
        {
            if (!is_press) { 
                curr_button = sender as Button;

                RightEmptyButton();
                LeftEmptyButton();
                UpEmptyButton();
                DownEmptyButton();
            }
        }
        public void RightEmptyButton()
        {
            if (curr_button.Location.X == 241) //this is a last location
                return;
            bool flag = true;                
            
            for(int i = 0; i < fifteen_button.Length; i++) //there is a right available button
            {
                if (curr_button.Location.X == fifteen_button[i].Location.X &&
                    curr_button.Location.Y == fifteen_button[i].Location.Y)    //this is the same button
                    continue;                  
                
                if (curr_button.Location.X + width_button == fifteen_button[i].Location.X &&
                    curr_button.Location.Y == fifteen_button[i].Location.Y)    //there isn't a right available button
                {
                    flag = false;
                    break;
                }
            }
            
            if (flag)
            {
                locationX = 4;
                locationY = 0;
                is_press = true;
                Timer.Start();
            }
        }
        public void LeftEmptyButton()
        {
            if (curr_button.Location.X == 1) //this is a last location
                return;
            bool flag = true;                 
            
            for (int i = 0; i < fifteen_button.Length; i++) //there is a left available button
            {
                if (curr_button.Location.X == fifteen_button[i].Location.X &&
                    curr_button.Location.Y == fifteen_button[i].Location.Y)   //this is the same button
                    continue;                  
                
                if (curr_button.Location.X - width_button == fifteen_button[i].Location.X &&
                    curr_button.Location.Y == fifteen_button[i].Location.Y)   //there is a left available button
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                locationX = -4;
                locationY = 0;
                is_press = true;
                Timer.Start();
            }
        }
        public void UpEmptyButton()
        {
            if (curr_button.Location.Y == 50) //this is a last location
                return;
            bool flag = true;

            for (int i = 0; i < fifteen_button.Length; i++) //there is a up available button
            {
                if (curr_button.Location.X == fifteen_button[i].Location.X &&
                    curr_button.Location.Y == fifteen_button[i].Location.Y)   //this is the same button
                    continue;
               
                if (curr_button.Location.X == fifteen_button[i].Location.X &&
                    curr_button.Location.Y - height_button == fifteen_button[i].Location.Y)   //there is a up available button
                {
                    flag = false;
                    break;
                }
            }
           
            if (flag)
            {
                locationX = 0;
                locationY = -4;
                is_press = true;
                Timer.Start();
            }
        }
        public void DownEmptyButton()
        {
            if (curr_button.Location.Y == 290) //this is a last location
                return;
            bool flag = true;

            for (int i = 0; i < fifteen_button.Length; i++) //there is a down available button
            {
                if (curr_button.Location.X == fifteen_button[i].Location.X &&
                    curr_button.Location.Y == fifteen_button[i].Location.Y)   //this is the same button
                    continue;

                if (curr_button.Location.X == fifteen_button[i].Location.X &&
                    curr_button.Location.Y + height_button == fifteen_button[i].Location.Y)   //there is a down available button
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                locationX = 0;
                locationY = 4;
                is_press = true;
                Timer.Start();
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            curr_button.Location = new Point(curr_button.Location.X + locationX, curr_button.Location.Y + locationY);
            counter++;
            if (counter == 20)
            {
                counter = 0;
                Timer.Stop();
                is_press = false;
                SolutionChecker();
            }
        }
        private void New_Game_Click(object sender, EventArgs e)
        {
            this.Refresh();
            this.Hide();
            Form1 newGame = new Form1();
            newGame.Show();
        }
        public void SolutionChecker()
        {
            bool flag = true;
            for (int i = 0; i < fifteen_button.Length; i++)
            {
                switch (fifteen_button[i].Location.Y)
                {
                    case 50:
                        if (fifteen_button[i].Location.X == 1 && fifteen_button[i].Text != Convert.ToString(1)) 
                            flag = false;
                        if (fifteen_button[i].Location.X == 81 && fifteen_button[i].Text != Convert.ToString(2)) 
                            flag = false;
                        if (fifteen_button[i].Location.X == 161 && fifteen_button[i].Text != Convert.ToString(3)) 
                            flag = false;
                        if (fifteen_button[i].Location.X == 241 && fifteen_button[i].Text != Convert.ToString(4)) 
                            flag = false;
                        break;

                    case 130:
                        if (fifteen_button[i].Location.X == 1 && fifteen_button[i].Text != Convert.ToString(5))
                            flag = false;
                        if (fifteen_button[i].Location.X == 81 && fifteen_button[i].Text != Convert.ToString(6))
                            flag = false;
                        if (fifteen_button[i].Location.X == 161 && fifteen_button[i].Text != Convert.ToString(7))
                            flag = false;
                        if (fifteen_button[i].Location.X == 241 && fifteen_button[i].Text != Convert.ToString(8))
                            flag = false;
                        break;

                    case 210:
                        if (fifteen_button[i].Location.X == 1 && fifteen_button[i].Text != Convert.ToString(9))
                            flag = false;
                        if (fifteen_button[i].Location.X == 81 && fifteen_button[i].Text != Convert.ToString(10))
                            flag = false;
                        if (fifteen_button[i].Location.X == 161 && fifteen_button[i].Text != Convert.ToString(11))
                            flag = false;
                        if (fifteen_button[i].Location.X == 241 && fifteen_button[i].Text != Convert.ToString(12))
                            flag = false;
                        break;

                    case 290:
                        if (fifteen_button[i].Location.X == 1 && fifteen_button[i].Text != Convert.ToString(13))
                            flag = false;
                        if (fifteen_button[i].Location.X == 81 && fifteen_button[i].Text != Convert.ToString(14))
                            flag = false;
                        if (fifteen_button[i].Location.X == 161 && fifteen_button[i].Text != Convert.ToString(15))
                            flag = false;
                        if ((fifteen_button[i].Text == Convert.ToString(15) || fifteen_button[i].Text == Convert.ToString(12)) && 
                                fifteen_button[i].Location.X == 241)
                            flag = false;
                        break;
                }
                if (!flag) 
                    break;
            }
            if (flag)
            {
                DialogResult gameOver = MessageBox.Show("New Game?", "Game Over!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (gameOver == DialogResult.Yes)
                {
                    this.Refresh();
                    this.Hide();
                    Form1 newGame = new Form1();
                    newGame.Show();
                }
                if (gameOver == DialogResult.No)
                    Application.Exit();
            }
        }
    }
}