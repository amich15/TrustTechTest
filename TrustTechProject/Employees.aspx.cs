using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrustTechProject
{


    public partial class Employees : System.Web.UI.Page
    {

        string companyName = "";
        string address = "";
        string telephone = "";

        Company Comp;
        CompanyEmployee empComp;



        string strmaincNum = "";
        int companyNum = 0;
        public string strCname = "";
        string strFname = "";
        string strLName = "";
        string strempId = "";
        string strgender = "";
        string strbirthdate = "";
        DateTime birthdate = new DateTime();

        internal void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                string strid = Request.QueryString["id"];
                int id = int.Parse(strid);
                strmaincNum = strid;
                ViewState["CNum"] = strmaincNum;
                strCname = Request.QueryString["cName"];
                GetCompanyData();
            }


        }

        protected void GetRowData()
        {



            strFname = GridEmployees.SelectedRow.Cells[0].Text;
            strLName = GridEmployees.SelectedRow.Cells[1].Text;
            strempId = GridEmployees.SelectedRow.Cells[2].Text;
            strgender = GridEmployees.SelectedRow.Cells[3].Text;
            strbirthdate = GridEmployees.SelectedRow.Cells[4].Text;

        }

        protected void GetCompanyData()
        {
            try
            {
                strmaincNum = Session["CompanyNum"].ToString();
                companyName = Session["CompanyName"].ToString();
                address = Session["Address"].ToString();
                telephone = Session["Telephone"].ToString();

                txtCompanyNum.Text = strmaincNum;
                txtCompanyName.Text = companyName;
                txtAddress.Text = address;
                txtTelephone.Text = telephone;

                ViewState["CNum"] = strmaincNum;
                ViewState["CName"] = companyName;
            }
            catch (Exception ex)
            {
                lblUpdateRow.Visible = true;
                lblUpdateRow.Text = ex.Message;
            }
        }

        private void UpdateCompanyChanges()
        {
            try
            {
                strmaincNum = ViewState["CNum"].ToString();
                companyNum = int.Parse(strmaincNum);

                using (var dtx = new TrustCompanyEntities())
                {

                    Comp = dtx.Companies.Where(s => s.CNum == companyNum).FirstOrDefault<Company>();

                }

                if (Comp != null)
                {
                    string newstrCompanyNum = txtCompanyNum.Text;
                    int newintCompanyNum = int.Parse(newstrCompanyNum);
                    Comp.CNum = newintCompanyNum;
                    Comp.Cname = txtCompanyName.Text;
                    Comp.Address = txtAddress.Text;
                    Comp.Telephone = txtTelephone.Text;

                }
                using (var dbCtx = new TrustCompanyEntities())
                {
                    dbCtx.Entry(Comp).State = System.Data.Entity.EntityState.Modified;
                    dbCtx.SaveChanges();
                }
                lblUpdateRow.Visible = true;
                lblUpdateRow.Text = "Company Updated";
            }
            catch (Exception ex)
            {
                lblUpdateRow.Visible = true;
                lblUpdateRow.Text = ex.Message;
            }

        }

        private void DeleteCompany()
        {

            try
            {
                strmaincNum = ViewState["CNum"].ToString();
                companyNum = int.Parse(strmaincNum);




                using (var dtx = new TrustCompanyEntities())
                {
                    empComp = dtx.CompanyEmployees.Where(s => s.CNum == companyNum).FirstOrDefault<CompanyEmployee>();
                    if (empComp != null)
                        throw new Exception("Company has to be Empty From Employees");

                    Comp = dtx.Companies.Where(s => s.CNum == companyNum).FirstOrDefault<Company>();
                    dtx.Entry(Comp).State = EntityState.Deleted;
                    dtx.SaveChanges();

                }
                lblUpdateRow.Visible = true;
                lblUpdateRow.Text = "Company Removed";
            }
            catch (Exception ex)
            {

                lblUpdateRow.Visible = true;

                lblUpdateRow.Text = ex.Message;

            }

        }

        protected void SendData()
        {
            strmaincNum = ViewState["CNum"].ToString();
            companyName = ViewState["CName"].ToString();
            Session["CompanyNum"] = strmaincNum;
            Session["CompanyName"] = companyName;
            Session["FName"] = strFname;
            Session["LName"] = strLName;
            Session["Gender"] = strgender;
            Session["EmpID"] = strempId;
            Session["BirthDate"] = strbirthdate;

            Response.Redirect("EmployeeUpdate.aspx?id=" + strmaincNum + "&cName=" + companyName);

        }

        protected void GridEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA';this.style.cursor='hand'");
                e.Row.Attributes.Add("onmouseout", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='white';this.style.cursor='pointer'");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridEmployees, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void GridEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridEmployees.Rows)
            {
                if (row.RowIndex == GridEmployees.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    GetRowData();
                    SendData();

                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateCompanyChanges();
        }

        protected void btnCompany_Click(object sender, EventArgs e)
        {
            Response.Redirect("Companies.aspx");
        }

        protected void btnInsertEmployess_Click(object sender, EventArgs e)
        {
            strmaincNum = Session["CompanyNum"].ToString();
            Response.Redirect("EmployeeInsert.aspx?id=" + strmaincNum);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCompany();

        }



    }
}