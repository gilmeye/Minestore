<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UserMaster.Master" AutoEventWireup="true" CodeBehind="Comment.aspx.cs" Inherits="_328419122.Users.comment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

    <h4>Add Comment</h4>
    <div>
        <table id="comment">
        <tr>
            <td>Name</td>
            <td>
                <asp:TextBox ID="name" Text="" runat="server" Width="250px"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="mail" runat="server" Width="250px"></asp:TextBox>
            </td>
           
        </tr>
        <tr>
            <td>Type</td>
            <td>
                <asp:DropDownList ID="type" runat="server" Width="250px">
                    <asp:ListItem >Copmlaint</asp:ListItem>
                    <asp:ListItem>Recommandation</asp:ListItem>
                    <asp:ListItem>Report</asp:ListItem>
                </asp:DropDownList>
            </td>
          
        </tr>
        <tr>
            <td>Content</td>
            <td>
                <asp:TextBox ID="content" runat="server" TextMode="MultiLine" Width="250px" Height="78px"></asp:TextBox>
            </td>
           
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="send" runat="server" Text="Comment Now!" OnClick="Button5_Click" />
           
        </tr>
    </table>
    </div>
    


</asp:Content>
