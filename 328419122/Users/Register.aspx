<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UserMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="_328419122.Users.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h3>Register</h3>

    <table style="margin:auto; width:30%; margin-top:2%; border:3px solid;">
        <tr>
            <td>First Name </td>
            <td>
                <asp:TextBox ID="fName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Last Name </td>
            <td>
                <asp:TextBox ID="lName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>User name </td>
            <td>
                <asp:TextBox ID="userName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Password </td>
            <td>
                <asp:TextBox ID="pass1" runat="server" TextMode="password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Confirm Password </td>
            <td>
                <asp:TextBox ID="pass2" runat="server" TextMode="password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Email </td>
            <td>
                <asp:TextBox ID="mail" runat="server" TextMode="Email"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="Button7" runat="server" Text="Register" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>


</asp:Content>
