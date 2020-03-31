using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Facturas.Classes.Factories
{
    class Factory : FactoryInterF
    {
        public Factory (){}

        public Client  creaCliente(int id, String nombre, String apellidos, Char genero, String fecha_nacimiento, String estado_civil)
        {
            return new Client(id, nombre, apellidos, genero, fecha_nacimiento, estado_civil);
        }
        public Item creaItem(TipoItem tipo, int id, String description, double valor)
        {
            return new Item(tipo,id, description,  valor);
        }
        public TipoItem creaTipoItem( int id, String description)
        {
            return new TipoItem( id, description);
        }
    }
}
