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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        int elegido = 0;
        string dni = null;
        protected void btnAuth1_ServerClick(object sender, EventArgs e)
        {
            elegido = 1;
                pnldni.Visible = true;
                pnlPremios.Visible = false;
            
            
        }
        protected void btnAuth2_ServerClick(object sender, EventArgs e)
        {
            elegido = 2;
                pnldni.Visible = true;
            pnlPremios.Visible = false;


        }
        protected void btnAuth3_ServerClick(object sender, EventArgs e)
        {
            elegido = 3;
                pnldni.Visible = true;
            pnlPremios.Visible = false;


        }
        protected void btnAuth4_ServerClick(object sender, EventArgs e)
        {
            elegido = 4;
                pnldni.Visible = true;
            pnlPremios.Visible = false;


        }
        protected void btnAuth5_ServerClick(object sender, EventArgs e)
        {
            elegido = 5;
                pnldni.Visible = true;
            pnlPremios.Visible = false;


        }


        protected void btnCancel_ServerClick(object sender, EventArgs e)
        {
            pnlCarga.Visible = false;
            pnlPremios.Visible = true;
        }
        protected void btnLoad_ServerClick(object sender, EventArgs e)
        {
            if( 1==1) //insertar validaciones de controladores
            {
                
                NEGOCIO.clienteNegocio cliente = new NEGOCIO.clienteNegocio();

                cliente.cargarCliente(int.Parse(dni), txtnombre.Value.ToString(), txtapellido.Value.ToString(), int.Parse(txtnumero.Value.ToString()), txtdireccion.Value.ToString(), txtlocalidad.Value.ToString(), int.Parse(txtnumero.Value.ToString()), txtemail.Value.ToString());


                pnlCarga.Visible = false;
                pnlend.Visible = true;
            }
            else
            {
                lblfail.Visible = true;
            }
            
        }
        protected void btnauthdni_ServerClick(object sender, EventArgs e)
        {
            //insertar validaciones de controladores
            if (1==1)//validar dni como valide voucher
            {
                
                dni = txtdni.Value.ToString();
                pnlCarga.Visible = true;
                pnldni.Visible = false;
            }
            else
            {
                lblerrordni.Visible = true;
            }
           
        }
    }
}