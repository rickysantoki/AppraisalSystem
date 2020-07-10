<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SubmitAppraisalForm.aspx.cs" Inherits="SubmitAppraisalForm" %>

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
            <li><i class="icon-edit"></i><a href="">Employee Details</a> </li>
        </ul>
        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header" data-original-title>
                    <h2>
                        <i class="halflings-icon edit"></i><span class="break"></span>Employee Details</h2>
                </div>
                <div class="box-content">
                    <div class="form-horizontal">
                        <fieldset>
                            <div class="span6">
                                <div class="control-group">
                                    <%--<asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>--%>
                                    <label class="control-label" id="lblName" runat="server" for="focusedInput">
                                        Name</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtName" runat="server" Enabled="false" placeholder="Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" id="lblDepartment" runat="server" for="focusedInput">
                                        Department</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDeparment" runat="server" Enabled="false" placeholder="Department"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" id="lblDoj" runat="server" for="focusedInput">
                                        Date Of Joining
                                    </label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDOJ" runat="server" Enabled="false" placeholder="Date of joining"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" id="lblCycle" runat="server" for="focusedInput">
                                        Appraisal Cycle
                                    </label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtCycle" runat="server" Enabled="false" placeholder="Appraisal cycle"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                           
                        </fieldset>
                    </div>
                </div>
            </div>
            <!--/span-->
        </div>
        <div>
            <div class="box span12">
                <div class="box-header" data-original-title>
                    <h2>
                        <i class="halflings-icon edit"></i><span class="break"></span>Self Assessment</h2>
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
                    <asp:Button ID="btnApply" runat="server" Text="Apply" CssClass="btn btn-success"
                        OnClick="btnApply_Click" />
                </div>
            </div>
        </div>
        <!--/row-->
    </div>
</asp:Content>
