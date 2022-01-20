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
        protected void Page_Init(object sender, EventArgs e)
        {
            customerDAO = new CustomerDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Registration Form";
        }

        protected void BttnSubmit_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            string EmailID = txtEmailID.Text;
            Customer customer = new Customer(Name, EmailID);
            customerDAO.InsertCustomer(customer);
        }
    }
}