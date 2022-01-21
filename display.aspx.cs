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
            //ObjectDataSource objectData = new ObjectDataSource();
            //objectData.DataObjectTypeName = "Three_Tier_Architecture_Application.dao.CustomerDAO";
            //objectData.SelectMethod = "DisplayCustomer";
            //r1.DataSource = objectData.DataObjectTypeName;
            //objectData.DataBind();
            //r1.DataBind();
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
            finally
            {
                customerDAO = null;
            }
        }
    }    
}