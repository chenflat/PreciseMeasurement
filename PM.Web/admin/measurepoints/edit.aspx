<%@ Page Title="计量点管理" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="edit.aspx.cs" Inherits="PM.Web.admin.measurepoints.edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/measurepoint.js") %>"></script>

 <section class="panel panel-default"> 
<header class="panel-heading font-bold">  编辑计量点</header> 
    <div class="panel-body"> 

    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=description.ClientID %>" class="col-lg-5 control-label">
                    测点名称*</label>
                <div class="col-lg-7">
                    <asp:TextBox ID="description" CssClass="form-control description" placeholder=""
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" Display="Dynamic"
                        ErrorMessage="必填字段" ControlToValidate="description" CssClass="help-inline"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=pointnum.ClientID %>" class="col-lg-5 control-label">
                    测点编号 *</label>
                <div class="col-lg-7">
                    <asp:TextBox ID="pointnum" CssClass="form-control pointnum" placeholder="" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="measurepointid" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvPointNum" runat="server" Display="Dynamic" ErrorMessage="必填字段"
                        ControlToValidate="pointnum" CssClass="help-inline"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=pointcode.ClientID %>" class="col-lg-5 control-label">
                    测点简拼</label>
                <div class="col-lg-7">
                    <asp:TextBox ID="pointcode" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=carrier.ClientID %>" class="col-lg-5 control-label">
                    携能载体
                </label>
                <div class="col-lg-7">
                    <asp:DropDownList ID="carrier" runat="server" CssClass="form-control">
                        <asp:ListItem Value="steam">汽</asp:ListItem>
                        <asp:ListItem Value="water">水</asp:ListItem>
                        <asp:ListItem Value="electricity">电</asp:ListItem>
                        <asp:ListItem Value="air">空气</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=supervisor.ClientID %>" class="col-lg-5 control-label">
                    负责人
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="supervisor" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=phone.ClientID %>" class="col-lg-5 control-label">
                    联系方式
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="phone" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=ddlOrgid.ClientID %>" class="col-lg-5 control-label">
                    所属机构
                </label>
                <div class="col-lg-7">
                    <asp:DropDownList ID="ddlOrgid" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=ddlLevel.ClientID %>" class="col-lg-5 control-label">
                    级别
                </label>
                <div class="col-lg-7">
                    <asp:DropDownList ID="ddlLevel" CssClass="form-control" runat="server">
                        <asp:ListItem Value="1">1级</asp:ListItem>
                        <asp:ListItem Value="2">2级</asp:ListItem>
                        <asp:ListItem Value="3">3级</asp:ListItem>
                        <asp:ListItem Value="4">4级</asp:ListItem>
                        <asp:ListItem Value="5">5级</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtClassstructureid.ClientID %>" class="col-lg-5 control-label">
                    所属系统 *
                </label>
                <div class="col-lg-7">
                     <asp:TextBox ID="txtClassstructureid"  runat="server"></asp:TextBox>  
                     
                     <a data-toggle="modal" href="../Class/ClassStructureTreeView.aspx" data-target="#myModal"><span class="glyphicon glyphicon-search" id="btnDlgClassstructureid"></span></a>
                    </div>
                   
                </div>
            </div>
        
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=ipaddress.ClientID %>" class="col-lg-5 control-label">
                    计量点IP *
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="ipaddress" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvIpAddress" runat="server" ControlToValidate="ipaddress"
                        CssClass="help-inline" Display="Dynamic" ErrorMessage="计量点IP必填"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revIpAddress" runat="server" ControlToValidate="ipaddress"
                        Display="Dynamic" ErrorMessage="IP地址格式无效" ValidationExpression="^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$"></asp:RegularExpressionValidator>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=cardnum.ClientID %>" class="col-lg-5 control-label">
                    手机号
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="cardnum" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=devicenum.ClientID %>" class="col-lg-5 control-label">
                    通讯设备号码
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="devicenum" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=serverip.ClientID %>" class="col-lg-5 control-label">
                    通讯服务器IP *
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="serverip" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvServerip" runat="server" ControlToValidate="serverip"
                        CssClass="help-inline" Display="Dynamic" ErrorMessage="通讯服务器IP必填"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revServerip" runat="server" ControlToValidate="serverip"
                        Display="Dynamic" ErrorMessage="通讯服务器IP格式无效" ValidationExpression="^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$"
                        CssClass="help-inline"></asp:RegularExpressionValidator>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=serverport.ClientID %>" class="col-lg-5 control-label">
                    服务器Port *
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="serverport" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revServerport" runat="server" ControlToValidate="serverport"
                        CssClass="help-inline" Display="Dynamic" ErrorMessage="服务端端口格式无效" ValidationExpression="^[-]?[0-9]*[.]?[0-9]*$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="serverport"
                        CssClass="help-inline" Display="Dynamic" ErrorMessage="服务器端口必填"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=displaysequence.ClientID %>" class="col-lg-5 control-label">
                    计量点排序
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="displaysequence" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revDisplaysequence" runat="server" ControlToValidate="displaysequence"
                        Display="Dynamic" ErrorMessage="数字格式无效" ValidationExpression="^[-]?[0-9]*[.]?[0-9]*$"></asp:RegularExpressionValidator>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=tbX.ClientID %>" class="col-lg-5 control-label">
                    X坐标
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="tbX" ToolTip="双击编辑坐标信息" CssClass="form-control coordinate x" placeholder=""
                        runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=tbY.ClientID %>" class="col-lg-5 control-label">
                    Y坐标
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="tbY" ToolTip="双击编辑坐标信息" CssClass="form-control coordinate y" placeholder=""
                        runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=tbZ.ClientID %>" class="col-lg-5 control-label">
                    Z坐标
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="tbZ" ToolTip="双击编辑坐标信息" CssClass="form-control coordinate z" placeholder=""
                        runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
   
    <div class="row">
        <div class="col-md-6 col-md-offset-1">
         <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="保存" />
         <asp:Button ID="btnSaveAndNew" CssClass="btn btn-primary" runat="server" Text="保存并新增" OnClick="btnSaveAndNew_Click" />
            <asp:HyperLink ID="btnParams" CssClass="btn btn-info" runat="server">参量设置</asp:HyperLink>
            <asp:Button ID="btnDelte" CssClass="btn btn-danger" runat="server" Text="删除" OnClientClick="return confirm('删除记录点数据不可恢复，确定要删除记量点吗？')" />
            <a href="list.aspx" class="btn btn-info">返回</a>
        </div>
    </div>


    </div>
    </section>


<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                 <h4 class="modal-title">类别结构</h4>

            </div>
            <div class="modal-body"><div class="te"></div></div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-primary">Save changes</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<!-- /.modal -->
     
</asp:Content>
