using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace JobPortal_Web
{
	public class Connection
	{
        public static SqlConnection ConnectionEstablish()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["jobDB"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }
    }
}