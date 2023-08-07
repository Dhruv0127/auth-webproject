using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace auth_webproject
{
    public partial class testingDB : System.Web.UI.Page
    {
        String table_name = "country_tbl";

        private SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\App Dev\Net\auth-webproject\auth-webproject\App_Data\learning.mdf"";Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"insert into {table_name} values('" + TextBox3.Text + "')";
            cmd.ExecuteNonQuery();
            TextBox3.Text = "";
            Display_data("country_tbl" , GridView1);
        }

        public void Display_data(String tb, GridView gd)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from {tb}";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            gd.DataSource = dataTable;
            gd.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"DELETE FROM {table_name} WHERE ct_name='" + TextBox3.Text + "';";
            cmd.ExecuteNonQuery();
            Display_data("country_tbl", GridView1);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Display_data("country_tbl", GridView1);
            Display_data("state_tbl", GridView2);
            Display_data("city_tbl", GridView3);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"UPDATE state_tbl SET st_id = st_id - 1 WHERE st_id > (SELECT st_id FROM state_tbl WHERE st_name = 'Gujarat');";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }
    }
       
}


