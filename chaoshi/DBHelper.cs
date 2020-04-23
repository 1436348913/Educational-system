using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace chaoshi
{
    class DBHelper
    {
        //使用sqlconnection 类连接到SQL Server数据库
        //data source 是指数据库地址,initial catalog 是数据库名字userid和pwd分别指用户名和密码
        private string connString = @"Data Source=.;Initial Catalog=BookShop; User Id=sa;Pwd=123456";
        private SqlConnection connection;
        //连接对象
        public SqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SqlConnection(connString);
                }
                return connection;
            }
        }
        //打开数据库连接
        public void OpenConnection()
        {
            //如果状态关闭则打开
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            // 如果状态被中断，关闭再打开
            else if (Connection.State == ConnectionState.Broken)
            {
                Connection.Close();
                Connection.Open();
            }
        }
        //关闭数据库
        public void CloseConnection()
        {
            //如果数据库打开或者损坏则关闭
            if (Connection.State == ConnectionState.Open|| Connection.State == ConnectionState.Broken)
            {
                Connection.Close();
            }
        }
    }
}
