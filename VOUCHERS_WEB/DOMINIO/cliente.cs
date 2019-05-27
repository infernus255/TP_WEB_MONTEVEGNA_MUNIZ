using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class cliente
    {
        private int id;
        private List<compra> listaCompras;
        private string nombre;
        private string apellido;
        private int dni;
        private string email;
        private int nroCalle;
        private string calle;
        private string ciudad;

        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
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


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


    }
}
