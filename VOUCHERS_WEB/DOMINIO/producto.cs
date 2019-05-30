using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class producto
    {
        private int id;
        private string nombre;
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }



        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


    }
}
