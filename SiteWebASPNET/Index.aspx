<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="SiteWebASPNET.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <asp:Label ID="LabelSaisieNom" runat="server" Text="Entrez votre nom :"></asp:Label>
            <br />
            <br />


        </div>
        <asp:TextBox ID="TextBoxNom" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonOK" runat="server" Text="OK" OnClick="ButtonOK_Click" />

        <asp:Label ID="LabelBienvenue" runat="server" Text=""></asp:Label>

        <%
            foreach (var item in new string[] { "Admin", "Visiteur", "Collaborateur" })
            {
        %>
        <p><%=item %></p>
        <%
            }
        %>
    </form>
</body>
</html>
