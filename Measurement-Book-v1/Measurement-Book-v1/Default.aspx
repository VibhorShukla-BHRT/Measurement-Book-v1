<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Measurement_Book_v1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

<table>
    <tr>
        <td>Name:</td>
        <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Email:</td>
        <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Password:</td>
        <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView>

</asp:Content>
