using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrustTechProject
{
    public partial class CompanyInsert : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void InsertChanges()
        {


            try
            {
                string newstrCompanyNum = txtCompanyNum.Text;
                int newintCompanyNum = int.Parse(newstrCompanyNum);
                string strCompanyName = txtCompanyName.Text;
                string strAddress = txtAddress.Text;
                string strTelephone = txtTelephone.Text;


                using (var db = new TrustCompanyEntities())
                {
                    var companies = db.Set<Company>();
                    companies.Add(new Company { CNum = newintCompanyNum, Cname = strCompanyName, Address = strAddress, Telephone = strTelephone });

                    db.SaveChanges();
                    lblRowInsert.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblRowInsert.Visible = true;
                lblRowInsert.Text = ex.Message;

            }

        }

        protected void btnComapnies_Click(object sender, EventArgs e)
        {
            Response.Redirect("Companies.aspx");
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            InsertChanges();
        }

    }
}