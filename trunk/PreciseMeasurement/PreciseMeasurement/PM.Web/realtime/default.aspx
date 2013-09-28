<%@ Page Title="实时参数" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="PM.Web.realtime._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-2 col-xs-4">
            <div class="bs-sidebar hidden-print affix-top" role="complementary">
                <ul class="nav bs-sidenav">
                    <li class="active"><a href="#glyphicons">一级</a>
                        <ul class="nav">
                            <li class="active"><a href="#">1#煤炉出口蒸汽</a></li>
                            <li><a href="#e">2#煤炉出口蒸汽</a></li>
                            <li><a href="#">3#煤炉出口蒸汽</a></li>
                            <li><a href="#">4#气炉出口蒸汽</a></li>
                        </ul>
                    </li>
                    <li class="active"><a href="#dropdowns">二级</a>
                        <ul class="nav">
                            <li><a href="#">食品出锅炉房蒸汽</a></li>
                            <li><a href="#">食品入车间蒸汽</a></li>
                            <li><a href="#">热充出锅炉房蒸汽</a></li>
                            <li><a href="#">热充入车间蒸汽</a></li>
                            <li><a href="#">无菌出锅炉房蒸汽</a></li>
                            <li><a href="#">无菌入车间蒸汽</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
        <div class="col-md-10 col-xs-8" role="main">
            <div class="bs-docs-section">
                <div class="page-header" style="border-bottom: none; margin: 40px 0 0 0;">
                    <ul id="myTab" class="nav nav-tabs">
                        <li class="active"><a href="#realtime" data-toggle="tab">实时参数</a></li>
                        <li><a href="#minute" data-toggle="tab">分钟数据</a></li>
                        <li><a href="#hour" data-toggle="tab">小时数据</a></li>
                        <li><a href="#day" data-toggle="tab">每日数据</a></li>
                        <li><a href="#history" data-toggle="tab">历史曲线</a></li>
                        <li><a href="#alarm" data-toggle="tab">报警信息</a></li>
                        <li><a href="#info" data-toggle="tab">计量点信息</a></li>
                    </ul>
                </div>
                <div id="myTabContent" class="tab-content">
                    <div class="tab-pane fade in active" id="realtime">
                        <ol class="breadcrumb">
                            <li class="active">1#煤炉出口蒸汽的实时参数</li>
                        </ol>
                        realtime
                    </div>
                    <div class="tab-pane fade" id="minute">
                        <ol class="breadcrumb">
                            <li class="active">1#煤炉出口蒸汽的分钟数据</li>
                        </ol>
                        minute
                    </div>
                    <div class="tab-pane fade" id="hour">
                        <ol class="breadcrumb">
                            <li class="active">1#煤炉出口蒸汽的小时数据</li>
                        </ol>
                        hour
                    </div>
                    <div class="tab-pane fade" id="day">
                        <ol class="breadcrumb">
                            <li class="active">1#煤炉出口蒸汽的每日数据</li>
                        </ol>
                        hour
                    </div>
                    <div class="tab-pane fade" id="history">
                        <ol class="breadcrumb">
                            <li class="active">1#煤炉出口蒸汽的历史曲线</li>
                        </ol>
                        history
                    </div>
                    <div class="tab-pane fade" id="alarm">
                        <ol class="breadcrumb">
                            <li class="active">1#煤炉出口蒸汽的报警信息</li>
                        </ol>
                        alarm
                    </div>
                    <div class="tab-pane fade" id="info">
                        <ol class="breadcrumb">
                            <li class="active">1#煤炉出口蒸汽的基础信息</li>
                        </ol>
                        info
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $('#myTab a').click(function (e) {
            e.preventDefault()
            $(this).tab('show')
        })
    </script>
</asp:Content>
