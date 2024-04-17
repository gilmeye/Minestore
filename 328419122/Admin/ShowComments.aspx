<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ShowComments.aspx.cs" Inherits="_328419122.Admin.ShowComments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h3>Comments</h3>
    <div class="search">
        <asp:Label ID="Label1" runat="server" Text="Label">Search By...</asp:Label>
        <asp:DropDownList ID="D1" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="D1_SelectedIndexChanged">
            <asp:ListItem ></asp:ListItem>
            <asp:ListItem>User</asp:ListItem>
            <asp:ListItem>Date</asp:ListItem>
            <asp:ListItem>Type</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="typeSelect" Visible="false" runat="server" AutoPostBack ="true">
            <asp:ListItem >Copmlaint</asp:ListItem>
            <asp:ListItem>Recommandation</asp:ListItem>
            <asp:ListItem>Report</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="selector" Visible="false" runat="server"></asp:TextBox>
        <asp:Calendar ID="DateSelect" Visible="false" runat="server"></asp:Calendar>
        <asp:Button ID="select" Visible="false" runat="server" Text="Search" OnClick="select_Click"/>
    </div>
    
    <br />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

</asp:Content>
