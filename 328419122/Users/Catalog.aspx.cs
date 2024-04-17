using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _328419122.Users
{
    public partial class Catalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            DataTable dt = new DataTable();
            dt = ProductService.SelectFromProducts();
            GridView1.DataSource = dt;
            if (!IsPostBack)
            {
                GridView1.DataBind();
            }


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument.ToString());
            int id = int.Parse(GridView1.Rows[rowNumber].Cells[1].Text);
            string name = GridView1.Rows[rowNumber].Cells[2].Text;
            int price = int.Parse(GridView1.Rows[rowNumber].Cells[4].Text);
            if (ProductService.IsInStock(id, SalService.SelectKamutByID(id) + 1)) 
            {
                SalService.InsertIntoSal(id, name, 1, price);
                DataTable dt = SalService.SelectFromSal();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                cart.Visible = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product is out of stock')", true);
            }

        }

        protected void cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalFinal.aspx");
        }

    }
}