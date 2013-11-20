<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RealtimeParams.ascx.cs"
    Inherits="PM.Web.realtime.RealtimeParams" %>
<ol class="breadcrumb">
    <li class="active">
        <asp:Literal ID="ltDescription" runat="server"></asp:Literal>的实时参数</li>
</ol>
 <ul class="nav nav-pills nav-stacked" style="max-width: 260px;">
        <li class="">
          <a href="#">
            <span class="badge pull-right">0</span>
            频率
          </a>
        </li>
        <li><a href="#"><span class="badge pull-right">189</span>温度</a></li>
        <li>
          <a href="#">
            <span class="badge pull-right">3</span>
            瞬时流量
          </a>
        </li>
        <li>
          <a href="#">
            <span class="badge pull-right">3</span>
            压力
          </a>
        </li>
        <li>
          <a href="#">
            <span class="badge pull-right">3</span>
            累计流量
          </a>
        </li>
        
      </ul>