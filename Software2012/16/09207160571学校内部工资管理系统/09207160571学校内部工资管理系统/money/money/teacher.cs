using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;//引用SQL命名空间

namespace money
{
    public partial class teacher : Form
    {
        public teacher()
        {
            InitializeComponent();
        }

        private void teacher_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string number = textBox1.Text.ToString();
            string sqls = "select * from teacher where number='"+number+"'";
            SqlDataReader str = DBConnection.ReadData(sqls);
            while (str.Read())
            {
                textBox2.Text = str["name"].ToString();
                textBox3.Text = str["section"].ToString();
                textBox4.Text = str["sex"].ToString();
                textBox5.Text = str["zhi"].ToString();
                textBox6.Text = str["bao"].ToString();
                textBox7.Text = str["jiang"].ToString();
                textBox8.Text = str["faj"].ToString();
                textBox9.Text = str["base"].ToString();
                textBox10.Text = str["ban"].ToString();
                textBox11.Text = str["real"].ToString();//最终工资
                textBox12.Text = str["que"].ToString();
                textBox13.Text = str["chu"].ToString();
                textBox14.Text = str["tax"].ToString();
                textBox15.Text = str["fyuan"].ToString();
                textBox16.Text = str["diaos"].ToString();                
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
