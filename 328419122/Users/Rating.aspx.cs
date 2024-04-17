using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _328419122.Users
{
    public partial class Rating : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = Session["name"].ToString();
            int design = int.Parse(d1.SelectedValue);
            int comfort = int.Parse(c1.SelectedValue);
            int product = int.Parse(p1.SelectedValue);
            int service = int.Parse(s1.SelectedValue);
            localhost.RateService rs = new localhost.RateService();
            rs.AddRating(name, design, comfort, product, service);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Thanks :)')", true);
        }
    }
}