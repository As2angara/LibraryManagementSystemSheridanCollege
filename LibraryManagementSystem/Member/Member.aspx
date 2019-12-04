<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="LibraryManagementSystem.Member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogin" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMember" runat="server">
    <div class ="main-section" id ="main-section-member">
            <div id ="member-info">
                <asp:Image ID="imgMember" runat="server" height ="150" style ="margin-right: 50px;"/>
                <div class ="bubble bubble-extra">
                    Contact info:<hr><br>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br><br>
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label><br><br>
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                    <br>
                </div>
                <div class ="bubble bubble-extra" >
                    Overdue Books: Actions
                    <br><br><br>
                    <asp:DropDownList ID="ddlOverdues" runat="server">
                    </asp:DropDownList>
                    <br><br><br>
                    <asp:Button ID="btnOverdueAction" runat="server" Text="View Information" OnClick ="btnOverdueAction_Click"/>
                </div>
                <div class ="bubble bubble-extra">
                    <div>
                   Other:
                    <br><br><br>
                    
                    <asp:Button ID="btnViewProfile" runat="server" Text="View Profile" OnClick ="btnViewProfile_Click" CausesValidation="false" />
                        </div>
                </div>
            </div>
           
            <div id ="tables-info" class ="flex-center-center-column">
                <br><br>
                <div class ="flex-center-center">
                    <asp:Button ID="btnLoanBook" runat="server" Text="Loan Book" OnClick="btnLoanBook_Click" />
                
                    <asp:Button ID="btnReturnBook" runat="server" Text="Return Book" OnClick="btnReturnBook_Click" />
                
                    <asp:Button ID="btnHistory" runat="server" Text="Book Loan History" OnClick="btnHistory_Click"/>

                    <asp:Button ID="BtnSearchForBook" runat="server" Text="Search For Book" OnClick="BtnSearchForBook_Click"/>
                </div>
                <br><br>
                <div>
                    <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible ="false">
                        Search
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                        &nbsp;By
                    <asp:DropDownList ID="ddlSearch" runat="server">
                    </asp:DropDownList>
                        &nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        </asp:PlaceHolder>
                </div>
                <br><br>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible ="false">
                 <table>
                    <tr>
                        <td>Copy Id:</td>
                        <td>
                            <asp:TextBox ID="txtCopyId" runat="server" Width="67px"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>Book Name:</td>
                        <td>
                            <asp:TextBox ID="txtBookName" runat="server" Enabled ="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnRequestLoan" runat="server" AccessKey=" " Text="Request Loan" OnClick="btnRequestLoan_Click" Visible ="false"/>
                            <asp:Button ID="btnRequestReturn" runat="server" AccessKey=" " Text="Request Return" Visible ="false" OnClick="btnRequestReturn_Click"/>
                            <asp:Button ID="btnRequestExtension" runat="server" AccessKey=" " Text="Request Extension" Visible ="false" OnClick="btnRequestExtension_Click"/>
                        </td>
                    </tr>
                </table>
                </asp:PlaceHolder>
                 <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible ="false">
                 <h3>Pay for Overdue Book:</h3>
                 <table>
                    <tr>
                        <td>Loan Id:</td>
                        <td>
                            <asp:TextBox ID="txtLoanId" runat="server" Width="67px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Payment Amount:</td>
                        <td>
                            <asp:TextBox ID="txtPaymentAmount" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnMakePayment" runat="server" AccessKey=" " Text="Make Payment" OnClick="btnMakePayment_Click"/>
                        </td>
                    </tr>
                </table>
                </asp:PlaceHolder>
                <br>
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                <br>
                <asp:GridView ID="GridView1" runat="server" Height="267px" Width="388px"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" >
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                
                </asp:GridView>
                <br><br>
            
            </div>
            
    </div>
</asp:Content>
