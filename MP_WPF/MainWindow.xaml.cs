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
        bool firstFigureForQuantityOfDaysOfSimulation = true;
        bool firtsFigureForTextBoxQuantityOfRooms = true;
        bool firstFigureQuantityOfLux = true;
        bool firtsFigureQuantityOfJuniorSuites = true;
        bool firstFigureQuantityOfSingleRoom = true;
        bool firtsFigureQuantityOfDoubleRoom = true;
        bool firstFigureQuantityOfSingleRoomWithFoldingSofa = true;
        int QuantityOfDaysOfSimulation;
        int QuantityOfRooms;
        int QuantityOfLux;
        int QuantityOfJuniorSuite;
        int QuantityOfSingleRoom;
        int QuantityOfDoubleRoom;
        int QuantityOfSingleRoomWithFoldingSofa;
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
            if (TextBoxQuantityOfDaysOfSimulation.Text == "" || TextBoxQuantityOfRooms.Text == "")
            {
                SettingsSimulation.Visibility = Visibility.Collapsed;
                EmptyInput.Visibility = Visibility.Visible;
            }
            else if (int.Parse(TextBoxQuantityOfDaysOfSimulation.Text) > 30 || int.Parse(TextBoxQuantityOfRooms.Text) > 30 || int.Parse(TextBoxQuantityOfDaysOfSimulation.Text) < 12 || int.Parse(TextBoxQuantityOfRooms.Text) < 20)
            {
                SettingsSimulation.Visibility = Visibility.Collapsed;
                IncorrectInput.Visibility = Visibility.Visible;
            }
            else
            {
                SettingsSimulation2.Visibility = Visibility.Visible;
                SettingsSimulation.Visibility = Visibility.Visible;
                QuantityOfDaysOfSimulation = int.Parse(TextBoxQuantityOfDaysOfSimulation.Text);
                QuantityOfRooms = int.Parse(TextBoxQuantityOfRooms.Text);
            }

        }
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            TextBoxQuantityOfDaysOfSimulation.Clear();
            TextBoxQuantityOfRooms.Clear();
            firstFigureForQuantityOfDaysOfSimulation = true;
            firtsFigureForTextBoxQuantityOfRooms = true;
            SettingsSimulation.Visibility = Visibility.Collapsed;
            Main.Visibility = Visibility.Visible;
        }
        private void Сontinue2ButtonClick(object sender, RoutedEventArgs e)
        {
            QuantityOfLux = int.Parse(TextBoxQuantityOfLux.Text);
            QuantityOfJuniorSuite = int.Parse(TextBoxQuantityOfJuniorSuite.Text);
            QuantityOfSingleRoom = int.Parse(TextBoxQuantityOfSingleRoom.Text);
            QuantityOfDoubleRoom = int.Parse(TextBoxQuantityOfDoubleRoom.Text);
            QuantityOfSingleRoomWithFoldingSofa = int.Parse(TextBoxQuantityOfSingleRoomWithFoldingSofa.Text);
            if (QuantityOfLux + QuantityOfJuniorSuite + QuantityOfSingleRoom + QuantityOfDoubleRoom + QuantityOfSingleRoomWithFoldingSofa != QuantityOfRooms)
            {
                SettingsSimulation2.Visibility = Visibility.Collapsed;
                IncorrectSum.Visibility = Visibility.Visible;
            }
            SettingsSimulation2.Visibility = Visibility.Collapsed;
            Hotel.Visibility = Visibility.Visible;
            Button[] buttons = new Button[QuantityOfRooms];
            int left = -1150;
            int top = -800;
            int down = 0;
            for (int i = 0, j = 1; i < QuantityOfRooms; i++, j++)
            {
                buttons[i] = new Button();
                buttons[i].Content = "Room №" + j.ToString();
                buttons[i].Name = "Room" + j.ToString();
                buttons[i].Click += RoomClick;
                Hotel.Children.Add(buttons[i]);
                buttons[i].Height = 70;
                buttons[i].Width = 70;
                if (i % 10 == 0 && i != 0)
                {
                    left -= 2500;
                    down -= 200;
                }
                buttons[i].Margin = new Thickness(left, top, 0, down);
                left += 250;
            }

        }
        private void Back2ButtonClick(object sender, RoutedEventArgs e)
        {
            SettingsSimulation.Visibility = Visibility.Visible;
            SettingsSimulation2.Visibility = Visibility.Collapsed;
        }
        private void TextBoxQuantityOfDaysOfSimulation_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) || (e.Text[0] == '0' && firstFigureForQuantityOfDaysOfSimulation))
            {
                e.Handled = true;
            }
            if (Char.IsDigit(e.Text, 0) && e.Text[0] != '0')
            {
                firstFigureForQuantityOfDaysOfSimulation = false;
            }
        }
        private void TextBoxQuantityOfRooms_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) || (e.Text[0] == '0' && firtsFigureForTextBoxQuantityOfRooms))
            {
                e.Handled = true;
            }
            if (Char.IsDigit(e.Text, 0) && e.Text[0] != '0')
            {
                firtsFigureForTextBoxQuantityOfRooms = false;
            }
        }
        private void TextBoxQuantityOfLux_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) || (e.Text[0] == '0' && firstFigureQuantityOfLux))
            {
                e.Handled = true;
            }
            if (Char.IsDigit(e.Text, 0) && e.Text[0] != '0')
            {
                firstFigureQuantityOfLux = false;
            }
        }
        private void TextBoxQuantityOfJuniorSuite_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) || (e.Text[0] == '0' && firtsFigureQuantityOfJuniorSuites))
            {
                e.Handled = true;
            }
            if (Char.IsDigit(e.Text, 0) && e.Text[0] != '0')
            {
                firtsFigureQuantityOfJuniorSuites = false;
            }
        }
        private void TextBoxQuantityOfSingleRoom_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) || (e.Text[0] == '0' && firstFigureQuantityOfSingleRoom))
            {
                e.Handled = true;
            }
            if (Char.IsDigit(e.Text, 0) && e.Text[0] != '0')
            {
                firstFigureQuantityOfSingleRoom = false;
            }
        }
        private void TextBoxQuantityOfDoubleRoom_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) || (e.Text[0] == '0' && firtsFigureQuantityOfDoubleRoom))
            {
                e.Handled = true;
            }
            if (Char.IsDigit(e.Text, 0) && e.Text[0] != '0')
            {
                firtsFigureQuantityOfDoubleRoom = false;
            }
        }
        private void TextBoxQuantityOfSingleRoomWithFoldingSofa_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) || (e.Text[0] == '0' && firstFigureQuantityOfSingleRoomWithFoldingSofa))
            {
                e.Handled = true;
            }
            if (Char.IsDigit(e.Text, 0) && e.Text[0] != '0')
            {
                firstFigureQuantityOfSingleRoomWithFoldingSofa = false;
            }
        }

        private void OKButtonClick(object sender, RoutedEventArgs e)
        {
            SettingsSimulation.Visibility = Visibility.Visible;
            EmptyInput.Visibility = Visibility.Collapsed;
        }
        private void OK2ButtonClick(object sender, RoutedEventArgs e)
        {
            SettingsSimulation.Visibility = Visibility.Visible;
            IncorrectInput.Visibility = Visibility.Collapsed;
        }

        private void OK3ButtonClick(object sender, RoutedEventArgs e)
        {
            IncorrectSum.Visibility = Visibility.Collapsed;
            SettingsSimulation2.Visibility = Visibility.Visible;
        }

        private void RoomClick(object sender, RoutedEventArgs e)
        {

        }
    }
}