<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="PM.Web.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="HOUR DATA" />
        <asp:Button ID="Button2" runat="server"  Text="DAY DATA" 
            onclick="Button2_Click" />
        <asp:Button ID="Button3" runat="server"  Text="MONTH DATA" 
            onclick="Button3_Click" />
    
        <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
            Text="RealtimeData" />
        <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
    </div>
    <asp:Button ID="Button5" runat="server" onclick="Button5_Click" 
        Text="FindFirstMeasurement" />
    </form>
</body>
</html>
