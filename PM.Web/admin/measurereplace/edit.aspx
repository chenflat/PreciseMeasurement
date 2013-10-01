<%@ Page Title="换表管理" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="edit.aspx.cs" Inherits="PM.Web.admin.measurereplace.edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="bs-docs-section">
        <div class="page-header">
            <h3>
                编辑换表记录</h3>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=pointnum.ClientID %>" class="col-lg-5 control-label">
                        更换测点*</label>
                    <div class="col-lg-7">
                        <asp:DropDownList ID="pointnum" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" Display="Dynamic"
                            ErrorMessage="必填字段" ControlToValidate="pointnum" CssClass="help-inline"></asp:RequiredFieldValidator>
                        <asp:HiddenField ID="measuretransid" runat="server" />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=topointnum.ClientID %>" class="col-lg-5 control-label">
                        更换后测点*</label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="topointnum" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTopointnum" runat="server" Display="Dynamic" ErrorMessage="必填字段"
                            ControlToValidate="topointnum" CssClass="help-inline"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=measureunitid.ClientID %>" class="col-lg-5 control-label">
                        参量名称*</label>
                    <div class="col-lg-7">
                        <asp:DropDownList ID="measureunitid" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMeasureunitid" runat="server" Display="Dynamic"
                            ErrorMessage="必填字段" ControlToValidate="measureunitid" CssClass="help-inline"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=measurementvalue.ClientID %>" class="col-lg-5 control-label">
                        换表前读数
                    </label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="measurementvalue" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=tomeasurementvalue.ClientID %>" class="col-lg-5 control-label">
                        新表读数
                    </label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="tomeasurementvalue" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=correctedvalue.ClientID %>" class="col-lg-5 control-label">
                        修正值
                    </label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="correctedvalue" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=replacetype.ClientID %>" class="col-lg-5 control-label">
                        更换类型
                    </label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="replacetype" CssClass="form-control" placeholder="" runat="server"
                            MaxLength="16"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=fromdept.ClientID %>" class="col-lg-5 control-label">
                        更换部门
                    </label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="fromdept" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=fromloc.ClientID %>" class="col-lg-5 control-label">
                        更换的位置
                    </label>
                    <div class="col-lg-7">
                        <asp:DropDownList ID="fromloc" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=replaceperson.ClientID %>" class="col-lg-5 control-label">
                        更换人
                    </label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="replaceperson" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=replacedate.ClientID %>" class="col-lg-5 control-label">
                        更换日期
                    </label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="replacedate" CssClass="form-control datepicker" placeholder="" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=status.ClientID %>" class="col-lg-5 control-label">
                        状态
                    </label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="status" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=memo.ClientID %>" class="col-lg-5 control-label">
                        备忘录
                    </label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="memo" CssClass="form-control" placeholder="" runat="server" Rows="3"
                            TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=enterby.ClientID %>" class="col-lg-5 control-label">
                        记录人
                    </label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="enterby" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=enterdate.ClientID %>" class="col-lg-5 control-label">
                        记录时间
                    </label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="enterdate" CssClass="form-control datepicker" placeholder="" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="toolbar bs-callout-danger">
            <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="提交" />
            <asp:Button ID="btnDelte" CssClass="btn btn-danger" runat="server" Text="删除" />
            <a href="list.aspx" class="btn btn-info">返回</a>
        </div>
    </div>
</asp:Content>
