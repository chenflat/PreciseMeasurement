<%@ Page Title="系统结构" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PM.Web.structure._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/knockout/knockout-3.1.0.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/moment/moment-with-langs.min.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/structure.js") %>"></script>
<!--<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/structure_realdata.js") %>"></script>-->
<script>
    var USERID = "<%=userid %>";
    var ORGID = "<%=orgid %>";
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
    <td colspan="3" class="structure-title">蒸汽计量系统图</td>
</tr>
<tr>
 <td colspan="3" id="tools" class="structure-tools"><span>拖动以确定位置，然后点击确定按钮。</span>
             <button type="button" id="btnSave" autocomplete="off" data-loading-text="Saveing..." class="btn">
  确定
</button>
             </td>
</tr>
<tr style="vertical-align:top; ">
    <td id="structWrap" class="scrollable">
     <div class="structure" id="structure">
        <div id="refresh"> <img src="../assets/img/sync.gif" id="refreshData" style="cursor:pointer;" title="点击获取实时值" /> <span id="counter">60</span>秒后刷新</div>
        <asp:Repeater ID="rptMeasurePoint" runat="server">
        <ItemTemplate>
            <div id="<%# Eval("Pointnum") %>" title="<%# Eval("Description") %>" class="meter text-center" style="left:<%# Eval("X") %>px;top:<%# Eval("Y") %>px;" devicenum="<%# Eval("Devicenum") %>" cardnum="<%# Eval("Cardnum") %>" orgid="<%# Eval("Orgid") %>">
          
            <span class="icon nomarl"> <br />
                <span class="text"><%# Eval("Pointnum") %></span>
            </span>
             
           <%-- <span class="status"><img src="../assets/img/status_on.gif" width="16px" alt="数据采集正常"/></span>--%>
            </div>
            <div id="<%# Eval("Pointnum") %>_data" class="popover meter_content" style="display:none;">
            <div class="arrow"></div>
            <button type="button" class="close">&times;</button>
            <h3 class="popover-title"><%# Eval("Description") %>[<%# Eval("Pointnum") %>]</h3>
                <div class="popover-content">
                <div class="form-group">
                    <div class="col-lg-5 text-right">温度:</div>
                    <div class="col-lg-7 SW_Temperature"> <span>-</span> ℃</div>
                </div>
                <div class="form-group">
                    <div class="col-lg-5 text-right">压力:</div>
                    <div class="col-lg-7 SW_Pressure"><span>-</span> MPa</div>
                </div>
                <div class="form-group">
                    <div class="col-lg-5 text-right">瞬时流量:</div>
                    <div class="col-lg-7 AF_FlowInstant"><span>-</span> t/h</div>
                </div>
                <div class="form-group">
                    <div class="col-lg-5 text-right">累积流量:</div>
                    <div class="col-lg-7 AT_Flow"><span>-</span> t</div>
                </div>
                 <div class="form-group">
                    <div class="col-lg-5 text-right">频率:</div>
                    <div class="col-lg-7 AI_Density"><span>-</span> Hz</div>
                </div>
                 <div class="form-group">
                    <div class="col-lg-5 text-right">采集时间:</div>
                    <div class="col-lg-7 MEASURETIME"><div>-</div></div>
                </div>
               
                <div class="detail text-center"><a href="../realtime/default.aspx?measurepointid=<%# Eval("Measurepointid") %>">查看详细</a></div>
 
                </div>
            
            </div>
       
        </ItemTemplate>
        </asp:Repeater>
        <img src="../assets/img/systemrunchart.png" width="1100" alt="" id="structrueimg" />
    </div>
    </td>
    <td> <div class="swichbar" id="swichbar">>></div></td>
    <td>
    <div class="table-responsive scrollable" style="z-index:50; display:none;" id="realdata">

            <div class="alert alert-info">
            <span id="spanType1" style="overflow: hidden;">
                                <input id="radSteam1" type="radio" value="steam" name="carrier" style="width: 15px; height: auto; margin: auto; padding: 0px; cursor: pointer;">
                                <label for="radSteam1" style="cursor: pointer;">汽</label>
                                <input id="radWater1" type="radio" value="water" name="carrier" style="width: 15px; height: auto; margin: auto; padding: 0px; cursor: pointer;">
                                <label for="radWater1" style="cursor: pointer;">水</label>
                                 <input id="radAll" type="radio" value="" name="carrier" style="width: 15px; height: auto; margin: auto; padding: 0px; cursor: pointer;" checked="checked">
                                <label for="radAll" style="cursor: pointer;">全部</label>
                            </span>
                        
            
            </div>
          
        <div id="datalist">
        <table class="table table-bordered table-striped" id="gvRealtimeData">
        <thead>
            <tr>
                <th>计量点</th>
                <th>采集<br />时间</th>
                <th>压力<br />(MPa)</th>
                <th>温度<br />(℃)</th>
                <th>瞬时<br />流量(t/h)</th>
            </tr>
        </thead>
        <tbody data-bind="foreach: measurepoint().rows"> 
            <tr data-bind="attr:{type:Carrier}">
                <td data-bind="text: fullName"></td>
                <td data-bind="text: time"></td>
                <td data-bind="text: formattedPressure"></td>
                <td data-bind="text: formattedTemp"></td>
                <td data-bind="text: AfFlowinstant"></td>
            </tr>
        </tbody>
        </table>

        
            
            </div>
    </div>
    </td>
</tr>
</table>

<div class="row">
   
   
    
</div>


</asp:Content>
