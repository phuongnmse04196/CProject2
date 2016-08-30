<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Display.aspx.cs" Inherits="Project.web.Admin.Display" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row caculate-footer" style="padding: 25px 0px">
        <div class="row" style="text-align:center; font-weight: 700; padding-bottom: 10px;">
                <h2>WELCOME ADMIN</h2>
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-sm-6 div-for-lb">
                    <label for="drHotel" class="lbFormInHotel">Select Hotel</label>
                </div>
                <div class="col-sm-6">
                    <asp:DropDownList ID="drHotel" runat="server" CssClass="drFormInHotel"></asp:DropDownList>
                </div>
            </div> 
            <div class="row" style="margin-top: 10px;">
                <div class="col-sm-6 div-for-lb">
                    <label for="drRoomType" class="lbFormInHotel">Select Room Type</label>
                </div>
                <div class="col-sm-6">
                    <asp:DropDownList ID="drRoomType" runat="server" CssClass="drFormInHotel"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-sm-4 div-for-lb">
                    <label for="txtCheckIn" class="lbFormInHotel">Check in</label>
                </div>
                <div class="col-sm-6">
                    <asp:TextBox type="date" ID="txtCheckIn" CssClass="txtFormInHotel" runat="server" ></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin-top: 10px;">
                <div class="col-sm-4 div-for-lb">
                    <label for="txtCheckOut" class="lbFormInHotel">Check out</label>
                </div>
                <div class="col-sm-6">
                    <asp:TextBox type="date" ID="txtCheckOut" CssClass="txtFormInHotel" runat="server" ></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-sm-12">
            <div class="row" style="margin-top: 10px">
                <div class="col-md-2 col-md-offset-1" style="text-align: left">
                    <asp:Button ID="btnView"  CssClass="btn-style" runat="server" Text="View" OnClick="btnView_Click" />
                </div>
            </div>
        </div>
        <div class="row" >
            <div class="col-sm-9 col-md-offset-1" style="width: 90%; height: 200px; overflow: scroll;">
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
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
    </style>
</asp:Content>
