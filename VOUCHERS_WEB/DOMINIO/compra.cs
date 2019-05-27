using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class compra
    {
        private int id;
        private voucher voucher;
        private producto producto;
        private DateTime fecha;


        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        public producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }


        public voucher Voucher
        {
            get { return voucher; }
            set { voucher = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }



    }
}
