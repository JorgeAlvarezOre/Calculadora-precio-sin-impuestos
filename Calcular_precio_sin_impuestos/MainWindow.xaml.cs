using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calcular_precio_sin_impuestos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            if (CheckBox2.IsChecked == true)
            {
                Window window = (Window)sender;
                window.Topmost = true;
            }
            else
            {
                Window window = (Window)sender;
                window.Topmost = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double Precio_original = Convert.ToDouble(TextBox1.Text);
            double Precio_sin_impuesto = Precio_original / 1.18;
            string Precio_sin_impuesto_string = (Precio_sin_impuesto).ToString("0.00");
            //string Precio_sin_impuesto_string = Convert.ToString(Precio_sin_impuesto,"#.##");

            Label1.Content = "S/ " + Precio_sin_impuesto_string;

            if (CheckBox1.IsChecked == true)
            {
                Clipboard.SetText(Precio_sin_impuesto_string);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Programado por Jorge Alvarez (2023)");
        }
    }
}
