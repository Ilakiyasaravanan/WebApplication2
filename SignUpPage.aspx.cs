using System;
using JobPortal_BL;
using JobPortal_Entity;
using JobPotal_Entity;

namespace JobPotal_Entity
{
	public partial class SignUpPage : System.Web.UI.Page
	{
		string passWord, role, firstName, lastName, address, gender, email;
		long phone;
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		

		protected void SignUp_Click(object sender, EventArgs e)
		{

			firstName = txtFirstname.Text;
			lastName = txtLastName.Text;
			address = txtAddress.Text;
			passWord = txtPassword.Text;
			gender = rdGender.Text;
			email = txtEmail.Text;
			role = rdUser.Text;
			phone = long.Parse(txtPhonenumber.Text);
			GenerateAccount();
		}

		public void GenerateAccount()
		{
			string temp = email + firstName;
			long hashcode = Math.Abs(temp.GetHashCode());
			string verify = new RepositoryMediator().AccountCheck(hashcode);
			if (verify.Equals("Job Searcher") || verify.Equals("Recruiter"))
			{
				Response.Write("Retry with another name and email id");
			}
			else
			{
				PersonDetails person = new PersonDetails(firstName, phone, lastName, address, passWord, gender, role, email, hashcode);
				
			    int result= new RepositoryMediator().CreateAccount(person);
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