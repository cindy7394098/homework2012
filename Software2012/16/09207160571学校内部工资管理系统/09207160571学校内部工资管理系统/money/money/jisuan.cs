﻿using System;
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
    public partial class jisuan : Form
    {
        public jisuan()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            renshi fm = new renshi();
            fm.Show();
        }

        private void jisuan_Load(object sender, EventArgs e)
        {
            //绑定数据到dataGridView1
            string sqls = "UPDATE teacher SET real='1000' ";
            DBConnection.OperateData(sqls);
            SqlConnection conn = DBConnection.MyConnection();            
            string sql = "select number as 编号,name as 姓名,real as 工资 from teacher";
            SqlDataAdapter DataViewALLDataAdaPter = new SqlDataAdapter(sql, conn);
            DataTable DataViewALLTable = new DataTable();
            DataViewALLDataAdaPter.Fill(DataViewALLTable);
            dataGridView1.DataSource = DataViewALLTable;
            conn.Close();    
        }
    }
}
