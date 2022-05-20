using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace AdoMvc.Models
{
    public class DbConfig
    {
        public SqlConnection sql { get; }

        public DbConfig()
        {
            string cnn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            sql = new SqlConnection(cnn);

        }
    }
}