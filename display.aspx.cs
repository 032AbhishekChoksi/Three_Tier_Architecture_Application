using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Three_Tier_Architecture_Application.dao;
using Three_Tier_Architecture_Application.model;

namespace Three_Tier_Architecture_Application
{
    public partial class display : System.Web.UI.Page
    {
        private CustomerDAO customerDAO;
        private int id = 0;
        private string type = String.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            customerDAO = new CustomerDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {    
            
            if (Request.QueryString["id"] != null && Request.QueryString["type"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                type = Request.QueryString["type"].ToString();
            }

            if (IsPostBack) return;
            
            if (id > 0 && type == "delete")
            {
                DeleteUser();
            }

            BindRecordsRepeater();

        }
        private void BindRecordsRepeater()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = customerDAO.DisplayCustomer();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    r1.DataSource = ds;
                    r1.DataBind();
                }
                else
                {
                    r1.DataSource = null;
                    r1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
           
        }
        private void DeleteUser() {
            Customer customer = new Customer();
            try
            {
                customer.SetId(id);
                int retVal = customerDAO.DeleteCustomer(customer);
                if (retVal > 0)
                {
                    Response.Redirect("~/display.aspx",false);
                }
                else
                {
                    Response.Write("Not Deleted");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }            
        }
    }    
}