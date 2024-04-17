<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ShowOrders.aspx.cs" Inherits="_328419122.Admin.ShowOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h3>Orders</h3>
    <br />
    <div class="search">
        <asp:Label ID="Label1" runat="server" Text="Label">Search By...</asp:Label>
        <asp:DropDownList ID="D1" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem ></asp:ListItem>
            <asp:ListItem>User</asp:ListItem>
            <asp:ListItem>Order ID</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="selector" Visible="false" runat="server"></asp:TextBox>
        <asp:Button ID="select" Visible="false" runat="server" Text="Search" OnClick="select_Click" />
    </div>
    <br />
    <br />
    <asp:GridView id="gridview1" runat="server"></asp:GridView>
    <div class="search">
        <asp:Label ID="NumOfProducts" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="TotalPrice" runat="server" Text=""></asp:Label>
    </div>
    

</asp:Content>
