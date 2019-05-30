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
        private int idSorteo;
        private int idProdSelec;

        public int IdProdSelec
        {
            get { return idProdSelec; }
            set { idProdSelec = value; }
        }


        public int IdSorteo
        {
            get { return idSorteo; }
            set { idSorteo = value; }
        }


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

        public voucher(string id,DateTime fecha,bool activo,int idSorteo,int idProdSelec)
        {
            Id = id;
            Fecha = fecha;
            Activo = activo;
            IdSorteo = idSorteo;
            IdProdSelec = idProdSelec;
        }
    }
}
