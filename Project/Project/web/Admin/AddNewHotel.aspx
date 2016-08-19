<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddNewHotel.aspx.cs" Inherits="Project.web.Admin.AddNewHotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="caculate-footer">
        <div class="row" style="padding: 25px 0px">
            <div class="col-md-8 col-md-offset-2">
                <div class="row" style="text-align: center; font-weight: 700; padding-bottom: 10px;">
                    <h2>Enter information of Hotel</h2>
                </div>
                <div class="row">
                    <div class="col-sm-4 div-for-lb">
                        <label for="txtCode" class="lbFormInHotel">Code</label>
                    </div>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtCode" runat="server" CssClass="txtFormInHotel" placeholder="Input Code here"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="margin-top: 10px;">
                    <div class="col-sm-4 div-for-lb">
                        <label for="txtName" class="lbFormInHotel">Name</label>
                    </div>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtName" runat="server" CssClass="txtFormInHotel" placeholder="Input Name here"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="margin-top: 10px;">
                    <div class="col-sm-4 div-for-lb">
                        <label for="txtAddress" class="lbFormInHotel">Address</label>
                    </div>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="txtFormInHotel" placeholder="Input Address here"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="padding: 25px 0px">
            <div class="col-md-2 col-md-offset-4">
                <asp:Button ID="btnSave" CssClass="btn-style" runat="server" Text="Save" />
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnClose" CssClass="btn-style" runat="server" Text="Close" />

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
    </style>
</asp:Content>
