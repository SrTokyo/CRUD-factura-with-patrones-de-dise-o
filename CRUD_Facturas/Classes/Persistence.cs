using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using CRUD_Facturas.Classes.Factories;
using CRUD_Facturas.Classes;

namespace CRUD_Facturas.Classes
{
    class Persistence
    {
        String directory = @"C:\";
        Init memoria = Init.Instance();
        private static Persistence instance = null;
        protected Persistence() { }

        public static Persistence Instance
        {
            get
            {
                if (instance == null)
                    instance = new Persistence();

                return instance;
            }
        }
        //public void loadANDsave()
        //{
        //    Stream stream = File.Open("persistence.dat", FileMode.Create);
        //    BinaryFormatter bf = new BinaryFormatter();
        //    bf.Serialize(stream, memoria);
        //    stream.Close();
        //    memoria = null;
        //    Stream strm = File.Open("persistence.dat", FileMode.Open);
        //    bf = new BinaryFormatter();
        //    memoria = (Init)bf.Deserialize(strm);
        //    strm.Close();
        //}
        public Init loadMemoria()
        {
            //Init
            if (File.Exists(directory + "Init.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Init));
                TextReader reader = new StreamReader(directory + "Init.xml");
                object obj = deserializer.Deserialize(reader);
                memoria= Init.Instance( (Init)obj);
                reader.Close();
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Init));
                using (TextWriter tw = new StreamWriter(directory + "Init.xml"))
                {
                    serializer.Serialize(tw, memoria);
                }

            }
            //mapC
            if (File.Exists(directory + "mapC.xml"))
            {
                Client[] auxC = null;
                XmlSerializer deserializer = new XmlSerializer(typeof(Client[]));
                TextReader reader = new StreamReader(directory + "mapC.xml");
                object obj = deserializer.Deserialize(reader);
                auxC = (Client[])obj;
                memoria.MapC = buildMapC(auxC);
                reader.Close();
            }
            else
            {
                Client[] auxClients = new Client[memoria.MapC.Count];
                for (int i = 0; i < memoria.MapC.Count; i++)
                {
                    auxClients[i] = memoria.MapC[i];
                }
                XmlSerializer serializerC = new XmlSerializer(typeof(Client[]));
                using (TextWriter tw = new StreamWriter(directory + "mapC.xml"))
                {
                    serializerC.Serialize(tw, auxClients);
                }

            }
            //mapT
            if (File.Exists(directory + "mapT.xml"))
            {
                TipoItem[] auxT = null;
                XmlSerializer deserializer = new XmlSerializer(typeof(TipoItem[]));
                TextReader reader = new StreamReader(directory + "mapT.xml");
                object obj = deserializer.Deserialize(reader);
                auxT = (TipoItem[])obj;
                memoria.MapT =buildMapT(auxT);
                reader.Close();
            }
            else
            {
                TipoItem[] auxTipo = new TipoItem[memoria.MapT.Count];
                for (int i = 0; i < memoria.MapT.Count; i++)
                {
                    auxTipo[i] = memoria.MapT[i];
                }
                XmlSerializer serializerT = new XmlSerializer(typeof(TipoItem[]));
                using (TextWriter tw = new StreamWriter(directory + "mapT.xml"))
                {
                    serializerT.Serialize(tw, auxTipo);
                }

            }
            //mapI
            if (File.Exists(directory + "mapI.xml"))
            {
                Item[] auxI = null;
                XmlSerializer deserializer = new XmlSerializer(typeof(Item[]));
                TextReader reader = new StreamReader(directory + "mapI.xml");
                object obj = deserializer.Deserialize(reader);
                auxI = (Item[])obj;
                memoria.MapI = buildMapI(auxI);
                reader.Close();
            }
            else
            {
                Item[] auxItem = new Item[memoria.MapI.Count];
                for (int i = 0; i < memoria.MapI.Count; i++)
                {
                    auxItem[i] = memoria.MapI[i];
                }
                XmlSerializer serializerI = new XmlSerializer(typeof(Item[]));
                using (TextWriter tw = new StreamWriter(directory + "mapI.xml"))
                {
                    serializerI.Serialize(tw, auxItem);
                }

            }
            //mapF
            if (File.Exists(directory + "mapF.xml"))
            {
                Factura[] auxF = null;
                XmlSerializer deserializer = new XmlSerializer(typeof(Factura[]));
                TextReader reader = new StreamReader(directory + "mapF.xml");
                object obj = deserializer.Deserialize(reader);
                 auxF = (Factura[])obj;
                reader.Close();
                memoria.MapF = buildMapF(auxF);
            }
            else
            {
                Factura[] auxFactura = new Factura[memoria.MapF.Count];
                for (int i = 0; i < memoria.MapF.Count; i++)
                {
                    auxFactura[i] = memoria.MapF[i];
                }
                XmlSerializer serializerF = new XmlSerializer(typeof(Factura[]));
                using (TextWriter tw = new StreamWriter(directory + "mapF.xml"))
                {
                    serializerF.Serialize(tw, auxFactura);
                }

            }
            return memoria;
        }
        public void saveMemoria()
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Init));
            using (TextWriter tw = new StreamWriter(directory + "Init.xml"))
            {
                serializer.Serialize(tw, memoria);
            }



            //mapC
            Client[] auxClients = new Client[memoria.MapC.Count];
            for (int i = 0; i < memoria.MapC.Count; i++)
            {
                auxClients[i] = memoria.MapC[i];
            }
            XmlSerializer serializerC = new XmlSerializer(typeof(Client[]));
            using (TextWriter tw = new StreamWriter(directory + "mapC.xml"))
            {
                serializerC.Serialize(tw, auxClients);
            }


            //mapT
            TipoItem[] auxTipo = new TipoItem[memoria.MapT.Count];
            for (int i = 0; i < memoria.MapT.Count; i++)
            {
                auxTipo[i] = memoria.MapT[i];
            }
            XmlSerializer serializerT = new XmlSerializer(typeof(TipoItem[]));
            using (TextWriter tw = new StreamWriter(directory + "mapT.xml"))
            {
                serializerT.Serialize(tw, auxTipo);
            }


            //mapI
            Item[] auxItem = new Item[memoria.MapI.Count];
            for (int i = 0; i < memoria.MapI.Count; i++)
            {
                auxItem[i] = memoria.MapI[i];
            }
            XmlSerializer serializerI = new XmlSerializer(typeof(Item[]));
            using (TextWriter tw = new StreamWriter(directory + "mapI.xml"))
            {
                serializerI.Serialize(tw, auxItem);
            }


            //mapF
            Factura[] auxFactura = new Factura[memoria.MapF.Count];
            for (int i = 0; i < memoria.MapF.Count; i++)
            {
                auxFactura[i] = memoria.MapF[i];
            }
            XmlSerializer serializerF = new XmlSerializer(typeof(Factura[]));
            using (TextWriter tw = new StreamWriter(directory + "mapF.xml"))
            {
                serializerF.Serialize(tw, auxFactura);
            }
            



        }
        public Dictionary<int, Client> buildMapC(Client[] toMap)
        {
            Dictionary<int, Client> map = new Dictionary<int, Client>();
            for (int i = 0; i < toMap.Length; i++)
            {
                map.Add(i, toMap[i]);
            }
            return map;
        }
        public Dictionary<int,TipoItem> buildMapT(TipoItem[] toMap)
        {
            Dictionary<int, TipoItem> map = new Dictionary<int, TipoItem>();
            for (int i = 0; i < toMap.Length; i++)
            {
                map.Add(i, toMap[i]);
            }
            return map;
        }
        public Dictionary<int, Item> buildMapI(Item[] toMap)
        {
            Dictionary<int, Item> map = new Dictionary<int, Item>();
            for (int i = 0; i < toMap.Length; i++)
            {
                map.Add(i, toMap[i]);
            }
            return map;
        }
        public Dictionary<int, Factura> buildMapF(Factura[] toMap)
        {
            Dictionary<int,Factura> map = new Dictionary<int, Factura>();
            for (int i = 0; i < toMap.Length; i++)
            {
                map.Add(i, toMap[i]);
            }
            return map;
        }
        /*
          if (File.Exists(@"C:\Init.xml")){
                XmlSerializer deserializer = new XmlSerializer(typeof(Init));
                TextReader reader = new StreamReader(@"C:\Init.xml");
                object obj = deserializer.Deserialize(reader);
                 memoria = (Init)obj;
                reader.Close();
            }
            else {
                XmlSerializer serializer = new XmlSerializer(typeof(Init));
                using (TextWriter tw = new StreamWriter(@"C:\Init.xml"))
                {
                    serializer.Serialize(tw, memoria);
                }

            } 
            */
    }
}
