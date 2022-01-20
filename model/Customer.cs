using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Three_Tier_Architecture_Application.model
{
    public class Customer
    {
        protected int id;
        protected string name;
        protected string emailid;

        public Customer()
        {
            this.id = 0;
            this.name = string.Empty;
            this.emailid = string.Empty;
        }

        public Customer(int id, string name, string emailid)
        {
            this.id = id;
            this.name = name;
            this.emailid = emailid;
        }

        public Customer(string name, string emailid)
        {
            this.name = name;
            this.emailid = emailid;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetEmailid()
        {
            return emailid;
        }
        public void SetEmailid(string emailid)
        {
            this.emailid = emailid;
        }
       
    }

}