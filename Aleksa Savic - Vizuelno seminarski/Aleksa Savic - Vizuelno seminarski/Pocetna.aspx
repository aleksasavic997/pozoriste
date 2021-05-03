<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pocetna.aspx.cs" Inherits="Aleksa_Savic___Vizuelno_seminarski.Pocetna" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pozoriste</title>
    <link href="App_Theme/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="main">
            <div id="meni">
                <ul>
                   <li><asp:LinkButton CssClass="selektovano" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Predstave</asp:LinkButton></li>
                   <li><a runat="server" id="kupljeneKarte" href="MojePredstave.aspx">Kupljene karte</a></li>
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
                        <asp:BoundField DataField="OstaloKarata" HeaderText=" Ostalo karata " ReadOnly="true" Visible="true"  />
                        <asp:HyperLinkField ControlStyle-Font-Size="15" Visible="true" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="Pocetna.aspx?detalji={0}" Text="Opis" > 
                            <ControlStyle  ForeColor="white"  Font-Bold="false"/>
                        </asp:HyperLinkField> 
                        <asp:HyperLinkField ControlStyle-Font-Size="15" Visible="true" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="Pocetna.aspx?izmeni={0}" Text="Kupi kartu" > 
                            <ControlStyle ForeColor="white"  Font-Bold="false"/>
                        </asp:HyperLinkField> 
                        <asp:HyperLinkField ControlStyle-Font-Size="15" Visible="false" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="Pocetna.aspx?brisi={0}" Text="Obrisi predstavu" > 
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
            <div id="dodajPredstavu" runat="server" visible="false">
           <div id="dodajPredstavuDiv"> 
           <p style="padding-top:15px;">DODAJ PREDSTAVU</p>
            <table>
                <tr>
                    <td>Naziv predstave:</td>
                    <td><asp:TextBox ID="tb_ime_predstave" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Ime autora teksta:</td>
                    <td><asp:TextBox ID="tb_ime_autora" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>O predstavi:</td>
                    <td><asp:TextBox ID="tb_o_predstavi" Height="150px" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Button ID="dodaj" Text="Dodaj" runat="server" OnClick="dodaj_Click"></asp:Button></td>
                </tr>
            </table>
            <asp:Label ID="greskaD" runat="server" ></asp:Label>
               </div>
        </div>
        </div>
    </form>
</body>
</html>
