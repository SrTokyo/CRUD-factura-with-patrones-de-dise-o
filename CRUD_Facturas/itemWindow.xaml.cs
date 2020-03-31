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
    /// Lógica de interacción para itemWindow.xaml
    /// </summary>
    public partial class itemWindow : Window
    {
        Init memoria = Init.Instance();
        public itemWindow()
        {
            InitializeComponent();
        }

        private bool existeTipo()
        {
            bool compare = false;
            TipoItem[] aux = new TipoItem[memoria.MapT.Count];
            for (int i = 0; i < memoria.MapT.Count; i++)
            {
                aux[i] = memoria.MapT[i];
            }
            foreach (TipoItem item in aux)
            {
                if (item.Description.Equals( txtTipo.Text))
                {
                    compare = true;
                }
            }
            return compare;
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TipoItem tipo = null;
            if (existeTipo())
            {
                
                TipoItem[] aux = new TipoItem[memoria.MapT.Count];
                for (int i = 0; i < memoria.MapT.Count; i++)
                {
                    aux[i] = memoria.MapT[i];
                }
                foreach (TipoItem item in aux)
                {
                    if (item.Description.Equals(txtTipo.Text))
                    {
                        tipo = item;
                    }
                }
            }
            else
            {
                tipo = new TipoItem(memoria.tipoItemCount, txtTipo.Text);
                memoria.tipoItemCount++;
            }

            memoria.MapI.Add(memoria.itemCount, new Item(tipo, memoria.itemCount, txtDesc.Text, Double.Parse(txtValor.Text)));
            memoria.itemCount++;

        }
    }
}
