<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Measurement_Book_v1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!--<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

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
</table>-->
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True"></asp:GridView>

<asp:CheckBox ID="chkSolar" runat="server" Text="Solar" />
<asp:CheckBox ID="chkSVS" runat="server" Text="SVS" />
<asp:CheckBox ID="chkRetro" runat="server" Text="Retro" />
<asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="BtnFilter_Click" />

<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
    <Columns>
        <asp:BoundField DataField="ComponentName" HeaderText="Component Name" />
        <asp:BoundField DataField="Unit" HeaderText="Unit" />

        <asp:TemplateField HeaderText="Amount">
            <ItemTemplate>
                <asp:TextBox ID="txtAmount" runat="server" AutoPostBack="true" 
                    OnTextChanged="txtAmount_TextChanged"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Percentage">
            <ItemTemplate>
                <asp:Label ID="lblPercentage" runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<asp:Button ID="Button1" runat="server" Text="Save" OnClick="BtnSave_Click" />

</asp:Content>
