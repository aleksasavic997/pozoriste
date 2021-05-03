using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aleksa_Savic___Vizuelno_seminarski
{
    public partial class Registracija : System.Web.UI.Page
    {
        PozoristeDataContext pdc = new PozoristeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registracija_Click(object sender, EventArgs e)
        {
            string ime = tb_name.Text;
            string prezime = tb_lastname.Text;
            string korisnicko_ime = tb_username.Text;
            string lozinka = tb_lozinka.Text;

            var proveraDostupnostiImena = pdc.Korisniks.Where(x => x.username == korisnicko_ime).FirstOrDefault();

            if (proveraDostupnostiImena != null)
            {
                lGreska2.Text = "Korisničko ime " + korisnicko_ime + " postoji!";
            }
            else
            {
                if (lozinka == "")
                {
                    lGreska2.Text = "Potrebno je da unesete lozinku!";
                }
                else
                {
                    Korisnik korisnik = new Korisnik();

                    korisnik.ime = ime;
                    korisnik.prezime = prezime;
                    korisnik.username = korisnicko_ime;
                    korisnik.pass = lozinka;
                    korisnik.tip = "user";

                    pdc.Korisniks.InsertOnSubmit(korisnik);
                    pdc.SubmitChanges();

                    Session["userID"] = pdc.Korisniks.Max(x => x.id);
                    Session["ime"] = ime;
                    Session["ind"] = 0;
                    Session["prezime"] = prezime;
                    Session["tip"] = "user";

                    Response.Redirect("Pocetna.aspx");
                }
            }



        }
    }
}