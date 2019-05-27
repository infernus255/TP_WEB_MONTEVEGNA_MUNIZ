using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class noCliente
    {
        private int id;
        private compra compra;


        public compra Compra
        {
            get { return compra; }
            set { compra = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


    }
}
