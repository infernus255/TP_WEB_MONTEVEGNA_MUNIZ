using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class cliente
    {
        
        private List<compra> listaCompras;
        private string nombre;
        private string apellido;
        private int dni;
        private string email;
        private int nroCalle;
        private string calle;
        private string localidad;
        private int telefono;

        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }


        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }


        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }


        public int NroCalle
        {
            get { return nroCalle; }
            set { nroCalle = value; }
        }


        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }


        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public List<compra> ListaCompras
        {
            get { return listaCompras; }
            set { listaCompras = value; }
        }


        public cliente()
        {

        }

        public cliente(int dni, string nombre, string apellido, int nroCalle, string calle, string localidad,int telefono, string email)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            NroCalle = nroCalle;
            Calle = calle;
            Localidad = localidad;
            Telefono = telefono;
            Email = email;
        }

    }
}
