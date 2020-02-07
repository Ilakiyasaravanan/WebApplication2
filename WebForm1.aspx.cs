using System;
using System.Data.SqlClient;

namespace JobPortal_Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string passWord;
        long userName;
        protected void LoginButton(object sender, EventArgs e)
        {
            userName = long.Parse(txtAccountNumber.Text);
            passWord = txtPassword.Text;
            try
            {
               
                LoginManager login = new LoginManager();
                string role = login.LoginCheck(userName, passWord);
                Response.Write(role);
            }
            catch
            {
                Response.Write("Check your entries!");
               
            }

        }

    }
}