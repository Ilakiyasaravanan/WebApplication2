<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FrontPage.aspx.cs" Inherits="JobPotal_Entity.FrontPage" %>

<asp:Content ID="ContentHome" runat="server" ContentPlaceHolderID="head">
    <link rel="stylesheet" href="Style.css" />

</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="home">

        <asp:HyperLink ID="hyp_grid" Text="gridview" NavigateUrl="~/GridSample.aspx" align="center" runat="server" Font-Bold="true">GridView</asp:HyperLink>
        <asp:HyperLink ID="hyp_login" Text="login" NavigateUrl="~/LogIn.aspx" runat="server" align="center" Font-Bold="true">LogIn</asp:HyperLink>

        <asp:HyperLink ID="hyp_signup" Text="signup" NavigateUrl="~/SignUpPage.aspx" align="center" runat="server" Font-Bold="true">SignUp</asp:HyperLink>


    </div>

</asp:Content>
