using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Three_Tier_Architecture_Application.dao;

namespace Three_Tier_Architecture_Application
{
    public partial class display : System.Web.UI.Page
    {
        private CustomerDAO customerDAO;
        protected void Page_Init(object sender, EventArgs e)
        {
            customerDAO = new CustomerDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            r1.DataSource = customerDAO.DisplayCustomer();
            r1.DataBind();
        }
    }
}