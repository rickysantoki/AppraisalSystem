<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AppraisalFormList.aspx.cs" Inherits="SearchForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <div id="content">
        <%--<ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Home.aspx">Home</a> <i class="icon-angle-right">
            </i></li>
            <li><a href="#">Search Appraisal Form</a></li>
        </ul>
        Name:
        <asp:TextBox ID="txtSearchName" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-primary" Style="position: relative;
            top: -5px" OnClick="btnSearch_Click" />--%>
        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header">
                    <h2>
                        <i class="halflings-icon align-justify"></i><span class="break"></span>Search Results</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-setting"><i class="halflings-icon wrench"></i></a><a href="#"
                            class="btn-minimize"><i class="halflings-icon chevron-up"></i></a><a href="#" class="btn-close">
                                <i class="halflings-icon remove"></i></a>
                    </div>
                </div>
                <asp:GridView ID="GridView1" CssClass="table table-striped" runat="server" AutoGenerateColumns="false"
                    GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="Department">
                            <ItemTemplate>
                                <%# Eval("DepartmentName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Start Date">
                            <ItemTemplate>
                                <%# Eval("Start_Date", "{0:d}")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="End Date">
                            <ItemTemplate>
                                <%# Eval("End_Date", "{0:d}")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Appraisal Cycle">
                            <ItemTemplate>
                                <%# Eval("AppraisalCycle") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href='<%# "AppraisalFormDetail.aspx?FID=" + Eval("App_Form_Id") + "&IsEdit=1" %>'>
                                    EDIT</a> | <a href='<%# "Report_AppraisalFormStatus.aspx?FID=" + Eval("App_Form_Id") %>'>
                                        Status Report</a>
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
