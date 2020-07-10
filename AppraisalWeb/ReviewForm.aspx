<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReviewForm.aspx.cs" Inherits="ReviewForm" %>

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
                        <i class="halflings-icon edit"></i><span class="break"></span>Review</h2>
                </div>
                <div class="box-content">
                    <div class="form-horizontal">
                        <fieldset>
                            <div class="span10">
                                <asp:PlaceHolder ID="DynamicControlsHolder" runat="server"></asp:PlaceHolder>
                                <%--<asp:Panel ID="DynamicControlsHolder" runat="server">
                                 </asp:Panel>--%>
                            </div>
                        </fieldset>
                    </div>
                </div>
                <div class="asdsa" style="padding-left: 810px">
                    <asp:Button ID="btnApply" runat="server" Text="Reviewed" CssClass="btn btn-success"
                        OnClick="btnApply_Click" />
                </div>
            </div>
        </div>
        <!--/row-->
    </div>
</asp:Content>
