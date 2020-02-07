<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="JobPortal_Web.WebForm2" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link rel="stylesheet" href="Style.css" />
</asp:Content>


<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentbody">

        <table style="width: 100%;">
            <caption class="signup">
                <strong>Registration Form</strong>

                <tr>
                    <td>Name:</td>
                    <td>
                        <asp:TextBox ID="Firstname" runat="server" placeholder="Enter Firstname" Style="height: 25px"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ID="validateFN" ControlToValidate="Firstname" ErrorMessage="FirstName Required" Style="color: red">

                        </asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td>Last Name:</td>
                    <td>
                        <asp:TextBox ID="LastName" runat="server" placeholder="Enter Lastname" Style="height: 25px"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td>Phone Number:</td>
                    <td>
                        <asp:TextBox ID="Phonenumber" runat="server" placeholder="Enter phone number" Style="height: 25px"></asp:TextBox>
                    </td>
                    <%-- <td><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Style="color:red" ErrorMessage="Invalid Phone number" ControlToValidate="Phonenumber" ValidationExpression=@"^(\(?\s*\d{3}\s*[\)\-\.]?\s*)?[2-9]\d{2}\s*[\-\.]\s*\d{4}$"></asp:RegularExpressionValidator></td><--%>

                    <td></td>
                </tr>

                <tr>
                    <td>Password:</td>
                    <td>

                        <asp:TextBox runat="server" ID="Password" Placeholder="Enter Password" Style="height: 25px"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>Confirm Password:</td>
                    <td>
                        <asp:TextBox runat="server" ID="ConfirmPassword" placeholder="Re-Enter Password" Style="height: 25px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:CompareValidator runat="server" ControlToValidate="ConfirmPassword" ControlToCompare="Password" ErrorMessage="Password doesn't match" ID="comparePassword" Style="color: red"></asp:CompareValidator></td>
                </tr>

                <tr>
                    <td>Address:</td>
                    <td>
                        <asp:TextBox ID="Address" runat="server" placeholder="Enter address" Height="25px"></asp:TextBox>
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
                        <asp:TextBox ID="Email" runat="server" placeholder="Enter Email" Height="25px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="Regex" runat="server" Style="color: red" ErrorMessage="Invalid Email" ControlToValidate="Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td>Role:</td>
                    <td>
                        <asp:RadioButton ID="rdUser" runat="server" Text="JOB SEARCHER" GroupName="Role" Checked />

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="style2">
                        <asp:RadioButton ID="rdHR" runat="server" Text="RECRUITER" GroupName="Role" /></td>
                </tr>

                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        <center>  <asp:Button ID ="btnSignUp" runat="server" text= "Sign up"  onclick="SignUp_Click" ></asp:Button></center>

                    </td>
                </tr>

            </caption>
        </table>
    </div>
    </div>
</asp:Content>
