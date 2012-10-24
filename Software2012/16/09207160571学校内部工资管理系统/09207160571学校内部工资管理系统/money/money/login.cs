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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")//判断用户名和密码是否为空
            {
                MessageBox.Show("用户名或密码不能为空！",//弹出消息对话框
                    "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;//退出事件
            }
            else
            {
                string name = textBox1.Text.Trim();//移除用户名前部和后部的空格
                string pwd = textBox2.Text.Trim();//移除密码前部和后部的空格
                SqlConnection conn = DBConnection.MyConnection();//创建数据库连接对象
                conn.Open();//连接到SQL数据库
                //教师端登陆
                if (radioButton1.Checked)
                {                    
                    SqlCommand cmd = new SqlCommand(//创建数据库命令对象
                        "select * from teacher where name='" +
                        name + "' and password='" + pwd + "'", conn);
                    SqlDataReader sdr = cmd.ExecuteReader();//得到数据读取器对象
                    sdr.Read();//读取一条记录
                    if (sdr.HasRows)//判断是否包含数据
                    {
                        
                        this.Hide();
                        teacher fm = new teacher();
                        fm.Show();
                    }
                    else
                    {
                        this.clean();
                    }
                }

                //人事端登陆
                if (radioButton2.Checked)
                {
                     SqlCommand cmd = new SqlCommand(//创建数据库命令对象
                        "select * from renshi where username='" +
                        name + "' and password='" + pwd + "'", conn);
                    SqlDataReader sdr = cmd.ExecuteReader();//得到数据读取器对象
                    sdr.Read();//读取一条记录
                    if (sdr.HasRows)//判断是否包含数据
                    {
                        
                        this.Hide();
                        renshi fm = new renshi();
                        fm.Show();
                    }
                    else
                    {
                        this.clean();
                    }
                }

                //财务端登陆
                if (radioButton3.Checked)
                {
                    SqlCommand cmd = new SqlCommand(//创建数据库命令对象
                        "select * from cai where caiuser='" +
                        name + "' and password='" + pwd + "'", conn);
                    SqlDataReader sdr = cmd.ExecuteReader();//得到数据读取器对象
                    sdr.Read();//读取一条记录
                    if (sdr.HasRows)//判断是否包含数据
                    {
                       
                        this.Hide();
                        cai fm = new cai();
                        fm.Show();
                    }
                    else
                    {
                        this.clean();
                    }
                }
            }
        }

        //清空textbox
         public void clean(){
             textBox1.Text = "";//清空用户名
             textBox2.Text = "";//清空密码
             MessageBox.Show("用户名或密码错误！", "提示",//弹出消息对话框
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
             

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);//完全关闭窗体代码
        }
    }
}
