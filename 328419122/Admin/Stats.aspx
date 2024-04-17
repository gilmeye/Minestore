<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Stats.aspx.cs" Inherits="_328419122.Admin.Stats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Statistics</h1>

    <h3>Site rating</h3>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

    <h3>sales by month</h3>
    <div class="select">
        <asp:Label runat="server" Text="Select month"></asp:Label>
        <asp:DropDownList ID="D1" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="D1_SelectedIndexChanged">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
        </asp:DropDownList>
    </div>

    <table id="pTable">
        <tr>
            <td>Products sold</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Total money made</td>
            <td> 
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Most popular product</td>
            <td>
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>


    <h3>Users who orderded</h3>
    <asp:GridView ID="G2" runat="server"></asp:GridView>

</asp:Content>
