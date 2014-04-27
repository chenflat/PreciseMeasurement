<%@ Page Title="计量器组" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="MeterGroupForm.aspx.cs" Inherits="PM.Web.admin.Meter.MeterGroupForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/MeterGroup/MeterGroupForm.js") %>"></script>
            <asp:Button ID="btnSave" CssClass="btn btn-warning" runat="server" Text="保存" />
             <a href="MeterGroupList.aspx" class="btn btn-info">返回</a>

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <label for="<%=txtGroupName.ClientID %>" class="col-lg-2 control-label">
                    计量器组：*</label>
                <div class="col-lg-8">
                    <asp:TextBox ID="txtGroupName" CssClass="form-control" Width="120px" placeholder="编号"
                        runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtDescription" CssClass="form-control description" Width="200px"
                        placeholder="描述" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hdnMetergroupid" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvGroupName" runat="server" Display="Dynamic" ErrorMessage="必填字段"
                        ControlToValidate="txtGroupName" CssClass="help-inline"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfvDescrption" runat="server" Display="Dynamic" ErrorMessage="必填字段"
                        ControlToValidate="txtDescription" CssClass="help-inline"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <ul class="nav nav-tabs" id="myTab">
            <li class="active"><a href="#home" data-toggle="tab">成组的计量器</a></li>
        </ul>
        <!-- Tab panes -->
        <div class="tab-content">
            <div class="tab-pane active" id="home">
                <asp:Repeater ID="rptMeteringroup" runat="server">
                <HeaderTemplate>
                <table class="table table-hover table-bordered table-condensed">
                <tr>
                    <td width="10%">序号</td>
                    <td width="25%">计量点编号</td>
                    <td width="50%">说明</td>
                    <td width="15%">编辑</td>
                </tr>
                </HeaderTemplate>
                <ItemTemplate>
                <tr>
                    <td><input type="text" name="sequence" placeholder="序号" value="<%# Eval("SEQUENCE") %>" /></td>
                    <td><input type="text" name="metername" placeholder="计量点编号" value="<%# Eval("METERNAME") %>"  /></td>
                    <td><%# Eval("DESCRIPTION") %></td>
                    <td><span class="glyphicon glyphicon-remove"></span></td>
                </tr>
                </ItemTemplate>
                <FooterTemplate>
                <tr>
                    <td colspan="4"><a href="#" id="">添加计量器</a></td>
                </tr>
                </table>
                </FooterTemplate>
                </asp:Repeater>



               </div>
        </div>
    </div>


    <script>
        $('#myTab a').click(function (e) {
            e.preventDefault()
            $(this).tab('show')
        })
    </script>
</asp:Content>
