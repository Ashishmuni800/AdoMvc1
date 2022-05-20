using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdoMvc.ViewModel;
using System.Data.SqlClient;
using System.Data;

namespace AdoMvc.Models
{
    public class DepartmentDb
    {
        private DbConfig db = new DbConfig();

        public List<Department> GetDepartments()
        {
            SqlCommand cmd = new SqlCommand("sp_Department", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@Action";
            sqlParameter.Value = "select";
            sqlParameter.DbType = DbType.String;
            cmd.Parameters.Add(sqlParameter);

            if (db.sql.State == ConnectionState.Closed)
            {
                db.sql.Open();
            }

            List<Department> departments = new List<Department>();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Department obj = new Department();
                obj.Id =(int) reader[0];
                obj.Name = reader[1].ToString();
                departments.Add(obj);
            }
            db.sql.Close();
            return departments;
        }
        public void CreateList(Department dept)
        {
            SqlCommand cmd = new SqlCommand("sp_Department", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Action", "create");
            cmd.Parameters.AddWithValue("@Name", dept.Name);

            if (db.sql.State == ConnectionState.Closed)
                db.sql.Open();
            var result = cmd.ExecuteReader();
            db.sql.Close();
        }

        public void DeleteList(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_Department", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@Id", id);
            if (db.sql.State == ConnectionState.Closed)
                db.sql.Open();
            var result = cmd.ExecuteReader();
            db.sql.Close();
        }

        public void UpdateList(Department dpt)
        {
            SqlCommand cmd = new SqlCommand("sp_Department", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Action", "Update");
            cmd.Parameters.AddWithValue("@Id", dpt.Id);
            cmd.Parameters.AddWithValue("@Name", dpt.Name);
            
            if (db.sql.State == ConnectionState.Closed)
                db.sql.Open();
            var result = cmd.ExecuteReader();
            db.sql.Close();
        }
    }
}