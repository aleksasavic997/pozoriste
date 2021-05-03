<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Aleksa_Savic___Vizuelno_seminarski.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login page</title>
    <link href="App_Theme/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
            <p style="padding-top:150px; padding-left:320px; font-size:60px; color:white;">Dobrodošli u pozorište</p>
            
            <div id="login">
                <div class="loginKlasa">
                    <asp:Label Font-Size="25" ID="label1" runat="server" Text="Korisničko ime:" Font-Bold="true" ></asp:Label><br /><br /><br />
                    <asp:Label Font-Size="25" ID="label2" runat="server" Text="Lozinka:" Font-Bold="true" ></asp:Label><br /><br /><br />
                </div>
                <div class="loginKlasa">
                    <asp:TextBox Font-Size="20" Width="250" Height="30" ID="tb_username" runat="server"></asp:TextBox><br /><br /><br />
                    <asp:TextBox Font-Size="20" Width="250" Height="30" ID="tb_lozinka" runat="server" TextMode="Password" ></asp:TextBox><br /><br />
                </div>
                <div style="margin-left:300px">
                    <asp:Label Width="200px" ID="lGreska1" runat="server" Text=""></asp:Label><br /><br />
                </div>
                <div style="margin-left:300px">
                    <asp:Button Font-Size="20" Width="200px" Height="50px" ID="prijava" runat="server" Text="Prijavite se" OnClick="prijava_Click" />
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />
            <div style="padding-left:1050px; color:white">
                <asp:Label ID="label3" runat="server" Text="Nemate nalog?" Font-Bold="true" ></asp:Label><br />
                <asp:Button ID="registracija" runat="server" Text="Registrujte se!" OnClick="registracija_Click" />
            </div>

        
    </form>
</body>
</html>
