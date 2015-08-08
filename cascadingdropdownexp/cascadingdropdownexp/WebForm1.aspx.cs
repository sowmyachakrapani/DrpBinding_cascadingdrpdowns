using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace cascadingdropdownexp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack != true)
            {
                ddlcontinents.DataTextField = "continentName";
                ddlcontinents.DataValueField = "continentId";
                ddlcontinents.DataSource = GetData("spgetcontinents", null);
                ddlcontinents.DataBind();
                ListItem licontinent = new ListItem("Select continent", "-1");
                ddlcontinents.Items.Insert(0, licontinent);
                ListItem licountry = new ListItem("Select country", "-1");
                ddlcountries.Items.Insert(0, licountry);
                ListItem licity = new ListItem("Select city", "-1");
                ddlcities.Items.Insert(0, licity);
                ddlcountries.Enabled = false;
                ddlcities.Enabled = false;

            }

        }

        private DataSet GetData(string spname, SqlParameter spparameter)
        {
            SqlConnection con = new SqlConnection(@"Data Source=JAYA-CHAKRAPANI;Initial Catalog=Sample;Integrated Security=true");
            SqlDataAdapter adap = new SqlDataAdapter(spname,con);
            adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (spparameter != null)
            {
                adap.SelectCommand.Parameters.Add(spparameter);

            }
            DataSet ds = new DataSet();
            adap.Fill(ds);
            return ds;

        }

        protected void ddlcontinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcontinents.SelectedIndex == 0)
            {
                ddlcountries.SelectedIndex = 0;
                ddlcountries.Enabled = false;
                ddlcities.SelectedIndex = 0;
                ddlcities.Enabled = false;
            }
            else
            {
                ddlcountries.Enabled = true;
                SqlParameter parameter = new SqlParameter("@ContinentId", ddlcontinents.SelectedValue);
                DataSet ds = GetData("spgetcountriesbycontinentid", parameter);
                
                ddlcountries.DataSource = ds;
                ddlcountries.DataBind();
                ListItem licountry = new ListItem("Select country", "-1");
                ddlcountries.Items.Insert(0, licountry);
                ddlcities.SelectedIndex = 0;
                ddlcities.Enabled = false;
           }
        }

        protected void ddlcountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcountries.SelectedIndex == 0)
            {
                ddlcities.SelectedIndex = 0;
                ddlcities.Enabled = false;
            }
            else
            {
             ddlcities.Enabled = true;
            SqlParameter parameter = new SqlParameter("@countryid", ddlcountries.SelectedValue);
            DataSet ds = GetData("spgetcitiesbycountryid", parameter);

            ddlcities.DataSource = ds;
            ddlcities.DataBind();
            ListItem licity = new ListItem("Select city", "-1");
            ddlcities.Items.Insert(0, licity);
            }
        }
    }
}