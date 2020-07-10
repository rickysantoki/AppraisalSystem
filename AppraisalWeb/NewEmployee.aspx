<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="NewEmployee.aspx.cs" Inherits="NewEmployee" %>

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
            <li><i class="icon-edit"></i><a href="">New Employee</a> </li>
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
                                    <label class="control-label" for="focusedInput">
                                        Name</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtName" runat="server" class="input-xlarge focused" placeholder="Employee Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                                            ControlToValidate="txtName" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid Name"
                                            ControlToValidate="txtName" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true" ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="focusedInput">
                                        Mobile</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtPhone" runat="server" class="input-xlarge focused" placeholder="Phone"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required"
                                            ControlToValidate="txtPhone" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Phone"
                                            ControlToValidate="txtPhone" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true" ValidationExpression="^[0-9]{10,10}$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="focusedInput">
                                        Username</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtUname" runat="server" class="input-xlarge focused" placeholder="Username"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required"
                                            ControlToValidate="txtUname" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="focusedInput">
                                        Password</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtPassword" runat="server" class="input-xlarge focused" 
                                            placeholder="Password" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required"
                                            ControlToValidate="txtPassword" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="focusedInput">
                                        Is Admin</label>
                                    <div class="controls">
                                        <asp:Checkbox ID="cbIsAdmin" runat="server" class="input-xlarge focused"></asp:Checkbox>                                        
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="focusedInput">
                                        Department
                                    </label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlDept" runat="server">
                                        </asp:DropDownList>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required"
                                            ControlToValidate="ddlDept" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="focusedInput">
                                        Supervisor </label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlSupervisor" runat="server">
                                        </asp:DropDownList>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Required"
                                            ControlToValidate="ddlSupervisor" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                                <div class="control-group">
                                <label class="control-label" for="focusedInput">
                                        Email</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtEmail" runat="server" class="input-xlarge focused" placeholder="Email"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                                            ControlToValidate="txtEmail" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email"
                                            ControlToValidate="txtEmail" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                
                                <div class="control-group">
                                    <label class="control-label" for="focusedInput">
                                        Date Of Birth</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDate" runat="server" class="input-xlarge focused datepicker"
                                            placeholder="dd-mm-yy"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required"
                                            ControlToValidate="txtDate" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="focusedInput">
                                        Date Of Joining</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDate1" runat="server" class="input-xlarge focused datepicker"
                                            placeholder="Date Of Joining"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Required"
                                            ControlToValidate="txtDate1" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                 <div class="control-group">
                                <label class="control-label" for="focusedInput">
                                        Appraisal Cycle</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlAppCycle" runat="server">
                                        <asp:ListItem>April</asp:ListItem>
                                         <asp:ListItem>September</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required"
                                            ControlToValidate="txtEmail" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                                       
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="focusedInput">
                                        Salary</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtSalary" runat="server" class="input-xlarge focused" placeholder="Salary"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Required"
                                            ControlToValidate="txtSalary" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="focusedInput">
                                        Photo</label>
                                    <div class="controls">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                      
                                    </div>
                                </div>
                                <%--<div class="control-group">
                                    <label class="control-label" for="focusedInput">
                                        Status</label>
                                   <div class="controls">
                                       <asp:RadioButton ID="RadioButton1" CssClass="radio" Text="Active" runat="server" />
                                       <div style="clear:both"></div>
                                       <asp:RadioButton ID="RadioButton2" CssClass="radio" Text="Non Active" runat="server" />
                                    </div>
                                </div>--%>
                                <div class="control-group">
                                    <label class="control-label">
                                        Status</label>
                                    <div class="controls">
                                        <label class="radio">
                                            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Group1" />
                                            Active
                                        </label>
                                        <div style="clear: both">
                                        </div>
                                        <label class="radio">
                                            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Group1"/>
                                            Inactive
                                        </label>
                                    </div>
                                    <div class="asdsa" style="padding-left: 90px">
                                        <asp:Button ID="btnSave" runat="server" Text="Save employee" ValidationGroup="Save"
                                            CssClass="btn btn-success" OnClick="btnSave_Click" />
                                    </div>
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
