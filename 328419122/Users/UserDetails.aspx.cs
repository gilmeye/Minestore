using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _328419122.Users
{
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                DataTable dt = UserService.SelectUserByID(int.Parse(Session["id"].ToString()));
                uname.Text = dt.Rows[0][0].ToString();
                pass.Text = dt.Rows[0][1].ToString();
                fname.Text = dt.Rows[0][2].ToString();
                lname.Text = dt.Rows[0][3].ToString();
                mail.Text = dt.Rows[0][4].ToString();
                tuname.Text = uname.Text;
                tpass.Text = pass.Text;
                tfname.Text = fname.Text;
                tlname.Text = lname.Text;
                tmail.Text = mail.Text;
            }

        }

        protected void Edit_Click(object sender, EventArgs e)
        {

            uname.Visible= false;
            pass.Visible = false;
            fname.Visible= false;
            lname.Visible = false;
            mail.Visible= false;
            tuname.Visible = true;
            tpass.Visible = true;
            tfname.Visible = true;
            tlname.Visible = true;
            tmail.Visible = true;
            Update.Visible = true;
            Cancel.Visible = true;
            Edit.Visible = false;
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["id"].ToString());
            string Uname = tuname.Text;
            string Pass = tpass.Text;
            string Fname = tfname.Text;
            string Lname = tlname.Text;
            string Mail = tmail.Text;

            bool valid = true;
  

            if (Pass.Length < 5)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password must be longer than 5 characters')", true);
                valid = false;
            }

            if (Uname.Length < 3)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username must be longer than 3 characters')", true);
                valid = false;
            }

            if (Fname.Length < 3)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('First name must be longer than 3 characters')", true);
                valid = false;
            }

            if (Lname.Length < 3)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Last name must be longer than 3 characters')", true);
                valid = false;
            }


            if (UserService.EmailIsValid(Mail) != true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email not valid')", true);
                valid = false;
            }

            if (valid) 
            {
                UserService.UpdateUserInfo(id, Uname, Pass, Fname, Lname, Mail);
                tuname.Text = string.Empty;
                tpass.Text = string.Empty;
                tfname.Text = string.Empty;
                tlname.Text = string.Empty;
                tmail.Text = string.Empty;
                uname.Visible = true;
                pass.Visible = true;
                fname.Visible = true;
                lname.Visible = true;
                mail.Visible = true;
                tuname.Visible = false;
                tpass.Visible = false;
                tfname.Visible = false;
                tlname.Visible = false;
                tmail.Visible = false;
                Update.Visible = false;
                Cancel.Visible = false;
                Edit.Visible = true;

                DataTable dt = UserService.SelectUserByID(int.Parse(Session["id"].ToString()));
                uname.Text = dt.Rows[0][0].ToString();
                pass.Text = dt.Rows[0][1].ToString();
                fname.Text = dt.Rows[0][2].ToString();
                lname.Text = dt.Rows[0][3].ToString();
                mail.Text = dt.Rows[0][4].ToString();
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            tuname.Text= string.Empty;
            tpass.Text = string.Empty;
            tfname.Text= string.Empty;
            tlname.Text= string.Empty;
            tmail.Text= string.Empty;
            uname.Visible = true;
            pass.Visible = true;
            fname.Visible = true;
            lname.Visible = true;
            mail.Visible = true;
            tuname.Visible = false;
            tpass.Visible = false;
            tfname.Visible = false;
            tlname.Visible = false;
            tmail.Visible = false;
            Update.Visible = false;
            Cancel.Visible = false;
            Edit.Visible = true;
        }
    }
}