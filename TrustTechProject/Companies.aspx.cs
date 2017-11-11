using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrustTechProject
{
    public partial class Companies : System.Web.UI.Page
    {
        string companyNum = "";
        string companyName = "";
        string address = "";
        string telephone = "";

        protected void Page_Load(object sender, EventArgs e)
        {
           


        }

        protected void GetRowData()
        {
             companyNum = GridCompanies.SelectedRow.Cells[1].Text;
             companyName = GridCompanies.SelectedRow.Cells[2].Text;
             address = GridCompanies.SelectedRow.Cells[3].Text;
             telephone = GridCompanies.SelectedRow.Cells[4].Text;
         }

        protected void SendData()
        {
            Session["CompanyNum"] = companyNum;
            Session["CompanyName"] = companyName;
            Session["Address"] = address;
            Session["Telephone"] = telephone;

           
            

           Response.Redirect("Employees.aspx?id="+companyNum+"&cName="+companyName);
            
        }

        protected void GridCompanies_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA';this.style.cursor='hand'");
                e.Row.Attributes.Add("onmouseout", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='white';this.style.cursor='pointer'");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridCompanies, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void GridCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridCompanies.Rows)
            {
                if (row.RowIndex == GridCompanies.SelectedIndex)
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

        protected void btnInsertCompany_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyInsert.aspx");
        }
    
      
    }
}