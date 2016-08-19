<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddNewStaff.aspx.cs" Inherits="Project.web.Admin.AddNewStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row caculate-footer" style="padding: 25px 0px">
        <div class="col-md-8 col-md-offset-2">
            <div class="row" style="text-align:center; font-weight: 700; padding-bottom: 10px;">
                <h2>Enter information of User</h2>
            </div>
            <div class="row" style="margin-top: 10px;">
                <div class="col-sm-4 div-for-lb">
                    <label for="txtUsername" class="lbFormInUser">UserName</label>
                </div>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="txtFormInUser" placeholder="Input Username here"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin-top: 10px;">
                <div class="col-sm-4 div-for-lb">
                    <label for="txtAddress" class="lbFormInUser">Address</label>
                </div>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="txtFormInUser"  placeholder="Input Address here"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row" style="padding: 25px 0px">
        <div class="col-md-2 col-md-offset-4">
            <asp:RadioButton ID="rbAdmin" runat="server" GroupName="rbGroup" Text="Administrator"/>
        </div>
        <div class="col-md-2">
            <asp:RadioButton ID="rbStaff" runat="server" GroupName="rbGroup" Text="Staff"/>
        </div>
    </div>
    <div class="row" style="padding: 25px 0px">
        <div class="col-md-2 col-md-offset-4">
            <asp:Button ID="btnSave"  CssClass="btn-style" runat="server" Text="Save" />
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnClose"  CssClass="btn-style" runat="server" Text="Close" />
        </div>
    </div>
    <style type="text/css">
        .lbFormInUser {
            font-weight: bold;

        }
        .txtFormInUser {
            width: 100%;
            border-radius: 10px;
            border: none;
            height: 35px;
            padding: 10px;
        }
        .div-for-lb {
            text-align: right;
        }
        .btn-style {
            width: 70%;
            height: 30px;
            border: initial;
            border-radius: 5px;
        }
    </style>
</asp:Content>
