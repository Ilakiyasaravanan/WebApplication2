using System;
using System.Data.SqlClient;
using System.Data;

namespace JobPortal_Web
{
	public class AccountRepository
	{
        string firstname, email,lastname, password, gender,address, role,phoneNumber;
        long account;
        public AccountRepository(PersonDetails person)
        {
            this.firstname = person.personFirstName;
            this.lastname = person.personLastName;
            this.password = person.personPassword;
            this.account = person.personUserId;
            this.role = person.personRole;
            this.address = person.personAddress;
            this.email = person.personEmail;
            this.phoneNumber = person.personPhoneNumber;
            this.gender = person.persongender;

        }
       
        public int AddDb()
        {
            SqlConnection sql = Connection.ConnectionEstablish();
            sql.Open();
            using (SqlCommand command = new SqlCommand("sp_SIGNUP", sql))  //sqlCommand class
            {
                command.CommandType = CommandType.StoredProcedure; //stored porrocedure

                SqlParameter param = new SqlParameter(); //paramter class

                param.ParameterName = "@Firstname";
                param.Value = firstname;
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Lastname";
                param.Value = lastname;
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Address";
                param.Value = address;
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Email";
                param.Value = email;
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Password";
                param.Value = password;
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Role";
                param.Value = role;
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(param);                

                param = new SqlParameter();
                param.ParameterName = "@AccountNumber";
                param.Value = account;
                param.SqlDbType = System.Data.SqlDbType.BigInt;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Phonenumber";
                param.Value = phoneNumber;
                param.SqlDbType = System.Data.SqlDbType.BigInt;
                command.Parameters.Add(param);


                param = new SqlParameter();
                param.ParameterName = "@Gender";
                param.Value = gender;
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(param);

                int rows= command.ExecuteNonQuery();
                if (rows == 1)
                {
                    return 1;
                }
                sql.Close();
                return 0;
                
                
                
            }
          

        }
     /*   public string AccountExists(long user)
        {

            SqlConnection sql = Connection.ConnectionEstablish();
            sql.Open();

            using (SqlCommand command = new SqlCommand("USERNAMEEEXISTS", sql))  //sqlCommand class
            {
                command.CommandType = CommandType.StoredProcedure; //stored porrocedure

                SqlParameter param = new SqlParameter(); //paramter class

                param.ParameterName = "@UserName";
                param.Value = userName;
                param.SqlDbType = System.Data.SqlDbType.BigInt;
                command.Parameters.Add(param);



                command.Parameters.Add("@Role", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();
                string s = Convert.ToString(command.Parameters["@Role"].Value);
                Console.WriteLine("after" + s);

                sql.Close();
                return s;

            }
        }*/
    }
}