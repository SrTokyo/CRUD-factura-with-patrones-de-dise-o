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
    /// Lógica de interacción para ClienteWindow.xaml
    /// </summary>
    public partial class ClienteWindow : Window
    {
        Init memoria = Init.Instance();
        public ClienteWindow()
        {
            InitializeComponent();
        }
        public bool generoChar()
        {
            Char[] aux = txtGenero.Text.ToCharArray();
            if (aux.Length == 1)
            {
                return true;
            }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (generoChar())
            {
                Char[] aux = txtGenero.Text.ToCharArray();
                memoria.MapC.Add(memoria.clientCount, new Client(memoria.clientCount, txtNombre.Text, txtApellidos.Text, aux[0], txtDate.Text, txtCivil.Text));
                memoria.clientCount++;
            }
        }
    }
}
