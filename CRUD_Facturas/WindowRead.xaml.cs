using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CRUD_Facturas.Classes;
using CRUD_Facturas.Classes.Factories;

namespace CRUD_Facturas
{
    /// <summary>
    /// Lógica de interacción para WindowRead.xaml
    /// </summary>
    public partial class WindowRead : Window
    {
        int id_factura;
        Factura facturaza;
        Client Clientaso;
        
        Item[] items;
        Init memoria = Init.Instance();
        public WindowRead(int id)
        {
            id_factura = id;
            
            facturaza = memoria.MapF[id_factura];
            Clientaso = facturaza.Cliente;
            items = facturaza.Items;
            
            
            InitializeComponent();
            initListClient();
            initListFactura();
            initListItems();
        }
        public void initListClient()
        {
            
            ListaC.Items.Add(" _ID_         : \n" + Clientaso.Id);
            ListaC.Items.Add(" Nombre       : \n" + Clientaso.Nombre);
            ListaC.Items.Add(" Apellidos    : \n" + Clientaso.Apellidos);
            ListaC.Items.Add(" Genero       : \n" + Clientaso.Genero);
            ListaC.Items.Add(" Nacimiento   : \n" + Clientaso.Fecha_nacimiento);
            ListaC.Items.Add(" Estado civil : \n" + Clientaso.Estado_civil);
           
        }
        public void initListFactura()
        {

            ListaF.Items.Add(" Numero de factura    : \n" + facturaza.NroFactura);
            ListaF.Items.Add(" Fecha de facturacion : \n" + facturaza.Fecha_factura);
            ListaF.Items.Add(" Estado               : \n" + facturaza.Estado);
            ListaF.Items.Add(" Total facturado      : \n" + facturaza.Total_factura);
            

        }
        public void initListItems()
        {
            foreach (Item i in items)
            {
                ListaI.Items.Add(i.Description + "    " + i.Valor);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
