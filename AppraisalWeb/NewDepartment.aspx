<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewDepartment.aspx.cs" Inherits="NewDepartment" %>

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
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Home.aspx">Home</a> <i class="icon-angle-right">
            </i></li>
            <li><i class="icon-edit"></i><a href="">New Department</a> </li>
        </ul>
        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header" >
                    <h2>
                        <i class="halflings-icon edit"></i><span class="break"></span>Department Details</h2>
                </div>
                <div class="box-content">
                    <div class="form-horizontal">
                        <fieldset>
                        
                            <div class="span12">
                               <table id = "tblDept" cellpadding="10px">
                               <tr>
                                <div class="control-group">
                                <td>
                                    <label class="control-label" for="focusedInput">
                                        Department Name</label>
                                </td>
                                <td align=Right>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDeptName" runat="server" Width ="240" class="input-xlarge focused" placeholder="Department Name" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ControlToValidate="txtDeptName" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                    </td>
                                   </div>
                                </tr>
                                <tr>
                                <div class="control-group">
                                <td>
                                    <label class="control-label" for="focusedInput">
                                        Head of Department </label>
                                </td>
                                <td align=Right>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlHead" runat="server" Width ="250">
                                        </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ControlToValidate="ddlHead" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                </div>
                                </tr>
                                <tr>
                                <td></td>
                                <td align=right>
                               <div class="asdsa" style="padding-Right:64px">
                                    <asp:Button ID="btnSave" runat="server" Text="Save Department" ValidationGroup="Save"
                                        CssClass="btn btn-success" onclick="btnSave_Click" />

                            </div>
                            </td>
                            </tr>
                            </table>
                            </div>
                         
                        </fieldset>
                    </div>
                </div>
            </div>
            <!--/span-->
        </div>
        <!--/row-->
    </div>
</asp:Content>

