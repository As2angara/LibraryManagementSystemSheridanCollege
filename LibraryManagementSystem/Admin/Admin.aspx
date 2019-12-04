<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="LibraryManagementSystem.Admin" %>
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
    <section class ="grid-2rows-1fr-2fr">
        <div style ="grid-area: top;">
            <div class ="bubble flex-center-center" style ="background-color: rgba(232, 233, 235, 1);">
                <asp:Image ID="Image1" runat="server" height ="150" style ="margin-right: 50px;"/>
                
                <div class ="bubble bubble-extra">
                    <h3>Contact Info:</h3>
                    <hr>
                    
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <br><br>
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    <br><br>
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                </div>

                <div class ="bubble bubble-extra">
                    <h3>Choose an action:</h3>
                    <asp:DropDownList ID="ddlAction" runat="server" OnSelectedIndexChanged="ddlAction_SelectedIndexChanged" AutoPostBack ="true"></asp:DropDownList><br><br>
                </div>

            </div>

        </div>
        <div class ="bubble flex-center-center-column" style ="background-color: rgba(232, 233, 235, 1); grid-area: main;">
            
            <asp:PlaceHolder ID="PlaceHolderDefault" runat="server" Visible ="true">
                <h1>Please Choose an Action.</h1>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible ="false">
                <div class ="flex-center-center">
                    <asp:Button ID="btnRequest1" runat="server" Text="Issue Requests" OnClick ="btnRequest1_Click"/>
                    <asp:Button ID="btnRequest2" runat="server" Text="Return Requests" OnClick ="btnRequest2_Click"/>
                    <asp:Button ID="btnRequest3" runat="server" Text="Extension Requests" OnClick ="btnRequest3_Click"/>
                </div>
                <br><br>
                 <table>
                    <tr>
                        <asp:PlaceHolder ID="PlaceHolderLoanId" runat="server" Visible ="false">
                        <td>Loan Id:</td>
                        <td>
                            <asp:TextBox ID="txtLoanId" runat="server" Width="67px"></asp:TextBox>
                  
                        </td>
                        </asp:PlaceHolder>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnApprove" runat="server" AccessKey=" " Text="Approve Request" OnClick="btnApprove_Click" Visible ="false"/>
                        </td>
                        <td>
                            <asp:Button ID="btnReject" runat="server" AccessKey=" " Text="Reject Request" OnClick="btnReject_Click" Visible ="false"/>
                        </td>
                    </tr>
                     <tr>
                         <td><asp:Button ID="btnReturned" runat="server" AccessKey=" " Text="Confirm Return" OnClick="btnReturned_Click" Visible ="false"/></td>
                         
                     </tr>
                     <tr>
                         <td><asp:Button ID="btnExtension" runat="server" AccessKey=" " Text="Confirm Extension" OnClick="btnExtend_Click" Visible ="false"/></td>
                     </tr>
                </table>

            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible ="false">
                <div class ="flex-center-center">
                    <asp:Button ID="btnReport1" runat="server" Text="All Book Information" OnClick ="btnReport1_Click"/>
                    <asp:Button ID="btnReport2" runat="server" Text="All Book Loans" OnClick ="btnReport2_Click"/>
                    <asp:Button ID="btnReport3" runat="server" Text="All Overdue Books" OnClick ="btnReport3_Click"/>
                </div>
                <br><br>
                <asp:Button ID="btnRefreshOverdues" runat="server" Text="Refresh Overdue Book Table" OnClick ="btnRefreshOverdues_Click" Visible ="false"/>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible ="false">
                <div>
                    Search
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                            &nbsp;By
                    <asp:DropDownList ID="ddlSearch" runat="server"></asp:DropDownList>
                            &nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick ="btnSearch_Click"/>
                </div>

            </asp:PlaceHolder>
            
            
           <br>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <br>

            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                

        </div>
    </section>
</asp:Content>
