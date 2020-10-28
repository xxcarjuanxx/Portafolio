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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Arriendo.Presentacion.form_mensaje
{
    /// <summary>
    /// Lógica de interacción para ejemplo.xaml
    /// </summary>
    public partial class ejemplo : Window
    {
        bool MenuClosed = false;
        public ejemplo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MenuClosed)
            {
                Storyboard openMenu = (Storyboard)button.FindResource("OpenMenu");
                openMenu.Begin();
            }
            else {
                Storyboard closeMenu = (Storyboard)button.FindResource("CloseMenu");
                closeMenu.Begin();
            }
            MenuClosed = !MenuClosed;
        }
    }
}
