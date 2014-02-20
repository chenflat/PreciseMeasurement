<%@ Page Title="资产" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="AssetForm.aspx.cs" Inherits="PM.Web.admin.Asset.AssetForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    
    <script type="text/javascript" src="<%=ResolveUrl("~/assets/js/SystemConfig.js") %>"></script>
    <script>
        var USERID = "<%=userid %>";
        var ORGID = "<%=orgid %>";
    
    </script>
<asp:Literal ID="ltStatus" runat="server" Visible="false"></asp:Literal>
                <asp:Button ID="btnSave" CssClass="btn btn-warning" runat="server" Text="保存" />
                <a href="AssetList.aspx" class="btn btn-info">返回</a>

    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <label for="<%=txtAssetNum.ClientID %>" class="col-lg-3 control-label">
                    资产：*</label>
                <div class="col-lg-9">
                    <asp:TextBox ID="txtAssetNum" CssClass="form-control assetnum" Width="120px" placeholder="编号"
                        runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtDescription" CssClass="form-control description" Width="200px"
                        placeholder="描述" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAssetNum" runat="server" Display="Dynamic" ErrorMessage="必填字段"
                        ControlToValidate="txtAssetNum" CssClass="help-inline"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfvDescrption" runat="server" Display="Dynamic" ErrorMessage="必填字段"
                        ControlToValidate="txtDescription" CssClass="help-inline"></asp:RequiredFieldValidator>
                    <asp:HiddenField ID="hdnAssetuid" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <label for="<%=txtStatus.ClientID %>" class="col-lg-3 control-label">
                    状态：</label>
                <div class="col-lg-9">
                    <asp:TextBox ID="txtStatus" runat="server" Enabled="false" Width="120px"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label for="<%=txtSiteId.ClientID %>" class="col-lg-3 control-label">
                    地点：</label>
                <div class="col-lg-9">
                    <asp:TextBox ID="txtSiteId" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="<%=ddlSpecClass.ClientID %>" class="col-lg-3 control-label">
                    子系统：</label>
                <div class="col-lg-9" >

                    <asp:DropDownList ID="ddlSpecClass" CssClass="select2" Width="190px" runat="server">
                    </asp:DropDownList>
                </div>
              </div>
             <div class="form-group">
                <label for="<%=txtClassstructureid.ClientID %>" class="col-lg-3 control-label">
                    类型：</label>
                <div class="col-lg-9" >
                    <asp:TextBox ID="txtClassstructureid" runat="server"></asp:TextBox>
                    </div>
                </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
        </div>
    </div>
    <div class="panel panel-info">
        <div class="panel-heading">
            详细信息</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="<%=ddlParent.ClientID %>" class="col-lg-3 control-label">
                            父资产：</label>
                        <div class="col-lg-9">
                            <asp:DropDownList ID="ddlParent" Enabled="false" Width="190px" CssClass="select2" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="<%=chkMainthierchy.ClientID %>" class="col-lg-3 control-label">
                            维护结构：</label>
                        <div class="col-lg-9">
                            <asp:CheckBox ID="chkMainthierchy" Enabled="false" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="<%=ddlGroupName.ClientID %>" class="col-lg-3 control-label">
                            计量器组：</label>
                        <div class="col-lg-9">
                            <asp:DropDownList ID="ddlGroupName" Width="190px" CssClass="select2" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="<%=txtUsage.ClientID %>" class="col-lg-3 control-label">
                            使用情况：</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtUsage" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="<%=txtX.ClientID %>" class="col-lg-3 control-label">
                            拓扑位置：</label>
                        <div class="col-lg-9">
                            X:<asp:TextBox ID="txtX" runat="server" CssClass="coordinate x" Width="40px"></asp:TextBox>
                            Y:<asp:TextBox ID="txtY" runat="server" CssClass="coordinate y" Width="40px"></asp:TextBox>
                            Z:<asp:TextBox ID="txtZ" runat="server" CssClass="coordinate z" Width="40px"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    
                    <div class="form-group">
                        <label for="<%=txtSiteId.ClientID %>" class="col-lg-3 control-label">
                            优先级：</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtPriority" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="<%=txtSerialnum.ClientID %>" class="col-lg-3 control-label">
                            序列#：</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtSerialnum" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="<%=txtSiteId.ClientID %>" class="col-lg-3 control-label">
                            故障类：</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtFailurecode" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6" style="padding: 0px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    采购信息</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group">
                            <label for="<%=txtVendor.ClientID %>" class="col-lg-3 control-label">
                                供应商：</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtVendor" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="<%=txtManufacturer.ClientID %>" class="col-lg-3 control-label">
                                制造商：</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtManufacturer" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="<%=txtInstalldate.ClientID %>" class="col-lg-3 control-label">
                                安装日期：</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtInstalldate" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6" style="padding-right: 0px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    停工时间</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group">
                            <label for="<%=chkIsrunning.ClientID %>" class="col-lg-3 control-label">
                                资产运行?</label>
                            <div class="col-lg-9">
                                <asp:CheckBox ID="chkIsrunning" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="<%=txtStatusDate.ClientID %>" class="col-lg-3 control-label">
                                上次变更日期：</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtStatusDate" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="<%=txtTotdowntime.ClientID %>" class="col-lg-3 control-label">
                                停工总计：</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtTotdowntime" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
