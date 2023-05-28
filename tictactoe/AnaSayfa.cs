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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Form1 form = new Form1();
                form.Show();
                form.FormClosing += (obj, args) => { this.Close(); };
                this.Hide();
            }
            else if (radioButton2.Checked)
            {
                Form2 form2 = new Form2(this);
                form2.Show();
                form2.FormClosing += (obj, args) => { this.Close(); };
                this.Hide();
            }
            else
            {
                MessageBox.Show("İlk önce seçim yapınız", "Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                trackBar1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                trackBar1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }
    }
}
