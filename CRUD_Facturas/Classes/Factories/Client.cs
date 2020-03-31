using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace CRUD_Facturas.Classes.Factories
{
    [Serializable()]
    public class Client : ISerializable
    {
        public static ArrayList allIDs = new ArrayList();
        public int id;
        public String nombre;
        public String apellidos;
        public Char genero;
        public String fecha_nacimiento;
        public String estado_civil; 
    
        public Client(int id, String nombre, String apellidos, Char genero, String fecha_nacimiento, String estado_civil)
        {
            if (!(allIDs.Contains(id)))
            {
                allIDs.Add(id);
                this.id = id;
                this.nombre = nombre;
                this.apellidos = apellidos;
                this.genero = genero;
                this.fecha_nacimiento = fecha_nacimiento;
                this.estado_civil = estado_civil;
            }
            
        }


       
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public char Genero { get => genero; set => genero = value; }
        public string Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public string Estado_civil { get => estado_civil; set => estado_civil = value; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", id);
            info.AddValue("allIDs", allIDs);
            info.AddValue("nombre", nombre);
            info.AddValue("apellidos", apellidos);
            info.AddValue("genero", genero);
            info.AddValue("fecha_nacimiento", fecha_nacimiento);
            info.AddValue("estado_civil", estado_civil);
        }

        public Client() { }

        public Client(SerializationInfo info, StreamingContext context)
        {
            id = (int)info.GetValue("id", typeof(int));
            allIDs = (ArrayList)info.GetValue("allIDs", typeof(ArrayList));
            nombre = (String)info.GetValue("nombre", typeof(String));
            apellidos = (String)info.GetValue("apellidos", typeof(String));
            genero = (char)info.GetValue("genero", typeof(char));
            fecha_nacimiento = (String)info.GetValue("fecha_nacimiento", typeof(String));
            estado_civil = (String)info.GetValue("estado_civil", typeof(String));

        }
    }
}
