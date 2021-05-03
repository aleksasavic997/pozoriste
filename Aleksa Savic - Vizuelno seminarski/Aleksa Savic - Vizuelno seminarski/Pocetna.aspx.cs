using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aleksa_Savic___Vizuelno_seminarski
{
    public partial class Pocetna : System.Web.UI.Page
    {
        PozoristeDataContext pdc = new PozoristeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["ind"] == 0)
            {
    
                azuriraj();
            }
            
            if(Session["tip"].ToString()=="admin")
            {
                gvPredstave.Columns[4].Visible = false;
                gvPredstave.Columns[5].Visible = false;
                gvPredstave.Columns[6].Visible = true;

                kupljeneKarte.Visible = false;
                dodajPredstavu.Visible = true;
                azuriraj();
            }

            if (Session["tip"].ToString() == "admin" && !(string.IsNullOrEmpty(Request["brisi"])))
            {
                var predstava = (from p in pdc.Predstavas
                                 where p.id == Convert.ToInt32(Request.QueryString["brisi"])
                                 select p).FirstOrDefault();

                var karte = (from k in pdc.Kartas
                             where k.idPredstave == Convert.ToInt32(Request.QueryString["brisi"])
                             select k
                             );

                if (karte!=null)
                {
                    foreach ( var item in karte)
                    {
                        pdc.Kartas.DeleteOnSubmit(item);
                        pdc.SubmitChanges();
                    }
                }

                pdc.Predstavas.DeleteOnSubmit(predstava);
                pdc.SubmitChanges();

                Response.Redirect("Pocetna.aspx");
                azuriraj();
            }

            if (Session["tip"].ToString() == "user" && !(string.IsNullOrEmpty(Request["detalji"])))
            {
                gvPredstave.Visible = false;
                nazad.Visible = true;
                var opis = (from o in pdc.Predstavas
                            where o.id == Convert.ToInt32(Request.QueryString["detalji"])
                            select o.opisPredstave).FirstOrDefault();

                var naslov = (from o in pdc.Predstavas
                              where o.id == Convert.ToInt32(Request.QueryString["detalji"])
                              select o.imePredstave).FirstOrDefault();
                predstaveLabela.Text = naslov;
                det.Text = opis;


            }

            if (Session["tip"].ToString() == "user" && !(string.IsNullOrEmpty(Request["izmeni"])))
            {
                var predstava = (from o in pdc.Predstavas
                              where o.id == Convert.ToInt32(Request.QueryString["izmeni"])
                              select o).FirstOrDefault();
                //dodaj
                int mojID = (int)Session["userID"];
                Karta karta = new Karta();
                karta.idKorisnika = mojID;
                karta.idPredstave = predstava.id;
                if (predstava.brojKarata > 0)
                {
                    pdc.Kartas.InsertOnSubmit(karta);
                    predstava.brojKarata--;
                    pdc.SubmitChanges();
                    azuriraj();
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pocetna.aspx");
        }

        protected void nazad_Click(object sender, EventArgs e)
        {
            Session["ind"] = 0;
            Response.Redirect("Pocetna.aspx");
        }

        private void azuriraj()
        {
            nazad.Visible = false;
            var upit1 = (from o in pdc.Predstavas
                         select new
                         {
                             NazivPredstave = o.imePredstave,
                             AutorTeksta = o.autorTeksta,
                             ID = o.id,
                             OstaloKarata = o.brojKarata

                         });

            gvPredstave.DataSource = upit1;
            gvPredstave.DataBind();

        }

        protected void dodaj_Click(object sender, EventArgs e)
        {
            string imePredstave = tb_ime_predstave.Text;
            string imeAutora = tb_ime_autora.Text;
            string opis = tb_o_predstavi.Text;

            var predstava = (from p in pdc.Predstavas
                             where p.imePredstave == imePredstave
                             select p
                             ).FirstOrDefault();
            if (predstava==null)
            {
                Predstava p = new Predstava();
                p.imePredstave = imePredstave;
                p.autorTeksta = imeAutora;
                p.opisPredstave = opis;
                p.brojKarata = 30;
                pdc.Predstavas.InsertOnSubmit(p);
                pdc.SubmitChanges();

                azuriraj();
            }
            else
            {
                greskaD.Text = "Predstava je vec na repertoaru";
            }
        }
    }
}