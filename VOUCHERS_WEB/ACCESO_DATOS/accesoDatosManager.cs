using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ACCESO_DATOS
{
    public class AccesoDatosManager
    {
        //public static string cadenaConexion = "data source=(local); initial catalog=VOUCHERS_WEB_DB; integrated security=sspi";
        public static string cadenaConexion = "server=DESKTOP-D4I30IF\\SQLEXPRESS; database=VOUCHERS_WEB_DB; integrated security=true";
        private SqlCommand comando;
        private SqlConnection conexion;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public SqlCommand Comando
        {
            get { return comando; }
        }

        public AccesoDatosManager()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        //setear consulta embebida
        public void setearConsulta(string consulta)
        {
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        //setear store procedure
        public void setearSP(string sp)
        {
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        //setear parametros del store procedure, dando un vector de parametros, el nombre del paramtro, su tipo de dato en la base de datos y el valor que contiene
        public void agregarParametroSP(SqlParameter[] vectorParam, int pos, string parametro, System.Data.SqlDbType dbType, object valor)
        {

            vectorParam[pos] = new SqlParameter(parametro, dbType);
            vectorParam[pos].Value = valor;
        }

        public void abrirConexion()
        {
            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            try
            {
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            try
            {
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ejecutarAccionReturn()
        {
            try
            {
                comando.Connection = conexion;
                return (int)comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ejecutarConsulta()
        {
            try
            {
                comando.Connection = conexion;
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
