<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LibraryManagementSystem.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogin" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMember" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderMemberEdit" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderLibrarian" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolderLogout" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolderRoot" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolderRegister" runat="server">
    <div class="bubble flex-center-center-column color1">
     <h2>Register</h2>
    <br><br>
        Username:
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br>
    
        Password:
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox><br>
   
        Confirm Password:
        <asp:TextBox ID="txtConfirmPassword" runat="server"></asp:TextBox><br><br>
    
        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
    
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    
        </div>
</asp:Content>
