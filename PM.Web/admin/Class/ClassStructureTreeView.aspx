<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassStructureTreeView.aspx.cs" Inherits="PM.Web.admin.Class.ClassStructureTreeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>类别结构</title>
</head>
<body>
<div style="width:400px;height:200px; background:red;">
    <form id="form1" runat="server">
    <asp:TreeView ID="tvClassstructure" runat="server">
    </asp:TreeView>
    </form>
    </div>
</body>
</html>
