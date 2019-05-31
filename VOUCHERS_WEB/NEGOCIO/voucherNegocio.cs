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
    public class voucherNegocio
    {
        //BUSCA EL VOUCHER EN LA DB, SI NO ES VALIDO DEVUELVE UN ID="INVALIDO"
        //si el id es igual al de db, esta activo,fue comprado, no fue utilizado antes y esta en el sorteo actual, EN RESUMEN, VERIFICA SI ES VALIDO 
        //PERO NO SI TIENE PREMIO
        public voucher buscarXID(string id)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            voucher voucher=new voucher("INVALIDO",DateTime.Now,false,0,0);

            try
            {

                accesoDatos.setearSP("SP_BUSCAR_VOUCHER_X_ID");//SETEO EL SP

                SqlParameter[] VectorParam = new SqlParameter[1]; //no funciona con lista, aqui se debe agregar la cantidad de parametros totales

                accesoDatos.agregarParametroSP(VectorParam, 0, "@ID_VOUCHER", System.Data.SqlDbType.VarChar, id); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION


                accesoDatos.Comando.Parameters.AddRange(VectorParam);//AGREGO LA MATRIZ DE PARAMETROS A LOS PARAMETROS DEL COMANDO

                accesoDatos.abrirConexion(); // abro conexion   
                accesoDatos.ejecutarConsulta();//EJECUTO EL SP

                while (accesoDatos.Lector.Read())
                {
                    voucher voucherNew = new voucher(accesoDatos.Lector.GetString(0), accesoDatos.Lector.GetDateTime(1), accesoDatos.Lector.GetBoolean(2), accesoDatos.Lector.GetInt32(3),0);
                    voucher = voucherNew;
                }

                if (voucher.Id == id && voucher.Activo==true)
                {
                    return voucher;
                }
                else
                {
                    voucher.Id = "INVALIDO";
                    return voucher;
                }

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


        //VERIFICA SI EL VOUCHER EXISTE EN LA DB CON CIERTAS CONDICIONES
        //si el id es igual al de db, esta activo,fue comprado, no fue utilizado antes y esta en el sorteo actual Y TIENE PREMIOS
        public bool isWin(string id)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            voucher voucher = this.buscarXID(id);
            bool result = false;

            try
            {

                //si lo encuentra revisa si tiene premios
                if (voucher.Id==id)
                {

                    accesoDatos.setearSP("SP_IS_WIN");//SETEO EL SP

                    SqlParameter[] VectorParam = new SqlParameter[1]; //no funciona con lista, aqui se debe agregar la cantidad de parametros totales

                    accesoDatos.agregarParametroSP(VectorParam, 0, "@ID_VOUCHER", System.Data.SqlDbType.VarChar, voucher.Id); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION


                    accesoDatos.Comando.Parameters.AddRange(VectorParam);//AGREGO LA MATRIZ DE PARAMETROS A LOS PARAMETROS DEL COMANDO

                    accesoDatos.abrirConexion(); // abro conexion   
                    accesoDatos.ejecutarConsulta();//EJECUTO EL SP

                    while (accesoDatos.Lector.Read())
                    {
                        result = accesoDatos.Lector.GetBoolean(0);                        
                    }

                }

                return result;

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

        //INSERTA EL ID DEL PRODUCTO SELECCIONADO EN EL VOUCHER GANADOR USADO Y DA DE BAJA EL VOUCHER
        public void bajaVoucher(string idVoucher, int idProd)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();

            try
            {

                accesoDatos.setearSP("SP_BAJA_VOUCHER");//SETEO EL SP

                SqlParameter[] VectorParam = new SqlParameter[2]; //no funciona con lista, aqui se debe agregar la cantidad de parametros totales

                accesoDatos.agregarParametroSP(VectorParam, 0, "@ID_VOUCHER", System.Data.SqlDbType.VarChar, idVoucher); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                accesoDatos.agregarParametroSP(VectorParam, 1, "@ID_PROD", System.Data.SqlDbType.Int, idProd); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION


                accesoDatos.Comando.Parameters.AddRange(VectorParam);//AGREGO LA MATRIZ DE PARAMETROS A LOS PARAMETROS DEL COMANDO

                accesoDatos.abrirConexion(); // abro conexion   
                accesoDatos.ejecutarConsulta();//EJECUTO EL SP
                
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
