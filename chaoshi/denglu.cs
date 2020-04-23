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
    public partial class denglu : Form
    {
        #region 变量
        TUser tuser = new TUser();
        SUser suser = new SUser();
        User user = new User();
        #endregion

        #region 构造函数
        public denglu()
        {
            InitializeComponent();
        }
        #endregion

        #region 事件

        #region 验证
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (CheckInput())
            {
                //管理员登录验证
                if (Login() && radioButton1.Checked)
                {
                    user.UserName = txtName.Text.Trim();
                    user.Password = txtPwd.Text.Trim();
                    MessageBox.Show("登录成功");

                    //打开图书的窗口
                    bookchuangti bct = new bookchuangti();

                    //将登录信息以对象的形式保存起来，在窗体之间传值
                    bct.user = user;

                    bct.Show();

                    //隐藏登录窗口
                    this.Hide();
                }


                //教师登录验证
                else if (Login() && radioButton2.Checked)
                {
                    tuser.TuserName = txtName.Text.Trim();
                    tuser.Tpassword = txtPwd.Text.Trim();
                    MessageBox.Show("登录成功");

                    //打开教师的窗口
                    teacher tea = new teacher();


                    //将登录信息以对象的形式保存起来，在窗体之间传值
                    tea.tuser = tuser;

                    tea.Show();
                    //隐藏登录窗口
                    this.Hide();
                }


                //学生登录验证
                else if (Login() && radioButton3.Checked)
                {
                    suser.SuserName = txtName.Text.Trim();
                    suser.Spassword = txtPwd.Text.Trim();
                    MessageBox.Show("登录成功");

                    //打开学生的窗口
                    student stu = new student();


                    //将登录信息以对象的形式保存起来，在窗体之间传值
                    stu.suser = suser;
                    stu.Show();
                    //隐藏登录窗口
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("登录失败");
                }
            }
        }
        #endregion

        #region 未使用

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        } 
        #endregion
        #endregion

        #region 方法

        #region 非空验证
        //输入非空验证
        private bool CheckInput()
        {
            //判断输入的数据是否为空。--  Trim去掉框中前后空格
            if(txtName.Text.Trim()==""||txtPwd.Text.Trim()=="")
            {
                //弹出提示框
                MessageBox.Show("请输入用户名和密码");
                return false;
            }
            return true;
        }
        #endregion

        #region 登录
        //登录 如果返回true登录成功 false登录失败
        public bool Login()
        {
            bool flag = false;
            //获取用户名和密码
            string name = txtName.Text.Trim();
            string pwd = txtPwd.Text.Trim();
            //创建连接对象
            DBHelper dbHelper = new DBHelper();
            try
            {
               
                if (radioButton1.Checked)
                {
                    //1.创建sql语句
                    string sql = string.Format("select *from [User] where UserName='{0}' and PassWord='{1}'", name, pwd);


                    //2.command工具
                    SqlCommand cmd = new SqlCommand(sql, dbHelper.Connection);
                    //3.打开连接
                    dbHelper.OpenConnection();
                    //4.执行
                    SqlDataReader reader = cmd.ExecuteReader();
                    //5.判断
                    if (reader.Read())
                    {
                        //将所有的属性读出来
                        user.UserID = Convert.ToInt32(reader[0]);
                        user.UserName = reader[1].ToString();
                        user.Password = reader[2].ToString();
                        flag = true;
                    }
                }

                if (radioButton2.Checked)
                {
                    //1.创建sql语句
                    string sql = string.Format("select *from [Teacher] where TID='{0}' and TPassWord='{1}'", name, pwd);


                    //2.command工具
                    SqlCommand cmd = new SqlCommand(sql, dbHelper.Connection);
                    //3.打开连接
                    dbHelper.OpenConnection();
                    //4.执行
                    SqlDataReader reader = cmd.ExecuteReader();
                    //5.判断
                    if (reader.Read())
                    {
                        //将所有的属性读出来
                        tuser.TuserID = Convert.ToInt32(reader[4]);
                        tuser.TuserName = reader[0].ToString();
                        tuser.Tpassword = reader[1].ToString();
                        flag = true;
                    }
                }
                if (radioButton3.Checked)
                {
                    //1.创建sql语句
                    string sql = string.Format("select *from [Student] where MID='{0}' and MPassWord='{1}'", name, pwd);


                    //2.command工具
                    SqlCommand cmd = new SqlCommand(sql, dbHelper.Connection);
                    //3.打开连接
                    dbHelper.OpenConnection();
                    //4.执行
                    SqlDataReader reader = cmd.ExecuteReader();
                    //5.判断
                    if (reader.Read())
                    {
                        //将所有的属性读出来
                        suser.SuserID = Convert.ToInt32(reader[5]);
                        suser.SuserName = reader[0].ToString();
                        suser.Spassword = reader[1].ToString();
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生异常" + ex.Message);
            }
            finally
            {
                dbHelper.CloseConnection();
            }
            return flag;
        }
        #endregion

        #region 取消
        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        #endregion

        #endregion


    }
}
