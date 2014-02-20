<%@ Page Title="系统信息" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeBehind="config.aspx.cs" Inherits="PM.Web.admin.system.config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/AssetManager.js") %>"></script>
    <script>
        var USERID = "<%=userid %>";
        var ORGID = "<%=orgid %>";
    
    </script>
    <section class="panel panel-default">
        <header class="panel-heading font-bold">编辑系统信息</header>
        <div class="panel-body">
            <div class="form-group">
                <label for="<%=txtSysname.ClientID %>" class="col-lg-2">
                    系统名称
                </label>
                <div class="col-lg-6">
                    <asp:TextBox ID="txtSysname" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSysname" runat="server"
                        ControlToValidate="txtSysname" Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="<%=txtVersion.ClientID %>" class="col-lg-2">
                    系统版本
                </label>
                <div class="col-lg-6">
                    <asp:TextBox ID="txtVersion" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="<%=txtCopyright.ClientID %>" class="col-lg-2">
                    版权信息
                </label>
                <div class="col-lg-6">
                    <asp:TextBox ID="txtCopyright" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="<%=txtSysifno.ClientID %>" class="col-lg-2">
                    信息系统
                </label>
                <div class="col-lg-6">
                    <asp:TextBox ID="txtSysifno" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-lg-6 col-lg-offset-2">
                    <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="提交" />
                    <button class="btn" data-toggle="modal" data-target="#myModal">添加子系统</button>
                </div>
            </div>


            <asp:Repeater ID="rptSystemItems" runat="server">
                <HeaderTemplate>
                    <table style="width: 100%;" class="table table-bordered">
                        <tr>
                            <th>代码</th>
                            <th>名称</th>
                            <th>描述</th>
                            <th>系统图长宽</th>
                            <td>操作</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td width="25%"><%# Eval("Code") %></td>
                        <td width="25%"><%# Eval("Name") %></td>
                        <td><%# Eval("Description") %></td>
                        <td style="width:10%">
                          
                            <%# Eval("StructImageWidth") %>×<%# Eval("StructImageHeight") %>
     

                        </td>
                        <td style="width:10%"><a href="#" id="<%# Eval("Code") %>"  class="linkEdit">编辑</a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>


        </div>
    </section>

    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">子系统信息</h4>
                </div>
                <div class="modal-body">

                    <div class="form-group">
                        <label for="Code" class="col-lg-4">
                            系统代码 *
                        </label>
                        <div class="col-lg-6">
                            <input id="Code" type="text" class="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="Name" class="col-lg-4">
                            系统名称 *
                        </label>
                        <div class="col-lg-6">
                            <input id="Name" type="text" class="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="Description" class="col-lg-4">
                            描述
                        </label>
                        <div class="col-lg-6">
                            <input id="Description" type="text" class="form-control" />
                        </div>
                    </div>
                     <div class="form-group">
                        <label for="StructImage" class="col-lg-4">
                            系统图 *
                        </label>
                        <div class="col-lg-6">
                            <input id="StructImage" type="text" class="form-control" />
                        </div>
                    </div>
                     <div class="form-group">
                        <label for="StructImageWidth" class="col-lg-4">
                            图片大小
                        </label>
                        <div class="col-lg-6">
                            <input id="StructImageWidth" type="text" class="form-control" style="width:80px;" />
                            <input id="StructImageHeight" type="text" class="form-control" style="width:80px;" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <button type="button" id="btnSaveSystemItem" class="btn btn-primary">保存</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
