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
    public partial class StuEdit : Form
    {
        #region 变量
        public int ssID = 0; 
        #endregion

        #region 构造方法
        public StuEdit()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        #region 保存按钮
        //保存
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (ssID == 0)  //新增
                {
                    InsertStu();
                }
                else//修改
                {
                    UpdateStu();


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

        #region 加载事件
        private void StuEdit_Load(object sender, EventArgs e)
        {
            if (ssID == 0)//添加
            {
            }
            else //修改
            {
                // 显示信息
                GetStu();
            }
        }
        #endregion 
        #endregion

        #region 方法

        #region 检查窗体输入

        private bool CheckInput()
        {
            bool ok = true;
            if (textBox1.Text.Trim().Length == 0)
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
                MessageBox.Show("学生号不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ok = false;
            }
            if (textBox5.Text.Trim().Length == 0)
            {
                MessageBox.Show("班级不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ok = false;
            }
            if (textBox6.Text.Trim().Length == 0)
            {
                MessageBox.Show("班序号不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ok = false;
            }
            return ok;
        }




        #endregion

        #region 将信息获取到窗体
        private void GetStu()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format("select * from Student where MUserID={0}", ssID);

                SqlCommand cmd = new SqlCommand(sql, dBHelper.Connection);

                dBHelper.OpenConnection();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    this.textBox1.Text = reader["MName"].ToString();
                    this.textBox2.Text = reader["Msex"].ToString();
                    this.textBox3.Text = reader["MPassWord"].ToString();
                    this.textBox4.Text = reader["MID"].ToString();
                    this.textBox5.Text = reader["Mclass"].ToString();
                    this.textBox6.Text = reader["MclassID"].ToString();
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
        private void UpdateStu()
        {
            DBHelper dBHelper = new DBHelper();

            try
            {
                string sql = string.Format(@"update Student
  set Student.MID = '{0}', MName = '{1}', Msex = '{2}', MPassWord = '{3}',Mclass='{4}',MclassID='{5}'
  where MUserID = '{6}'", textBox4.Text.Trim(), textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox5.Text.Trim(), textBox6.Text.Trim(), ssID);

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

        #region 增加
        private void InsertStu()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format("  insert into Student values('{0}','{1}','{2}','{3}','{4}','{5}')",
                    textBox4.Text.Trim(), textBox3.Text.Trim(), textBox1.Text.Trim(), textBox2.Text.Trim(), textBox5.Text.Trim(),textBox6.Text.Trim());

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

        #endregion





    }
}
