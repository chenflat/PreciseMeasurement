<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PM.Web.valve._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/lang/zh-cn.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/WdatePicker.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/ASPSnippets_Pager.min.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/valve.js") %>"></script>
<script>
    var USERID = "<%=userid %>";
    var ORGID = "<%=orgid %>";
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="row">
        <div class="bs-docs-section">
            <div class="alert alert-warning">
                时间类型：<label><input type="radio" name="datetype" checked="checked" value="MINUTE" />分钟</label>
                <label>
                    <input type="radio" name="datetype" value="HOUR" />小时</label>
                &nbsp;&nbsp;&nbsp;&nbsp; 起始时间：<input type="text" id="startdate" class="Wdate startdate" />
                终止时间：<input type="text" class="Wdate enddate" id="enddate" />
               
                <input type="button" class="btn btn-danger" id="btnQuery" value="查询" />
            </div>
        </div>

    </div>
</asp:Content>
