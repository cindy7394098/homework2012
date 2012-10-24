using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;//引用SQL命名空间

namespace money
{
    class DBConnection
    {
        public static SqlConnection MyConnection()
        {            
            return new SqlConnection(//创建数据库连接对象
      //@"server=localhost;database=test;uid=sa;pwd=123");//数据库连接字符串
      @"Data Source=HYB70-20120811M\MYSSERVER;Initial Catalog=money;User ID=sa;Password=123");
        }


        //只能insert 和update 操作
        public static int OperateData(string strSql)
        {
            SqlConnection conn = MyConnection();
            conn.Open();//打开数据库连接
            SqlCommand cmd = new SqlCommand(strSql, conn);//创建命令对象
            int i = (int)cmd.ExecuteNonQuery();//执行SQL命令
            conn.Close();//关闭数据库连接
            return i;//返回数值
        }

        //只能select 操作
        //外面读数据   sql="select * from teacher ";
        //     SqlDataReader str=DBConnection.ReadData();
        //   while(str.read()){
        //  str[字段];
        //}
        //
        public static SqlDataReader ReadData(string strSql)
        {
            SqlConnection conn = MyConnection();
            conn.Open();//打开数据库连接
            SqlCommand cmd = new SqlCommand(strSql, conn);//创建命令对象
            SqlDataReader sr = cmd.ExecuteReader();
            return sr;//返回数值
        }


       

    }
}
