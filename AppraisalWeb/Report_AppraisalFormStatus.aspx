<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Report_AppraisalFormStatus.aspx.cs" Inherits="Report_AppraisalFormStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <div id="content">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Home.aspx">Home</a> <i class="icon-angle-right">
            </i></li>
            <li><a href="#">Appraisal Form Status Report</a></li>
        </ul>
        Appraisal Form:
        <asp:TextBox ID="txtAppForm" runat="server"></asp:TextBox>
        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header">
                    <div class="box-icon">
                        <a href="#" class="btn-setting"><i class="halflings-icon wrench"></i></a><a href="#"
                            class="btn-minimize"><i class="halflings-icon chevron-up"></i></a><a href="#" class="btn-close">
                                <i class="halflings-icon remove"></i></a>
                    </div>
                </div>
                <!-- <div class="box-content">
						<table class="table table-bordered table-striped table-condensed">
							  <thead>
								  <tr>
									  <th>Username</th>
									  <th>Date registered</th>
									  <th>Role</th>
									  <th>Status</th>                                          
								  </tr>
							  </thead>   
							  <tbody>
								<tr>
									<td>Dennis Ji</td>
									<td class="center">2012/01/01</td>
									<td class="center">Member</td>
									<td class="center">
										<span class="label label-success">Active</span>
									</td>                                       
								</tr>
								<tr>
									<td>Dennis Ji</td>
									<td class="center">2012/02/01</td>
									<td class="center">Staff</td>
									<td class="center">
										<span class="label label-important">Banned</span>
									</td>                                       
								</tr>
								<tr>
									<td>Dennis Ji</td>
									<td class="center">2012/02/01</td>
									<td class="center">Admin</td>
									<td class="center">
										<span class="label">Inactive</span>
									</td>                                        
								</tr>
								<tr>
									<td>Dennis Ji</td>
									<td class="center">2012/03/01</td>
									<td class="center">Member</td>
									<td class="center">
										<span class="label label-warning">Pending</span>
									</td>                                       
								</tr>
								<tr>
									<td>Dennis Ji</td>
									<td class="center">2012/01/21</td>
									<td class="center">Staff</td>
									<td class="center">
										<span class="label label-success">Active</span>
									</td>                                        
								</tr>                                   
							  </tbody>
						 </table>  
						


					</div>-->
                    <asp:Button ID="btnSendEmail" runat="server" Text="Send Email" 
                    onclick="btnSendEmail_Click"  />
                <asp:GridView ID="GridView1" CssClass="table table-striped" runat="server" AutoGenerateColumns="false"
                    GridLines="None">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <img style="max-width: 100px; max-height: 100px" src='<%# "uploads/" + Eval("Photo") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <%# Eval("STATUS") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%# Eval("Name") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Salary">
                            <ItemTemplate>
                                <%# Eval("Salary") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <%# Eval("Email") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phone">
                            <ItemTemplate>
                                <%# Eval("Phone") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Department Name">
                            <ItemTemplate>
                                <%# Eval("Dept_Name") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Supervisor">
                            <ItemTemplate>
                                <%# Eval("SName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
            </div>
            <!--/span-->
        </div>
        <!--/row-->
    </div>
</asp:Content>
