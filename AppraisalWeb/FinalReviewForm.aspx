<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FinalReviewForm.aspx.cs" Inherits="FinalReviewForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
    <style>
        .control-group
        {
            overflow: auto;
        }
    </style>
    <style type="text/css">
        tr
        {
            height: 1px;
        }
        td
        {
            height: 100%;
            width: 100%;
        }
       
        textbox
        {
           margin-left: 0%;
           margin-right: 0%;
        }
        input
        {
           margin-left: 0%;
           margin-right: 0%;
        }
        textarea
        {
           margin-left: 0%;
           margin-right: 0%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <div id="content" class="span10">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Home.aspx">Home</a> <i class="icon-angle-right">
            </i></li>
            <li><i class="icon-edit"></i><a href="">Review Form</a> </li>
        </ul>
        <div>
            <div class="box span12">
                <div class="box-header" data-original-title>
                    <h2>
                        <i class="halflings-icon edit"></i><span class="break"></span>Final Review</h2>
                </div>
                <div class="box-content">
                    <div class="form-horizontal">
                        <fieldset>
                            <div class="span10">
                                <asp:PlaceHolder ID="DynamicControlsHolder" runat="server"></asp:PlaceHolder>
                                <%--<asp:Panel ID="DynamicControlsHolder" runat="server">
                                 </asp:Panel>--%>
                                <div class="control-group">
                                    <label class="control-label" for="focusedInput">
                                        Appraisal (in %)</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlIncrement" runat="server" Width="100px" class="input-xlarge focused"
                                            placeholder="Appraisal">
                                            <asp:ListItem Text="5" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="25" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
                <div class="asdsa" style="padding-left: 810px">
                    <asp:Button ID="btnApply" runat="server" Text="Submit" CssClass="btn btn-success"
                        OnClick="btnApply_Click" />
                </div>
            </div>
        </div>
        <!--/row-->
    </div>
</asp:Content>
