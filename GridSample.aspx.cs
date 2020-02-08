using System;
using JobPortal_BL;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using JobPortal_Entity;
using JobPortal_BL;
namespace JobPotal_Web
{
    public partial class GridSample : System.Web.UI.Page
    {
        string Firstname, Lastname,Address ,Email,Role , Gender, Password ;
        long Phonenumber;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                FillData();
            }
        }
        protected void FillData()
        {
            SqlConnection con =new ConnectionMediator().ConnectionProvider();
            SqlCommand cmd = new SqlCommand("select AccountId,FirstName,PhoneNumber,LastName,Address,Password,Gender,Role,Email,UserName from tbl_JOBPORTAL ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            JobPortalView.DataSource = dt;
            JobPortalView.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new ConnectionMediator().ConnectionProvider();
            int id = Convert.ToInt16(JobPortalView.DataKeys[e.RowIndex].Values["AccountId"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from tbl_JOBPORTAL where AccountId = @Id", con);
            cmd.Parameters.AddWithValue("@id", id);
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
            SqlConnection con = new ConnectionMediator().ConnectionProvider();
            int id = Convert.ToInt32((JobPortalView.Rows[e.RowIndex].FindControl("TxtId") as TextBox).Text);
            TextBox firstname = JobPortalView.Rows[e.RowIndex].FindControl("TxtName") as TextBox;
            long phonenumber = long.Parse((JobPortalView.Rows[e.RowIndex].FindControl("TxtPhone") as TextBox).Text);
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

        protected void GridView1_Inserting(object sender, EventArgs e)
        {
           Firstname = (JobPortalView.FooterRow.FindControl("txtFirstName") as TextBox).Text;
          Phonenumber = Convert.ToInt64((JobPortalView.FooterRow.FindControl("txtPhone") as TextBox).Text);
           Lastname= (JobPortalView.FooterRow.FindControl("txtLastName") as TextBox).Text;
            Address = (JobPortalView.FooterRow.FindControl("txtAddress") as TextBox).Text;
           Email = (JobPortalView.FooterRow.FindControl("txtEmail") as TextBox).Text;
             Role = (JobPortalView.FooterRow.FindControl("txtRole") as TextBox).Text;
             Gender = (JobPortalView.FooterRow.FindControl("txtGender") as TextBox).Text;
            Password= (JobPortalView.FooterRow.FindControl("txtPassword") as TextBox).Text;
            GenerateId();
            
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
