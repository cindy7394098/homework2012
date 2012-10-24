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
    public partial class jfs : Form
    {
        public jfs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bian = textBox1.Text.ToString();
            string fyuan = textBox4.Text.ToString();
            string jiang = textBox6.Text.ToString();
            string faj = textBox7.Text.ToString();
            if(bian==null){
                MessageBox.Show("教职工编号不能为空！");
                return;
            }
            string sql = "UPDATE teacher SET fyuan = '" + fyuan + "',jiang = '" + jiang + "',faj = '" + faj + "' WHERE number = '" + bian + "' ";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            renshi fm = new renshi();
            fm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
