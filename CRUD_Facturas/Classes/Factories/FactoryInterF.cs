using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Facturas.Classes.Factories
{
    interface FactoryInterF
    {
        Client creaCliente(int id, String nombre, String apellidos, Char genero, String fecha_nacimiento, String estado_civil);
        Item creaItem(TipoItem tipo, int id, String description, double valor);
        TipoItem creaTipoItem(int id, String description);
    }
}
