<%@ Page Title="水系统结构图" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="water.aspx.cs" Inherits="PM.Web.structure.water" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/lang/zh-cn.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/WdatePicker.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/assets/js/ASPSnippets_Pager.min.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/assets/js/steamtrap.js") %>"></script>
    <script>
        var USERID = "<%=userid %>";
        var ORGID = "<%=orgid %>";
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3" class="structure-title">
                水系统图
            </td>
        </tr>
        <tr>
            <td colspan="3" id="tools" class="structure-tools">
                <span>拖动以确定位置，然后点击确定按钮。</span>
                <input type="button" id="btnSave" value="确定" />
            </td>
        </tr>
        <tr style="vertical-align: top">
            <td>
                <div class="structure" id="structure">
                    <asp:Repeater ID="rptAsset" runat="server">
                        <ItemTemplate>
                            <div id="<%# Eval("ASSETNUM") %>" title="<%# Eval("Description") %>" class="meter"
                                uid="<%# Eval("ASSETUID") %>" style="left: <%# Eval("EC1") %>px; top: <%# Eval("EC2") %>px;">
                                <span class="text">
                                    <%# Eval("ASSETNUM")%></span> <span class="steamtrap_status invalid"></span>
                            </div>
                            <div id="<%# Eval("ASSETNUM") %>_data" class="popover meter_content" style="display: none;">
                                <div class="arrow">
                                </div>
                                <button type="button" class="close">
                                    &times;</button>
                                <h3 class="popover-title">
                                    <%# Eval("Description") %>[<%# Eval("ASSETNUM")%>]</h3>
                                <div class="popover-content">
                                    <div class="form-group">
                                        <div class="col-lg-5 text-right">
                                            前端温度:</div>
                                        <div class="col-lg-7 front_temperature">
                                            <span>-</span> ℃</div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-5 text-right">
                                            后端温度:</div>
                                        <div class="col-lg-7 after_temperature">
                                            <span>-</span> ℃</div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-5 text-right">
                                            采集时间:</div>
                                        <div class="col-lg-7 measuretime">
                                            <div>
                                                -</div>
                                        </div>
                                    </div>
                                    <div class="detail text-center">
                                        <a href="../analysis/streamtrap.aspx?assetuid=<%# Eval("ASSETUID") %>">查看详细</a></div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <img src="../assets/img/systemrunchart.png" width="1100" alt="" />
                </div>
            </td>
        </tr>
    </table>
    <div style="width:500px;margin:20px auto;">
    <div class="row">
         <div class="meter col-md-3">
            <span class="steamtrap_status invalid"></span><span class="text">失效</span>
        </div>
        <div class="meter col-md-3">
            <span class="steamtrap_status normal"></span><span class="text">正常</span>
        </div>
        <div class="meter col-md-3">
            <span class="steamtrap_status error"></span><span class="text">堵塞</span>
        </div>
        <div class="meter col-md-3">
            <span class="steamtrap_status warn"></span><span class="text">直通</span>
        </div>
        </div>
    </div>


</asp:Content>
