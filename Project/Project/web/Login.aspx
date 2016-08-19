<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
    <meta charset="utf-8">
    <link href="../css/style.css" rel="stylesheet" type="text/css">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="https://pagead2.googlesyndication.com/pub-config/r20160601/ca-pub-9153409599391170.js"></script>
    <script async="" src="//www.google-analytics.com/analytics.js"></script>
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--webfonts-->
    <link href="//fonts.googleapis.com/css?family=Open+Sans:600italic,400,300,600,700" rel="stylesheet" type="text/css">
    <!--//webfonts-->
    <script id="_fbn_projs" type="text/javascript" src="//srv.buysellads.com/ads/C6ADVKE.json?segment=placement:w3layouts&amp;callback=_fbn_go"></script>
</head>
<body>

    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
        ga('create', 'UA-30027142-1', 'w3layouts.com');
        ga('send', 'pageview');
    </script>
    <script async="" type="text/javascript" src="//cdn.fancybar.net/ac/fancybar.js?zoneid=1502&amp;serve=C6ADVKE&amp;placement=w3layouts" id="_fancybar_js"></script>


    <!-----start-main---->
    <div class="main">
        <!---728x90--->
        <div style="text-align: center;">
            <script async="" src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
            <ins class="adsbygoogle" style="display: inline-block; width: 728px; height: 90px" data-ad-client="ca-pub-9153409599391170" data-ad-slot="6850850687" data-adsbygoogle-status="done"><ins id="aswift_0_expand" style="display: inline-table; border: none; height: 90px; margin: 0; padding: 0; position: relative; visibility: visible; width: 728px; background-color: transparent"><ins id="aswift_0_anchor" style="display: block; border: none; height: 90px; margin: 0; padding: 0; position: relative; visibility: visible; width: 728px; background-color: transparent">
                <iframe width="728" height="90" frameborder="0" marginwidth="0" marginheight="0" vspace="0" hspace="0" allowtransparency="true" scrolling="no" allowfullscreen="true" onload="var i=this.id,s=window.google_iframe_oncopy,H=s&amp;&amp;s.handlers,h=H&amp;&amp;H[i],w=this.contentWindow,d;try{d=w.document}catch(e){}if(h&amp;&amp;d&amp;&amp;(!d.body||!d.body.firstChild)){if(h.call){setTimeout(h,0)}else if(h.match){try{h=s.upd(h,i)}catch(e){}w.location.replace(h)}}" id="aswift_0" name="aswift_0" style="left: 0; position: absolute; top: 0;"></iframe>
            </ins></ins></ins>
            <script>
                (adsbygoogle = window.adsbygoogle || []).push({});
            </script>
        </div>
        <div class="login-form">
            <h1>Member Login</h1>
            <div class="head">
                <img src="../images/user.png" alt="">
            </div>
            <form id="form1" runat="server" action="" method="POST">
                
                <asp:TextBox ID="txtUser" runat="server" class="text" value="USERNAME" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'USERNAME';}"></asp:TextBox>
                
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" value="Password" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Password';}"></asp:TextBox>
                
                <div class="submit">
                    <asp:Button type="submit" ID="Button1"  runat="server" Text="LOGIN" OnClick="Button1_Click" />
                </div>
                <p><a href="#">Forgot Password ?</a></p>
            </form>
        </div>
        <!--//End-login-form-->
        <!---728x90--->
        <div style="text-align: center;">
            <script async="" src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
            <ins class="adsbygoogle" style="display: inline-block; width: 728px; height: 90px" data-ad-client="ca-pub-9153409599391170" data-ad-slot="6850850687" data-adsbygoogle-status="done"><ins id="aswift_1_expand" style="display: inline-table; border: none; height: 90px; margin: 0; padding: 0; position: relative; visibility: visible; width: 728px; background-color: transparent"><ins id="aswift_1_anchor" style="display: block; border: none; height: 90px; margin: 0; padding: 0; position: relative; visibility: visible; width: 728px; background-color: transparent">
                <iframe width="728" height="90" frameborder="0" marginwidth="0" marginheight="0" vspace="0" hspace="0" allowtransparency="true" scrolling="no" allowfullscreen="true" onload="var i=this.id,s=window.google_iframe_oncopy,H=s&amp;&amp;s.handlers,h=H&amp;&amp;H[i],w=this.contentWindow,d;try{d=w.document}catch(e){}if(h&amp;&amp;d&amp;&amp;(!d.body||!d.body.firstChild)){if(h.call){setTimeout(h,0)}else if(h.match){try{h=s.upd(h,i)}catch(e){}w.location.replace(h)}}" id="aswift_1" name="aswift_1" style="left: 0; position: absolute; top: 0;"></iframe>
            </ins></ins></ins>
            <script>
                (adsbygoogle = window.adsbygoogle || []).push({});
            </script>
            <div style="text-align: center;">
                <script async="" src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
                <ins class="adsbygoogle" style="display: inline-block; width: 728px; height: 90px" data-ad-client="ca-pub-9153409599391170" data-ad-slot="6850850687" data-adsbygoogle-status="done"><ins id="aswift_2_expand" style="display: inline-table; border: none; height: 90px; margin: 0; padding: 0; position: relative; visibility: visible; width: 728px; background-color: transparent"><ins id="aswift_2_anchor" style="display: block; border: none; height: 90px; margin: 0; padding: 0; position: relative; visibility: visible; width: 728px; background-color: transparent">
                    <iframe width="728" height="90" frameborder="0" marginwidth="0" marginheight="0" vspace="0" hspace="0" allowtransparency="true" scrolling="no" allowfullscreen="true" onload="var i=this.id,s=window.google_iframe_oncopy,H=s&amp;&amp;s.handlers,h=H&amp;&amp;H[i],w=this.contentWindow,d;try{d=w.document}catch(e){}if(h&amp;&amp;d&amp;&amp;(!d.body||!d.body.firstChild)){if(h.call){setTimeout(h,0)}else if(h.match){try{h=s.upd(h,i)}catch(e){}w.location.replace(h)}}" id="aswift_2" name="aswift_2" style="left: 0; position: absolute; top: 0;"></iframe>
                </ins></ins></ins>
                <script>
                    (adsbygoogle = window.adsbygoogle || []).push({});
                </script>
            </div>
            <!-----//end-main---->
</body>
</html>
