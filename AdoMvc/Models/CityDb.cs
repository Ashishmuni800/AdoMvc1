using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AdoMvc.ViewModel;

namespace AdoMvc.Models
{
    public class CityDb
    {
        private DbConfig db = new DbConfig();

        public List<Entities> GetCity(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_city", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@id";
            sqlParameter.Value = id;
            sqlParameter.DbType = DbType.Int32;
            cmd.Parameters.Add(sqlParameter);

            if (db.sql.State == ConnectionState.Closed)
            {
                db.sql.Open();
            }

            List<Entities> cities = new List<Entities>();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Entities obj = new Entities();
                obj.Id = (int)reader[0];
                obj.Name = reader[1].ToString();
                cities.Add(obj);
            }
            db.sql.Close();
            return cities;
        }
    }
}