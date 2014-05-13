<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="PM.Web.alarm._default" %>

<%@ Register src="../controls/PageControl.ascx" tagname="PageControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/lang/zh-cn.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/WdatePicker.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/ASPSnippets_Pager.min.js") %>"></script>

    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/moment/moment-with-langs.min.js") %>"></script>

<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/alarm.js") %>"></script>
<script>
        var USERID = "<%=userid %>";
        var ORGID = "<%=orgid %>";
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="bs-docs-section">
            <div class="toolbar bs-callout-info alarm">
                报警状态：
                <select id="ddlStatus" name="ddlStatus" class="status input-sm" >
                    <option value="0">未确认</option> 
                    <option value="1">已确认</option> 
                    <option value="-1">全部</option> 
                </select>

                起始时间：
                   <input type="text" class="startdate" name="txtStartDate" id="txtStartDate" />  
                   &nbsp;
                终止时间：<input type="text" class="enddate" name="txtEndDate" id="txtEndDate" />  
                &nbsp; <button id="btnAlarmQuery" class="btn btn-danger btnAlarmQuery" type="button" data-bind="click:loadAlarmlogs">查询</button>
                
                <asp:Button ID="btnTotal" runat="server" Text="统计" CssClass="btn btn-danger" />
                <asp:Button ID="btnPing" runat="server" Text="通信状态" CssClass="btn btn-danger" />
                <asp:Button ID="btnExport" runat="server" Text="导出Excel" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="bs-docs-section">


            <table id="alarmgrd" class="table table-bordered table-striped" data-bind="dataTable:
            {
                dataSource: alarmlogInfos,
                rowTemplate: 'alarmlogGridTemplate',
                iDisplayLength: 10,
                sPaginationType: 'bootstrap',
                gridId: 'alarmlogGrid',
                sDom: 't<\'row\'<\'col-md-6\'i><\'col-md-6 text-right\'p>>', 
                columns: [
                    {'name':'Pointnum' },
                    {'name':'AlarmtypeDesc' },
                    {'name':'Measureunitname' },
                    {'name':'Measurevalue'},
                    {'name':'Almcomment'},
                    {'name':'Logtime'},
                    {'name':'Acktime'},
                    {'name':'Ackoperatorname'},
                    {'name':'Logid'}
                ]}">
                    <thead>
                        <tr>
                            <th>计量点</th>
                            <th>报警类型</th>
                            <th>报警参量</th>
                            <th>报警值</th>
                            <th>报警描述</th>
                            <th>报警时间</th>
                            <th>确认时间</th>
                            <th>确认人</th>
                            <th>处理</th>
                        </tr>
                    </thead>
                    
                    <tbody>
                    </tbody>
        </table>
                    
        <script Id="alarmlogGridTemplate" type="text/html">
            <td data-bind="text: Pointnum"></td>
            <td data-bind="text: AlarmtypeDesc"></td>
            <td data-bind="text: Measureunitname"></td>
            <td data-bind="text: Measurevalue"></td>
            <td data-bind="text: Almcomment"></td>
            <td data-bind="text: Logtime"></td>
            <td data-bind="text: Acktime"></td>
            <td data-bind="text: Ackoperatorname"></td>
                <td><a href="#" data-bind="attr : {id: Logid }">处理</a></td>

            </script>
            
        </div>
    </div>
</asp:Content>
