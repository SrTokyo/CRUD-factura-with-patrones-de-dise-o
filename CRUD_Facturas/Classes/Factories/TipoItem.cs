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
    public class TipoItem : ISerializable
    {
        public static ArrayList allIDs = new ArrayList();
        public int id;
        public String description;
        public TipoItem() { }


        public TipoItem( int id, String description)
        {
            if (!(allIDs.Contains(id)))
            {
                allIDs.Add(id);
                this.id = id;
                this.description = description;

            }
            
        }

        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", id);
            info.AddValue("allIDs", allIDs);
            info.AddValue("description", description);
            
        }
        public TipoItem(SerializationInfo info, StreamingContext context)
        {
            id = (int)info.GetValue("id", typeof(int));
            allIDs = (ArrayList)info.GetValue("allIDs", typeof(ArrayList));
            description = (String)info.GetValue("description", typeof(String));
            

        }
    }
}
