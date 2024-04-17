using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _328419122.Users
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = userName.Text;
            string password = pass1.Text;
            string password2 = pass2.Text;
            string fname = fName.Text;
            string lname = lName.Text;
            string email = mail.Text;

            bool valid = true;

            if (username.Length < 3)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username must be longer than 3 characters')", true);
                valid = false;
            }

            if (password.Length < 5)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password must be longer than 5 characters')", true);
                valid = false;
            }

            if (fname.Length < 3)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('First name must be longer than 3 characters')", true);
                valid = false;
            }

            if (lname.Length < 3)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Last name must be longer than 3 characters')", true);
                valid = false;
            }


            if (UserService.EmailIsValid(email) != true) 
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email not valid')", true);
                valid = false;
            }


            if (valid)
            {
                if (password.Equals(password2))
                {
                    UserService.Register(username, password, fname, lname, email);
                    Response.Redirect("Login.aspx");
                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Both passwords must be the same')", true);


            }


            
        }
    }
}