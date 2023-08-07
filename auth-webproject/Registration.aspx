<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="auth_webproject.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <div class="regcontainer">
        <div class="left-column">
            <div class="about-us">
                <br />
                <h2>About Us</h2>
                <p>
                    Welcome to our registration platform. We strive to provide a
                    seamless and user-friendly experience for all our users.
                </p>
                <br />
                <br />
                <br />
            </div>
            <div class="login-section">
                <br />
                <br />
                <h2>Login with Social Media</h2>
                
                <br />
                <div class="social-buttons">
                    <button class="google-button">
                        <img class="google-logo" src="../images/glogo.png" alt="Google Logo" />
                        Login with Google
                    </button>
                    <button class="fb-button">
                        <img class="fb-logo" src="../images/fblogo.png" alt="Facebook Logo" />
                        Login with Facebook
                    </button>
                </div>
            </div>
        </div>
        <div class="registration-form">
            <reg>Register</reg>
            <div class="form-group">
                <asp:TextBox type="text" ID="username" runat="server" class="textbox" placeholder="Enter Username" Required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox type="email" ID="email" runat="server" class="textbox" placeholder="Enter Email" Required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox type="password" ID="password" runat="server" class="textbox" TextMode="Password" placeholder="Enter Password" Required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <maingen ID="lblDateOfBirth"> Date of birth</maingen>
                <asp:TextBox type="date" ID="dateOfBirth" runat="server" class="textbox" placeholder="Date of Birth" Required="true"></asp:TextBox>
            </div>
            <div class="form-group flex-container">
                <div class="form-group hobbies">
                    <maingen>Hobbies</maingen>
                    <div class="hobbies-checkbox-group">
                        <asp:CheckBox ID="chkReading" runat="server"  />
                        <gen class="gender-name">Reading </gen>
                        <asp:CheckBox ID="chkSports" runat="server"/>
                        <gen class="gender-name">Sports </gen>
                        <asp:CheckBox ID="chkTraveling" runat="server" />
                        <gen class="gender-name">Traveling </gen>
                    </div>
                </div>
                <div class="form-group gender">
                    <maingen>Gender</maingen>
                    <div class="hobbies-checkbox-group">
                        <asp:RadioButton ID="rbMale" runat="server" GroupName="gender" Required="true" />
                        <gen class="gender-name">Male</gen>
                        <asp:RadioButton ID="rbFemale" runat="server" GroupName="gender" Required="true" />
                        <gen class="gender-name">Female</gen>

                    </div>
                </div>
            </div>
            <div class="form-group flex-container">
                <div>
                    <maingen>Country</maingen>
                    <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True"   
                    DataTextField="co_name" DataValueField="co_id" AppendDataBoundItems="true"   
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">  
                    <asp:ListItem Value="0">--Select Country--</asp:ListItem>  
                </asp:DropDownList> 
                </div>
                <div>
                    <maingen>State</maingen>
                     <asp:DropDownList ID="ddlState" runat="server" AppendDataBoundItems="true" DataTextField="st_name"   
                    DataValueField="st_id" AutoPostBack="True"   
                    onselectedindexchanged="DropDownList2_SelectedIndexChanged">  
                    <asp:ListItem Value="0">-- Select State--</asp:ListItem>  
                </asp:DropDownList> 
                </div>
                <div>
                    <maingen>City</maingen>
                    <asp:DropDownList ID="ddlCity" runat="server" AppendDataBoundItems="true" DataTextField="ct_name"   
                    DataValueField="ct_id">  
                    <asp:ListItem Value="0">-- Select City--</asp:ListItem>  
                </asp:DropDownList>
                </div>
            </div>
                <div>
                    <asp:TextBox type="text" ID="TextBox1" runat="server" class="textbox" placeholder="Enter Full Address" ></asp:TextBox>
                </div>
            <div class="form-group">
                <asp:Button ID="Button1" runat="server" CssClass="register-button" Text="Register" OnClick="btnRegister_Click" />
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </div>
        </div>
    </div>
    <div id="userDetailsDiv" runat="server" class="user-details"></div>

   



</asp:Content>




