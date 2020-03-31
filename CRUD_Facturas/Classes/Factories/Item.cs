using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace CRUD_Facturas.Classes.Factories
{
    [Serializable()]
    public class Item : ISerializable
    {
        public static ArrayList allIDs = new ArrayList();
        public int id;
        public TipoItem tipo;
        public String description;
        public double valor;

        public Item(){ }
        public Item(TipoItem tipo, int id, String description, double valor)
        {
            if (!(allIDs.Contains(id)))
            {
                allIDs.Add(id);
                this.id = id;
                this.tipo = tipo;
                this.description = description;
                this.valor = valor;
                
            }
            
        }

        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public double Valor { get => valor; set => valor = value; }
        internal TipoItem Tipo { get => tipo; set => tipo = value; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", id);
            info.AddValue("allIDs", allIDs);
            info.AddValue("tipo", tipo);
            info.AddValue("description", description);
            info.AddValue("valor", valor);
           
        }
        public Item(SerializationInfo info, StreamingContext context)
        {
            id = (int)info.GetValue("id", typeof(int));
            allIDs = (ArrayList)info.GetValue("allIDs", typeof(ArrayList));
            tipo = (TipoItem)info.GetValue("tipo", typeof(TipoItem));
            description = (String)info.GetValue("description", typeof(String));
            valor = (double)info.GetValue("valor", typeof(double));
            

        }
    }
}
