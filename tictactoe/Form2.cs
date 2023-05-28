using System;
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
    public partial class Form2 : Form
    {
        public int userPoint = 0, computerPoint = 0; //0 is player 1 is computer
        Random rnd = new Random();
        string tag;
        AnaSayfa anaFr;
        public int[,] checkBoxPattern = { {0,1,2},
                                          {3,4,5},
                                          {6,7,8},
                                          {0,4,8},
                                          {2,4,6},
                                          {0,3,6},
                                          {1,4,7},
                                          {2,5,8}};

        public Button[] boxes = new Button[9];
        public Form2(AnaSayfa fr)
        {
            InitializeComponent();
            this.anaFr = fr;
        }
        void stateControl(Button[] newList)
        {
            bool finish = false;
            for (int i = 0; i < 8; i++)
            {
                if ((newList[checkBoxPattern[i, 0]].Text == "X" && newList[checkBoxPattern[i, 1]].Text == "X" && newList[checkBoxPattern[i, 2]].Text == "X"))
                {

                    finish = true;
                    label4.Text = "X Kazandı!";
                    for (int a = 0; a < 9; a++)
                    {
                        boxes[a].Enabled = false;

                    }
                    userPoint += 1;
                    timer1.Stop();
                    break;
                }
                else if ((newList[checkBoxPattern[i, 0]].Text == "O" && newList[checkBoxPattern[i, 1]].Text == "O" && newList[checkBoxPattern[i, 2]].Text == "O"))
                {
                    label4.Text = "O Kazandı!";
                    for (int j = 0; j < 9; j++)
                    {
                        boxes[j].Enabled = false;

                    }
                    computerPoint += 1;
                    finish = true;
                    timer1.Stop();
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
                    label4.Text = "Berabere!";
                    timer1.Stop();
                    for (int a = 0; a < 9; a++)
                    {
                        boxes[a].Enabled = false;
                    }
                    timer1.Stop();
                }
            }

            label1.Text = "Oyuncu 1 : " + userPoint;
            label2.Text = "Oyuncu 2 : " + computerPoint;

        }
        int sayac = 0;
        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                Button btn = new Button();
                btn.Location = new Point(12 + (i % 3) * 206, 12 + (i / 3) * 206);
                btn.Font = new Font("Arial", 100, FontStyle.Bold);
                btn.Size = new Size(180, 180);
                btn.Name = ("box" + (i + 1).ToString());
                btn.Click += new EventHandler(boxClick);
                btn.Text = " ";
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.Black;
                btn.FlatAppearance.BorderSize = 5;
                boxes[i] = btn;
                this.Controls.Add(btn);
            }
            label3.Text = anaFr.label1.Text;
            sayac = Convert.ToInt16(label3.Text);
            progressBar1.Maximum = sayac;
            timer1.Start();
            GenerateTag();
        }

        private void boxClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text.Equals(" "))
            {
                btn.Text = tag;
                tag = tag == "X" ? "O" : "X";
                label3.Text = anaFr.label1.Text;
                sayac = Convert.ToInt16(label3.Text);
                progressBar1.Maximum = sayac;
                timer1.Start();
                stateControl(boxes);
            }
        }

        void GenerateTag()
        {
            var r =new Random();
            tag = r.Next(0, 2) != 1 ? "X" : "O"; 
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AnaSayfa form = new AnaSayfa();
            form.Show();
            form.FormClosing += (obj, args) => { this.Close(); };
            this.Hide();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sayac==0)
            {
                label4.Text = tag + " Kaybetti!";
                for (int j = 0; j < 9; j++)
                {
                    boxes[j].Enabled = false;

                }
                timer1.Stop();
            }
            
            progressBar1.Value = sayac;
            label3.Text = sayac.ToString();
            sayac--;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                boxes[i].Text = " ";
                boxes[i].Enabled = true;

            }
            label3.Text = anaFr.label1.Text;
            sayac = Convert.ToInt16(label3.Text);
            progressBar1.Maximum = sayac;
            timer1.Start();
            label4.Text = " ";

        }

    }
}
