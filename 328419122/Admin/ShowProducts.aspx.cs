using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _328419122.Admin
{
    public partial class ShowProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = AdminService.ShowProducts();
            Gridview1.DataSource = dt;


            if (!IsPostBack)
            {

                Gridview1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            int category = AdminService.SelectCategoryID(DropDownList1.Text);
            int price = int.Parse(TextBox2.Text);
            int stock = int.Parse(TextBox3.Text);
            AdminService.AddProduct(name, category, price, stock);
            TextBox1.Text = string.Empty;
            TextBox2.Text= string.Empty;
            TextBox3.Text= string.Empty;
            DataTable dt = AdminService.ShowProducts();
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }

        protected void Gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gridview1.EditIndex = e.NewEditIndex;
            Gridview1.DataBind();
        }

        protected void Gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            Gridview1.EditIndex = -1;
            int price = int.Parse(((TextBox)(Gridview1.Rows[e.RowIndex].Cells[5].Controls[0])).Text);
            int stock = int.Parse(((TextBox)(Gridview1.Rows[e.RowIndex].Cells[6].Controls[0])).Text);
            string name = ((TextBox)(Gridview1.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
            int id = int.Parse(((TextBox)(Gridview1.Rows[e.RowIndex].Cells[2].Controls[0])).Text);
            AdminService.UpdateProduct(id, price, stock, name);
            DataTable dt = AdminService.ShowProducts();
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }

        protected void Gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gridview1.EditIndex = -1;
            Gridview1.DataBind();
        }

        protected void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(Gridview1.Rows[e.RowIndex].Cells[2].Text);
            AdminService.DeleteProduct(id);
            DataTable dt = AdminService.ShowProducts();
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }
    }
}