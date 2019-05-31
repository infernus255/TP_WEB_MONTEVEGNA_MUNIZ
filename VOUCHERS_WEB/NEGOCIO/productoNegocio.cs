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
    public class productoNegocio
    {
        public List<producto> listarPremiosXVoucher(string id)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<producto> ListProductos=new List<producto>();


            try
            {

                accesoDatos.setearSP("SP_LISTAR_PROD_WIN_X_VOUCHER");//SETEO EL SP

                SqlParameter[] VectorParam = new SqlParameter[1]; //no funciona con lista, aqui se debe agregar la cantidad de parametros totales

                accesoDatos.agregarParametroSP(VectorParam, 0, "@ID_VOUCHER", System.Data.SqlDbType.VarChar, id); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION              

                accesoDatos.Comando.Parameters.AddRange(VectorParam);//AGREGO LA MATRIZ DE PARAMETROS A LOS PARAMETROS DEL COMANDO

                accesoDatos.abrirConexion(); // abro conexion   
                accesoDatos.ejecutarConsulta();//EJECUTO EL SP

                while (accesoDatos.Lector.Read())
                {
                    producto producto = new producto();
                    producto.Id =accesoDatos.Lector.GetInt32(0);
                    producto.Nombre =accesoDatos.Lector.GetString(1);
                    //producto.Url =accesoDatos.Lector.GetString(2);

                    ListProductos.Add(producto);
                }

                return ListProductos;

                }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();//CIERRO CONEXION
            }
        }

    }
}
