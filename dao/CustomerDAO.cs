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
        private SqlConnection GetConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(maincon);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return connection;
        }
        public Int32 InsertCustomer(Customer customer)
        {
            SqlConnection con = GetConnection();
            int result;
            try
            {
              
                SqlCommand cmd = new SqlCommand("SP_Insert_Customer")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@name", customer.GetName());
                cmd.Parameters.AddWithValue("@emailid", customer.GetEmailid());
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public DataSet DisplayCustomer()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand("SP_Display_Customer")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        public Int32 DeleteCustomer(Customer customer)
        {
            SqlConnection con = GetConnection();
            int result;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_Delete_Customer")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@id", customer.GetId());
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public Int32 UpdateCustomer(Customer customer)
        {
            SqlConnection con = GetConnection();
            int result;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_Update_Customer")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@id",customer.GetId());
                cmd.Parameters.AddWithValue("@name", customer.GetName());
                cmd.Parameters.AddWithValue("@emailid", customer.GetEmailid());
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public Customer DisplayCustomerByID(int p_id)
        {
            SqlConnection con = GetConnection();
            Customer customer = new Customer();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Display_CustomerByID")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@id", p_id);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();
                cmd.Dispose();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["id"]);
                    string name = dr["name"].ToString();
                    string emailid = dr["emailid"].ToString();
                    customer = new Customer(id,name,emailid);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return customer;
        }
    }
}