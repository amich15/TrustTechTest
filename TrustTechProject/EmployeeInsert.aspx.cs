using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrustTechProject
{
    public partial class EmployeeInsert : System.Web.UI.Page
    {
        string strCompanyNum = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                strCompanyNum = Request.QueryString["id"];
                txtCompanyNum.Text = strCompanyNum;
                ViewState["CompanyNum"] = strCompanyNum;
            }
        }

        private void InsertChanges()
        {
            try
            {
                string strInCompanyNum = ViewState["CompanyNum"].ToString();
                int intCompanyNum = int.Parse(strInCompanyNum);
                string strFname = txtFName.Text;
                string strLname = txtLName.Text;
                string strGender = rblGender.SelectedValue;
                string strEmpId = txtEmployeeId.Text;
                int empId = int.Parse(strEmpId);
                string strNewBirthDate = dt2.Value;
                DateTime birthDate;
                birthDate = new DateTime(Convert.ToInt16(strNewBirthDate.Substring(0, 4)), Convert.ToInt16(strNewBirthDate.Substring(5, 2)), Convert.ToInt16(strNewBirthDate.Substring(8, 2)));




                using (var db = new TrustCompanyEntities())
                {
                    var employees = db.Set<CompanyEmployee>();
                    employees.Add(new CompanyEmployee { CNum = intCompanyNum, Fname = strFname, Lname = strLname, Gender = strGender, EmployeeId = empId, BirthDate = birthDate });

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

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            InsertChanges();
        }

        protected void btnEmployees_Click(object sender, EventArgs e)
        {

            Response.Redirect("Companies.aspx");
        }

    }
}