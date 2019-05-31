using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;
using DOMINIO;

namespace FRONTEND_WEB_FORM
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        //FALTA VALIDAR QUE LAS LETRAS SEAN SIEMPRE MAYUSCULAS



        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void btnAuth_ServerClick(object sender, EventArgs e)
        {
            string codigo = txtvoucher.Value.ToString();
            codigo=codigo.ToUpper();
            
            //si es de 8 digitos
            if(codigo.Length==8)
            {

                

                voucherNegocio voucherNegocio = new voucherNegocio();

                //si es el ganador
                if (voucherNegocio.isWin(codigo) == true)
                {
                    Session["codigo1"] = codigo;
                    Response.Redirect("PrizePage.aspx", true);
                }

                else
                {
                    lblfail.Visible = true;
                }

            }

            else
            {
                lblfail.Visible = true;
            }




        }
    }
}