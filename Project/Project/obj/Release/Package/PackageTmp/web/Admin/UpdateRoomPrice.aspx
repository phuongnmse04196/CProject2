<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateRoomPrice.aspx.cs" Inherits="Project.web.Admin.UpdateRoomPrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row caculate-footer" style="padding: 25px 0px">
        <div class="col-md-8 col-md-offset-2">
            <div class="row" style="text-align:center; font-weight: 700; padding-bottom: 10px;">
                <h2>Enter information of Room</h2>
            </div>
            <div class="row">
                <div class="col-sm-4 div-for-lb">
                    <label for="drHotel" class="lbFormInHotel">Select Hotel</label>
                </div>
                <div class="col-sm-6">
                    <asp:DropDownList ID="drHotel" runat="server" CssClass="drFormInHotel" AutoPostBack="True" OnSelectedIndexChanged="drHotel_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div> 
            <div class="row" style="margin-top: 10px;">
                <div class="col-sm-4 div-for-lb">
                    <label for="drRoomType" class="lbFormInHotel">Select Room Type</label>
                </div>
                <div class="col-sm-6">
                    <asp:DropDownList ID="drRoomType" runat="server" CssClass="drFormInHotel" AutoPostBack="True" OnSelectedIndexChanged="drRoomType_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <div class="row" style="margin-top: 10px;">
                <div class="col-sm-4 div-for-lb">
                    <label for="drRoom" class="lbFormInHotel">Select Room</label>
                </div>
                <div class="col-sm-6">
                    <asp:DropDownList ID="drRoom" runat="server" CssClass="drFormInHotel" OnSelectedIndexChanged="drRoom_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>
            <div class="row" style="margin-top: 10px;">
                <div class="col-sm-4 div-for-lb">
                    <label for="txtOldPrice" class="lbFormInHotel">Old Price</label>
                </div>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtOldPrice" runat="server" CssClass="txtFormInHotel"  placeholder="$ per night" Enabled="false" ></asp:TextBox>
                </div>
            </div><div class="row" style="margin-top: 10px;">
                <div class="col-sm-4 div-for-lb">
                    <label for="txtNewPrice" class="lbFormInHotel">New Price</label>
                </div>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtNewPrice" runat="server" CssClass="txtFormInHotel"  placeholder="$ per night"  ></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row" style="padding: 25px 0px">
        <div class="col-md-2 col-md-offset-4">
            <asp:Button ID="btnSave"  CssClass="btn-style" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnClose"  CssClass="btn-style" runat="server" Text="Close" />

        </div>
    </div>
    <style type="text/css">
        .lbFormInHotel {
            font-weight: bold;

        }
        .txtFormInHotel {
            width: 70%;
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
        .drFormInHotel {
            width: 70%;
            border-radius: 10px;
            border: none;
            height: 30px;
        }
    </style>
</asp:Content>
