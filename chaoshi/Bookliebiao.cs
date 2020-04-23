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
    public partial class Bookliebiao : Form
    {
        #region 构造函数
        public Bookliebiao()
        {
            InitializeComponent();
        }
        #endregion

        #region 变量

        DataSet ds = new DataSet();
        #endregion

        #region 事件

        #region 切换副本

        //选择被更改
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }
        #endregion

        #region 无用

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsmiModifyPwd_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        } 
        #endregion

        #region 打开修改窗体
        //打开课程修改窗体
        private void 课程修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kcxg kcxg = new kcxg();
            kcxg.kID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            kcxg.ShowDialog();
            this.FillCommodityInfo();
        } 
        #endregion

        #region 课程增加
        private void 课程增加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kcxg kcxg = new kcxg();
            kcxg.kID = 0;//表示新增
            kcxg.ShowDialog();
            this.FillCommodityInfo();
        } 
        #endregion

        #region 课程删除
        private void 课程删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deakc();
        } 
        #endregion

        #region 关于
        //关于窗口
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsmguanyu gy = new tsmguanyu();

            //让此对话框一直显示，这个不关闭其他都不能关闭
            gy.ShowDialog();
        }
        #endregion

        #region 教师显示
        //显示教师信息
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FillCommodityInfo();
        }
        #endregion

        #region 学生显示
        //显示学生信息
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FillCommodityInfo1();
        }
        #endregion

        #region 课程显示
        //显示课程信息
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FillCommodityInfo2();
        } 
        #endregion

        #region 增加教师数据事件
        //增加教师数据事件
        private void 修改数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit ed = new Edit();
            ed.ttID = 0;//表示新增
            ed.ShowDialog();
            this.FillCommodityInfo();
        } 
        #endregion

        #region 修改教师数据事件
        //修改教师数据事件
        private void 修改数据ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Edit ed = new Edit();

            ed.ttID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            ed.ShowDialog();

            this.FillCommodityInfo();
        }
        #endregion

        #region 删除教师数据事件
        //删除教师数据事件
        private void 删除数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeaTea();
        }
        #endregion

        #region 学生数据修改
        //学生数据修改
        private void 修改数据ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StuEdit stued = new StuEdit();
            stued.ssID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value); ;//表示新增
            stued.ShowDialog();
            this.FillCommodityInfo1();
        }
        #endregion

        #region 学生数据增加
        //学生数据增加
        private void 增加数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StuEdit stued = new StuEdit();
            stued.ssID = 0;//表示新增
            stued.ShowDialog();
            this.FillCommodityInfo1();
        }
        #endregion

        #region 学生数据删除
        //学生数据删除
        private void 删除数据ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeaStu();
        } 
        #endregion

        #region 加载窗体
        //窗体加载
        private void Bookliebiao_Load(object sender, EventArgs e)
        {
            FillCommodityInfo();
        }
        #endregion

        #region 退出
        //退出
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion

        #region 方法

        #region 添加DataGridView控件
        /// <summary>
        /// 填充dataGridView1控件
        /// </summary>
        #region 显示教师表
        public void FillCommodityInfo()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = @"select TUserID 编号, TID 教师学号,TPassWord 教师密码,TName 姓名,Tsex 性别 from Teacher";
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

        #region 显示学生表
        public void FillCommodityInfo1()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = @"select MUserID 编号,MID 学生学号,MPassWord 学生密码,MName 姓名,Msex 性别 ,Mclass 班级 ,MclassID 班级序号 from Student";
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

        #region 显示课程表
        public void FillCommodityInfo2()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = @"select F.Fnum 编号, F.FID 课程号, F.FName 课程名 from F";
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

        #region 删除教师表数据

        //删除教师表数据
        private void DeaTea()
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("确定要删除名称为" + dataGridView1.CurrentRow.Cells[1].Value, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DBHelper dBHelper = new DBHelper();

                    try
                    {
                        string sql = string.Format("delete from KC where TID=(select Teacher.TID from Teacher where TUserID='{1}');delete from Teacher where TUserID='{0}'", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));

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

        #region 删除学生表数据

        //删除学生表数据
        private void DeaStu()
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("确定要删除名称为" + dataGridView1.CurrentRow.Cells[1].Value, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DBHelper dBHelper = new DBHelper();

                    try
                    {
                        string sql = string.Format("delete from Student where MUserID='{0}'", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));

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

        #region 删除课程表数据

        //删除课程表数据
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
                        string sql = string.Format("delete from KC where FID=(select F.FID from F where Fnum='{1}');delete from F where Fnum='{0}'", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));

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

        #endregion

        #endregion


    }
}
