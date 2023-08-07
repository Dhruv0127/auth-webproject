using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace auth_webproject
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        String table_name = "user_entry";
        private SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\App Dev\Net\auth-webproject\auth-webproject\App_Data\learning.mdf"";Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            conn.Open();
            if (!Page.IsPostBack)
            {
                SqlCommand cmd = new SqlCommand("select * from country_tbl", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ddlCountry.DataSource = dt;
                ddlCountry.DataBind();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlState.Items.Clear();
            ddlState.Items.Add("Select State");

            SqlCommand cmd = new SqlCommand("select * from state_tbl where co_id='" + ddlCountry.SelectedItem.Value + "' ", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlState.DataSource = dt;
            ddlState.DataBind();
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("Select State");

            SqlCommand cmd = new SqlCommand("select * from city_tbl where st_id='" + ddlState.SelectedItem.Value + "' ", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            ddlCity.DataSource = dt;
            ddlCity.DataBind();

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = this.username.Text;
            string email = this.email.Text;
            string password = this.password.Text;
            string dateOfBirth = this.dateOfBirth.Text;
            string hobbies = string.Join(", ", GetSelectedHobbies());
            string gender = GetSelectedGender();
            string country = this.ddlCountry.SelectedItem.Text;
            string state = this.ddlState.SelectedItem.Text;
            string city = this.ddlCity.SelectedItem.Text;
            string address = this.TextBox1.Text;

            DateTime birthDate = DateTime.Parse(dateOfBirth);
            int age = CalculateAge(birthDate);

            string userDetails = $"<strong>Username:</strong> {username}<br />" +
                                 $"<strong>Email:</strong> {email}<br />" +
                                 $"<strong>Date of Birth:</strong> {dateOfBirth}<br />" +
                                 $"<strong>Age:</strong> {age} yr<br />" +
                                 $"<strong>Hobbies:</strong> {hobbies}<br />" +
                                 $"<strong>Gender:</strong> {gender}<br />" +
                                 $"<strong>Country:</strong> {country}<br />" +
                                 $"<strong>State:</strong> {state}<br />" +
                                 $"<strong>City:</strong> {city}<br />" +
                                 $"<strong>Address:</strong> {address}<br />";

            userDetailsDiv.InnerHtml = userDetails;



            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"insert into {table_name} values('" + username + "','" + email + "','" + password + "','" + dateOfBirth + "','" + age + "','" + hobbies + "','" + gender + "','" + country + "','" + state + "','" + city + "','" + address + "')";
            cmd.ExecuteNonQuery();
            Display_data("country_tbl", GridView1);

        }

        private int CalculateAge(DateTime dob)
        {
            int age = DateTime.Now.Year - dob.Year;
            if (DateTime.Now.DayOfYear < dob.DayOfYear)
                age--;
            return age;
        }

        private List<string> GetSelectedHobbies()
        {
            List<string> selectedHobbies = new List<string>();

            if (chkReading.Checked)
                selectedHobbies.Add("Reading");

            if (chkSports.Checked)
                selectedHobbies.Add("Sports");

            if (chkTraveling.Checked)
                selectedHobbies.Add("Traveling");

            return selectedHobbies;
        }

        private string GetSelectedGender()
        {
            if (rbMale.Checked)
                return "Male";
            else if (rbFemale.Checked)
                return "Female";
            else
                return "Unknown";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Display_data("country_tbl", GridView1);
        }

        public void Display_data(String td, GridView gd)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from {td}";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            gd.DataSource = dataTable;
            gd.DataBind();
        }
    }
}
