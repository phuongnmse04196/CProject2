<%@ Page Title="" Language="C#" MasterPageFile="~/web/Staff/Staff.Master" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="Project.web.Staff.Print" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="caculate-footer clearfix">
        <div class="col-md-11 col-md-offset-1">
            <div class="row" style="padding: 25px 0px">
                <div class="col-md-6">
                    <div class="col-sm-4 div-for-lb">
                        <label for="txtName" class="lbFormInHotel">Customer Name </label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtName" runat="server" CssClass="txtFormInHotel" placeholder="Input name here"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="col-sm-4 div-for-lb">
                        <label for="txtDate" class="lbFormInHotel">Or select booking date</label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox type="date" ID="txtDate" CssClass="txtFormInHotel" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row" >
                <div class="col-md-4 col-md-offset-1">
                    <asp:Button ID="btnSearch" CssClass="btn-style" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </div>
            </div>
            <div class="row" style="padding: 25px 0px">
                <div class="col-md-10 col-md-offset-1">
                    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
                </div>
            </div>
            <div class="row" style="padding: 25px 0px">
                <div class="col-md-6 col-md-offset-1">
                    <div class="col-md-" >
                        <asp:TextBox ID="txtChekOut" runat="server" CssClass="txtFormInHotel" placeholder="Input a room no to check out"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4 ">
                    <asp:Button ID="btnCheckOut" CssClass="btn-style" runat="server" Text="Check Out" OnClientClick="return confirm('Are you sure you want to checkout?');" OnClick="btnCheckOut_Click" />
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
