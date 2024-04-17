<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UserMaster.Master" AutoEventWireup="true" CodeBehind="Rating.aspx.cs" Inherits="_328419122.Users.Rating" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <br />
    <h3>Rate Us!</h3>
    
    <table id="comment"  >
        <tr>
            <td>
                <asp:Label ID="label4" runat="server" Text="How would you rate our design?"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="d1" runat="server" Width="150px">
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="How would you rate the site's comfortability?"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="c1" runat="server" Width="150px">
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="How would you rate our site's products?"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="p1" runat="server" Width="150px">
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="How would you rate our Service?"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="s1" runat="server" Width="150px">
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td>
                <asp:Button ID="Rate" runat="server" Text="Add Rating" OnClick="Button1_Click" />
           </td>
        </tr>
    </table>
    




</asp:Content>
