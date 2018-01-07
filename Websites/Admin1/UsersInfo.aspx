<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsersInfo.aspx.cs" Inherits="UsersInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        The access of this Information is restricted to priveleged staff only.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="SignOutButton" runat="server" OnClick="SignOutButton_Click" Text="Sign Out" />
        <br />
        This page displays the registered users and their Information: 
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send Message" />
        <br />
        <br />
        <asp:Label ID="DataLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <br />
        Verify the bank account and set the status to verified<br />
        <br />
        Username
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="SetStatusButton" runat="server" OnClick="SetStatusButton_Click" Text="Set Status" />
        <br />
        <%--<asp:GridView ID="GridView1" runat="server" AllowSorting="True">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="#33CCFF" />
        </asp:GridView>--%>
    </form>
</body>
</html>
