using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Facturas.Classes.Factories;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CRUD_Facturas.Classes
{
    [Serializable()]
    public class Init : ISerializable
    {
        public int facturasCount = 0;
        public int clientCount = 0;
        public int itemCount = 0;
        public int tipoItemCount = 0;
        static Factory theFactory = new Factory();
        static Dictionary<int, Factura> mapF = new Dictionary<int, Factura>();
        static Dictionary<int, Client> mapC = new Dictionary<int, Client>();
        static Dictionary<int, Item> mapI = new Dictionary<int, Item>();
        static Dictionary<int, TipoItem> mapT = new Dictionary<int, TipoItem>();
        static Calendario cal = Calendario.Instance;
        


        private static Init instance = null;
        protected Init() { }
        public Init(SerializationInfo info, StreamingContext context) {
            facturasCount = (int)info.GetValue("FacturasCount", typeof(int));
            clientCount = (int)info.GetValue("ClientCount", typeof(int));
            itemCount = (int)info.GetValue("ItemCount", typeof(int));
            tipoItemCount = (int)info.GetValue("TipoItemCount", typeof(int));

            mapC = (Dictionary<int, Client>)info.GetValue("mapC", typeof(Dictionary<int, Client>));
            mapT = (Dictionary<int, TipoItem>)info.GetValue("mapT", typeof(Dictionary<int, TipoItem>));
            mapI = (Dictionary<int, Item>)info.GetValue("mapI", typeof(Dictionary<int, Item>));
            mapF = (Dictionary<int, Factura>)info.GetValue("mapF", typeof(Dictionary<int, Factura>));
            
        }

        public static Init Instance()
        {


            if (instance == null)
            {
                instance = new Init();
                
            }


            return instance;

        }
        public static Init Instance(Init newOne)
        {

            instance = newOne;
            
            return instance;

        }
        public static Init Instance(SerializationInfo info, StreamingContext context)
        {
            if (instance == null)
            {
                instance = new Init(info,context);
            }
            

            return instance;

        }
        private static void initClients()
        {
            cal.ran_dom();
            mapC.Add(0, theFactory.creaCliente(0, "Rowaldo", "Perez Perez", 'M', cal.getFecha(), "Soltero"));
            cal.ran_dom();
            mapC.Add(1, theFactory.creaCliente(1, "Maria", "Blesson Hawk", 'F', cal.getFecha(), "Viuda"));
            cal.ran_dom();
            mapC.Add(2, theFactory.creaCliente(2, "Antony", "Washington Apple", 'M', cal.getFecha(), "Casado"));
        }
       
        
        

        internal Dictionary<int, Client> MapC { get => mapC; set => mapC = value; }
        internal Dictionary<int, Item> MapI { get => mapI; set => mapI = value; }
        internal Dictionary<int, TipoItem> MapT { get => mapT; set => mapT = value; }
        internal Dictionary<int, Factura> MapF { get => mapF; set => mapF = value; }
        internal Factory TheFactory { get => theFactory; set => theFactory = value; }
        internal Calendario Cal { get => cal; set => cal = value; }
        public int FacturasCount { get => facturasCount; set => facturasCount = value; }
        public static Init Instance1 { get => instance; set => instance = value; }

        public void setFacturasCount (int newV)
        {
            facturasCount = newV;
        }

        

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FacturasCount", facturasCount);
            info.AddValue("ClientCount", clientCount);
            info.AddValue("ItemCount", itemCount);
            info.AddValue("TipoItemCount", tipoItemCount);
            info.AddValue("mapC", mapC);
            info.AddValue("mapT", mapT);
            info.AddValue("mapI", mapI);
            info.AddValue("mapF", mapF);
        }
    }
}
