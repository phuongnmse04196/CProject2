<%@ Page Title="" Language="C#" MasterPageFile="~/web/Staff/Staff.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="Project.web.Staff.AddCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="caculate-footer clearfix">
        <div class="col-md-11 col-md-offset-1">
            <div class="row" style="padding: 25px 0px">
                <p>Enter infomation of Customer</p>
                <div class="col-md-8 col-md-offset-2">
                    <div class="row" style="margin-top: 10px;">
                        <div class="col-sm-4 div-for-lb">
                            <label for="txtCode" class="lbFormInHotel">Code </label>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtCode" runat="server" CssClass="txtFormInHotel" placeholder="Input code here"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row" style="margin-top: 10px;">
                        <div class="col-sm-4 div-for-lb">
                            <label for="txtName" class="lbFormInHotel">Name</label>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtName" runat="server" CssClass="txtFormInHotel" placeholder="Input name here"></asp:TextBox>
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
            <div class="row" style="margin-top: 10px; margin-bottom: 20px;">
                <div class="col-md-6 col-md-offset-2">
                    <div class="col-md-6">
                        <div class="row" style="margin-top: 10px;">
                            <asp:Button ID="btnSave" CssClass="btn-style" runat="server" Text="Save" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row" style="margin-top: 10px;">
                            <asp:Button ID="btnClose" CssClass="btn-style" runat="server" Text="Close" />
                        </div>
                    </div>
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
