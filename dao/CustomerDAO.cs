using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Three_Tier_Architecture_Application.model;

namespace Three_Tier_Architecture_Application.dao
{
    public class CustomerDAO
    {
        private static readonly string maincon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public CustomerDAO()
        {
        }
        protected SqlConnection GetConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(maincon);
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return connection;
        }
        public void InsertCustomer(Customer customer)
        {
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Insert_Customer")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@name", customer.GetName());
                cmd.Parameters.AddWithValue("@emailid", customer.GetEmailid());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public List<Customer> DisplayCustomer()
        {
            List<Customer> listCustomer = new List<Customer>();
            try
            {

                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_Customer")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string name = reader["name"].ToString();
                    string email = reader["emailid"].ToString();
                    listCustomer.Add(new Customer(id, name, email));
                }
                con.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return listCustomer;
        }
        //public DataTable DisplayCustomer()
        //{
        //    DataTable dt = null;
        //    try
        //    {
        //        SqlDataAdapter adp = new SqlDataAdapter();
        //        SqlConnection con = GetConnection();
        //        SqlCommand cmd = new SqlCommand("SP_Display_Customer")
        //        {
        //            CommandType = CommandType.StoredProcedure,
        //            Connection = con
        //        };
        //        adp = new SqlDataAdapter(cmd);
        //        dt = new DataTable();
        //        adp.Fill(dt);
        //    }
        //    catch (SqlException e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    return dt;
        //}
    }
}