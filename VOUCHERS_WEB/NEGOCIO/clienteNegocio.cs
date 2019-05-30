using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMINIO;
using ACCESO_DATOS;
using System.Data.SqlClient;

namespace NEGOCIO
{
    public class clienteNegocio
    {

        public void cargarCliente(int dni,string nombre, string apellido,int nroCalle,string calle,int codPostal,int telefono,string email)
        {

        }

        public bool verificarRegistro(int dni)
        {

        }

        public cliente buscarXDni(int dni)
        {

        }

        public void modificarCliente(int dni, string nombre, string apellido, int nroCalle, string calle, int codPostal, int telefono, string email)
        {

        }

        public string buscarlocalidadXCodPostal(int codPostal)
        {

        }
    }
}
