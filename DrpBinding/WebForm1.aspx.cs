using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DrpBinding
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                Db db = new Db();
                DropDownList1.DataSource = db.Fetch("select  distinct job from emp");
                DropDownList1.DataTextField = "job";
                DropDownList1.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Db db = new Db();
            GridView1.DataSource = db.Fetch(string.Format("select * from emp where job = '{0}'", DropDownList1.SelectedValue));
            GridView1.DataBind();
            lblCnt.Text = GridView1.Rows.Count.ToString();
        }
    }
}