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
    public partial class student : Form
    {
        #region 变量
        public SUser suser;

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        #endregion

        #region 构造函数
        public student()
        {
            InitializeComponent();

        }

        #endregion

        #region 事件
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
        //显示个人成绩
        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            FillCommodityInfo();//调用显示信息方法
        }
        //显示全系成绩
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FillCommodityInfo2();
        }
        //显示全班成绩
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FillCommodityInfo1();
        }


        private void tsmiModifyPwd_Click(object sender, EventArgs e)
        {
            //弹出修改密码窗口
            Sxiugaimima xg = new Sxiugaimima();
            xg.suser = this.suser;
            xg.Show();
        }

        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            //弹出提示框 确认后退出
            DialogResult dr = MessageBox.Show("确定要退出吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsmguanyu gy = new tsmguanyu();

            //让此对话框一直显示，这个不关闭其他都不能关闭
            gy.ShowDialog();
        }

        private void student_Load(object sender, EventArgs e)
        {
            FillCommodityInfo();//调用显示信息方法
        }

        #endregion

        #region 方法

        #region 添加DataGridView控件

        #region 个人成绩
        /// <summary>
        /// 填充dataGridView1控件
        /// </summary>
        /// 显示信息方法

        /// 个人成绩
        public void FillCommodityInfo()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                if (suser.SuserName != null)
                {
                    string sql = @"select Mclass 班级,MName 姓名,Msex 性别,FName 课程名,Score 成绩,TName 老师
                                          from [Student] t 
                                          join score s on t.MID=s.MID
                                          join F f on s.FID=f.FID
                                          join Teacher e on s.TID=e.TID
                                          where t.MID='" + suser.SuserName + "'";

                    //创建适配器 
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dBHelper.Connection);
                    //适配器填充表
                    adapter.Fill(ds, "Commodity");
                    //绑定表的数据源
                    this.dataGridView1.DataSource = this.ds.Tables["Commodity"];
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
        #endregion

        #region 班级成绩
        //班级成绩
        public void FillCommodityInfo1()
        {

            ds1 = new DataSet();
            ds1.Tables.Clear();
            DBHelper dBHelper1 = new DBHelper();
            try
            {
                string a = suser.SuserName.Substring(1, 1);
                string sql = @"select MName 姓名,Mclass 班级,Msex 性别,
							总分=sum(score)
                            from Student t 
                            join score s on t.MID=s.MID
                            join F f on s.FID=f.FID 
                            join Teacher e on s.TID=e.TID 
                            where t.MclassID='" + a + "' group by MName,Mclass,Msex order by 总分 desc";

                //创建适配器 
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql, dBHelper1.Connection);
                //适配器填充表
                adapter1.Fill(ds1, "STUDENT");
                //绑定表的数据源
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = this.ds1.Tables["STUDENT"];


            }
            catch (Exception)
            {
                MessageBox.Show("数据库操作错误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        #endregion

        #region 年级成绩
        //年级成绩
        public void FillCommodityInfo2()
        {

            ds1 = new DataSet();
            ds1.Tables.Clear();
            DBHelper dBHelper1 = new DBHelper();
            try
            {

                string sql = @"select MName 姓名,Mclass 班级,Msex 性别,FName 单科成绩 ,Score 成绩
                            from Student t 
                            join score s on t.MID=s.MID
                            join F f on s.FID=f.FID 
                            join Teacher e on s.TID=e.TID 
                            where t.MID=s.MID order by 单科成绩,成绩 desc ";

                //创建适配器 
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql, dBHelper1.Connection);
                //适配器填充表
                adapter1.Fill(ds1, "STUDENT");
                //绑定表的数据源
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = this.ds1.Tables["STUDENT"];


            }
            catch (Exception)
            {
                MessageBox.Show("数据库操作错误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }





        #endregion

        #endregion

        #endregion

        private void 商品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stuxk stuxk = new stuxk();
            stuxk.suser = suser;
            stuxk.ShowDialog();

        }
    }
}
