<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FrontPage.aspx.cs" Inherits="JobPortal_Web.FrontPage" %>
 <asp:Content ID="ContentHome" runat="server" contentplaceholderid="head">
     <link rel="stylesheet" href="Style.css" />
     
   </asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   


    <div class="home">
   
        
       <asp:HyperLink ID="hyp_login" text="login"  NavigateUrl="~/WebForm1.aspx" runat="server" align="center" Font-Bold="true">LogIn</asp:HyperLink>

       <asp:HyperLink ID="hyp_signup" text="login" NavigateUrl="~/WebForm2.aspx" align="center" runat="server" Font-Bold="true">SignUp</asp:HyperLink>
  

    </div>

</asp:Content>
