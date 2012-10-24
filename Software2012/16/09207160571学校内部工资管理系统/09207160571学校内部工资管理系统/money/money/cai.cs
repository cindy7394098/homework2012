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
    public partial class cai : Form
    {
        public cai()
        {
            InitializeComponent();
            SqlConnection conn = DBConnection.MyConnection();
            string sql = "select number as 编号,name as 姓名,real as 工资 from teacher";
            SqlDataAdapter DataViewALLDataAdaPter = new SqlDataAdapter(sql, conn);
            DataTable DataViewALLTable = new DataTable();
            DataViewALLDataAdaPter.Fill(DataViewALLTable);
            dataGridView1.DataSource = DataViewALLTable;
            conn.Close();    
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            xiug fm = new xiug();
            fm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("上交银行成功！");
            return;
        }
    }
}
