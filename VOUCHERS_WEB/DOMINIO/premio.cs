using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class premio
    {
        private int id;
        private voucher voucher;
        private producto producto;
        private bool activo;

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }


        public producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }



        public int Id { get => id; set => id = value; }
        public voucher Voucher { get => voucher; set => voucher = value; }
    }
}
