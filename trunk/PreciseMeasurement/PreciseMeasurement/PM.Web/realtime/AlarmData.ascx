<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlarmData.ascx.cs" Inherits="PM.Web.realtime.AlarmData" %>
<ol class="breadcrumb">
    <li class="active">
        <asp:Literal ID="ltDescription" runat="server"></asp:Literal>的报警信息</li>
</ol>
<div class="panel panel-default">
    <div class="panel-heading alarm">
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
                &nbsp; <button id="btnAlarmQuery" class="btn btn-danger btnAlarmQuery" type="button" data-bind="click: loadAlarmlogs">查询</button>
                
      </div>
     <div class="panel-body">
        <div class="bs-docs-section">
           <table class="table table-bordered table-striped" data-bind="dataTable:
            {
                dataSource: alarmlogInfos,
                rowTemplate: 'alarmlogGridTemplate',
                iDisplayLength: 10,
                sPaginationType: 'bootstrap',
                gridId: 'alarmlogGrid',
                sDom: 't<\'row\'<\'col-md-6\'i><\'col-md-6 text-right\'p>>',
                columns: [
                    {'name':'Pointnum' },
                    {'name':'Alarmtype' },
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
            <td data-bind="text: Pointnum"></td><td data-bind="text: Alarmtype"></td><td data-bind="text: Measureunitname"></td><td data-bind="    text: Measurevalue"></td>
            <td data-bind="text: Almcomment"></td>
            <td data-bind="text: Logtime"></td>
            <td data-bind="text: Acktime"></td>
            <td data-bind="text: Ackoperatorname"></td>
            <td data-bind="text: Logid"></td>

            </script>
        </div>
    </div>
</div>