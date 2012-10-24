using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;//引用SQL命名空间

namespace money
{
    public partial class renshi : Form
    {
        public renshi()
        {
            InitializeComponent();
            //绑定数据到dataGridView1
            SqlConnection conn = DBConnection.MyConnection();
            string sql = "select number as 编号,name as 姓名,chu as 出勤次数,que as 缺席次数 from teacher";
            SqlDataAdapter DataViewALLDataAdaPter = new SqlDataAdapter(sql,conn);
            DataTable DataViewALLTable = new DataTable();
            DataViewALLDataAdaPter.Fill(DataViewALLTable);
            dataGridView1.DataSource = DataViewALLTable;
            conn.Close();           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            jisuan fm = new jisuan();
            fm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            diaocs fm = new diaocs();
            fm.Show();
        }

        private void renshi_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        //导入excel代码
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() == DialogResult.OK)
            {
                string filepath = of.FileName;
                FileInfo fi = new FileInfo(filepath);
                string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="  + filepath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                DataSet ds = new DataSet();
                using (OleDbConnection con = new OleDbConnection(strCon))
                {
                    con.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [Sheet1$]", con);
                    adapter.Fill(ds, "dtSheet1");
                    con.Close();
                    con.Dispose();
                }
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                {
                    string number = ds.Tables[0].Rows[i]["编号"].ToString();
                    string name = ds.Tables[0].Rows[i]["姓名"].ToString();
                    string attendance = ds.Tables[0].Rows[i]["出勤次数"].ToString();
                    string absence = ds.Tables[0].Rows[i]["缺勤次数"].ToString();
                    string sql = "insert into teacher(number,name,chu,que) values ('" + number + "','" + name + "','" + attendance + "','" + absence + "')";
                    int j=DBConnection.OperateData(sql);
                    if (j==0)
                    {
                        MessageBox.Show("插入数据失败");
                        return;                       
                    }                     
                }
                  MessageBox.Show("插入数据成功！");

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            jfs fm = new jfs();
            fm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("上交报表成功！");
            return;
        }


   

        
    }
}
