using System;
using JobPortal_BL;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using JobPortal_Entity;
namespace JobPotal_Web
{
	public partial class GridSample : System.Web.UI.Page
	{
		string Firstname, Lastname, Address, Email, Role, Gender, Password;
		long Phonenumber;
		long id;
		public GridSample(long accountnumber)
		{
			this.id = accountnumber;
		}
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!Page.IsPostBack)
			{
				FillData();
			}
		}

		protected void FillData()
		{
			SqlConnection con = new ConnectionMediator().ConnectionProvider();
			SqlCommand cmd = new SqlCommand("sp_JOBPORTALGRID_VIEW", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@userid", id);
			SqlDataAdapter sda = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			sda.Fill(dt);
			JobPortalView.DataSource = dt;
			JobPortalView.DataBind();
		}
		protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			SqlConnection con = new ConnectionMediator().ConnectionProvider();
			int id = Convert.ToInt16(JobPortalView.DataKeys[e.RowIndex].Values["AccountId"].ToString());
			con.Open();
			SqlCommand cmd = new SqlCommand("sp_JOBPORTALGRID_DELETE", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Id", id);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			FillData();
		}
		protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
		{
			JobPortalView.EditIndex = e.NewEditIndex;
			FillData();
		}
		protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			JobPortalView.EditIndex = -1;
			FillData();
		}
		protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			SqlConnection con = new ConnectionMediator().ConnectionProvider();
			int id = Convert.ToInt32((JobPortalView.Rows[e.RowIndex].FindControl("TxtId") as TextBox).Text);
			string firstname = (JobPortalView.Rows[e.RowIndex].FindControl("TxtName") as TextBox).Text;
			string lastname = (JobPortalView.Rows[e.RowIndex].FindControl("TxtLastName") as TextBox).Text;
			string address = (JobPortalView.Rows[e.RowIndex].FindControl("TxtAddress") as TextBox).Text;
			string gender = (JobPortalView.Rows[e.RowIndex].FindControl("TxtGender") as TextBox).Text;
			string role =(JobPortalView.Rows[e.RowIndex].FindControl("TxtRole") as TextBox).Text;
			string password = (JobPortalView.Rows[e.RowIndex].FindControl("TxtPassword") as TextBox).Text;
			string email =(JobPortalView.Rows[e.RowIndex].FindControl("TxtEmail") as TextBox).Text;
			long phonenumber = long.Parse((JobPortalView.Rows[e.RowIndex].FindControl("TxtPhone") as TextBox).Text);
			con.Open();
			SqlCommand cmd = new SqlCommand("sp_JOBPORTALGRID_UPDATE", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@id", id);
			cmd.Parameters.AddWithValue("@firstname", firstname);
			cmd.Parameters.AddWithValue("@lastname", lastname);
			cmd.Parameters.AddWithValue("@phonenumber", phonenumber);
			cmd.Parameters.AddWithValue("@address",address);
			cmd.Parameters.AddWithValue("@gender",gender);
			cmd.Parameters.AddWithValue("@role", role);
			cmd.Parameters.AddWithValue("@email", email);
			cmd.Parameters.AddWithValue("@password", password);

			cmd.ExecuteNonQuery();
			con.Close();
			JobPortalView.EditIndex = -1;
			FillData();
		}

		protected void GridView_Inserting(object sender, EventArgs e)
		{
			try
			{
				Firstname = (JobPortalView.FooterRow.FindControl("txtFirstName") as TextBox).Text;
				Phonenumber = Convert.ToInt64((JobPortalView.FooterRow.FindControl("txtPhone") as TextBox).Text);
				Lastname = (JobPortalView.FooterRow.FindControl("txtLastName") as TextBox).Text;
				Address = (JobPortalView.FooterRow.FindControl("txtAddress") as TextBox).Text;
				Email = (JobPortalView.FooterRow.FindControl("txtEmail") as TextBox).Text;
				Role = (JobPortalView.FooterRow.FindControl("txtRole") as TextBox).Text;
				Gender = (JobPortalView.FooterRow.FindControl("txtGender") as TextBox).Text;
				Password = (JobPortalView.FooterRow.FindControl("txtPassword") as TextBox).Text;
				GenerateId();
			}
			catch(Exception)
			{
				Response.Write("Input all details");
			}
			
		}
		void GenerateId()
		{

			string temp = Email + Firstname;
			long hashcode = Math.Abs(temp.GetHashCode());
			string verify = new RepositoryMediator().AccountCheck(hashcode);
			if (verify.Equals("Job Searcher") || verify.Equals("Recruiter"))
			{
				Response.Write("Retry with another name and email id");
			}
			else
			{
				PersonDetails person = new PersonDetails(Firstname, Phonenumber, Lastname, Address, Password, Gender, Role, Email, hashcode);

				int result = new RepositoryMediator().CreateAccount(person);
				if (result == 1)
				{

					Response.Write("signin successfully!!! Your account number is: " + hashcode);
				}
				else
				{
					Response.Write("Unable to create account");
				}

			}
		}
	}


}
