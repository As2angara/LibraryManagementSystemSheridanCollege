<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibraryManagementSystem.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogin" runat="server">
     <section class ="flex-center-center" height: auto;" >
            <div class ="bubble" id ="login-form">
                <div>
                    <h1 style ="margin-bottom: 70px">Login: </h1>
                    Username: <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br><br>
                    Password: <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox><br><br><br>
                    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />

                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
                
            </div>
        </section>
</asp:Content>
