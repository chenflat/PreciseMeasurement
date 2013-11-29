<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="PM.Web.valve._default" %>

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
                <input type="button" class="btn btn-danger" id="btnChart" value="查看趋势" />
            </div>
        </div>
    </div>
    <div class="row">
    <table class="table table-bordered table-hover">
    <thead>
        <tr>
            <th>计量点</th>
            <th>起始时间</th>
            <th>起始值</th>
            <th>终止时间</th>
            <th>终止值</th>
            <th>时间用量</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    
    </tbody>
    </table>


    </div>
</asp:Content>
