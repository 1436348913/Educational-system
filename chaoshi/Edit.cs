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
    

    public partial class Edit : Form
    {
        #region 变量
        public int ttID = 0;
        #endregion

        #region 构造函数
        public Edit()
        {
            InitializeComponent();
        } 
        #endregion

        #region 事件
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Focus();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        #region 添加
        private void Edit_Load(object sender, EventArgs e)
        {
            if (ttID == 0)//添加
            {

            }
            else //修改
            {
                //将信息显示在修改窗体
                this.GetTea();

            }
        }
        #endregion

        #region 保存
        //保存
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (ttID == 0)  //新增
                {
                    InsertTea();
                }
                else//修改
                {
                    UpdateTea();
                }
            }
        }
        #endregion

        #region 退出
        //退出
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 
        #endregion

        #region 方法

        #region 检查窗体输入

        private bool CheckInput()
        {
            bool ok = true;
            if(textBox1.Text.Trim().Length==0)
            {
                MessageBox.Show("姓名不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ok = false;
            }
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("性别不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ok = false;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("密码不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ok = false;
            }
            if (textBox4.Text.Trim().Length == 0)
            {
                MessageBox.Show("教师号不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ok = false;
            }
            return ok;
        }




        #endregion

        #region 将信息获取到窗体
        private void GetTea()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format("select * from Teacher where TUserID={0}", ttID);

                SqlCommand cmd = new SqlCommand(sql, dBHelper.Connection);

                dBHelper.OpenConnection();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    this.textBox1.Text = reader["TName"].ToString();
                    this.textBox2.Text = reader["Tsex"].ToString();
                    this.textBox3.Text = reader["TPassWord"].ToString();
                    this.textBox4.Text = reader["TID"].ToString();
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

        #region 增加
        private void InsertTea()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format("  insert into Teacher values('{0}','{1}','{2}','{3}')",
                    textBox4.Text.Trim(), textBox3.Text.Trim(), textBox1.Text.Trim(), textBox2.Text.Trim());

                SqlCommand cmd = new SqlCommand(sql, dBHelper.Connection);
                dBHelper.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
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

        #region 修改
        private void UpdateTea()
        {
            DBHelper dBHelper = new DBHelper();

            try
            {
                string sql = string.Format(@"update Teacher
  set Teacher.TID = '{0}', TName = '{1}', Tsex = '{2}', TPassWord = '{3}'
  where TUserID = '{4}' ; Update KC set KC.TName=Teacher.TName FROM KC , Teacher where KC.TID='{5}'", textBox4.Text.Trim(), textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), ttID, textBox4.Text.Trim());

                SqlCommand cmd = new SqlCommand(sql, dBHelper.Connection);

                dBHelper.OpenConnection();

                int result = cmd.ExecuteNonQuery();
                if (result >0)
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
