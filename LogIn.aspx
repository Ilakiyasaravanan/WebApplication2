<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="JobPotal_Entity.LogIn" %>
 
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div></div>
               <h2 align="center"> Login Form</h2>
               
      
        <table style="width: 100%;">
            <tr>
             
                <td class="auto-style5" >Account Number:</td>
                <td>
                      <asp:TextBox ID="txtAccountNumber"  runat="server"  placeholder="Enter Accountnumber" Height="25px">
              </asp:TextBox> 
                   
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Password:</td>
                <td>
                  
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" placeholder="Enter Password" Height="25px">
              </asp:TextBox>  </td>

            </tr>


            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

       
            <div>
                <center>
			<asp:Button ID="Button1" runat="server" Text="Login" OnClick="LoginButton" Width="111px" > </asp:Button>
			</center>
            </div>
      
        
    </asp:Content>


   



