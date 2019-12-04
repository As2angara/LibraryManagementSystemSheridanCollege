<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberEdit.aspx.cs" Inherits="LibraryManagementSystem.MemberEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogin" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMember" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderMemberEdit" runat="server">
    <div class ="bubble" style ="background-color: rgba(232, 233, 235, 1);">
            <h2>Profile</h2><hr />
            <br />
            <div class ="flex-spaceBetween-flexStart">
                <div>
                    <asp:Image ID="imgMember" runat="server" height ="150" style ="margin-right: 50px;"/>
                <br />
                <br>
                <br />

                </div>
                                <div>
                     <asp:Label ID="Label1" runat="server" Text="Member Info:"></asp:Label>
                    <br>
                     <br />
                    Username: <asp:TextBox ID="txtbUsername" runat="server" Enabled ="false"></asp:TextBox>
                    <br /><br>
                    Password:
                    <asp:TextBox ID="txtbPassword" runat="server"></asp:TextBox>
                    <br />
                </div>
               
            </div>
            
            <br />
            <h2>Contact</h2><hr />
            <br />
            Address:
            <asp:TextBox ID="txtbAddress" runat="server"></asp:TextBox>
            <br /><br>
            Phone #:
            <asp:TextBox ID="txtbPhoneNum" runat="server"></asp:TextBox>
            <br /><br>
            Email:
            <asp:TextBox ID="txtbEmail" runat="server"></asp:TextBox>
            
            <br />
            <br />
           
            <h2>Requests</h2><hr />
            <br />
            Request Account Deletion:
            <asp:Button ID="btnDeleteAccount" runat="server" Text="Delete" OnClick ="btnDeleteAccount_Click"/>

            <br />
            Save Changes:
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick ="btnSave_Click"/>

        </div>
</asp:Content>
