<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="PM.Web.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>异常提示</title>
    <link href="~/assets/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/assets/css/custom-theme/jquery-ui-1.10.0.custom.css" rel="stylesheet"
        type="text/css" />
    <link href="~/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="~/assets/css/icon.css" rel="stylesheet" type="text/css" />
    <link href="~/assets/css/pygments-manni.css" rel="stylesheet" />
    <link href="~/assets/lib/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css"
        rel="stylesheet" />
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="<%=ResolveUrl("~/assets/js/html5shiv.js") %>"></script>
      <script src="<%=ResolveUrl("~/assets/js/respond.min.js") %>"></script>
    <![endif]-->
    <script src="<%=ResolveUrl("~/assets/js/jquery.js") %>"></script>
    <script src="<%=ResolveUrl("~/assets/js/bootstrap.js") %>"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="alert alert-warning">
        <strong>提示!</strong>
        <asp:Label ID="lblErrmsg" runat="server" Text="对不起，您的此次登录已失效，请重新登录."></asp:Label>
        <a href="<%=strBasePath %>Account/Login.aspx" class="alert-link">返回</a>.
    </div>
    </form>
</body>
</html>
