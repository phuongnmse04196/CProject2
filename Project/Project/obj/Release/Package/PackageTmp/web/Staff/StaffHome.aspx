﻿<%@ Page Title="" Language="C#" MasterPageFile="~/web/Staff/Staff.Master" AutoEventWireup="true" CodeBehind="StaffHome.aspx.cs" Inherits="Project.StaffHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="caculate-footer clearfix">
        <div class="col-md-11 col-md-offset-1">
            <div class="row" style="padding: 25px 0px">
                <p>Enter infomation of Customer</p>
                <div class="col-md-8">
                    <div class="row" style="margin-top: 10px;">
                        <div class="col-sm-4 div-for-lb">
                            <label for="txtCode" class="lbFormInHotel">Customer code </label>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtCode" runat="server" CssClass="txtFormInHotel" placeholder="Input Code here"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 10px;">
                        <div class="col-sm-4 div-for-lb">
                            <label for="txtName" class="lbFormInHotel">Customer name </label>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtName" runat="server" CssClass="txtFormInHotel" placeholder="Input Name here"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="row" style="margin-top: 10px;">
                        <asp:Button ID="btnSearch" CssClass="btn-style" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </div>
                    <div class="row" style="margin-top: 10px;">
                        <asp:Button ID="btnCreate" CssClass="btn-style" runat="server" Text="Create new customer" OnClick="btnCreate_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-11 col-md-offset-1">
            <div class="row" style="padding: 25px 0px">
                <p>Select Room</p>
                <div class="col-md-8">
                    <div class="row" style="margin-top: 10px;">
                        <div class="col-sm-4 div-for-lb">
                            <label for="drHotel" class="lbFormInHotel">Select Hotel</label>
                        </div>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="drHotel" runat="server" CssClass="drFormInHotel"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 10px;">
                        <div class="col-sm-4 div-for-lb">
                            <label for="drRoomType" class="lbFormInHotel">Select Room type</label>
                        </div>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="drRoomType" runat="server" CssClass="drFormInHotel"></asp:DropDownList>
                        </div>
                    </div>


                    <div class="row" style="margin-top: 10px;">
                        <div class="col-sm-4 div-for-lb">
                            <label for="txtCheckIn" class="lbFormInHotel">Check in</label>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox type="date" ID="txtCheckIn" CssClass="txtFormInHotel" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 10px;">
                        <div class="col-sm-4 div-for-lb">
                            <label for="txtCheckOut" class="lbFormInHotel">Check out</label>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox type="date" ID="txtCheckOut" CssClass="txtFormInHotel" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <div class="row" style="margin-top: 10px;">
                        <div class="col-md-6 col-md-offset-4">
                            <asp:Button ID="btnView" CssClass="btn-style" runat="server" Text="View available rooms" OnClick="btnView_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="row" style="margin-top: 10px;">
                        <asp:ListBox ID="ListBox1" runat="server" Height="94px" Width="466px"></asp:ListBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="margin-top: 10px;">
            <div class="col-md-4 col-md-offset-1">
                <asp:Button ID="btnBook" CssClass="btn-style" runat="server" Text="Book" OnClick="btnBook_Click" />
            </div>
        </div>
        <div class="row" style="margin-top: 10px;">
            <div class="col-md-9 col-md-offset-1">
                <asp:GridView ID="GridView2" runat="server" CssClass="gvFormInHotel" AutoGenerateColumns="False">
                </asp:GridView>
            </div>
        </div>
        <div class="row" style="margin-top: 10px;">
            <div class="col-md-4 col-md-offset-1">
                <h4 style="text-align: left;">Total amount (in $): </h4>
                <asp:Label ID="lbAmount" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row" style="margin-top: 10px; margin-bottom: 20px;">
            <div class="col-md-6 col-md-offset-1">
                <div class="col-md-6">
                    <asp:Button ID="btnSave" CssClass="btn-style" runat="server" Text="Save" OnClick="btnSave_Click" />
                </div>
                <div class="col-md-6">
                    <asp:Button ID="btnClose" CssClass="btn-style" runat="server" Text="Close" />
                </div>
            </div>
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
            width: 100%;
            border-radius: 10px;
            border: none;
            height: 30px;
        }

        .gvFormInHotel {
            width: 80%;
            border-radius: 5px;
            border: none;
            padding: 10px;
        }
    </style>
</asp:Content>
