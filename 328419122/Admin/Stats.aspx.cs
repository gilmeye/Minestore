using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _328419122.Admin
{
    public partial class Stats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            localhost.RateService rt = new localhost.RateService();
            DataTable dt = rt.ShowRating();
            GridView1.DataSource = dt;
            GridView1.DataBind();

            G2.DataSource = AdminService.UsersWhoOrdered();
            G2.DataBind();
        }

        protected void D1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int month = int.Parse(D1.SelectedItem.Text);
            DataTable dt = AdminService.ShowInfoByMonth(month);
            int i = 0;
            int tproducts = 0;
            int tmoney = 0;
            while(i < dt.Rows.Count)
            {
                tproducts += int.Parse(dt.Rows[i][0].ToString());
                i++;
            }
            i = 0;
            while (i < dt.Rows.Count)
            {
                tmoney += int.Parse(dt.Rows[i][1].ToString());
                i++;
            }

            Label1.Text = tproducts.ToString();
            Label2.Text = tmoney.ToString();
            dt = AdminService.ProductAmount(month);
            int max = 0;
            string most = "";
            i = 0;
            while (i < dt.Rows.Count)
            {
                if (max < int.Parse(dt.Rows[i][1].ToString()))
                {
                    max = int.Parse(dt.Rows[i][1].ToString());
                    most = dt.Rows[i][0].ToString();
                }
                i++;

            }
            Label3.Text = most;
        }
    }
}