using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aleksa_Savic___Vizuelno_seminarski
{
    public partial class MojePredstave : System.Web.UI.Page
    {
        PozoristeDataContext pdc = new PozoristeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tip"].ToString() == "user")
            {
                azuriraj();
            }

            if (Session["tip"].ToString() == "user" && !(string.IsNullOrEmpty(Request["detalji"])))
            {
                nazad.Visible = true;
                var opis = (from o in pdc.Kartas
                            where o.id == Convert.ToInt32(Request.QueryString["detalji"])
                            select o.Predstava.opisPredstave).FirstOrDefault();

                var naslov = (from o in pdc.Kartas
                              where o.id == Convert.ToInt32(Request.QueryString["detalji"])
                              select o.Predstava.imePredstave).FirstOrDefault();
                predstaveLabela.Text = naslov;
                gvPredstave.Visible = false;
                det.Text = opis;


            }

            if (Session["tip"].ToString() == "user" && !(string.IsNullOrEmpty(Request["izmeni"])))
            {
                var predstava = (from o in pdc.Kartas
                                 where o.id == Convert.ToInt32(Request.QueryString["izmeni"])
                                 select o.Predstava).FirstOrDefault();
                //dodaj
                var karta = (
                                from o in pdc.Kartas
                                where o.id == Convert.ToInt32(Request.QueryString["izmeni"])
                                select o
                            ).FirstOrDefault();

                if (karta != null)
                {
                    pdc.Kartas.DeleteOnSubmit(karta);
                    predstava.brojKarata++;
                    pdc.SubmitChanges();
                    azuriraj();
                }
            }
        }

        private void azuriraj()
        {
            nazad.Visible = false;
            var upit1 = (from o in pdc.Kartas
                         where o.idKorisnika==(int)Session["userID"]
                         select new
                         {
                             NazivPredstave = o.Predstava.imePredstave,
                             AutorTeksta = o.Predstava.autorTeksta,
                             ID = o.id,

                         });

            gvPredstave.DataSource = upit1;
            gvPredstave.DataBind();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pocetna.aspx");
        }

        protected void nazad_Click(object sender, EventArgs e)
        {
            Session["ind"] = 0;
            Response.Redirect("MojePredstave.aspx");
        }
    }
}