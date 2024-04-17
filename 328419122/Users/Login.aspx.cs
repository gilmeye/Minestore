using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _328419122.Users
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string password = TextBox2.Text;
            bool isCorrect = UserService.DoesExist(name, password);
            if (isCorrect) 
            {
                Session["name"] = name;
                Session["id"] = UserService.SelectIDbyName(name);
                bool IsAdmin = UserService.IsAdmin(name);

                if (IsAdmin)
                {
                    Session["IsAdmin"] = true;
                    Response.Redirect("../Admin/ShowProducts.aspx");
                }
                else
                {
                    Session["IsAdmin"] = false;
                    Response.Redirect("Catalog.aspx");
                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username or password are wrong')", true);
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
            }
            
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}