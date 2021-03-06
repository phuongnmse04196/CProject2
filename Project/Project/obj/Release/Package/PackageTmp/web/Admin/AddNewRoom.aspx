﻿<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddNewRoom.aspx.cs" Inherits="Project.web.Admin.AddNewRoom1" %>
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
                    <asp:DropDownList ID="drHotel" runat="server" CssClass="drFormInHotel"></asp:DropDownList>
                </div>
            </div> 
            <div class="row" style="margin-top: 10px;">
                <div class="col-sm-4 div-for-lb">
                    <label for="drRoomType" class="lbFormInHotel">Select Room Type</label>
                </div>
                <div class="col-sm-6">
                    <asp:DropDownList ID="drRoomType" runat="server" CssClass="drFormInHotel"></asp:DropDownList>
                </div>
            </div>
            <div class="row" style="margin-top: 10px;">
                <div class="col-sm-4 div-for-lb">
                    <label for="txtRoom" class="lbFormInHotel">Room no</label>
                </div>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtRoom" runat="server" CssClass="txtFormInHotel"  placeholder="Input Address here"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin-top: 10px;">
                <div class="col-sm-4 div-for-lb">
                    <label for="txtPrice" class="lbFormInHotel">Price</label>
                </div>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="txtFormInHotel"  placeholder="$ per night"  ></asp:TextBox>
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
        .drFormInHotel {
            width: 70%;
            border-radius: 10px;
            border: none;
            height: 30px;
        }
    </style>
</asp:Content>
