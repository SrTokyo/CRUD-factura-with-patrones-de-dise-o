using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Facturas
{
    class Calendario
    {
        int dia;
        int mes;
        int ano;
        private static Calendario instance = null;
        protected Calendario() { }

       public static Calendario Instance
        {
            get
            {
                if (instance == null)
                    instance = new Calendario();

                return instance;
            }
        }

        public int Dia { get => dia; set => dia = value; }
        public int Mes { get => mes; set => mes = value; }
        public int Ano { get => ano; set => ano = value; }

        public String getFecha()
        {
            return dia + " / " + mes + " / " + ano;
        }
        public void ran_dom() {
            var seed = Environment.TickCount;
            var random = new Random(seed);

            dia = random.Next(1, 30);
            mes = random.Next(1, 12);
            ano = random.Next(1960, 2005);
        }
    }
}
