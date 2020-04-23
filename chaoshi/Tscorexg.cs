using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace chaoshi
{
    public partial class Tscorexg : Form
    {
        #region 构造函数
        public Tscorexg()
        {
            InitializeComponent();
        }
        #endregion

        #region 变量
        public int tscorexgID = 0;
        #endregion

        #region 事件
        private void Tscorexg_Load(object sender, EventArgs e)
        {
            GetTea();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateTea();

        }
        //退出
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 方法

        #region 将信息获取到窗体
        private void GetTea()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format( @"select SID 编号,Student.MID 学号,Mclass 班级,MName 学生姓名,FName 科目,Score 成绩,TName 教师姓名 from score s join F f on s.FID=f.FID join teacher t on t.TID= s.TID join Student on Student.MID=s.MID where SID='{0}'",tscorexgID);

                SqlCommand cmd = new SqlCommand(sql, dBHelper.Connection);

                dBHelper.OpenConnection();
                
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                        this.textBox3.Text = reader["成绩"].ToString();
  
                }
                reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("数据库操作错误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                dBHelper.CloseConnection();
            }
        }

        #endregion

        #region 修改
        private void UpdateTea()
        {
            DBHelper dBHelper = new DBHelper();

            try
            {
                string sql = string.Format(@"update score
  set Score = '{0}' where SID = '{1}'",  textBox3.Text.Trim(), tscorexgID);

                SqlCommand cmd = new SqlCommand(sql, dBHelper.Connection);

                dBHelper.OpenConnection();

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("执行成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("重复", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                dBHelper.CloseConnection();
            }
        }


        #endregion
        #endregion


    }
}
