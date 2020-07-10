<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AppraisalFormItemDetail.aspx.cs" Inherits="AppraisalFormItemDetail" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
    <style>
        .control-group
        {
            overflow: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <div id="content" class="span10">
        
        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header">
                    <h2>
                        <i class="halflings-icon edit"></i><span class="break"></span>Appraisal Form Item Configuration</h2>
                </div>
                <div class="box-content">
                
                    <div class="form-horizontal">
                        <fieldset>
                        
                            <div class="span6">
                           
                            
                                <div class="control-group">
                                
                                    <label class="control-label" for="focusedInput">
                                        Title</label>
                                   <div class="controls">
                                       <asp:TextBox ID="txtTitle" runat="server" placeholder="Question"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required"
                                            ControlToValidate="txtTitle" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                             
                                </div>
                              
                              
                               
                                <div class="control-group">
                                
                                       
                                    <label class="control-label" for="focusedInput">
                                        Description</label>
                                    
                                    <div class="controls">
                                        <asp:TextBox ID="txtDescription" runat="server" 
                                            placeholder="Description"></asp:TextBox>
                              
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                                            ControlToValidate="txtDescription" ValidationGroup="Save" ForeColor="Red" EnableClientScript="true"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            
                                    </div>
                                   
                                </div>
                                
                                    <div class="asdsa" style="padding-left: 90px">
                                        <asp:Button ID="btnSave" runat="server" Text="Save Item" ValidationGroup="Save"
                                            CssClass="btn btn-success" onclick="btnSave_Click" />
                                    </div>
                                </div>
                        </fieldset>
                    </div>
                </div>
            </div>
            <!--/span-->
        </div>
        <!--/row-->
</asp:Content>