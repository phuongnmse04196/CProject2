<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddNewRoomType.aspx.cs" Inherits="Project.web.Admin.AddNewRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Room Type"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add" />
</asp:Content>
