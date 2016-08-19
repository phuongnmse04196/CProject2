<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
    <meta charset="utf-8" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="https://pagead2.googlesyndication.com/pub-config/r20160601/ca-pub-9153409599391170.js"></script>
    <script async="" src="//www.google-analytics.com/analytics.js"></script>

</head>
<body>

    <!-----start-main---->
    <div class="main">
        <div class="login-form">
            <h1>Member Login</h1>
            <div class="head">
                <img src="../images/user.png" alt="" />
            </div>
            <form id="form1" runat="server" action="Login.aspx" method="POST">

                <asp:TextBox ID="txtUser" runat="server" class="text" value="USERNAME" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'USERNAME';}"></asp:TextBox>

                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" value="Password" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Password';}"></asp:TextBox>

                <div class="submit">
                    <asp:Button type="submit" ID="Button1" runat="server" Text="LOGIN" OnClick="Button1_Click" />
                </div>
                <p><a href="#">Forgot Password?</a></p>
                <p><a href="#">You are the customer?</a></p>
            </form>
        </div>
    </div>
</body>
</html>
