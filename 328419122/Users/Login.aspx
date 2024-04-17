<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UserMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_328419122.Users.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Log In</h3>

    <table style="margin:auto; width:30%; margin-top:2%; border:3px solid;">
        <tr>
            <td>Username </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Password </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button6" runat="server" Text="Login" OnClick="Unnamed1_Click" />
            </td>
            <td>
                <asp:Button ID="Button7" runat="server" Text="Register" OnClick="Unnamed2_Click" />
            </td>
        </tr>
    </table>
   

</asp:Content>

