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
    public partial class teacher : Form
    {
        #region 变量
        public TUser tuser;

        DataSet ds = new DataSet();
        #endregion

        #region 构造函数
        public teacher()
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
            FillCommodityInfo1();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FillCommodityInfo();
        }

        private void 商品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #region 加载窗体

        //加载窗体
        private void teacher_Load(object sender, EventArgs e)
        {
            FillCommodityInfo();//调用显示信息方法
        }

        #endregion

        #region 修改密码
        //修改密码
        private void tsmiModifyPwd_Click(object sender, EventArgs e)
        {
            //弹出修改密码窗口
            Txiugaimima xg = new Txiugaimima();
            xg.tuser = this.tuser;
            xg.Show();
        }
        #endregion

        #region 退出
        //退出
        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            //弹出提示框 确认后退出
            DialogResult dr = MessageBox.Show("确定要退出吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }

        #endregion

        #region 关于
        //关于
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsmguanyu gy = new tsmguanyu();

            //让此对话框一直显示，这个不关闭其他都不能关闭
            gy.ShowDialog();
        }
        #endregion

        #endregion

        #region 方法

        #region 添加DataGridView控件
        /// <summary>
        /// 填充dataGridView1控件
        /// </summary>
        /// 显示信息方法
        /// 
        #region 全班成绩
        public void FillCommodityInfo()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = @"select SID 编号,Student.MID 学号,Mclass 班级,MName 学生姓名,FName 科目,Score 成绩,TName 教师姓名
from score s 
join F f on s.FID=f.FID
join teacher t on t.TID= s.TID
join Student on Student.MID=s.MID
where t.TID='" + tuser.TuserName + "'";
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

        #region 不及格成绩
        public void FillCommodityInfo1()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = @"select Student.MID 学号,Mclass 班级,MName 学生姓名,FName 科目,Score 成绩,TName 教师姓名
from score s 
join F f on s.FID=f.FID
join teacher t on t.TID= s.TID
join Student on Student.MID=s.MID
where t.TID='" + tuser.TuserName + "' and score<60";
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

        #region 课程安排
        public void FillCommodityInfo3()
        {
            ds = new DataSet();
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = @"select KC.FName from KC where KC.TID='" + tuser.TuserName + "'";
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

        #endregion

        #endregion

        //修改事件
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Tscorexg tscorexg = new Tscorexg();
            tscorexg.tscorexgID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value); ;//表示新增
            tscorexg.ShowDialog();
            this.FillCommodityInfo();
        }

        private void 课程安排ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillCommodityInfo3();
        }
    }
}
