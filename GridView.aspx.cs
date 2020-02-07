using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace JobPortal_Web
{
	public partial class GridView : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				FillData();
			}
		}
        protected void FillData()
        {
            SqlConnection con = Connection.ConnectionEstablish();
            SqlCommand cmd = new SqlCommand("select EmployeeId,EmployeeName,EmployeePhoneNumber from Employee", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Jobview.DataSource = dt;
            Jobview.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = Connection.ConnectionEstablish();
            int employeeId = Convert.ToInt16(Jobview.DataKeys[e.RowIndex].Values["EmployeeId"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Employee where @Employeeid =employeeId", con);
            cmd.Parameters.AddWithValue("@Employeeid", employeeId);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            FillData();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Jobview.EditIndex = e.NewEditIndex;
            FillData();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Jobview.EditIndex = -1;
            FillData();
        }
         
    }
}