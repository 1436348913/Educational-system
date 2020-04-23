using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chaoshi
{
    public partial class bookchuangti : Form
    {
        #region 变量
        //将封装的数据传过来
        public User user;
        #endregion

        #region 构造函数
        public bookchuangti()
        {
            InitializeComponent();
        } 
        #endregion

        #region 事件
        private void label2_Click(object sender, EventArgs e)
        {

        }

        //退出当前窗口
        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            //弹出提示框 确认后退出
            DialogResult dr = MessageBox.Show("确定要退出吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }

        //修改密码
        private void tsmiModifyPwd_Click(object sender, EventArgs e)
        {
            //弹出修改密码窗口
            XiugaiPwd xg = new XiugaiPwd();
            xg.user = this.user;
            xg.Show();
        }

        //关于窗口
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsmguanyu gy = new tsmguanyu();

            //让此对话框一直显示，这个不关闭其他都不能关闭
            gy.ShowDialog();
        }

        //单击管理
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Bookliebiao lb = new Bookliebiao();
            //显示列表窗体
            lb.ShowDialog();
        }

        private void 商品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //显示课程信息
            LB lB = new LB();
            lB.ShowDialog();
        }
        #endregion


    }
}
