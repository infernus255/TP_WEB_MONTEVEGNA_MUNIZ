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

        public void cargarCliente(int dni,string nombre, string apellido,int nroCalle,string calle,int idLocalidad,int telefono,string email)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            clienteNegocio clienteNegocio = new clienteNegocio();

            try
            {

                

                accesoDatos.setearSP("SP_CARGAR_CLIENTE");//SETEO EL SP

                SqlParameter[] VectorParam = new SqlParameter[8]; //no funciona con lista, aqui se debe agregar la cantidad de parametros totales

                accesoDatos.agregarParametroSP(VectorParam, 0, "@DNI", System.Data.SqlDbType.Int, dni); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                accesoDatos.agregarParametroSP(VectorParam, 1, "@NOMBRE", System.Data.SqlDbType.VarChar, nombre); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                accesoDatos.agregarParametroSP(VectorParam, 2, "@APELLIDO", System.Data.SqlDbType.VarChar, apellido); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                accesoDatos.agregarParametroSP(VectorParam, 3, "@NROCALLE", System.Data.SqlDbType.SmallInt, nroCalle); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                accesoDatos.agregarParametroSP(VectorParam, 4, "@CALLE", System.Data.SqlDbType.VarChar, calle); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                accesoDatos.agregarParametroSP(VectorParam, 5, "@IDLOCALIDAD", System.Data.SqlDbType.Int, idLocalidad); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                accesoDatos.agregarParametroSP(VectorParam, 6, "@TELEFONO", System.Data.SqlDbType.Int, telefono); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                accesoDatos.agregarParametroSP(VectorParam, 7, "@EMAIL", System.Data.SqlDbType.VarChar, email); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                
                

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

        public bool verificarCliente(int dni)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();

            try
            {

                accesoDatos.setearSP("SP_VERIFICAR_CLIENTE");//SETEO EL SP

                SqlParameter[] VectorParam = new SqlParameter[1]; //no funciona con lista, aqui se debe agregar la cantidad de parametros totales

                accesoDatos.agregarParametroSP(VectorParam, 0, "@DNI", System.Data.SqlDbType.Int, dni); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION



                accesoDatos.Comando.Parameters.AddRange(VectorParam);//AGREGO LA MATRIZ DE PARAMETROS A LOS PARAMETROS DEL COMANDO

                accesoDatos.abrirConexion(); // abro conexion   
                accesoDatos.ejecutarConsulta();//EJECUTO EL SP

                bool validar = false; 

                while(accesoDatos.Lector.Read())
                {

                    validar = accesoDatos.Lector.GetBoolean(0);

                }

                return validar;                                                 

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

        public cliente buscarXDni(int dni)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            cliente c = new cliente();

            try
            {

                accesoDatos.setearSP("SP_BUSCAR_CLIENTE_X_DNI");//SETEO EL SP

                SqlParameter[] VectorParam = new SqlParameter[1]; //no funciona con lista, aqui se debe agregar la cantidad de parametros totales

                accesoDatos.agregarParametroSP(VectorParam, 0, "@DNI", System.Data.SqlDbType.Int, dni); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION               


                accesoDatos.Comando.Parameters.AddRange(VectorParam);//AGREGO LA MATRIZ DE PARAMETROS A LOS PARAMETROS DEL COMANDO

                accesoDatos.abrirConexion(); // abro conexion   
                accesoDatos.ejecutarConsulta();//EJECUTO EL SP


                while (accesoDatos.Lector.Read())
                {
                    string localidad=buscarLocalidadXId(accesoDatos.Lector.GetInt32(5));
                    c = new cliente(accesoDatos.Lector.GetInt32(0),accesoDatos.Lector.GetString(1),accesoDatos.Lector.GetString(2),accesoDatos.Lector.GetInt16(3),accesoDatos.Lector.GetString(4),localidad,accesoDatos.Lector.GetInt32(6),accesoDatos.Lector.GetString(7));

                }

                return c;

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

        public void modificarCliente(int dni, string nombre, string apellido, int nroCalle, string calle, int idLocalidad, int telefono, string email)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();

            try
            {

                accesoDatos.setearSP("SP_MODIFICAR_CLIENTE");//SETEO EL SP

                SqlParameter[] VectorParam = new SqlParameter[8]; //no funciona con lista, aqui se debe agregar la cantidad de parametros totales

                accesoDatos.agregarParametroSP(VectorParam, 0, "@DNI", System.Data.SqlDbType.Int, dni); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                accesoDatos.agregarParametroSP(VectorParam, 1, "@NOMBRE", System.Data.SqlDbType.VarChar, nombre); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                accesoDatos.agregarParametroSP(VectorParam, 2, "@APELLIDO", System.Data.SqlDbType.VarChar, apellido); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                accesoDatos.agregarParametroSP(VectorParam, 3, "@NROCALLE", System.Data.SqlDbType.SmallInt, nroCalle); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                accesoDatos.agregarParametroSP(VectorParam, 4, "@CALLE", System.Data.SqlDbType.VarChar, calle); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                accesoDatos.agregarParametroSP(VectorParam, 5, "@IDLOCALIDAD", System.Data.SqlDbType.Int, idLocalidad); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                accesoDatos.agregarParametroSP(VectorParam, 6, "@TELEFONO", System.Data.SqlDbType.Int, telefono); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION
                accesoDatos.agregarParametroSP(VectorParam, 7, "@EMAIL", System.Data.SqlDbType.VarChar, email); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION



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

        public string buscarLocalidadXId(int idLocalidad)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            string result = "NO EXISTE O FALLO";

            try
            {

                accesoDatos.setearSP("SP_BUSCAR_LOC_X_ID");//SETEO EL SP

                SqlParameter[] VectorParam = new SqlParameter[1]; //no funciona con lista, aqui se debe agregar la cantidad de parametros totales

                accesoDatos.agregarParametroSP(VectorParam, 0, "@ID", System.Data.SqlDbType.Int, idLocalidad); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION               


                accesoDatos.Comando.Parameters.AddRange(VectorParam);//AGREGO LA MATRIZ DE PARAMETROS A LOS PARAMETROS DEL COMANDO

                accesoDatos.abrirConexion(); // abro conexion   
                accesoDatos.ejecutarConsulta();//EJECUTO EL SP


                while (accesoDatos.Lector.Read())
                {
                    result = accesoDatos.Lector.GetString(0);                    
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


        //BUSCAR EL ID DE LA LOCALIDAD, si no encuentra devuelve -1
        public int buscarIdXLocalidad(string Localidad)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            int result =-1;

            try
            {

                accesoDatos.setearSP("SP_BUSCAR_ID_X_LOC");//SETEO EL SP

                SqlParameter[] VectorParam = new SqlParameter[1]; //no funciona con lista, aqui se debe agregar la cantidad de parametros totales

                accesoDatos.agregarParametroSP(VectorParam, 0, "@LOCALIDAD", System.Data.SqlDbType.VarChar, Localidad); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION               


                accesoDatos.Comando.Parameters.AddRange(VectorParam);//AGREGO LA MATRIZ DE PARAMETROS A LOS PARAMETROS DEL COMANDO

                accesoDatos.abrirConexion(); // abro conexion   
                accesoDatos.ejecutarConsulta();//EJECUTO EL SP


                while (accesoDatos.Lector.Read())
                {
                    result = accesoDatos.Lector.GetInt32(0);
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

        public void cargarLocalidad(string localidad)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();

            try
            {              
                accesoDatos.setearSP("SP_AGREGAR_LOCALIDAD");//SETEO EL SP

                SqlParameter[] VectorParam = new SqlParameter[1]; //no funciona con lista, aqui se debe agregar la cantidad de parametros totales

                accesoDatos.agregarParametroSP(VectorParam, 0, "@LOCALIDAD", System.Data.SqlDbType.VarChar, localidad); // AGREGO UN PARAMETRO AL VECTOR EN ESA POSICION               


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
                accesoDatos.cerrarConexion();
            }
        }
    }
}
