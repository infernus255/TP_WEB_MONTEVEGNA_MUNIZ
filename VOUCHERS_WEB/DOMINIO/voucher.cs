using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class voucher
    {
        private string id;
        private DateTime fecha;
        private bool activo;

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }


        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        public string Id { get => id; set => id = value; }
    }
}
