using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace auth_webproject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              /*  LoadCountryDropdown();*/
            }
        }
/*
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStateDropdown(ddlCountry.SelectedItem.Value);
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCityDropdown(ddlState.SelectedItem.Value);
        }

        private Dictionary<string, Dictionary<string, List<string>>> GetCountriesData()
        {
            return new Dictionary<string, Dictionary<string, List<string>>>
            {
                {
                    "USA",
                    new Dictionary<string, List<string>>
                    {
                        {"New York", new List<string>{"New York City", "Buffalo"}},
                        {"California", new List<string>{"Los Angeles", "San Francisco"}},
                        {"Texas", new List<string>{"Houston", "Austin"}}
                    }
                },
                // ... Repeat the same pattern for other countries ...
            };
        }

        private void LoadCountryDropdown()
        {
            ddlCountry.DataSource = GetCountries();
            ddlCountry.DataBind();
        }

        private void LoadStateDropdown(string country)
        {
            ddlState.DataSource = GetStates(country);
            ddlState.DataBind();
        }

        private void LoadCityDropdown(string state)
        {
            ddlCity.DataSource = GetCities(state);
            ddlCity.DataBind();
        }

        private List<ListItem> GetCountries()
        {
            Dictionary<string, Dictionary<string, List<string>>> countriesData = GetCountriesData();
            return countriesData.Keys.Select(country => new ListItem(country)).ToList();
        }

        private List<ListItem> GetStates(string country)
        {
            Dictionary<string, Dictionary<string, List<string>>> countriesData = GetCountriesData();
            if (countriesData.ContainsKey(country))
            {
                return countriesData[country].Keys.Select(state => new ListItem(state, state)).ToList();
            }
            return new List<ListItem>();
        }

        private List<ListItem> GetCities(string state)
        {
            Dictionary<string, Dictionary<string, List<string>>> countriesData = GetCountriesData();
            foreach (var countryData in countriesData.Values)
            {
                foreach (var stateData in countryData.Values)
                {
                    if (stateData.ContainsKey(state))
                    {
                        return stateData[state].Select(city => new ListItem(city, city)).ToList();
                    }
                }
            }
            return new List<ListItem>();
        }

        */
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = this.username.Text;
            string email = this.email.Text;
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
    }
}
