<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UserMaster.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="_328419122.Users.Catalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="tbl-header">
        <div class ="container">
            <asp:GridView ID="GridView1" AlternatingRowStyle-CssClass="fl-table" runat="server" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    
                    <asp:ButtonField  Text="Add" />
                </Columns>
                
            </asp:GridView>
        

    </div>

        <div class ="sal">
            <asp:GridView ID="GridView2" runat="server"></asp:GridView> 
            <asp:Button ID="cart" class="btn1" runat="server" Visible="false" Text="Move To Cart" OnClick="cart_Click" />
        </div>
            
       
              
        </div>

</asp:Content>
