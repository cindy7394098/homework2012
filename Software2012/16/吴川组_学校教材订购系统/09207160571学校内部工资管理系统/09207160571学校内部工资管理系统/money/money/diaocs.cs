using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace money
{
    public partial class diaocs : Form
    {
        public diaocs()
        {
            InitializeComponent();
        }

        private void diaocs_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            renshi fm = new renshi();
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //1 6 4 2
            string number = textBox1.Text.ToString();           
            string section = textBox6.Text.ToString();
            string zhi= textBox4.Text.ToString();
            string bases = textBox2.Text.ToString();
            string diaos = textBox9.Text.ToString();
            if (number == null)
            {
                MessageBox.Show("教职工编号不能为空！");
                return;
            }
            string sql = "UPDATE teacher SET section = '" + section + "',zhi = '" + zhi + "',base = '" + bases + "' WHERE number = '" + number + "' ";
            int j = DBConnection.OperateData(sql);
            if (j == 0)
            {
                MessageBox.Show("确认失败，请重试！");
            }
            else
            {
                MessageBox.Show("确认成功！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
