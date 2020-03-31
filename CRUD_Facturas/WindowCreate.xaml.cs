using System;
using System.Collections;
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
using CRUD_Facturas;
using CRUD_Facturas.Classes.Factories;
using CRUD_Facturas.Classes;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace CRUD_Facturas
{
    /// <summary>
    /// Lógica de interacción para WindowCreate.xaml
    /// </summary>
    public partial class WindowCreate : Window
    {
        int i = 0;
        Dictionary<int, Item> mapAux = new Dictionary<int, Item>();
        Persistence tool = Persistence.Instance;
        Item[] products;
        Client selectedClient;
        bool firstTimeClient = true;
        bool firstTimeItems = true;
        Init memoria = Init.Instance();
        

        
        public WindowCreate()
        {
            

            InitializeComponent();
        }

        private void Clientes_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (firstTimeClient)
            {

                Client[] auxCl = new Client[memoria.MapC.Count];
                for (int i = 0; i < memoria.MapC.Count; i++)
                {

                    auxCl[i] = memoria.MapC[i];

                }
                foreach (Client i in auxCl) { 

                    if (i != null)
                        Clientes.Items.Add(i.nombre + "    ID --->"+i.Id);
                }

            firstTimeClient = false;
            }
        }

      


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Canasta.SelectedIndex == -1)
            {
            }
            else
            {
                 mapAux.Add(i,memoria.MapI[Canasta.SelectedIndex ]);
                i++;
                ListaDeCompras.Items.Add(memoria.MapI[Canasta.SelectedIndex ].Description);
            }
        }

        private void Canasta_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (firstTimeItems)
            {

                Item[] auxIl = new Item[memoria.MapI.Count];
                for (int i = 0; i < memoria.MapI.Count; i++)
                {

                    auxIl[i] = memoria.MapI[i];

                }
                foreach (Item i in auxIl)
                {

                    if (i != null)
                        Canasta.Items.Add(i.Description + "    Valor: " + i.Valor);

                }

                firstTimeItems = false;
            }
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Clientes.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente");
            }
            else
            {
                String getID = Clientes.SelectedItem.ToString();
                String[] getSplit = getID.Split('>');
                int index = Int32.Parse(getSplit[1]);
                selectedClient = memoria.MapC[index];
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            products = new Item[mapAux.Count];

            for (int i = 0; i < mapAux.Count; i++)
            {
                products[i] = mapAux[i];
            }



            String pay_Nopay = "";
            if (Estado.SelectedIndex == -1) {
                pay_Nopay = "No pago";
            }else if(Estado.SelectedIndex == 0)
            {
                pay_Nopay = "Pago";
            }
            else
            {
                pay_Nopay = "No pago";
            }

            
            Factura auxFactura = new Factura(memoria.facturasCount , DateTime.Now.ToString() , selectedClient , pay_Nopay , products);
            
            MessageBox.Show("El ID de su factura es " + memoria.facturasCount);
            
            memoria.MapF.Add(memoria.facturasCount, auxFactura);
            memoria.setFacturasCount(memoria.facturasCount + 1);
            

            this.Close();
        }

        

    }
}
