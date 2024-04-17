using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _328419122.Admin
{
    public partial class ShowUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = AdminService.ShowUsers();
            gridview1.DataSource= dt;
            if (!IsPostBack)
            {
                gridview1.DataBind();
            }
        }
        protected void gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridview1.EditIndex = e.NewEditIndex;
            gridview1.DataBind();
        }
        protected void gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(((TextBox)(gridview1.Rows[e.RowIndex].Cells[2].Controls[0])).Text);
            string uname = ((TextBox)(gridview1.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
            string pass = ((TextBox)(gridview1.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
            string fname = ((TextBox)(gridview1.Rows[e.RowIndex].Cells[5].Controls[0])).Text;
            string lname = ((TextBox)(gridview1.Rows[e.RowIndex].Cells[6].Controls[0])).Text;
            string email = ((TextBox)(gridview1.Rows[e.RowIndex].Cells[7].Controls[0])).Text;
            bool isAdmin = ((CheckBox)(gridview1.Rows[e.RowIndex].Cells[8].Controls[0])).Checked;
            gridview1.EditIndex = -1;
            AdminService.UpdateUser(id, uname, pass, fname, lname, email, isAdmin);
            DataTable dt = AdminService.ShowUsers();
            gridview1.DataSource = dt;
            gridview1.DataBind();
        }
        protected void gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridview1.EditIndex = -1;
            gridview1.DataBind();
        }
        protected void gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(gridview1.Rows[e.RowIndex].Cells[2].Text);
            AdminService.DeleteUser(id);
            DataTable dt = AdminService.ShowUsers();
            gridview1.DataSource = dt;
            gridview1.DataBind();
        }
        protected void AddUser_Click(object sender, EventArgs e)
        {
            string Uname = uname.Text;
            string Pass = pass.Text;
            string Fname = fname.Text;
            string Lname = lname.Text;
            string Mail = mail.Text;
            AdminService.AddUser(Uname, Pass, Fname, Lname, Mail);
            uname.Text = string.Empty;
            pass.Text = string.Empty;
            fname.Text = string.Empty;
            lname.Text = string.Empty;
            mail.Text = string.Empty;
            DataTable dt = AdminService.ShowUsers();
            gridview1.DataSource = dt;
            gridview1.DataBind();
        }
    }
}