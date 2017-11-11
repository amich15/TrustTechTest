using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrustTechProject
{
    public partial class EmployeeUpdate : System.Web.UI.Page
    {
      

        string strCompanyNum = "";
        int companyNum = 0;
        string strcompanyName = "";
        string strFname = "";
        string strLname = "";
        string strempId = "";
        int empId = 0;
        string strGender = "";
        string birthdate = "";
        DateTime BirthDate = new DateTime();

        CompanyEmployee empComp;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GetData();
        }

        private void UpdateChanges()
        {
            try
            {
                string strEmpId = ViewState["EmpId"].ToString();
                empId = int.Parse(strEmpId);


                using (var dtx = new TrustCompanyEntities())
                {

                    empComp = dtx.CompanyEmployees.Where(s => s.EmployeeId == empId).FirstOrDefault<CompanyEmployee>();

                }

                if (empComp != null)
                {
                    empComp.Fname = txtFName.Text;
                    empComp.Lname = txtLName.Text;
                    string strEmployeeId = txtEmployeeId.Text;
                    empComp.EmployeeId = int.Parse(strEmployeeId);
                    string gender = rblGender.SelectedValue;
                    empComp.Gender = gender;
                    string strNewBirthDate = dt1.Value;
                    BirthDate = new DateTime(Convert.ToInt16(strNewBirthDate.Substring(0, 4)), Convert.ToInt16(strNewBirthDate.Substring(5, 2)), Convert.ToInt16(strNewBirthDate.Substring(8, 2)));
                    empComp.BirthDate = BirthDate;


                }
                using (var dbCtx = new TrustCompanyEntities())
                {
                    dbCtx.Entry(empComp).State = System.Data.Entity.EntityState.Modified;

                    dbCtx.SaveChanges();
                }
                lblUpdateRow.Visible = true;
            }
            catch (Exception ex)
            {
                lblUpdateRow.Visible = true;
                lblUpdateRow.Text = ex.Message;
            }

        }

        private void DeleteEmployee()
        {

            try
            {
                strempId = ViewState["EmpId"].ToString();
                empId = int.Parse(strempId);

                using (var dtx = new TrustCompanyEntities())
                {

                    empComp = dtx.CompanyEmployees.Where(s => s.EmployeeId == empId).FirstOrDefault<CompanyEmployee>();
                    dtx.Entry(empComp).State = EntityState.Deleted;
                    dtx.SaveChanges();

                    lblUpdateRow.Text = "Employee Removed";
                    strCompanyNum = ViewState["CompanyNum"].ToString();
                    strcompanyName = ViewState["CompanyName"].ToString();
                    Response.Redirect("Employees.aspx?id=" + strCompanyNum + "&cName=" + strcompanyName, false);
                }
            }
            catch (Exception ex)
            {

                lblUpdateRow.Visible = true;
                lblUpdateRow.Text = ex.InnerException.InnerException.Message;

            }

        }

        protected void GetData()
        {
            try
            {

                strCompanyNum = Session["CompanyNum"].ToString();
                strcompanyName = Session["CompanyName"].ToString();
                strFname = Session["Fname"].ToString();
                strLname = Session["LName"].ToString();
                strempId = Session["EmpID"].ToString();
                strGender = Session["Gender"].ToString();
                birthdate = Session["BirthDate"].ToString();

                txtFName.Text = strFname;
                txtLName.Text = strLname;
                txtEmployeeId.Text = strempId;
                rblGender.SelectedValue = strGender;
                DateTime dtdate = DateTime.Parse(birthdate);
                string birthdate1 = dtdate.ToString("yyyy-MM-dd");


                dt1.Value = birthdate1;


                ViewState["EmpId"] = txtEmployeeId.Text;
                ViewState["CompanyNum"] = strCompanyNum;
                ViewState["CompanyName"] = strcompanyName;


            }
            catch (Exception ex)
            {
                lblUpdateRow.Visible = true;
                lblUpdateRow.Text = ex.Message;
            }
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateChanges();
        }

        protected void btnEmployees_Click(object sender, EventArgs e)
        {
            strCompanyNum = ViewState["CompanyNum"].ToString();
            strcompanyName = ViewState["CompanyName"].ToString();
            Response.Redirect("Employees.aspx?id=" + strCompanyNum + "&cName=" + strcompanyName);
        }

        protected void btnCompanies_Click(object sender, EventArgs e)
        {
            Response.Redirect("Companies.aspx");
        }


        protected void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            DeleteEmployee();
        }


    }
}