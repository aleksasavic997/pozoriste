using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aleksa_Savic___Vizuelno_seminarski
{

    public partial class login : System.Web.UI.Page
    {
        private readonly PozoristeDataContext pdc = new PozoristeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void prijava_Click(object sender, EventArgs e)
        {

            string username = tb_username.Text;
            string lozinka = tb_lozinka.Text;

            var korisnik = pdc.Korisniks.Where(x => x.username == username && x.pass == lozinka).FirstOrDefault();

            if (korisnik != null)
            {
                Session["userID"] = korisnik.id;
                Session["ime"] = korisnik.ime;
                Session["prezime"] = korisnik.prezime;
                Session["ind"] = 0;
                Session["tip"] = korisnik.tip;

                Response.Redirect("Pocetna.aspx");
            }
            else
            {
                lGreska1.Text = "Korisničko ime - lozinka nisu ispravni!";
            }
        }

        protected void registracija_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registracija.aspx");
        }
    }
}