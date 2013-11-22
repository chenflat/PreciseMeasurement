<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MeasurePointBaseInfo.ascx.cs" Inherits="PM.Web.realtime.MeasurePointBaseInfo" %>


<ol class="breadcrumb">
    <li class="active">
        <asp:Literal ID="ltDescription" runat="server"></asp:Literal>的基础信息</li>
</ol>
<div class="row">
    <div class="col-md-4">
        <div class="form-group">
            <label for="<%=description.ClientID %>" class="col-lg-5 text-right">
                测点名称*：</label>
            <div class="col-lg-7">
                <asp:Literal ID="description" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <div class="form-group">
            <label for="<%=pointcode.ClientID %>" class="col-lg-5 text-right">
                测点简拼：</label>
            <div class="col-lg-7">
                <asp:Literal ID="pointcode" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <div class="form-group">
            <label for="<%=pointnum.ClientID %>" class="col-lg-5 text-right">
                测点编号 *：</label>
            <div class="col-lg-7">
                <asp:Literal ID="pointnum" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-4">
        <div class="form-group">
            <label for="<%=carrier.ClientID %>" class="col-lg-5 text-right">
                携能载体：
            </label>
            <div class="col-lg-7">
                <asp:Literal ID="carrier" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <div class="form-group">
            <label for="<%=supervisor.ClientID %>" class="col-lg-5 text-right">
                负责人：
            </label>
            <div class="col-lg-7">
                <asp:Literal ID="supervisor" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <div class="form-group">
            <label for="<%=phone.ClientID %>" class="col-lg-5 text-right">
                联系方式：
            </label>
            <div class="col-lg-7">
                <asp:Literal ID="phone" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-4">
        <div class="form-group">
            <label for="<%=ddlOrgid.ClientID %>" class="col-lg-5 text-right">
                所属公司：
            </label>
            <div class="col-lg-7">
                <asp:Literal ID="ddlOrgid" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <div class="form-group">
            <label for="<%=location.ClientID %>" class="col-lg-5 text-right">
                安装位置：
            </label>
            <div class="col-lg-7">
                <asp:Literal ID="location" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-4">
        <div class="form-group">
            <label for="<%=ipaddress.ClientID %>" class="col-lg-5 text-right">
                计量点IP *：
            </label>
            <div class="col-lg-7">
                <asp:Literal ID="ipaddress" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <div class="form-group">
            <label for="<%=cardnum.ClientID %>" class="col-lg-5 text-right">
                3G卡号：
            </label>
            <div class="col-lg-7">
                <asp:Literal ID="cardnum" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <div class="form-group">
            <label for="<%=devicenum.ClientID %>" class="col-lg-5 text-right">
                通讯设备号码：
            </label>
            <div class="col-lg-7">
                <asp:Literal ID="devicenum" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-4">
        <div class="form-group">
            <label for="<%=serverip.ClientID %>" class="col-lg-5 text-right">
                通讯服务器IP *：
            </label>
            <div class="col-lg-7">
                <asp:Literal ID="serverip" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <div class="form-group">
            <label for="<%=serverport.ClientID %>" class="col-lg-5 text-right">
                服务器Port *：
            </label>
            <div class="col-lg-7">
                <asp:Literal ID="serverport" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <div class="form-group">
            <label for="<%=displaysequence.ClientID %>" class="col-lg-5 text-right">
                计量点排序：
            </label>
            <div class="col-lg-7">
                <asp:Literal ID="displaysequence" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</div>