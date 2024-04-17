using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _328419122.Admin
{
    public partial class ShowOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = AdminService.ShowOrders();
            gridview1.DataSource = dt;
            if (!IsPostBack)
            {

                gridview1.DataBind();
            }


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (D1.SelectedItem.Text == "User")
            {
                selector.Text = string.Empty;
                select.Visible = true;
                selector.Visible = true;
                DataTable dt = AdminService.ShowOrdersByUsers();
                gridview1.DataSource = dt;
                gridview1.DataBind();
                NumOfProducts.Text = string.Empty;
                TotalPrice.Text = string.Empty;
            }


            else if (D1.SelectedItem.Text == "")
            {
                selector.Text = string.Empty;
                select.Visible = false;
                selector.Visible = false;
                DataTable dt = AdminService.ShowOrders();
                gridview1.DataSource = dt;
                gridview1.DataBind();
                NumOfProducts.Text= string.Empty;
                TotalPrice.Text= string.Empty;
            }

            else if (D1.SelectedItem.Text == "Order ID")
            {
                selector.Text = string.Empty;
                select.Visible = true;
                selector.Visible = true;
                DataTable dt = AdminService.ShowOrdersByOrderID();
                gridview1.DataSource = dt;
                gridview1.DataBind();
                NumOfProducts.Text = string.Empty;
                TotalPrice.Text = string.Empty;
            }
        }

        protected void select_Click(object sender, EventArgs e)
        {
            if (D1.SelectedItem.Text == "User")
            {
                string name = selector.Text;
                DataTable dt = AdminService.ShowOrdersByUser(name);
                gridview1.DataSource = dt;
                gridview1.DataBind();
            }




            else if (D1.SelectedItem.Text == "Order ID")
            {
                int id = int.Parse(selector.Text);
                DataTable dt = AdminService.ShowOrdersByOrderID(id);
                gridview1.DataSource = dt;
                gridview1.DataBind();
                int numOfProducts = 0;
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    numOfProducts += int.Parse(dt.Rows[i][9].ToString());
                    i++;
                }
                NumOfProducts.Text = "The amout of products is " + numOfProducts.ToString();
                i = 0;
                int tPrice = 0;
                while (i < dt.Rows.Count)
                {
                    tPrice += int.Parse(dt.Rows[i][10].ToString());
                    i++;
                }
                TotalPrice.Text = "The total price is " + tPrice;
            }
        }
    }
}