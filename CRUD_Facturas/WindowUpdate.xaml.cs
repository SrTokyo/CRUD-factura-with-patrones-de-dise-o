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
using CRUD_Facturas.Classes.Factories;
using CRUD_Facturas.Classes;

namespace CRUD_Facturas
{
    /// <summary>
    /// Lógica de interacción para WindowUpdate.xaml
    /// </summary>
    public partial class WindowUpdate : Window
    {
        int i = 0;
        int f;
        //int ?newFID = null ;
        Dictionary<int, Item> mapAux = new Dictionary<int, Item>();
        Persistence tool = Persistence.Instance;
        Item[] products;
        Client selectedClient;
        bool firstTimeClient = true;
        bool firstTimeItems = true;
        Init memoria = Init.Instance();
        public WindowUpdate(int f)
        {
            this.f = f;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Canasta.SelectedIndex == -1)
            {
            }
            else
            {
                mapAux.Add(i, memoria.MapI[Canasta.SelectedIndex ]);
                i++;
                ListaDeCompras.Items.Add(memoria.MapI[Canasta.SelectedIndex].Description);
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
                        Canasta.Items.Add(i.Description + "    Valor: "+ i.Valor);
                }

                firstTimeItems = false;
            }
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (C.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente");
            }
            else
            {
                String getID = C.SelectedItem.ToString();
                String[] getSplit;
                getSplit = getID.Split('>');
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
            if (Estado.SelectedIndex == -1)
            {
                pay_Nopay = "No pago";
            }
            else if (Estado.SelectedIndex == 0)
            {
                pay_Nopay = "Pago";
            }
            else
            {
                pay_Nopay = "No pago";
            }
            //if (newFID == null) 
            //{

            //}
            //else
            //{
            //    f = Int32.Parse(newFID+"");
            //}

             

            

            
            memoria.MapF.Remove(f);
            memoria.MapF.Add(f, new Factura(f, txtDate.Text, selectedClient, pay_Nopay, products));

            MessageBox.Show("El ID de su factura es " + f);
            this.Close();
        }

        private void C_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (firstTimeClient)
            {
                Client[] auxCl = new Client[memoria.MapC.Count];
                for (int i = 0; i < memoria.MapC.Count; i++)
                {
                    
                    auxCl[i] = memoria.MapC[i];

                }
                foreach (Client i in auxCl)
                
                    if(i != null)
                        C.Items.Add(i.nombre+ "    ID--->"+i.Id);
                }



                firstTimeClient = false;
            }

        //private void Button_Click_3(object sender, RoutedEventArgs e)
        //{
        //    int newID;
        //    try
        //    {
        //        newID = Int32.Parse(txtID.Text);
        //        try
        //        {
        //            if (memoria.MapF[newID] != null)
        //            {
        //                MessageBox.Show("ID ya correspondiente a una factura");
        //            }
        //            else
        //            {
        //                newFID = newID;
        //                MessageBox.Show("ID " + newFID + " asignado correctamente");
        //            }

        //        }
        //        catch (Exception)
        //        {

        //            newFID = newID;
        //            MessageBox.Show("ID " + newFID + " asignado correctamente");
        //        }
                
                
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Introdusca un numero entero Int32");
        //    }
        //}
        }
    }

