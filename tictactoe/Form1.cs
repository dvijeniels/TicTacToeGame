using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class Form1 : Form
    {
        public int state = 0,userPoint = 0, computerPoint=0; //0 is player 1 is computer
        Random rnd = new Random();
        public int[,] checkBoxPattern = { {0,1,2},
                                          {3,4,5},
                                          {6,7,8},
                                          {0,4,8},
                                          {2,4,6},
                                          {0,3,6},
                                          {1,4,7},
                                          {2,5,8}};
        
        public Button[] boxes = new Button[9];
        public Form1()
        {
            InitializeComponent();
        }

        void changePlayer()
        {

            stateControl(boxes);
            if (state == 1) {
                state = 0;
                for (int i = 0; i < 9; i++)
                {
                    boxes[i].Enabled = true;
                }
            }
            else if(state == 0) 
            {
                for (int i = 0; i < 9; i++)
                {
                    state = 1;
                    boxes[i].Enabled = false;
                   
                }
                computer(boxes);
            }
            else if (state == 2)
            {
                for (int i = 0; i < 9; i++)
                {
                    boxes[i].Enabled = false;
                }
            }
        }

        void stateControl(Button[] newList)
        {
            bool finish = false;
            for (int i = 0; i < 8; i++)
            {
                if ((newList[checkBoxPattern[i, 0]].Text == "X" && newList[checkBoxPattern[i, 1]].Text == "X" && newList[checkBoxPattern[i, 2]].Text == "X"))
                {

                    finish = true;
                    state = 2;
                    label4.Text = "X Kazandı!";
                    userPoint += 1;
                    break;
                }
                else if ((newList[checkBoxPattern[i, 0]].Text == "O" && newList[checkBoxPattern[i, 1]].Text == "O" && newList[checkBoxPattern[i, 2]].Text == "O"))
                {
                    label4.Text = "O Kazandı!";
                    computerPoint += 1;
                    finish = true;
                    state = 2;
                    break;
                }
            }
            if (!finish)
            {
                finish = true;
                for (int i = 0; i < 9; i++)
                {
                    if (newList[i].Text == " ")
                    {
                        finish = false;

                        break;
                    }
                }
                if (finish)
                {
                    state = 2;
                    label4.Text = "Berabere!";
                }
            }

            label1.Text = "Oyuncu : "+ userPoint;
            label2.Text = "Bilgisayar : " + computerPoint;

        }

        private void Form1_Load(object sender, EventArgs e)
        {     
            for (int i = 0; i < 9; i++)
            {
                Button btn = new Button();
                btn.Location = new Point(12+ (i%3)*206, 12 + (i / 3) * 206);
                btn.Font = new Font("Arial",100,FontStyle.Bold);
                btn.Size = new Size(180,180);
                btn.Name = ("box" + (i+1).ToString());
                btn.Click += new EventHandler(boxClick);
                btn.Text = " ";
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.Black;
                btn.FlatAppearance.BorderSize = 5;
                boxes[i] = btn;
                this.Controls.Add(btn);   
            }
        }

        private void boxClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text.Equals(" ")) {
                btn.Text = "X";
                changePlayer();
            }
        
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnaSayfa form = new AnaSayfa();
            form.Show();
            form.FormClosing += (obj, args) => { this.Close(); };
            this.Hide();
        }

        void computer(Button[] newList) {
            bool noMatch = true;
            int u = rnd.Next(0, 9);


            for (int i = 0; i < 8; i++)
            {
                if ((newList[checkBoxPattern[i, 0]].Text == "O" && newList[checkBoxPattern[i, 1]].Text == "O" && newList[checkBoxPattern[i, 2]].Text == " ") ||
                    (newList[checkBoxPattern[i, 1]].Text == "O" && newList[checkBoxPattern[i, 2]].Text == "O" && newList[checkBoxPattern[i, 0]].Text == " ") ||
                    (newList[checkBoxPattern[i, 0]].Text == "O" && newList[checkBoxPattern[i, 2]].Text == "O" && newList[checkBoxPattern[i, 1]].Text == " "))
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (newList[checkBoxPattern[i, k]].Text == " ")
                        {
                            newList[checkBoxPattern[i, k]].Text = "O";
                            noMatch = false;
                            break;
                        }
                    }
                    break;
                }

            }



            if (noMatch)
            {
                for (int i = 0; i < 8; i++)
                {
                    if ((newList[checkBoxPattern[i, 0]].Text == "X" && newList[checkBoxPattern[i, 1]].Text == "X" && newList[checkBoxPattern[i, 2]].Text == " ") ||
                        (newList[checkBoxPattern[i, 1]].Text == "X" && newList[checkBoxPattern[i, 2]].Text == "X" && newList[checkBoxPattern[i, 0]].Text == " ") ||
                        (newList[checkBoxPattern[i, 0]].Text == "X" && newList[checkBoxPattern[i, 2]].Text == "X" && newList[checkBoxPattern[i, 1]].Text == " "))
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (newList[checkBoxPattern[i, k]].Text == " ")
                            {
                                newList[checkBoxPattern[i, k]].Text = "O";
                                noMatch = false;
                                break;
                            }
                        }
                        break;
                    }
                }
            }

            if (noMatch)
            {             
                    while (true)
                    {
                        u = rnd.Next(0, 9) % 10;
                        if (newList[u].Text == " ")
                        {
                            newList[u].Text = "O";
                            break;
                        }
                    }                              
            }
            changePlayer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (state==2)
            {
                for (int i = 0; i < 9; i++)
                {
                    boxes[i].Text = " ";
                    boxes[i].Enabled = true;

                }
                state = 0;
                label4.Text = "";
            }
          
        }
    }
}
