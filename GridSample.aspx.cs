using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace JobPortal_Web
{
    public partial class GridSample : System.Web.UI.Page
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
            SqlCommand cmd = new SqlCommand("select AccountId,FirstName,PhoneNumber from tbl_JOBPORTAL ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            JobPortalView.DataSource = dt;
            JobPortalView.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = Connection.ConnectionEstablish();
            int Id = Convert.ToInt16(JobPortalView.DataKeys[e.RowIndex].Values["AccountId"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from tbl_JOBPORTAL where AccountId = Id", con);
            cmd.Parameters.AddWithValue("AccountId", Id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            FillData();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            JobPortalView.EditIndex = e.NewEditIndex;
            FillData();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            JobPortalView.EditIndex = -1;
            FillData();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = Connection.ConnectionEstablish();
            int id =Convert.ToInt32((JobPortalView.Rows[e.RowIndex].FindControl("TxtId") as TextBox).Text);
            TextBox firstname = JobPortalView.Rows[e.RowIndex].FindControl("TxtName") as TextBox;
            long phonenumber = long.Parse((JobPortalView.Rows[e.RowIndex].FindControl("TxtPhone")as TextBox).Text);           
            con.Open();
            SqlCommand cmd = new SqlCommand("Update tbl_JOBPORTAL SET FirstName=@firstname,PhoneNumber=@phonenumber WHERE AccountId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@firstname", firstname.Text);
            cmd.Parameters.AddWithValue("@phonenumber", phonenumber);          
            int i = cmd.ExecuteNonQuery();
            con.Close();
            JobPortalView.EditIndex = -1;
            FillData();
        }
    }
}