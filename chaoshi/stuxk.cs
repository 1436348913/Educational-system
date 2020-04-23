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
    public partial class stuxk : Form
    {
        public SUser suser;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        public stuxk()
        {
            InitializeComponent();
        }
        private void stuxk_Load(object sender, EventArgs e)
        {
            string s= suser.SuserName;
            textBox3.Text = s;
           GetKXK();
           
            
        }
        //课程查询
        private void button3_Click(object sender, EventArgs e)
        {
           
        }
        //教师查询
        private void button5_Click(object sender, EventArgs e)
        {
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 

            GetkckFF();
            this.comboBox2.DataSource = null;
            GetTxk();
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetkcktT();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 查询

        private void GetkckFF()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format("select FName from F where FID='{0}'",comboBox1.Text.Trim());

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

        private void GetkcktT()
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
                string sql = string.Format("select KC.TID from KC where KC.FID='{0}'", comboBox1.Text.Trim());
                SqlDataAdapter adapter = new SqlDataAdapter(sql,dBHelper.Connection);
                adapter.Fill(ds, "tkcr");
                this.comboBox2.DataSource = ds.Tables["tkcr"];
                this.comboBox2.DisplayMember = "TID";
                adapter.Dispose();
                this.ds.Tables.Clear();

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

        #region 增加
        private void InsertK()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = string.Format("  insert into score values('{0}','{1}','{2}','')", comboBox1.Text.Trim(),textBox3.Text.Trim(), comboBox2.Text.Trim());

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

        private void button1_Click(object sender, EventArgs e)
        {
            InsertK();
        }
    }
}
