<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AllDepartment.aspx.cs" Inherits="AllDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <div id="content" style="min-height: 659px">
        <asp:GridView ID="GridView1" CssClass="table table-bordered table-striped table-condensed"
            runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Department ID">
                    <ItemTemplate>
                        <%# Eval("Dept_Id") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department Name">
                    <ItemTemplate>
                        <%# Eval("Dept_Name") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department Head">
                    <ItemTemplate>
                        <%# Eval("Name") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# "NewDepartment.aspx?ID=" + Eval("Dept_Id") %>'>EDIT</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
