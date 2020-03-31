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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CRUD_Facturas.Classes;
using CRUD_Facturas.Classes.Factories;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace CRUD_Facturas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Persistence tool = Persistence.Instance;
        
        public MainWindow()
        {

            tool.loadMemoria();




            

            //XmlSerializer serializer = new XmlSerializer(typeof(Init));
            //using (TextWriter tw = new StreamWriter(@"C:\persistence.xml"))
            //{
            //    serializer.Serialize(tw, memoria);
            //}


            InitializeComponent();
        }
        

        private void create_Click(object sender, RoutedEventArgs e)
        {
            WindowCreate createWindow = new WindowCreate();
            //createWindow.Owner = this;
            createWindow.ShowDialog();
        }

        private void look_Click(object sender, RoutedEventArgs e)
        {
            IDGiver id_Update = new IDGiver();
            int id = 0;
            id_Update.ShowDialog();
            
                id = Int32.Parse(id_Update.Answer);
                Init memoria = Init.Instance();
                
                    if (memoria.MapF[id] != null)
                    {
                        WindowRead readWindow = new WindowRead(id);
                        //readWindow.Owner = this;
                        readWindow.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("ID de factura no encontrado");
                    }
                
            
            
            
        }
        private void update_Click(object sender, RoutedEventArgs e)
        {
            IDGiver id_Update = new IDGiver();
            int id = 0;
            id_Update.ShowDialog();
            try
            {
                id = Int32.Parse(id_Update.Answer);
                Init memoria = Init.Instance();
                try
                {
                    if (memoria.MapF[id] != null)
                    {
                        WindowUpdate updateWindow = new WindowUpdate(id);
                        //updateWindow.Owner = this;
                        updateWindow.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("ID de factura no encontrado");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("ID de factura no encontrado");
                }
            }
            catch (Exception)
            {
                
            }
            
            
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            IDGiver id_Update = new IDGiver();
            int id = 0;
            id_Update.ShowDialog();
            try
            {
                id = Int32.Parse(id_Update.Answer);
                Init memoria = Init.Instance();
                try
                {
                    if (memoria.MapF[id] != null)
                    {
                        memoria.MapF[id] = null;
                        MessageBox.Show("La Factura fue eliminada");
                    }
                    else
                    {
                        MessageBox.Show("ID de factura no encontrado");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("ID de factura no encontrado");
                }
            }
            catch (Exception)
            {

                
            }
            
            
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            tool.saveMemoria();
            this.Close();
        }

        private void client_Click(object sender, RoutedEventArgs e)
        {
            ClienteWindow clienteWindow = new ClienteWindow();
            //updateWindow.Owner = this;
            clienteWindow.ShowDialog();
        }

        private void item_Click(object sender, RoutedEventArgs e)
        {
            itemWindow itemsWindow = new itemWindow();
            //updateWindow.Owner = this;
            itemsWindow.ShowDialog();
        }
    }
}
