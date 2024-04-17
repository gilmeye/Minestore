using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _328419122.Users
{
    public partial class SalFinal : System.Web.UI.Page
    {
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            DataTable dt = new DataTable();
            dt = SalService.SelectFromSal();

            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Discount.xml"));
            int i = 0;
            int j = 0;
            while (i < dt.Rows.Count)
            {
                while (j < ds.Tables[0].Rows.Count)
                {
                    if (dt.Rows[i][1].Equals(ds.Tables[0].Rows[j][0]))
                    {
                        dt.Rows[i][2] = int.Parse(dt.Rows[i][2].ToString()) - int.Parse(dt.Rows[i][2].ToString()) * int.Parse(ds.Tables[0].Rows[j][1].ToString()) / 100;
                    }
                    j++;
                }
                i++;
                j = 0;
            }


            GridView1.DataSource = dt;

            if (!IsPostBack)
            {
                
                GridView1.DataBind();
                int numOfProducts = 0;
                i = 0;
                while (i < dt.Rows.Count)
                {
                    numOfProducts += int.Parse(dt.Rows[i][3].ToString());
                    i++;
                }
                NumOfProducts.Text = numOfProducts.ToString();
                i = 0;
                int tPrice = 0;
                while (i < dt.Rows.Count)
                {
                    tPrice += int.Parse(dt.Rows[i][3].ToString()) * int.Parse(dt.Rows[i][2].ToString());
                    i++;
                }
                TotalPrice.Text = tPrice.ToString();
            }

        }


        protected void Unnamed_Click(object sender, EventArgs e)
        {
            DataTable dt = SalService.SelectFromSal();
            int i = 0;
            int payment = 0;
            while (i < dt.Rows.Count)
            {
                payment += int.Parse(dt.Rows[i][3].ToString()) * int.Parse(dt.Rows[i][2].ToString());
                i++;
            }
            int uid = int.Parse(userId.Text);
            string num = cnum.Text;
            int CVC = int.Parse(cvc.Text);
            bool checksOut;
            localhostB.Bank bank = new localhostB.Bank();
            checksOut = bank.DoesExist(uid, num, CVC) && bank.HasAmount(uid, payment);

            if (checksOut)
            {
                bank.Pay(uid, payment);
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                int UserId = int.Parse(Session["id"].ToString());
                OrderService.InsertIntoOrders(date, UserId);
                dt = SalService.SelectFromSal();
                int id;
                int kamut;
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    id = int.Parse(dt.Rows[i][0].ToString());
                    kamut = int.Parse(dt.Rows[i][3].ToString());
                    ProductService.LowerStock(id, kamut);
                    OrderService.InsertIntoOrderDetails(id, kamut);
                }
                OrderService.DeleteAllSal();
                Response.Redirect("Catalog.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('some information details are wrong')", true);
            }
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int kamut;
            int rowNum = e.RowIndex;
            GridView1.EditIndex = -1;
            kamut = int.Parse(((TextBox)(GridView1.Rows[rowNum].Cells[5].Controls[0])).Text);
            int id = int.Parse(((TextBox)(GridView1.Rows[rowNum].Cells[2].Controls[0])).Text);
            if (ProductService.IsInStock(id, kamut))
            {
                SalService.UpdateInSal(id, kamut);
                DataTable dt = SalService.SelectFromSal();
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/Discount.xml"));
                int i = 0;
                int j = 0;
                while (i < dt.Rows.Count)
                {
                    while (j < ds.Tables[0].Rows.Count)
                    {
                        if (dt.Rows[i][1].Equals(ds.Tables[0].Rows[j][0]))
                        {
                            dt.Rows[i][2] = int.Parse(dt.Rows[i][2].ToString()) - int.Parse(dt.Rows[i][2].ToString()) * int.Parse(ds.Tables[0].Rows[j][1].ToString()) / 100;
                        }
                        j++;
                    }
                    i++;
                    j = 0;
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int numOfProducts = 0;
                i = 0;
                while (i < dt.Rows.Count)
                {
                    numOfProducts += int.Parse(dt.Rows[i][3].ToString());
                    i++;
                }
                NumOfProducts.Text = numOfProducts.ToString();
                i = 0;
                int tPrice = 0;
                while (i < dt.Rows.Count)
                {
                    tPrice += int.Parse(dt.Rows[i][3].ToString()) * int.Parse(dt.Rows[i][2].ToString());
                    i++;
                }
                TotalPrice.Text = tPrice.ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product is out of stock')", true);
                DataTable dt = SalService.SelectFromSal();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
                
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataBind();
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalog.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = SalService.SelectFromSal();
            int id = int.Parse(dt.Rows[e.RowIndex][0].ToString());
            SalService.DeleteFromSal(id);
            dt = SalService.SelectFromSal();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Discount.xml"));
            int i = 0;
            int j = 0;
            while (i < dt.Rows.Count)
            {
                while (j < ds.Tables[0].Rows.Count)
                {
                    if (dt.Rows[i][1].Equals(ds.Tables[0].Rows[j][0]))
                    {
                        dt.Rows[i][2] = int.Parse(dt.Rows[i][2].ToString()) - int.Parse(dt.Rows[i][2].ToString()) * int.Parse(ds.Tables[0].Rows[j][1].ToString()) / 100;
                    }
                    j++;
                }
                i++;
                j = 0;
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            int numOfProducts = 0;
            i = 0;
            while (i < dt.Rows.Count)
            {
                numOfProducts += int.Parse(dt.Rows[i][3].ToString());
                i++;
            }
            NumOfProducts.Text = numOfProducts.ToString();
            i = 0;
            int tPrice = 0;
            while (i < dt.Rows.Count)
            {
                tPrice += int.Parse(dt.Rows[i][3].ToString()) * int.Parse(dt.Rows[i][2].ToString());
                i++;
            }
            TotalPrice.Text = tPrice.ToString();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = SalService.SelectFromSal();
            int i = 0;
            double Price = 0;
            while (i < dt.Rows.Count)
            {
                Price += int.Parse(dt.Rows[i][3].ToString()) * int.Parse(dt.Rows[i][2].ToString());
                i++;
            }
            if (D1.SelectedItem.Text == "ILS")
            {
                TotalPrice.Text = Price.ToString();
            }
            if (D1.SelectedItem.Text == "EUR")
            {

                TotalPrice.Text = Math.Round(Price / 4, 2).ToString();
            }
            if (D1.SelectedItem.Text == "USD")
            {
                TotalPrice.Text = Math.Round(Price / 3.73, 2).ToString();
            }
        }
    }
}