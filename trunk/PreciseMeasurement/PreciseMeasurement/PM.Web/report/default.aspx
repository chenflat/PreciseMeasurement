<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="PM.Web.report._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/lang/zh-cn.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/WdatePicker.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/cookies/jquery.cookies.2.2.0.min.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/ASPSnippets_Pager.min.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>

<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/moment/moment-with-langs.min.js") %>"></script>

<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/report.js") %>"></script>
<script language="javascript">
    var USERID = "<%=userid %>";
    var ORGID = "<%=orgid %>"; 
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="bs-docs-section">
            <div class="toolbar bs-callout-info">
                起始时间：
                <asp:TextBox ID="startdate" CssClass="Wdate startdate" runat="server"></asp:TextBox>
                <label for="enddate" class="endzone">
                &nbsp;终止时间：<asp:TextBox ID="enddate" CssClass="Wdate enddate" runat="server"></asp:TextBox></label>
                级别：<asp:DropDownList ID="ddlLevel" runat="server" CssClass="level">
                     <asp:ListItem Value="">全部</asp:ListItem>
                     <asp:ListItem Value="1">一级</asp:ListItem>
                     <asp:ListItem Value="2">二级</asp:ListItem>
                     <asp:ListItem Value="3">三级</asp:ListItem>
                     <asp:ListItem Value="4">四级</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                部门：<asp:DropDownList ID="ddlOrgId" runat="server" CssClass="orgid"></asp:DropDownList>
                <button type="button" class="btn btn-info" id="btnQuery">查询</button>
                <asp:Button ID="btnExport" runat="server" Text="导出Excel" CssClass="btn btn-info" />
               
                <a href="custom.aspx" class="btn btn-danger" id="btnCustomReport">报表统计</a>
                
            </div>
        </div>
    </div>
    <div class="row">
    <asp:GridView ID="gvMeasurementReport" runat="server" AutoGenerateColumns="False" 
            CssClass="table table-bordered table-striped table-hover"  EnableModelValidation="True" 
            BorderStyle="None" BorderWidth="0px">
            <Columns>
                <asp:BoundField DataField="DESCRIPTION" HeaderText="计量点" />
                <asp:TemplateField HeaderText="级别">
                    <ItemTemplate>
                        <%# PM.Common.Utils.ConvertToRoma(PM.Common.Utils.StrToInt(Eval("LEVEL"),0))%> 级
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="STARTTIME" DataFormatString="{0:yyyy-MM-dd hh:mm}" HeaderText="起始时间" />
                <asp:BoundField DataField="STARTVALUE" HeaderText="起始表数(t)" />
                 <asp:BoundField DataField="ENDTIME" DataFormatString="{0:yyyy-MM-dd hh:mm}" HeaderText="截止时间" />
                <asp:BoundField DataField="LASTVALUE" HeaderText="终止表数(t)" />
                <asp:BoundField DataField="VALUE" HeaderText="日用量(t)" />
            
            </Columns>
        </asp:GridView>
        <br />
        <div id="pager" class="pager">
        </div>
    
    </div>
</asp:Content>
