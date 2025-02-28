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

namespace Slot2
{
    /// <summary>
    /// Interaction logic for DemoWrapPanel.xaml
    /// </summary>
    public partial class DemoWrapPanel : Window
    {
        public DemoWrapPanel()
        {        }
        private void btnDisplay1_Click(object sender, RoutedEventArgs e)
        {
            string CarInfo = $"Car Name:{txtCarName.Text}\n" +
                $"Color:{txtColor.Text}\n Brand:{txtBrand.Text} ";
            MessageBox.Show(CarInfo, "Car Details");
        }
    }
}
