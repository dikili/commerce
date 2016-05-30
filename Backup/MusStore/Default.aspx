<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MusStore.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                <h2>
        Welcome to WCF test website
    </h2>
    <p>
        Pair 1:&nbsp;&nbsp;
        <asp:TextBox ID="txtP1First" runat="server"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="txtp1Second" runat="server"></asp:TextBox>
    </p>
    <p>
        Pair 2:&nbsp;&nbsp;
        <asp:TextBox ID="txtP2First" runat="server"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="txtp2Second" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnCalculate" runat="server" Text="Calculate"
                    onclick="btnCalculate_Click" />
    </p>
    <p>
        Addition:
        <asp:Label ID="lblsum" runat="server" Text=""></asp:Label>
    </p>
    <p>
        Subtraction:
        <asp:Label ID="lblminus" runat="server" Text=""></asp:Label>
    </p>
    </div>
    </form>
</body>
</html>
