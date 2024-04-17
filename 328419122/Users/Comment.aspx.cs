using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _328419122.Users
{
    public partial class comment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            name.Text = Session["name"].ToString();

            DataTable dt = CommentService.ShowComments();
            GridView1.DataSource = dt;
            if (!IsPostBack)
                {
                    GridView1.DataBind();
                }



        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string uname = name.Text;
            string email = mail.Text;
            string ctype = type.Text;
            string Content = content.Text;
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            CommentService.AddComment(uname, email, ctype, date, Content);
            mail.Text = string.Empty;
            content.Text = string.Empty;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Noted! :) ')", true);
            DataTable dt = CommentService.ShowComments();
            GridView1.DataSource = dt;
            GridView1.DataBind();


        }


    }
}