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
    public partial class LB : Form
    {
        DataSet ds = new DataSet();

        public LB()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LB_Load(object sender, EventArgs e)
        {
            FillCommodityInfo();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FillCommodityInfo();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            LBtj lBtj = new LBtj();
            lBtj.kcID = 0;//表示新增
            lBtj.ShowDialog();
            this.FillCommodityInfo();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LBtj lBtj = new LBtj();
            lBtj.kcID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            lBtj.ShowDialog();
            this.FillCommodityInfo();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Deakc();
        }


        #region 显示表
        public void FillCommodityInfo()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = @"select KID 编号,FID 课程编号,FName 课程名, TID 教师学号,TName 姓名 from KC";
                //创建适配器 
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                //适配器填充表
                adapter.Fill(ds, "Commodity");
                //绑定表的数据源
                this.dataGridView1.DataSource = this.ds.Tables["Commodity"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库操作错误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        #endregion

        #region 删除表数据

        //删除表数据
        private void Deakc()
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("确定要删除名称为" + dataGridView1.CurrentRow.Cells[1].Value, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DBHelper dBHelper = new DBHelper();

                    try
                    {
                        string sql = string.Format("delete from KC where KID={0}", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));

                        SqlCommand cmd = new SqlCommand(sql, dBHelper.Connection);

                        dBHelper.OpenConnection();

                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("执行成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.FillCommodityInfo();
                        }

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

            }

        }




        #endregion


    }
}
