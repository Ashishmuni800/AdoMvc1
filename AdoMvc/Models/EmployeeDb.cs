using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using AdoMvc.ViewModel;

namespace AdoMvc.Models
{
    public class EmployeeDb
    {
        private DbConfig db = new DbConfig();

        public List<Employee> GetEmployees()
        {
            SqlCommand cmd = new SqlCommand("sp_emp",db.sql);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@action";
            sqlParameter.Value = "select";
            sqlParameter.DbType = DbType.String;
            cmd.Parameters.Add(sqlParameter);

            if (db.sql.State == ConnectionState.Closed)
            {
                db.sql.Open();
            }

            List<Employee> employees = new List<Employee>();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee obj = new Employee();
                obj.Id = (int)reader[0];
                obj.Name = reader[1].ToString();
                obj.Email = reader[2].ToString();
                obj.Mobile = reader[3].ToString();
                obj.Address = reader[4].ToString();
                obj.Gender = reader[5].ToString();
                obj.IsActive = reader[6].ToString();
                obj.Department =reader[7].ToString();
                employees.Add(obj);
            }
            db.sql.Close();
            return employees;
        }
    }
}