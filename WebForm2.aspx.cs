using System;


namespace JobPortal_Web
{
	public partial class WebForm2 : System.Web.UI.Page
	{
		//static string passWord, role,firstName, lastName, address,phone, gender,email;

		protected void SignUp_Click(object sender, EventArgs e)
		{
			//Response.Write("nithesh");
			Response.Write(Firstname.Text);
		}

		//protected void SignUp_Click(object sender, EventArgs e)
		//{
			//Response.Write( Firstname.Text);
			//	firstName = Request.Form["Firstname"];
			//	lastName = Request.Form["LastName"];
			//	address = Request.Form["Address"];
			//	passWord = Request.Form["Password"];
			//	gender = Request.Form["rdGender"];
			//	email = Request.Form["Email"];
			//	role = Request.Form["Role"];
			//	phone = Request.Form["Phonenumber"];
			//	GenerateAccount();
			
			
			
		//}
	//
		public void GenerateAccount()
		{
			//string temp = email + firstName;
			//long hashcode = Math.Abs(temp.GetHashCode());			
			//string verify=account.AccountExists();
			//PersonDetails person = new PersonDetails(firstName,phone, lastName, address, passWord, gender, role,email, hashcode);
			//AccountRepository account = new AccountRepository(person);
			//int result=account.AddDb();
			//if (result == 1)
			//{
				   
			//	Response.Write("Signin successfully");
			//}
			//else
			//{
			//	Response.Write("Unable to create account");
			//}
		}

	}
}