using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace _328419122.Admin
{
    public partial class ShowComments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = CommentService.ShowComments();
            GridView1.DataSource= dt;
            if (!IsPostBack)
            {

                GridView1.DataBind();
            }
        }

        protected void D1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (D1.SelectedItem.Text == "User")
            {
                selector.Text = string.Empty;
                select.Visible = true;
                selector.Visible = true;
                typeSelect.Visible = false;
                DateSelect.Visible = false;
                
            }

            else if (D1.SelectedItem.Text == "Date")
            {
                selector.Text = string.Empty;
                select.Visible = true;
                selector.Visible = false;
                typeSelect.Visible = false;
                DateSelect.Visible = true;
            }

            else if (D1.SelectedItem.Text == "")
            {
                selector.Text = string.Empty;
                select.Visible = false;
                selector.Visible = false;
                typeSelect.Visible = false;
                DateSelect.Visible = false;
                DataTable dt = CommentService.ShowComments();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            else if (D1.SelectedItem.Text == "Type")
            {
                selector.Text = string.Empty;
                select.Visible = true;
                typeSelect.Visible = true;
                selector.Visible = false;
                DateSelect.Visible = false;
            }
        }

        protected void select_Click(object sender, EventArgs e)
        {
            if (D1.SelectedItem.Text == "User")
            {
                string name = selector.Text;
                DataTable dt = CommentService.ShowCommentsByUser(name);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            else if (D1.SelectedItem.Text == "Date")
            {
                string date = DateSelect.SelectedDate.ToString("dd/MM/yyyy");
                DataTable dt = CommentService.ShowCommentsByDate(date);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (D1.SelectedItem.Text == "Type")
            {
                string type = typeSelect.SelectedItem.Text;
                DataTable dt = CommentService.ShowCommentsByType(type);
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
        }
    }
}