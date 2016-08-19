<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddNewRoomType.aspx.cs" Inherits="Project.web.Admin.AddNewRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="padding: 25px 0px; text-align: center; font-weight: 700;">
        <h2>Enter infomation of Room type</h2>
    </div>
    <div class="row" style="padding: 25px 0px">
        <div class="col-md-8 col-md-offset-2">
            <div class="row" style="margin-top: 10px;">
                <div class="col-sm-4 div-for-lb">
                    <label for="txtRoom" class="lbFormInUser">Room type</label>
                </div>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtRoom" runat="server" CssClass="txtFormInUser"  placeholder="Input Type here"></asp:TextBox>
                </div>
            </div>
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
