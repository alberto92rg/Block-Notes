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

namespace WPF_Notepad
{
    /// <summary>
    /// Logica di interazione per about_as.xaml
    /// </summary>
    public partial class about_as : Window
    {
        public about_as()
        {
            InitializeComponent();
        }

        private void ok_butt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
