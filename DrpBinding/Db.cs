using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace DrpBinding
{
    public class Db
    {
        SqlConnection con = null;

        public Db()
        {
            con = new SqlConnection("server=torus_1;database=dbcompany;user id=sa;pwd=unlock");
            con.Open();
        }

        public DataTable Fetch(string sql)
        {
            SqlDataAdapter adap = new SqlDataAdapter(sql , con);
            DataTable buffer = new DataTable();
            adap.Fill(buffer);
            return buffer;
        }

    }
}