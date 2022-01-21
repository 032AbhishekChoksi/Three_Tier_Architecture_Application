using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Three_Tier_Architecture_Application.dao;
using Three_Tier_Architecture_Application.model;

namespace Three_Tier_Architecture_Application
{
    public partial class index : System.Web.UI.Page
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
            Page.Title = "Registration Form";
           
            if (Request.QueryString["id"] != null && Request.QueryString["type"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                type = Request.QueryString["type"].ToString();
            }
            if (IsPostBack) return;

            if (id > 0 && type == "update")
            {
                RecordBindFields();
            }
        }

        protected void BttnSubmit_Click(object sender, EventArgs e)
        {
            
                string Name = txtName.Text;
                string EmailID = txtEmailID.Text;
                if (id == 0)
                {
                    InsertData(Name, EmailID);
                }
                else
                {
                    UpdateData(Name, EmailID);
                }
        }
        private void InsertData(string P_Name,string P_EmailID)
        {
            Customer customer = new Customer(); ;
           
            try
            {
                customer = new Customer(P_Name, P_EmailID);
                int retVal = customerDAO.InsertCustomer(customer);
                if (retVal > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Inserted Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Not Inserted Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void RecordBindFields()
        {
            Customer customer = new Customer();
            try
            {
                
                    customer = customerDAO.DisplayCustomerByID(id);
                    txtName.Text = customer.GetName();
                    txtEmailID.Text = customer.GetEmailid();
                
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
        private void UpdateData(string P_Name, string P_EmailID)
        {
            Customer customer = new Customer();
            try
            {
                customer = new Customer(id,P_Name, P_EmailID);
                int retVal = customerDAO.UpdateCustomer(customer);
                if (retVal > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Udate Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Not Udate Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }
    }
}