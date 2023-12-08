using MP_WPF;
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
using System.Threading;
using System.Windows.Threading;

namespace ProjectMP
{
    public partial class MainWindow : Window
    {

        bool firstFigureForQuantityOfDaysOfSimulation = true;
        bool firtsFigureForTextBoxQuantityOfRooms = true;
        bool firstFigureQuantityOfLuxe = true;
        bool firtsFigureQuantityOfJuniorSuites = true;
        bool firstFigureQuantityOfSingleRoom = true;
        bool firtsFigureQuantityOfDoubleRoom = true;
        bool firstFigureQuantityOfSingleRoomWithFoldingSofa = true;
        int quantityOfDaysOfSimulation;
        int quantityOfRooms;
        int quantityOfLuxe;
        int quantityOfJuniorSuite;
        int quantityOfSingleRoom;
        int quantityOfDoubleRoom;
        int quantityOfSingleRoomWithFoldingSofa;
        static Button[] buttons;
        List<HotelRoom> hotelRooms = new List<HotelRoom>();
        List<Booking> wholeInformationAboutBooking = new List<Booking>();
        public MainWindow()
        {
            InitializeComponent();
        }
        #region Start
        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            SettingsSimulation.Visibility = Visibility.Visible;
            Main.Visibility = Visibility.Collapsed;
        }
        #endregion
        #region Reports
        private void ReportsButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("Reports");
        }
        #endregion
        #region Exit
        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion
        #region FirstPageOfSettings
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
                quantityOfDaysOfSimulation = int.Parse(TextBoxQuantityOfDaysOfSimulation.Text);
                quantityOfRooms = int.Parse(TextBoxQuantityOfRooms.Text);
            }

        }
        #endregion
        #region BackToStart
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            TextBoxQuantityOfDaysOfSimulation.Clear();
            TextBoxQuantityOfRooms.Clear();
            firstFigureForQuantityOfDaysOfSimulation = true;
            firtsFigureForTextBoxQuantityOfRooms = true;
            SettingsSimulation.Visibility = Visibility.Collapsed;
            Main.Visibility = Visibility.Visible;
        }
        #endregion
        #region SecondPageOfSettings
        private void Сontinue2ButtonClick(object sender, RoutedEventArgs e)
        {
            quantityOfLuxe = int.Parse(TextBoxQuantityOfLuxe.Text);
            quantityOfJuniorSuite = int.Parse(TextBoxQuantityOfJuniorSuite.Text);
            quantityOfSingleRoom = int.Parse(TextBoxQuantityOfSingleRoom.Text);
            quantityOfDoubleRoom = int.Parse(TextBoxQuantityOfDoubleRoom.Text);
            quantityOfSingleRoomWithFoldingSofa = int.Parse(TextBoxQuantityOfSingleRoomWithFoldingSofa.Text);
            if (quantityOfLuxe + quantityOfJuniorSuite + quantityOfSingleRoom + quantityOfDoubleRoom + quantityOfSingleRoomWithFoldingSofa != quantityOfRooms)
            {
                SettingsSimulation2.Visibility = Visibility.Collapsed;
                IncorrectSum.Visibility = Visibility.Visible;
            }
            else
            {
                SettingsSimulation2.Visibility = Visibility.Collapsed;
                Hotel.Visibility = Visibility.Visible;
                int numberOfRoom = 1;
                for (int i = 0; i < quantityOfLuxe; i++)
                {
                    hotelRooms.Add(new Luxe());
                    wholeInformationAboutBooking.Add(new Booking(hotelRooms[numberOfRoom - 1], false, false, numberOfRoom));
                    numberOfRoom++;
                }
                for (int i = 0; i < quantityOfJuniorSuite; i++)
                {
                    hotelRooms.Add(new JuniorSuite());
                    wholeInformationAboutBooking.Add(new Booking(hotelRooms[numberOfRoom - 1], false, false, numberOfRoom));
                    numberOfRoom++;
                }
                for (int i = 0; i < quantityOfSingleRoom; i++)
                {
                    hotelRooms.Add(new SingleRoom());
                    wholeInformationAboutBooking.Add(new Booking(hotelRooms[numberOfRoom - 1], false, false, numberOfRoom));
                    numberOfRoom++;
                }
                for (int i = 0; i < quantityOfDoubleRoom; i++)
                {
                    hotelRooms.Add(new DoubleRoom());
                    wholeInformationAboutBooking.Add(new Booking(hotelRooms[numberOfRoom - 1], false, false, numberOfRoom));
                    numberOfRoom++;
                }
                for (int i = 0; i < quantityOfSingleRoomWithFoldingSofa; i++)
                {
                    hotelRooms.Add(new DoubleRoomWithSofa());
                    wholeInformationAboutBooking.Add(new Booking(hotelRooms[numberOfRoom - 1], false, false, numberOfRoom));
                    numberOfRoom++;
                }
                buttons = new Button[quantityOfRooms];
                int left = -1150;
                int top = -800;
                int down = 0;
                for (int i = 0, j = 1; i < quantityOfRooms; i++, j++)
                {
                    buttons[i] = new Button();
                    buttons[i].Content = "Room №" + j.ToString();
                    buttons[i].Name = "Room" + j.ToString();
                    buttons[i].Background = new SolidColorBrush(Colors.LightGreen);
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


        }
        #endregion
        #region BackToFirstPageOfSettings
        private void Back2ButtonClick(object sender, RoutedEventArgs e)
        {
            SettingsSimulation.Visibility = Visibility.Visible;
            SettingsSimulation2.Visibility = Visibility.Collapsed;
        }
        #endregion
        #region CheckCorrectnessOfInputOnSecondPageOfSettings
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
        private void TextBoxQuantityOfLuxe_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) || (e.Text[0] == '0' && firstFigureQuantityOfLuxe))
            {
                e.Handled = true;
            }
            if (Char.IsDigit(e.Text, 0) && e.Text[0] != '0')
            {
                firstFigureQuantityOfLuxe = false;
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
        #endregion
        #region OKButtons
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
        #endregion
        private void RoomClick(object sender, RoutedEventArgs e)
        {
            RoomInformation roomInformation = new RoomInformation();
            Button clickedButton = sender as Button;
            for (int i = 1; i <= quantityOfRooms; i++)
            {
                string str = "Room" + i.ToString();
                if (clickedButton.Name == str)
                {
                    roomInformation.TextBox_InformationAboutRoom.Text += wholeInformationAboutBooking[i - 1].room.ToString();
                    roomInformation.TextBox_InformationAboutRoom.Text += wholeInformationAboutBooking[i - 1].bookings.Last().ToString();
                    break;
                }
            }
            roomInformation.ShowDialog();            
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            RequestGenerator RG = new RequestGenerator();
            RequestHandler RH = new RequestHandler();
            for (int i = 0;i<int.Parse(QuantityOfRequest.Text);i++)
            {
                RH.RabotaNeWolkRabotaWork(RG.Generator(1), wholeInformationAboutBooking);
            }
        }

    }
}