using System;
using System.Collections.Generic;
using System.IO;
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

namespace ProjectMP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int QuantityOfDaysOfSimulation;
        int QuantityOfRooms;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            SettingsSimulation.Visibility = Visibility.Visible;
            Main.Visibility = Visibility.Collapsed;
        }
        private void ReportsButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("Reports");
        }
        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void СontinueButtonClick(object sender, RoutedEventArgs e)
        {
            SettingsSimulation2.Visibility = Visibility.Visible;
            SettingsSimulation.Visibility = Visibility.Visible;
            QuantityOfDaysOfSimulation = int.Parse(TextBoxQuantityOfDaysOfSimulation.Text);
            QuantityOfRooms = int.Parse(TextBoxQuantityOfRooms.Text);
        }
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            SettingsSimulation.Visibility = Visibility.Collapsed;
            Main.Visibility = Visibility.Visible;
        }
        private void Сontinue2ButtonClick(object sender, RoutedEventArgs e)
        {

        }
        private void Back2ButtonClick(object sender, RoutedEventArgs e)
        {
            SettingsSimulation.Visibility = Visibility.Visible;
            SettingsSimulation2.Visibility = Visibility.Collapsed;
        }
        private void TextBoxQuantityOfDaysOfSimulation_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
        private void TextBoxQuantityOfRooms_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
        //доделать для остальных textbox и проверку на то, чтобы сумма всех номеров разных типов была равна общему количеству номеров.
    }
}
