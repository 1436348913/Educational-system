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
    public partial class kcxg : Form
    {
        public int kID = 0;

        public kcxg()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 保存
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (kID == 0)  //新增
                {

                    InsertKc();

                }
                else//修改
                {
                    Updatekc();
                }
            }
        }
        #endregion

        #region 加载
        private void kcxg_Load(object sender, EventArgs e)
        {
            if (kID == 0)//添加
            {
                textBox1.ReadOnly = false;
            }
            else //修改
            {
                //将信息显示在修改窗体
                this.Getkckc();

            }
        } 
        #endregion


        #region 检查窗体输入
        private bool CheckInput()
        {
            bool ok = true;

            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("课程号不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ok = false;
            }

            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("课程名不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ok = false;
            }

            return ok;
        }
        #endregion

        #region 将信息获取到窗体


        private void Getkckc()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format("select * from F where Fnum={0}", kID);

                SqlCommand cmd = new SqlCommand(sql, dBHelper.Connection);

                dBHelper.OpenConnection();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    this.textBox2.Text = reader["FName"].ToString();
                    this.textBox1.Text = reader["FID"].ToString();
                }
                reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("错误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                dBHelper.CloseConnection();
            }
        }

        #endregion

        #region 增加
        private void InsertKc()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format("  insert into F values('{0}','{1}')",
                    textBox1.Text.Trim(), textBox2.Text.Trim());

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
        private void Updatekc()
        {
            DBHelper dBHelper = new DBHelper();

            try
            {
                string sql = string.Format(@"update F set F.FName='{0}' where F.FID='{1}' ; Update KC set KC.FName=F.FName FROM KC , F where KC.FID=F.FID", textBox2.Text.Trim(), textBox1.Text.Trim(), kID);

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


    }
}
