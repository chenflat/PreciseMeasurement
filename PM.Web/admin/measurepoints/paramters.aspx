<%@ Page Title="测点参量设置" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="paramters.aspx.cs" Inherits="PM.Web.admin.measurepoints.paramters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
      <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/measurepoint.js") %>"></script>
    <section class="panel panel-default">
        <header class="panel-heading font-bold"><asp:Literal ID="ltPointName" runat="server"></asp:Literal>的参量设置</header>
        <div class="panel-body">
        
        <a class="btn btn-info" id="btnAddParamter">新增参量</a>
                <a href="list.aspx" class="btn btn-info">返回</a>

    <asp:GridView ID="gvParamters" runat="server" AutoGenerateColumns="False" CellPadding="4"
        CellSpacing="1" CssClass="table table-bordered table-hover table-striped" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="MEASUREUNITNAME" HeaderText="参量名称" />
            <asp:BoundField DataField="ABBREVIATION" HeaderText="单位" />
            <asp:BoundField DataField="UPPERWARNING" HeaderText="运行上限" >
            <HeaderStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="LOWERWARNING" HeaderText="运行下限" >
            <HeaderStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="UPPERACTION" HeaderText="故障上限" >
            <HeaderStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="LOWERACTION" HeaderText="故障下限" >
            <HeaderStyle Width="120px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="编辑">
                <ItemTemplate>
                    <a href="#" name="<%# Eval("MEASUREUNITID") %>" class="editlink" id="<%# DataBinder.Eval(Container.DataItem, "MEASUREPOINTPARAMUID")%>"
                        title="修改">修改</a>  <a href="#" class="dellink" value="<%# DataBinder.Eval(Container.DataItem, "MEASUREPOINTPARAMUID")%>" onclick="return confirm('确定要删除参量吗?')">删除</a>
                </ItemTemplate>
                <HeaderStyle Width="120px" />
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
                                <label class="col-lg-5 text-right">
                                    计量点:</label>
                                <div class="col-lg-7">
                                    <asp:DropDownList ID="ddlPointNum" runat="server">
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hdnMeasurePointId" runat="server"></asp:HiddenField>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-5 text-right">
                                    参量单位:</label>
                                <div class="col-lg-7">
                                    <asp:DropDownList ID="ddlAbbreviation" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="col-lg-5 text-right">
                                     作为主要参数显示?</label>
                                <div class="col-lg-7">
                                    
                                    <select id="ddlIsMainParam">
                                        <option value="true">是</option>
                                        <option value="false">否</option>
                                    </select>
                                </div>
                            </div>
                            
                            
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-lg-5 text-right">
                                    参量名称:</label>
                                <div class="col-lg-7">
                                    <asp:DropDownList ID="ddlMeasureUnitId" runat="server">
                                    </asp:DropDownList>
                                    <input type="hidden" id="measurepointparamuid" />
                                    
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="col-lg-5 text-right">
                                    是否参与运算?</label>
                                <div class="col-lg-7">
                                    
                                     <select id="ddlIsCalculate">
                                        <option value="true">是</option>
                                        <option value="false">否</option>
                                    </select>
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="col-lg-5 text-right">
                                    是否显示?</label>
                                <div class="col-lg-7">
                                    <select id="ddlVisabled">
                                        <option value="true">是</option>
                                        <option value="false">否</option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-5 text-right">
                                    显示顺序:</label>
                                <div class="col-lg-7">
                                   
                               <input type="text" id="txtDisplaysequence" />
                                     </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-lg-5 text-right">
                                    运行上限:</label>
                                <div class="col-lg-7">
                                    
                                     <input type="text" id="txtUpperwarning" />
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="col-lg-5 text-right">
                                    故障上限:</label>
                                <div class="col-lg-7">
                                    
                                    <input type="text" id="txtUpperaction" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-lg-5 text-right">
                                    运行下限:</label>
                                <div class="col-lg-7">
                                    <input type="text" id="txtLowerwarning" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-5 text-right">
                                    故障下限:</label>
                                <div class="col-lg-7">
                                   
                                    <input type="text" id="txtLoweraction" />
                                </div>
                            </div>
                        </div>
                    </div>
                   
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        关闭</button>
                        <button type="button" id="btnSaveSetting" class="btn btn-primary">保存设置</button>
                    
                </div>
            </div>
        </div>
</div>
</div>
    </section>
        <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/editParamters.js") %>"></script>
</asp:Content>
