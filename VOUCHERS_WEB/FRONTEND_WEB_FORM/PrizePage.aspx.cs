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

        public int elegido = 0;
        public int dni = 0;
        public cliente cliente1 = new cliente(0,"","",0,"","",0,"");
        
        


        protected void btnAuth1_ServerClick(object sender, EventArgs e)
        {
            elegido = 1;
            Session["elegido1"] = elegido;
            pnldni.Visible = true;
            pnlPremios.Visible = false;
            


        }
        protected void btnAuth2_ServerClick(object sender, EventArgs e)
        {
            elegido = 2;
            Session["elegido1"] = elegido;
            pnldni.Visible = true;
            pnlPremios.Visible = false;


        }
        protected void btnAuth3_ServerClick(object sender, EventArgs e)
        {
            elegido = 3;
            Session["elegido1"] = elegido;
            pnldni.Visible = true;
            pnlPremios.Visible = false;


        }
        protected void btnAuth4_ServerClick(object sender, EventArgs e)
        {
            elegido = 4;
            Session["elegido1"] = elegido;
            pnldni.Visible = true;
            pnlPremios.Visible = false;


        }
        protected void btnAuth5_ServerClick(object sender, EventArgs e)
        {
            elegido = 5;
            Session["elegido1"] = elegido;
            pnldni.Visible = true;
            pnlPremios.Visible = false;


        }

        //BTN CANCELAR carga cliente
        protected void btnCancelCliente_ServerClick(object sender, EventArgs e)
        {
            pnldni.Visible = true;
            pnlCarga.Visible = false;
            pnlPremios.Visible = false;
            
            
        }

        //btn cancelar dni
        protected void btnCancelDni_ServerClick(object sender, EventArgs e)
        {
            pnldni.Visible = false;
            pnlCarga.Visible = false;
            pnlPremios.Visible = true;
           

        }

        // BTN PARA VALIDAR EL DNI //FALTA VERIFICAR SI ESE DNI COMPRO ESE VOUCHER Y SI YA HABIA GANADO QUE NO PUEDA GANAR DE NUEVO(OPCIONAL)
        protected void btnAceptarDni_ServerClick(object sender, EventArgs e)
        {
            clienteNegocio clienteNegocio1 = new clienteNegocio();
            funcionesAuxNegocio aux = new funcionesAuxNegocio();

            //insertar validaciones de controladores

            if (aux.validarNumeros(txtdni.Value) && txtdni.Value != "")
            {

                dni = Int32.Parse(txtdni.Value);

                if (dni > 0) // si el dni es mayor a 0
                {
                    if (clienteNegocio1.verificarCliente(dni) == true)//si el cliente esta registrado
                    {
                        cliente1 = clienteNegocio1.buscarXDni(dni); // busco el cliente

                        //cargo los txt box
                        txtnombre.Value = cliente1.Nombre;
                        txtapellido.Value = cliente1.Apellido;
                        txtdireccion.Value = cliente1.Calle;
                        txtnumero.Value = cliente1.NroCalle.ToString();
                        txtlocalidad.Value = cliente1.Localidad;
                        txttelefono.Value = cliente1.Telefono.ToString();
                        txtemail.Value = cliente1.Email;

                        Session["dni1"] = cliente1.Dni;
                    }
                    //si no esta registrado lo muestra vacio
                    else
                    {
                        txtnombre.Value = "Nombre";
                        txtapellido.Value = "Apellido";
                        txtdireccion.Value = "Direccion(Calle)";
                        txtnumero.Value = "Direccion(Numero)";
                        txtlocalidad.Value = "Localidad";
                        txttelefono.Value = "Telefono(SIN CODAREA)";
                        txtemail.Value = "Mail";

                        Session["dni1"] = dni;
                    }


                    pnlCarga.Visible = true;
                    pnldni.Visible = false;
                }

                else
                {
                    lblerrordni.Visible = true;
                }

            }

            else
            {
                lblerrordni.Visible = true;
            }




        }

        //evento boton para ACEPTAR LA CARGA DEL CLIENTE //falta terminar
        protected void btnAceptarCliente_ServerClick(object sender, EventArgs e)
        {
            funcionesAuxNegocio aux = new funcionesAuxNegocio();
            clienteNegocio clienteNegocio1 = new NEGOCIO.clienteNegocio();
            voucherNegocio vNeg = new voucherNegocio();

            string idVoucher = Convert.ToString(Session["codigo1"]);
            voucher v=vNeg.buscarXID(idVoucher);
            v.IdProdSelec = Convert.ToInt32(Session["elegido1"]);

            bool validado = false;

            validado=validarCargaCliente();


            if (validado == true)
            {
                cliente1.Apellido = txtapellido.Value;
                cliente1.Nombre = txtnombre.Value;
                cliente1.Email = txtemail.Value;
                cliente1.Localidad = txtlocalidad.Value;
                cliente1.NroCalle = Int32.Parse(txtnumero.Value);
                cliente1.Calle = txtdireccion.Value;
                cliente1.Dni = Convert.ToInt32(Session["dni1"]);
                cliente1.Telefono = Int32.Parse( txttelefono.Value);

                if (clienteNegocio1.verificarCliente(cliente1.Dni) == true) //si esta registrado hace un update
                {
                    clienteNegocio1.modificarCliente(cliente1.Dni, cliente1.Nombre, cliente1.Apellido, cliente1.NroCalle, cliente1.Calle, clienteNegocio1.buscarIdXLocalidad(txtlocalidad.Value), cliente1.Telefono, cliente1.Email);
                    vNeg.bajaVoucher(v.Id, v.IdProdSelec);

                    pnlCarga.Visible = false;
                    pnlend.Visible = true;
                }
                else //si no lo esta, le cargo el dni anterior 
                {

                    clienteNegocio1.cargarLocalidad(cliente1.Localidad);
                    clienteNegocio1.cargarCliente(cliente1.Dni, cliente1.Nombre, cliente1.Apellido, cliente1.NroCalle, cliente1.Calle, clienteNegocio1.buscarIdXLocalidad(txtlocalidad.Value), cliente1.Telefono, cliente1.Email);


                    vNeg.bajaVoucher(v.Id, v.IdProdSelec);

                    pnlCarga.Visible = false;
                    pnlend.Visible = true;


                }
            }

            else
            {
                lblfail.Visible = true;
            }
            
        }

        public bool validarCargaCliente()
        {

            funcionesAuxNegocio aux = new funcionesAuxNegocio();

            if(aux.validarLetras(txtapellido.Value)==true)
            {
                if(aux.validarLetras(txtnombre.Value)==true)
                {
                    if (aux.validarLetras(txtdireccion.Value)==true)
                    {
                        if(aux.validarLetras(txtlocalidad.Value)==true)
                        {
                            if(aux.validarNumeros(txttelefono.Value)==true)
                            {
                                if (aux.validarNumeros(txtnumero.Value) == true)
                                {
                                    if (aux.validarEmail(txtemail.Value) == true)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;


        }
    }
}