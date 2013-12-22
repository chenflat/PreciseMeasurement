<%@ Page Title="疏水系统结构图" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="steamtrap.aspx.cs" Inherits="PM.Web.structure.steamtrap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/lang/zh-cn.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/WdatePicker.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/ASPSnippets_Pager.min.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/steamtrap.js") %>"></script>
    <script>
        var USERID = "<%=userid %>";
        var ORGID = "<%=orgid %>";
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <table width="100%" cellpadding="0" cellspacing="0">
<tr>
    <td colspan="3" class="structure-title">蒸汽蒸汽疏水阀系统图</td>
</tr>
<tr>
 <td colspan="3" id="tools" class="structure-tools"><span>拖动以确定位置，然后点击确定按钮。</span>
             <input type="button" id="btnSave" value="确定" /></td>
</tr>
<tr style="vertical-align:top">
    <td>
     <div class="structure pull-left" id="structure">
        <div id="refresh"> <img src="../assets/img/refresh.png" id="refreshData" style="cursor:pointer;" title="点击获取实时值" /> <span id="counter">60</span>秒后刷新</div>
        <asp:Repeater ID="rptAsset" runat="server">
        <ItemTemplate>
            <div id="<%# Eval("ASSETNUM") %>" title="<%# Eval("Description") %>" class="meter" uid="<%# Eval("ASSETUID") %>" style="left:<%# Eval("EC1") %>px;top:<%# Eval("EC2") %>px;">
            <span class="text"><%# Eval("ASSETNUM")%></span>
            <span class="icon"></span>
            </div>
            <div id="<%# Eval("ASSETNUM") %>_data" class="popover meter_content" style="display:none;">
            <div class="arrow"></div>
            <button type="button" class="close">&times;</button>
            <h3 class="popover-title"><%# Eval("Description") %>[<%# Eval("ASSETNUM")%>]</h3>
                <div class="popover-content">
                <div class="form-group">
                    <div class="col-lg-5 text-right">前端温度:</div>
                    <div class="col-lg-7 front_temperature"> <span>-</span> ℃</div>
                </div>
                
                 <div class="form-group">
                    <div class="col-lg-5 text-right">后端温度:</div>
                    <div class="col-lg-7 after_temperature"><div>-</div></div>
                </div>
               
                <div class="detail text-center"><a href="detailinfo.aspx?assetuid=<%# Eval("ASSETUID") %>">查看详细</a></div>
 
                </div>
            
            </div>
       
        </ItemTemplate>
        </asp:Repeater>
        <img src="../assets/img/systemrunchart.png" width="1100" alt="" />
    </div>
    </td>
    <td> <div class="swichbar" id="swichbar">>></div></td>
    <td>
    <div class="table-responsive" style="z-index:50; display:none;" id="realdata">

            <div class="alert alert-info">
            <span id="spanType1" style="overflow: hidden;">
                                <input id="radSteam1" type="radio" value="汽" name="carrier" style="width: 15px; height: auto; margin: auto; padding: 0px; cursor: pointer;" checked="checked">
                                <label for="radSteam1" style="cursor: pointer;">汽</label>
                                <input id="radWater1" type="radio" value="水" name="carrier" style="width: 15px; height: auto; margin: auto; padding: 0px; cursor: pointer;">
                                <label for="radWater1" style="cursor: pointer;">水</label>
                                 <input id="radAll" type="radio" value="" name="carrier" style="width: 15px; height: auto; margin: auto; padding: 0px; cursor: pointer;">
                                <label for="radAll" style="cursor: pointer;">全部</label>
                            </span>
                        
            
            </div>
          
        <table class="table table-bordered table-striped" id="gvRealtimeData">
        <thead>
            <tr>
                <th>计量点</th>
                <th>采集时间</th>
                <th>压力(MPa)</th>
                <th>温度(℃)</th>
                <th>瞬时流量(t/h)</th>
            </tr>
        </thead>
        <tbody>
        
        </tbody>
        </table>
    </div>
    </td>
</tr>
</table>



</asp:Content>