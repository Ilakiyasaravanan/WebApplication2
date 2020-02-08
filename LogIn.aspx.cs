using System;
using System.Data.SqlClient;
using JobPortal_BL;
namespace JobPotal_Entity
{
    public partial class LogIn : System.Web.UI.Page
    {
        string passWord;
        long userName;
        protected void LoginButton(object sender, EventArgs e)
        {
            userName = long.Parse(txtAccountNumber.Text);
            passWord = txtPassword.Text;
            try
            {
                string role= new LogInMediator().Login(userName,passWord);                                      
                Response.Write(role);
            }
            catch
            {
                Response.Write("Check your entries!");
               
            }

        }

    }
}