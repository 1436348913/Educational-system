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
    public partial class LBtj : Form
    {
        public int kcID = 0;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        public LBtj()
        {
            InitializeComponent();
        }
        //查询课程
        private void button1_Click(object sender, EventArgs e)
        {
         
        }
        //查询教师
        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void LBtj_Load(object sender, EventArgs e)
        {
            if (kcID == 0)//添加
            {
                GetKXK();
                GetTxk();
            }
            else //修改
            {
                //将信息显示在修改窗体
                GetKXK();
                GetTxkx();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (kcID == 0)  //新增
                {
                    InsertK();
                }
                else//修改
                {
                    Updatek();
                }
            }
        }


        #region 检查窗体输入
        private bool CheckInput()
        {
            bool ok = true;
            if (comboBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("课程号不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ok = false;
            }
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("请点击查询", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ok = false;
            }
            if (comboBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("教师号不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ok = false;
            }
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("请点击查询不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ok = false;
            }
            return ok;
        }
        #endregion


        #region 增加
        private void InsertK()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format("  insert into KC values('{0}','{1}','{2}','{3}')",
                    comboBox1.Text.Trim(),textBox1.Text.Trim(), comboBox2.Text.Trim(), textBox2.Text.Trim());

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
        private void Updatek()
        {
            DBHelper dBHelper = new DBHelper();

            try
            {
                string sql = string.Format(@"update KC
  set KC.FID = '{0}', FName = '{1}', TID = '{2}', TName = '{3}'
  where KID = '{4}'", comboBox1.Text.Trim(), textBox1.Text.Trim(), comboBox2.Text.Trim(), textBox2.Text.Trim(),kcID);

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetkckFFF();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetkcktTT();
        }



        #region 查询

        private void GetkckFFF()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format("select FName from F where FID='{0}'", comboBox1.Text.Trim());

                SqlCommand cmd = new SqlCommand(sql, dBHelper.Connection);

                dBHelper.OpenConnection();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    this.textBox1.Text = reader["FName"].ToString();
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

        private void GetkcktTT()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format("select * from Teacher where TID='{0}'", comboBox2.Text.Trim());

                SqlCommand cmd = new SqlCommand(sql, dBHelper.Connection);

                dBHelper.OpenConnection();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    this.textBox2.Text = reader["TName"].ToString();

                }

                reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("数据库错误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                dBHelper.CloseConnection();
            }
        }

        #endregion

        #region 将信息获取到窗体
        private void GetTxk()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format("select Teacher.TID from Teacher ");
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                adapter.Fill(ds, "tkcr");
                this.comboBox2.DataSource = ds.Tables["tkcr"];
                this.comboBox2.DisplayMember = "TID";

            }
            catch (Exception)
            {
                MessageBox.Show("xk数据库操作错误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                dBHelper.CloseConnection();
            }
        }
        private void GetTxkx()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format("select KC.TID from KC WHERE KID='{0}'",kcID);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                adapter.Fill(ds, "tkcr");
                this.comboBox2.DataSource = ds.Tables["tkcr"];
                this.comboBox2.DisplayMember = "TID";

            }
            catch (Exception)
            {
                MessageBox.Show("xk数据库操作错误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                dBHelper.CloseConnection();
            }
        }
        private void GetKXK()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format("select F.FID from F ");

                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                adapter.Fill(ds1, "tkc");
                this.comboBox1.DataSource = ds1.Tables["tkc"];
                this.comboBox1.DisplayMember = "FID";

            }
            catch (Exception)
            {
                MessageBox.Show("kxk数据库操作错误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                dBHelper.CloseConnection();
            }
        }




        #endregion
    }
}
