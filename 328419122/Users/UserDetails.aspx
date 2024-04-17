<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UserMaster.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="_328419122.Users.UserDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Your Details</h3>

    <div>
        <table id="detail">
        <tr>
            <td>Username</td>
            <td>
                <asp:Label ID="uname" Visible="true" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="tuname" Text="" runat="server" Visible="false" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:Label ID="pass" Visible="true" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="tpass" Text="" runat="server" Visible="false" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>First Name</td>
            <td>
                <asp:Label ID="fname" Visible="true" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="tfname" Text="" runat="server" Visible="false" Width="150px"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td>Last name</td>
            <td>
                <asp:Label ID="lname" Visible="true" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="tlname" runat="server" Visible="false" Width="150px"></asp:TextBox>
            </td>
           
        </tr>
        <tr>
            <td>Email</td>
            <td>
                <asp:Label ID="mail" Visible="true" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="tmail" runat="server" Visible="false" Width="150px"></asp:TextBox>
            </td>
          
        </tr>
        <tr>
            <td>
                <asp:Button ID="Edit" runat="server" Text="Edit info" OnClick="Edit_Click" />
                <asp:Button ID="Cancel" Visible="false" runat="server" Text="Cancel" OnClick="Cancel_Click" />
            </td>
            <td>
                <asp:Button ID="Update" Visible ="false" runat="server" Text="Update info" OnClick="Update_Click" />
            </td>
                
           
        </tr>
    </table>

    </div>      

    <div>




    </div>





</asp:Content>
