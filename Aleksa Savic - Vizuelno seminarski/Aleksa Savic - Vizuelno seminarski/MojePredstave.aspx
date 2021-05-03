<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MojePredstave.aspx.cs" Inherits="Aleksa_Savic___Vizuelno_seminarski.MojePredstave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kupljene karte</title>
    <link href="App_Theme/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="main">
            <div id="meni">
                <ul>
                   <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Predstave</asp:LinkButton></li>
                   <li><a runat="server" id="kupljeneKarte" class="selektovano" href="MojePredstave.aspx">Kupljene karte</a></li>
                   <li style="float:right"><a href="Login.aspx">Odjavi se</a></li>
               </ul>
            
            <br />
            <br />
            <br />
            <div style="padding-top:15px;padding-bottom:25px; text-align:center; font-weight:bold; font-size:30px; color:white; ">
                <asp:Label runat="server" ID="predstaveLabela">Predstave:</asp:Label>
                <br /> <br />

                <asp:GridView ID="gvPredstave" Font-Size="15" AutoGenerateColumns="false" runat="server" Height="30px" style="border-width:0;  border-color: black;text-align:left; margin:auto; margin-top: 27px" Width="90%" HeaderStyle-Font-Size="20"  >
                    <Columns>
                        <asp:BoundField DataField="ID" Visible="false" />
                        <asp:BoundField DataField="NazivPredstave" HeaderText=" Naziv predstave " ReadOnly="true" Visible="true"  />
                        <asp:BoundField DataField="AutorTeksta" HeaderText=" Autor teksta " ReadOnly="true" Visible="true"  />
                        <asp:HyperLinkField ControlStyle-Font-Size="15" Visible="true" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="MojePredstave.aspx?detalji={0}" Text="Opis" > 
                            <ControlStyle  ForeColor="white"  Font-Bold="false"/>
                        </asp:HyperLinkField> 
                        <asp:HyperLinkField ControlStyle-Font-Size="15" Visible="true" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="MojePredstave.aspx?izmeni={0}" Text="Prodaj kartu" > 
                            <ControlStyle ForeColor="white"  Font-Bold="false"/>
                        </asp:HyperLinkField> 
                    </Columns>
                </asp:GridView>
                <br />
                <div style="text-align:left;width:90%; margin:auto; ">
                <asp:Label ID="det" runat="server" Text=""></asp:Label>
                    <br /><br />
                    <asp:Button ID="nazad" runat="server" Text="Nazad" OnClick="nazad_Click" />
                </div>
            </div>
                </div>
        </div>
    </form>
</body>
</html>
