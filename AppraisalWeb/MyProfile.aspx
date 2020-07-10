<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MyProfile.aspx.cs" Inherits="MyProfile" %>

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
            <li><i class="icon-edit"></i><a href="">My Profile</a> </li>
        </ul>
        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header" data-original-title>
                    <h2>
                        <i class="halflings-icon edit"></i><span class="break"></span>My Profile</h2>
                </div>
                <div class="box-content">
                    <div class="form-horizontal">
                        <fieldset>
                            <div class="span6">
                            <table id=tbl1 cellpadding=5px>
                                <tr>
                                <td>
                                </td>
                                <td>
                                <div class="controls">
                                    <asp:Image style="max-width: 100px; max-height: 100px" ImageAlign="Right" 
                                    ID="UserImage" runat="server" /> 
                                    </div>
                                </td>
                                </tr>
                                   <tr>
                                <td>
                                </td>
                                <td>
                                <div class="controls">
                                   
                                    </div>
                                </td>
                                </tr>
                                <tr>
                                     <td>
                                         <div class="control-group">
                                         <label class="control-label" id="lblName" runat="server" for="focusedInput">
                                         Name</label>
                                          <div class="controls">
                                        <asp:TextBox ID="txtName" runat="server" Enabled="true" placeholder="Name"></asp:TextBox>
                                         </div>
                                     </div>
                                 </td>
                                  <td>
                                     <div class="control-group">
                                    <label class="control-label" id="lblDepartment" runat="server" for="focusedInput">
                                        Department</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDeparment" runat="server" Enabled="false" placeholder="Department"></asp:TextBox>
                                    </div>
                                </div>
                                </td>
                                </tr>
                                <tr>
                                <td>
                                <div class="control-group">
                                    <label class="control-label" id="lblDoj" runat="server" for="focusedInput">
                                        Date Of Joining
                                    </label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDOJ" runat="server" Enabled="false" placeholder="Date of joining"></asp:TextBox>
                                    </div>
                                </div>
                                </td>
                                <td>
                                <div class="control-group">
                                    <label class="control-label" id="lblCycle" runat="server" for="focusedInput">
                                        Appraisal Cycle
                                    </label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtCycle" runat="server" Enabled="false" placeholder="Appraisal cycle"></asp:TextBox>
                                    </div>
                                </div>
                                </td>
                                </tr>
                                <tr>
                                <td>
                                <div class="control-group">
                                    <label class="control-label" id="Label1" runat="server" for="focusedInput">
                                        Mobile number
                                    </label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtMobileNumber" runat="server" Enabled="true" placeholder="Mobile Number"></asp:TextBox>
                                    </div>
                                </div>
                                </td>
                                <td>
                                <div class="control-group">
                                    <label class="control-label" id="Label2" runat="server" for="focusedInput">
                                        EmailID
                                    </label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtEmailID" runat="server" Enabled="true" placeholder="EmailID"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                                            ControlToValidate="txtEmailID" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email"
                                            ControlToValidate="txtEmailID" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                </td>
                                </tr>
                                <tr>
                                <td>
                                <div class="control-group">
                                    <label class="control-label" id="Label4" runat="server" for="focusedInput">
                                        Date of birth
                                    </label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDOB" runat="server" class="input-xlarge focused datepicker"
                                            placeholder="dd-mm-yy"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required"
                                            ControlToValidate="txtDOB" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                </td>
                                <td>
                                         <div class="control-group">
                                    <label class="control-label" for="focusedInput">
                                        Photo</label>
                                    <div class="controls">
                                        <asp:FileUpload ID="FileUpload2" runat="server" />
                                      
                                    </div>
                                </div>
                                </td>
                                </tr>
                            
                            </table>
                                <div class="asdsa" style="padding-Left: 90px">
                                        <asp:Button ID="btnProfileSave" runat="server" Text="Save" ValidationGroup="Save"
                                            CssClass="btn btn-success" OnClick="btnSave_Click" />
                                    </div>
                                     
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
            <!--/span-->
        </div>
        <div>
    
        </div>
        <!--/row-->
    </div>
</asp:Content>
