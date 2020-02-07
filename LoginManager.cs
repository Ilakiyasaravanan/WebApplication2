using System;
using System.Data.SqlClient;
using System.Data;
namespace JobPortal_Web
{
	public class LoginManager
	{
        public string LoginCheck(long userName,string passWord)
        {
            SqlConnection sqlConnection = Connection.ConnectionEstablish();
            sqlConnection.Open();
            using (SqlCommand command = new SqlCommand("sp_LOGIN", sqlConnection))  //sqlCommand class
            {
                command.CommandType = CommandType.StoredProcedure; //stored porrocedure

                SqlParameter param = new SqlParameter(); //parameter class

                param.ParameterName = "@UserName";
                param.Value = userName;
                param.SqlDbType = SqlDbType.BigInt;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Password";
                param.Value = passWord;
                param.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(param);

                command.Parameters.Add("@Role", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();
                sqlConnection.Close();
                return Convert.ToString(command.Parameters["@Role"].Value);            

            }
        }
    }
}