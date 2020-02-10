<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SignUpPage.aspx.cs" Inherits="JobPotal_Entity.SignUpPage" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link rel="stylesheet" href="Style.css" />
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"><div class="contentbody" align="center">   <strong>Registration Form</strong> </div>
    <table style="width: 100%;"> 
                <tr>
                    <td>First Name:</td>
                    <td>
                        <asp:TextBox ID="txtFirstname" runat="server" placeholder="Enter Firstname" Style="height: 25px"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ID="validateFN" ControlToValidate="txtFirstname" ErrorMessage="FirstName Required" Style="color: red">

                        </asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td>Last Name:</td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server" placeholder="Enter Lastname" Style="height: 25px"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td>Phone Number:</td>
                    <td>
                        <asp:TextBox ID="txtPhonenumber" runat="server" placeholder="Enter phone number" Style="height: 25px"></asp:TextBox>
                    </td>
                     <td><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Style="color:red" ErrorMessage="Invalid Phone number" ControlToValidate="txtPhonenumber" ValidationExpression="[9876]\d{9}"></asp:RegularExpressionValidator></td><

                    <td></td>
                </tr>

                <tr>
                    <td>Password:</td>
                    <td>

                        <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" Placeholder="Enter Password" Style="height: 25px"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>Confirm Password:</td>
                    <td>
                        <asp:TextBox runat="server"  ID="txtConfirmPassword" TextMode="Password" placeholder="Re-Enter Password" Style="height: 25px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:CompareValidator runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ErrorMessage="Password doesn't match" ID="comparePassword" Style="color: red"></asp:CompareValidator></td>
                </tr>

                <tr>
                    <td>Address:</td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter address" Height="25px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Gender:</td>
                    <td>
                        <asp:RadioButtonList ID="rdGender" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>

                </tr>
            <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" placeholder="Enter Email" Height="25px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="Regex" runat="server" Style="color: red" ErrorMessage="Invalid Email" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                </tr>
                
                  <tr>
                    <td>Role:</td>
                    <td>
                        <asp:RadioButtonList ID="rdUser" runat="server">
                            <asp:ListItem>Job Searcher</asp:ListItem>
                            <asp:ListItem>Recruiter</asp:ListItem>                           
                        </asp:RadioButtonList>
                    </td>
                </tr>
                
        </table>
    <div align="center"><asp:Button ID="btnSign" runat="server" OnClick="SignUp_Click" Text="SignUp" /></div>
    
</asp:Content>