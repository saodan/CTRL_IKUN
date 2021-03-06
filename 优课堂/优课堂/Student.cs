﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace 优课堂
{
    public partial class Student : Form
    {
        int t=0;
        public Student()
        {
            InitializeComponent();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            User_list user_List = new User_list();
            string sql = string.Format("userName='{0}' and userPassword='{1}'", user.Text.ToString(), password.Text.ToString());
            int t=user_List.GetRecordCount(sql);
            if (skinCode1.CodeStr == skinWaterTextBox1.Text.ToString())
            {
                if (t > 0)
                {
                    Student_user student_User = new Student_user(user.Text.ToString());
                    this.Hide();
                    student_User.ShowDialog();
                    Application.ExitThread();
                }
                else
                {
                    t++;
                    MessageBox.Show("用户名或密码错误!", "提示");
                    user.Text = "";
                    password.Text = "";
                    if (t > 5)
                    {
                        MessageBox.Show("多次登录失败，可能不存在该用户");
                    }
                }
            }
            else
            {
                MessageBox.Show("验证码错误！", "提示");
                skinWaterTextBox1.Text = "";
            }
            
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            Student_ZC _ZC = new Student_ZC();
            this.Hide();
            _ZC.ShowDialog();
        }
    }
}
