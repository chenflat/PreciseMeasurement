<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageControl.ascx.cs" Inherits="PM.Web.controls.PageControl" %>
<div class="page" runat="server" id="pagination">
    <asp:LinkButton ID="btnFirst" CausesValidation="False" CommandArgument="first" runat="server">首页</asp:LinkButton>
    <asp:LinkButton ID="btnPrev" CausesValidation="False" CommandArgument="prev" runat="server">上页</asp:LinkButton>
    <asp:LinkButton ID="btnNext" CausesValidation="False" CommandArgument="next" runat="server">下页</asp:LinkButton>
    <asp:LinkButton ID="btnLast" CausesValidation="False" CommandArgument="last" runat="server">末页</asp:LinkButton>
    &nbsp;
    <asp:TextBox ID="TxtPageSize" runat="server" CssClass="input_text" EnableTheming="False" MaxLength="4" Width="25px" OnTextChanged="TxtPageSize_TextChanged" CausesValidation="false" AutoPostBack="True"></asp:TextBox>
    条记录/页
    <asp:Label ID="lblPageInfo" runat="server"></asp:Label> 到第 <input id="txtPage" runat="server"  name="txtPage" onkeyup="keyDown();" class="input_text" style="width:25px;font-size:12px;height:16px;border:1px solid #919090;"/> 页
            <input id="btnGo" runat="server" name="btnGo" type="button" value="转到" class="input_button" onserverclick="btnGo_ServerClick" style="border:1px solid #919090;background:#fff;font-size:10px;height:18px;" />
<input id="hidPageSize" runat="server" name="hidPageSize" type="hidden" /><input
    id="hidCurrentPageIndex" runat="server" name="hidCurrentPageIndex" type="hidden" /><input
        id="hidRecordCount" runat="server" name="hidRecordCount" type="hidden" />
        <input type="hidden" name="page" value="<%=CurrentPageIndex %>" />

<script type="text/javascript">
	function keyDown(){		
		if(event.keyCode==13 && event.srcElement.type!='button'){
			__doPostBack('btnGo','');			
		}
	}
	
</script>
    
    </div>