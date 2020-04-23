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
    public partial class Sxiugaimima : Form
    {
        #region 变量
        public SUser suser;

        #endregion

        #region 构造函数
        public Sxiugaimima()
        {
            InitializeComponent();
        } 
        #endregion

        #region 事件

        #region 确认
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                int result = UpdataPwd();
                if (result > 0)
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
        }
        #endregion

        #region 退出
        //退出
        private void btnReturn_Click(object sender, EventArgs e)
        {
            //关闭修改密码窗口
            this.Close();
        }
        #endregion

        #endregion

        #region 方法
        #region 判断
        public bool CheckInput()
        {
            if (txtPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入原密码！");
                return false;
            }
            if (txtPwd.Text.Trim() != suser.Spassword)
            {
                MessageBox.Show("原密码输入错误,请重新输入！");
                return false;
            }
            if (txtXPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入新密码！");
                return false;
            }
            if (txtPwd.Text.Trim() == txtXPwd.Text.Trim())
            {
                MessageBox.Show("原密码和新密码输入相同，请重新输入！");
                return false;
            }
            if (txtXPwd.Text.Trim() != txtXpwd2.Text.Trim())
            {
                MessageBox.Show("两次密码输入不同，请重新输入！");
                return false;
            }
            return true;
        }
        #endregion

        #region 数据库更新密码
        /// <summary>
        /// 更新 如果返回值大于0更新成功 否则失败
        /// </summary>
        private int UpdataPwd()
        {
            //定义受影响的行数
            int result = 0;

            DBHelper dBHelper = new DBHelper();

            //sql 更新语句
            string sql = string.Format(@"update [Student] set MPassWord='{0}' where MID='{1}'", txtXPwd.Text.Trim(), suser.SuserName);

            try
            {
                //创建cmd
                SqlCommand cmd = new SqlCommand(sql, dBHelper.Connection);
                //打开连接
                dBHelper.OpenConnection();
                //执行
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //关闭连接
            finally
            {
                dBHelper.CloseConnection();
            }
            return result;
        }
        #endregion

        #endregion

    }
}
