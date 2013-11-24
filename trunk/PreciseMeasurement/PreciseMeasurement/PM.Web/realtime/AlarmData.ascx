<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlarmData.ascx.cs" Inherits="PM.Web.realtime.AlarmData" %>
<ol class="breadcrumb">
    <li class="active">
        <asp:Literal ID="ltDescription" runat="server"></asp:Literal>的报警信息</li>
</ol>
<div class="panel panel-default">
    <div class="panel-heading alarm">
                报警状态：<asp:DropDownList ID="ddlStatus" CssClass="status" runat="server">
                    <asp:ListItem Value="0">未确认</asp:ListItem>
                    <asp:ListItem Value="1">已确认</asp:ListItem>
                    <asp:ListItem Value="-1">全部</asp:ListItem>
                </asp:DropDownList>
                起始时间：<asp:TextBox ID="txtStartDate" CssClass="startdate" runat="server"></asp:TextBox>
                &nbsp;终止时间：<asp:TextBox ID="txtEndDate" CssClass="enddate" runat="server"></asp:TextBox>
                &nbsp;
                <button type="button" class="btn btn-danger btnAlarmQuery" id="btnAlarmQuery">查询</button>
                
      </div>
     <div class="panel-body">
        <div class="bs-docs-section">
            <asp:GridView ID="gvAlarmData" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" EnableModelValidation="True" CssClass="table table-striped table-hover">
                <Columns>
                    <asp:TemplateField HeaderText="报警类型">
                        <ItemTemplate>
                            低报警 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MEASUREVALUE" HeaderText="报警值" />
                    <asp:BoundField DataField="ALMCOMMENT" HeaderText="报警描述" />
                    <asp:BoundField DataField="LOGTIME" HeaderText="报警时间" />
                    <asp:BoundField DataField="ACKTIME" HeaderText="确认时间" />
                    <asp:BoundField DataField="ACKOPERATORNAME" HeaderText="确认人" />
                    <asp:TemplateField HeaderText="处理">
                        <ItemTemplate>处理</ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Visible="False" />
            </asp:GridView>
            <br />
            <div id="alarmpager" class="pager"></div>
        </div>
    </div>
</div>