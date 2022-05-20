using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AdoMvc.ViewModel;

namespace AdoMvc.Models
{
    public class countyDb
    {
        private DbConfig db = new DbConfig();

        public List<Entities> GetCountry()
        {
            SqlCommand cmd = new SqlCommand("sp_country", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;
            if (db.sql.State == ConnectionState.Closed)
            {
                db.sql.Open();
            }

            List<Entities> countries = new List<Entities>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Entities obj = new Entities();
                obj.Id = (int)reader[0];
                obj.Name = reader[1].ToString();
                countries.Add(obj);
            }
            db.sql.Close();
            return countries;
        }
    }
}