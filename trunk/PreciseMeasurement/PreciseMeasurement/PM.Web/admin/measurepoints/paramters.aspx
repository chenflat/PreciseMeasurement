<%@ Page Title="测点参量设置" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="paramters.aspx.cs" Inherits="PM.Web.admin.measurepoints.paramters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="bs-docs-section">
        <div class="page-header">
            <h3>
                <asp:Literal ID="ltPointName" runat="server"></asp:Literal>的参量设置
            </h3>
            <div class="manager_buttons">
            <a href="list.aspx" class="btn btn-info">返回</a>
            </div>
        </div>
    </div>
    <asp:GridView ID="gvParamters" runat="server" AutoGenerateColumns="False" CellPadding="4"
        CellSpacing="1" CssClass="table table-bordered table-hover table-striped" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="MEASUREUNITNAME" HeaderText="参量名称" />
            <asp:BoundField DataField="ABBREVIATION" HeaderText="单位" />
            <asp:BoundField DataField="UPPERWARNING" HeaderText="运行上限" />
            <asp:BoundField DataField="LOWERWARNING" HeaderText="运行下限" />
            <asp:BoundField DataField="UPPERACTION" HeaderText="故障上限" />
            <asp:BoundField DataField="LOWERACTION" HeaderText="故障下限" />
            <asp:TemplateField HeaderText="编辑">
                <ItemTemplate>
                    <a href="#" name="<%# Eval("MEASUREUNITID") %>" id="<%# DataBinder.Eval(Container.DataItem, "MEASUREPOINTPARAMUID")%>"
                        title="修改">修改</a>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
        </Columns>
        <PagerSettings Visible="False" />
    </asp:GridView>
    
    <div class="modal fade bs-example-modal" id="myModal" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title">
                        编辑参量设置</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-lg-5 text-right">计量点:</label>
                                <div class="col-lg-7">
                                    <asp:DropDownList ID="ddlPointNum" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                            <label class="col-lg-5 text-right">参量名称:</label>
                            <div class="col-lg-7">
                                <asp:DropDownList ID="ddlMeasureUnitId" runat="server">
                                    </asp:DropDownList>
                                    <input type="hidden" id="measurepointparamuid" />
                            </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-lg-5 text-right">运行上限:</label>
                                <div class="col-lg-7">
                                   <input type="text" id="upperwarning" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                            <label class="col-lg-5 text-right">运行下限:</label>
                            <div class="col-lg-7">
                                <input type="text" id="lowerwarning" />
                            </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-lg-5 text-right">故障上限:</label>
                                <div class="col-lg-7">
                                    <input type="text" id="upperaction" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                            <label class="col-lg-5 text-right">故障下限:</label>
                            <div class="col-lg-7">
                                <input type="text" id="loweraction" />
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        关闭</button>
                    <button type="button" class="btn btn-primary" id="btnSaveSetting">
                        保存设置</button>
                </div>
            </div>
        </div>
        <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/editParamters.js") %>"></script>
</asp:Content>
