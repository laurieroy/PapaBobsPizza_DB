using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobs.Web
{
    public partial class success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void backButton_Click(object sender, EventArgs e)
        {
           // orderLabel.Text = String.Format("Your order of {0} {1} {2} has been placed.", order.size, order.crust, toppings);
            Response.Redirect("default.aspx");
        }
    }
}