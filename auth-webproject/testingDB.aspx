<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testingDB.aspx.cs" Inherits="auth_webproject.testingDB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <asp:Label ID="Label1" runat="server" Text="FirstName"></asp:Label>
            
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="LastName"></asp:Label>
            <asp:TextBox type="number" ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="City"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="insert" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="update" />
            <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" Text="view" OnClick="Button4_Click" />
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <asp:Label ID="Label4" runat="server" Text="-----------------------------------------"></asp:Label>
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            <asp:Label ID="Label5" runat="server" Text="-----------------------------------------"></asp:Label>
            <asp:GridView ID="GridView3" runat="server">
            </asp:GridView>
            <asp:Label ID="Label6" runat="server" Text="-----------------------------------------"></asp:Label>
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Button" />
        </div>
    </form>
</body>
</html>
