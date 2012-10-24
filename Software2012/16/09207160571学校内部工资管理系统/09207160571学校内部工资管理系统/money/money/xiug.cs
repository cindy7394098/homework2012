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
    public partial class xiug : Form
    {
        public xiug()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cai fm = new cai();
            fm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = textBox1.Text.ToString();         
            
            string real = textBox2.Text.ToString();           
            if (number == null)
            {
                MessageBox.Show("教职工编号不能为空！");
                return;
            }
            string sql = "UPDATE teacher SET real = '" + real + "' WHERE number = '" + number + "' ";
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
    }
}
