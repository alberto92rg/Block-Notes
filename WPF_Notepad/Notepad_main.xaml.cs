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
    /// Logica di interazione per Notepad_main.xaml
    /// </summary>
    public partial class Notepad_main : Window
    {
        public Notepad_main()
        {
            InitializeComponent();
        }

        #region FILE
        private void new_butt_Click(object sender, RoutedEventArgs e)
        {
            /*Pulisce tutta la textBox*/
            this.tbox_ctl.Text = "";
            this.tbox_ctl.Focus();
        }

        private void open_butt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog open_file = new Microsoft.Win32.OpenFileDialog();
            open_file.Filter = "Text Files|*.txt";
            open_file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            open_file.ShowDialog();

            if (open_file.FileName != "")
            {
                this.tbox_ctl.Text = System.IO.File.ReadAllText(open_file.FileName, Encoding.UTF8);

            }
        }

        private void save_butt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog save_file = new Microsoft.Win32.SaveFileDialog();
            save_file.Filter = "Text Files|*.txt";
            save_file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            save_file.AddExtension = true;
            save_file.ShowDialog();
            if (save_file.FileName != "")
            {
                System.IO.File.WriteAllText(save_file.FileName, this.tbox_ctl.Text, Encoding.UTF8);
                MessageBox.Show("Ben Fatto !");
            }
        }

        private void exit_butt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region EDIT
        private void undo_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Undo();
        }

        private void redo_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Redo();
        }

        private void cut_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Cut();
        }

        private void copy_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Copy();
        }

        private void paste_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Paste();
        }

        private void select_all_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Focus();
            this.tbox_ctl.SelectAll();
        }

        #endregion

        #region FORMAT
        private void word_wrap_Click(object sender, RoutedEventArgs e)
        {
            if (this.word_wrap.IsChecked == true)
            {
                this.tbox_ctl.TextWrapping = TextWrapping.Wrap;
                this.tbox_ctl.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            }
            else
            {
                this.tbox_ctl.TextWrapping = TextWrapping.NoWrap;
                this.tbox_ctl.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            }
        }

        #endregion

        #region VIEW
        private void zoom_in_Click(object sender, RoutedEventArgs e)
        {
            if ((this.tbox_ctl.FontSize + 4) < 100)
            {
                this.tbox_ctl.FontSize += 4;
            }
        }

        private void zoom_out_Click(object sender, RoutedEventArgs e)
        {
            if ((this.tbox_ctl.FontSize - 4) > 7)
            {
                this.tbox_ctl.FontSize -= 4;
            }
        }

        private void default_zoom_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.FontSize = 15;
        }

        #endregion

        #region HELP
        private void about_Click(object sender, RoutedEventArgs e)
        {
            WPF_Notepad.about_as about = new about_as();
            about.ShowDialog();
        }





        #endregion

        private void item_scuro_Checked(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Background = Brushes.Black;
            this.tbox_ctl.Foreground = Brushes.White;
        }

        private void item_scuro_Unchecked(object sender, RoutedEventArgs e)
        {

            this.tbox_ctl.Background = Brushes.White;
            this.tbox_ctl.Foreground = Brushes.Black;
        }

        private void info_btt_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        /*---Protezione al codice--- */
           if (tbox_ctl.Text == null)
           {
                return;
           }
        /*---------------------------*/
            if (this.cmb_zoom.SelectedIndex == 0) //50%
           {
                this.tbox_ctl.FontSize = 9;
           }
           if(this.cmb_zoom.SelectedIndex == 1) //75%
           {
                this.tbox_ctl.FontSize = 12;
           }
           if (this.cmb_zoom.SelectedIndex == 2) //100% defualt fontsize = 18!
           {
               this.tbox_ctl.FontSize = 18;
           }
           if (this.cmb_zoom.SelectedIndex == 3) //125%
           {
               this.tbox_ctl.FontSize = 21;
           }
           if (this.cmb_zoom.SelectedIndex == 4) //150%
           {
               this.tbox_ctl.FontSize = 24; 
           }
        }

        private void tbox_ctl_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            this.lbl_count_char.Content = this.tbox_ctl.Text.Length.ToString();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog save_file = new Microsoft.Win32.SaveFileDialog();
            save_file.Filter = "Text Files|*.txt";
            save_file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            save_file.AddExtension = true;
            save_file.ShowDialog();
            if (save_file.FileName != "")
            {
                System.IO.File.WriteAllText(save_file.FileName, this.tbox_ctl.Text, Encoding.UTF8);
                MessageBox.Show("Ben Fatto !");
            }
        }
    }
    
}
