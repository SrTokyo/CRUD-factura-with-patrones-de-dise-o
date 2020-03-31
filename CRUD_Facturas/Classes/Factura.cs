using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Facturas.Classes.Factories;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace CRUD_Facturas.Classes
{
    [Serializable()]
    public class Factura : ISerializable
    {
        public static ArrayList ids = new ArrayList();
        public int nroFactura;
        public String fecha_factura;
        public Client cliente;
        public double total_factura;
        public String estado;
        public Item[] items;
        public Factura() { }
        
        public Factura(int nroFactura, String fecha_factura,Client cliente, String estado,Item[] items)
        {
            if (!(ids.Contains(nroFactura)))
            {
                ids.Add(nroFactura);
                this.nroFactura = nroFactura;
                this.fecha_factura = fecha_factura;
                this.cliente = cliente;
                this.estado = estado;
                this.items = items;
                total_factura = generateTotal();
            }
            

        }

        public string Estado { get => estado; set => estado = value; }
        public double Total_factura { get => total_factura; }
        public string Fecha_factura { get => fecha_factura; set => fecha_factura = value; }
        public int NroFactura { get => nroFactura; set => nroFactura = value; }
        public Item[] getItems()
        {
            return items;
        }
        public void setItems(Item[] items)
        {
            this.items = items;
            generateTotal();
        }
        internal Client Cliente { get => cliente; set => cliente = value; }
        internal Item[] Items { get => items; set => items = value; }

        private double generateTotal()
        {
            double total = 0;
            foreach (Item item in items)
            {
                total = total + item.Valor;
            }
            return total;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("nroFactura", nroFactura);
            info.AddValue("ids", ids);
            info.AddValue("fecha_factura", fecha_factura);
            info.AddValue("estado", estado);
            info.AddValue("total_factura", total_factura);
            info.AddValue("cliente", cliente);
            info.AddValue("items", items);
        }
        public Factura(SerializationInfo info, StreamingContext context)
        {
            nroFactura = (int)info.GetValue("nroFactura", typeof(int));
            ids = (ArrayList)info.GetValue("ids", typeof(ArrayList));
            fecha_factura = (String)info.GetValue("fecha_factura", typeof(String));
            estado = (String)info.GetValue("estado", typeof(String));
            total_factura = (double)info.GetValue("total_factura", typeof(double));
            cliente = (Client)info.GetValue("cliente", typeof(Client));
            items = (Item[])info.GetValue("items", typeof(Item[]));

        }
    }
}
