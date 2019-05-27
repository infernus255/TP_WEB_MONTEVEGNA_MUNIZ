using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class sorteo
    {
        private int id;
        private List<premio> listaPremios;
        private DateTime fechaIni;
        private DateTime fechaFin;
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }


        public DateTime FechaIni
        {
            get { return fechaIni; }
            set { fechaIni = value; }
        }


        public List<premio> ListaPremios
        {
            get { return listaPremios; }
            set { listaPremios = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }



    }
}
