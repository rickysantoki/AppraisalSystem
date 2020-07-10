<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AppraisalFormDetail.aspx.cs" Inherits="AppraisalFormDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
    <style>
        .control-group
        {
            overflow: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <div id="content" class="span10">
        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header">
                    <h2>
                        <i class="halflings-icon edit"></i><span class="break"></span>Appraisal Form Configuration</h2>
                </div>
                
                <div class="box-content">
                    <div class="form-horizontal">
                        <fieldset>
                        <table  cellpadding="10px">
                            <div class="span6">
                            <tr align=right>
                            
                                <div class="control-group">
                            <td >
                                    <label class="control-label" for="focusedInput">
                                        Department</label>
                            </td>
                            
                                    <div class="controls">
                             <td >
                                        <asp:DropDownList ID="ddlDept1" runat="server">
                                        </asp:DropDownList>
                            </td>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required"
                                            ControlToValidate="ddlDept" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                    </div>
                            
                                </div>
                            </tr>
                            <tr align=right>
                            
                                <div class="control-group">
                            <td>
                                    <label class="control-label" for="focusedInput">
                                        Start</label>
                            </td>
                                    <div class="controls">
                                    <td>
                                        <asp:TextBox ID="txtStart" runat="server" class="input-xlarge focused datepicker"
                                            placeholder="Starting Date Of Appraisal Form" Width="140px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                                            ControlToValidate="txtStart" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                                     </td>
                                    </div>
                           
                                </div>
                            </tr>
                            <tr align=right>
                            
                                <div class="control-group">
                            <td>
                                    <label class="control-label" for="focusedInput">
                                        End</label>
                            </td>
                            
                                    <div class="controls">
                            <td>
                                        <asp:TextBox ID="txtEnd" runat="server" class="input-xlarge focused datepicker"
                                         placeholder="Ending Date Of Appraisal Form" Width="140px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required"
                                            ControlToValidate="txtEnd" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </td>
                                    </div>
                            
                                </div>
                            </tr>
                            <tr align=right>
                                <div class="control-group">

                             <td>       <label class="control-label" for="focusedInput">
                                        Appraisal Cycle</label>
                            </td>
                            
                                    <div class="controls">
                            <td>
                                        <asp:DropDownList ID="ddlAppCycle" runat="server">
                                            <asp:ListItem>April</asp:ListItem>
                                            <asp:ListItem>September</asp:ListItem>
                                        </asp:DropDownList>
                            </td>
                                    </div>
                                </div>
                            </tr>
                            <tr align=right>
                            <td></td>
                            
                                <div class="asdsa" style="padding-left: 90px">
                            <td> 
                                   <asp:Button ID="btnSave" runat="server" Text="Save Form" ValidationGroup="Save" CssClass="btn btn-success"
                                        OnClick="btnSave_Click" />
                            </td>
                                </div>
                                <div class="control-group">
                                    <asp:Label ID="lblTitle" runat="server" Style="color: Red;"></asp:Label>
                                </div>
                            </div>
                            </tr>
                            </table>
                        </fieldset>
                    </div>
                </div>
            </div>
            <!--/span-->
        </div>
        <!--/row-->
        <asp:PlaceHolder ID="placeholder1" runat="Server" Visible="false">
            <div id="Div1" class="span10">
                <div class="row-fluid sortable">
                    <div class="box span12">
                        <div class="box-header">
                            <h2>
                                <i class="halflings-icon align-justify"></i><span class="break"></span>Form Details</h2>
                        </div>
                        <asp:GridView ID="GridView2" CssClass="table table-striped" runat="server" AutoGenerateColumns="false"
                            GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="Title">
                                    <ItemTemplate>
                                        <%# Eval("Title") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Descripton">
                                    <ItemTemplate>
                                        <%# Eval("Description") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href='<%# "AppraisalFormItemDetail.aspx?FIID=" + Eval("App_Form_Item_Id") %>'>EDIT</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <div class="asdsa" style="padding-left: 810px">
                            <asp:Button ID="btnAdd" runat="server" Text="ADD" CssClass="btn btn-success" OnClick="btnAdd_Click" />
                        </div>
                    </div>
                    <!--/span-->
                </div>
                <!--/row-->
            </div>
        </asp:PlaceHolder>
</asp:Content>
