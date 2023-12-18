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
        #region FlagsForCheckOfInput
        bool firstFigureForQuantityOfDaysOfSimulation = true;
        bool firtsFigureForTextBoxQuantityOfRooms = true;
        bool firstFigureQuantityOfLuxe = true;
        bool firtsFigureQuantityOfJuniorSuites = true;
        bool firstFigureQuantityOfSingleRoom = true;
        bool firtsFigureQuantityOfDoubleRoom = true;
        bool firstFigureQuantityOfSingleRoomWithFoldingSofa = true;
        int pageWithEmptyInput = 0;
        bool firstFigureForQuantityOfRequests = true;
        #endregion
        #region InputData
        int quantityOfDaysOfSimulation;
        int quantityOfRooms;
        int quantityOfLuxe;
        int quantityOfJuniorSuite;
        int quantityOfSingleRoom;
        int quantityOfDoubleRoom;
        int quantityOfSingleRoomWithFoldingSofa;
        #endregion
        Button[] buttons;
        List<Booking> wholeInformationAboutBooking = new List<Booking>();
        StatisticCounter statisticCounter = new StatisticCounter();
        RequestGenerator RG = new RequestGenerator();
        RequestHandler RH = new RequestHandler();
        int pastTime = 0;
        int intervalBetweenAppearanceOfTwoRequests;
        DateTime dateInSimulation = DateTime.Now;
        public MainWindow()
        {
            InitializeComponent();
        }
        #region MainPage
        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            SettingsSimulation1Grid.Visibility = Visibility.Visible;
            MainGrid.Visibility = Visibility.Collapsed;
        }
        private void ReportsButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("Reports");
        }
        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion
        #region FirstPageOfSettings
        private void FirstPageOfSettingsСontinueButtonClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(QuantityOfDaysOfSimulationTextBox.Text) || string.IsNullOrWhiteSpace(QuantityOfRoomsTextBox.Text))
            {
                SettingsSimulation1Grid.Visibility = Visibility.Collapsed;
                EmptyInputGrid.Visibility = Visibility.Visible;
                pageWithEmptyInput = 1;
            }
            else if (int.Parse(QuantityOfDaysOfSimulationTextBox.Text) > 30 || int.Parse(QuantityOfRoomsTextBox.Text) > 30 || int.Parse(QuantityOfDaysOfSimulationTextBox.Text) < 12 || int.Parse(QuantityOfRoomsTextBox.Text) < 20)
            {
                SettingsSimulation1Grid.Visibility = Visibility.Collapsed;
                IncorrectInputGrid.Visibility = Visibility.Visible;
            }
            else
            {
                SettingsSimulation2Grid.Visibility = Visibility.Visible;
                SettingsSimulation1Grid.Visibility = Visibility.Collapsed;
                quantityOfDaysOfSimulation = int.Parse(QuantityOfDaysOfSimulationTextBox.Text);
                quantityOfRooms = int.Parse(QuantityOfRoomsTextBox.Text);
            }

        }
        private void BackToStartButtonClick(object sender, RoutedEventArgs e)
        {
            QuantityOfDaysOfSimulationTextBox.Clear();
            QuantityOfRoomsTextBox.Clear();
            QuantityOfLuxeTextBox.Clear();
            QuantityOfJuniorSuiteTextBox.Clear();
            QuantityOfSingleRoomTextBox.Clear();
            QuantityOfDoubleRoomTextBox.Clear();
            QuantityOfDoubleRoomWithFoldingSofaTextBox.Clear();
            firstFigureForQuantityOfDaysOfSimulation = true;
            firtsFigureForTextBoxQuantityOfRooms = true;
            firstFigureQuantityOfLuxe = true;
            firtsFigureQuantityOfJuniorSuites = true;
            firstFigureQuantityOfSingleRoom = true;
            firtsFigureQuantityOfDoubleRoom = true;
            firstFigureQuantityOfSingleRoomWithFoldingSofa = true;
            SettingsSimulation1Grid.Visibility = Visibility.Collapsed;
            MainGrid.Visibility = Visibility.Visible;
        }
        #endregion
        #region SecondPageOfSettings
        private void SecondPageOfSettingsСontinueButtonClick(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(QuantityOfLuxeTextBox.Text) || string.IsNullOrWhiteSpace(QuantityOfJuniorSuiteTextBox.Text) || string.IsNullOrWhiteSpace(QuantityOfSingleRoomTextBox.Text) || string.IsNullOrWhiteSpace(QuantityOfDoubleRoomTextBox.Text) || string.IsNullOrWhiteSpace(QuantityOfDoubleRoomWithFoldingSofaTextBox.Text))
            {
                SettingsSimulation2Grid.Visibility = Visibility.Collapsed;
                EmptyInputGrid.Visibility = Visibility.Visible;
                pageWithEmptyInput = 2;
            }
            else if (int.Parse(QuantityOfLuxeTextBox.Text) + int.Parse(QuantityOfJuniorSuiteTextBox.Text) + int.Parse(QuantityOfSingleRoomTextBox.Text) + int.Parse(QuantityOfSingleRoomTextBox.Text) + int.Parse(QuantityOfDoubleRoomWithFoldingSofaTextBox.Text) != quantityOfRooms)
            {
                SettingsSimulation2Grid.Visibility = Visibility.Collapsed;
                IncorrectSumGrid.Visibility = Visibility.Visible;
            }
            else
            {
                SettingsSimulation2Grid.Visibility = Visibility.Collapsed;
                HotelGrid.Visibility = Visibility.Visible;
                quantityOfLuxe = int.Parse(QuantityOfLuxeTextBox.Text);
                quantityOfJuniorSuite = int.Parse(QuantityOfJuniorSuiteTextBox.Text);
                quantityOfSingleRoom = int.Parse(QuantityOfSingleRoomTextBox.Text);
                quantityOfDoubleRoom = int.Parse(QuantityOfDoubleRoomTextBox.Text);
                quantityOfSingleRoomWithFoldingSofa = int.Parse(QuantityOfDoubleRoomWithFoldingSofaTextBox.Text);
                int numberOfRoom = 1;
                for (int i = 0; i < quantityOfLuxe; i++)
                {
                    wholeInformationAboutBooking.Add(new Booking(new Luxe(), false, false, numberOfRoom));
                    numberOfRoom++;
                }
                for (int i = 0; i < quantityOfJuniorSuite; i++)
                {
                    wholeInformationAboutBooking.Add(new Booking(new JuniorSuite(), false, false, numberOfRoom));
                    numberOfRoom++;
                }
                for (int i = 0; i < quantityOfSingleRoom; i++)
                {
                    wholeInformationAboutBooking.Add(new Booking(new SingleRoom(), false, false, numberOfRoom));
                    numberOfRoom++;
                }
                for (int i = 0; i < quantityOfDoubleRoom; i++)
                {
                    wholeInformationAboutBooking.Add(new Booking(new DoubleRoom(), false, false, numberOfRoom));
                    numberOfRoom++;
                }
                for (int i = 0; i < quantityOfSingleRoomWithFoldingSofa; i++)
                {
                    wholeInformationAboutBooking.Add(new Booking(new DoubleRoomWithSofa(), false, false, numberOfRoom));
                    numberOfRoom++;
                }
                int left = -1150;
                int top = -800;
                int down = 0;
                buttons = new Button[quantityOfRooms];
                for (int i = 0, j = 1; i < quantityOfRooms; i++, j++)
                {
                    buttons[i] = new Button();
                    buttons[i].Content = "Room №" + j.ToString();
                    buttons[i].Name = "Room" + j.ToString();
                    buttons[i].Background = new SolidColorBrush(Colors.LightGreen);
                    buttons[i].Click += RoomClick;
                    HotelGrid.Children.Add(buttons[i]);
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
                TimeSimulationTextBox.Text += DateTime.Now;
            }
        }
        private void BackToFirstPageOfSettingsButtonClick(object sender, RoutedEventArgs e)
        {
            SettingsSimulation2Grid.Visibility = Visibility.Collapsed;
            SettingsSimulation1Grid.Visibility = Visibility.Visible;
        }
        #endregion
        #region CheckOfInputIntegersOnTextBoxesPagesOfSettings
        private void QuantityOfDaysOfSimulationTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        private void QuantityOfRoomsTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        private void QuantityOfLuxeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        private void QuantityOfJuniorSuiteTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        private void QuantityOfSingleRoomTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        private void QuantityOfDoubleRoomTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        private void QuantityOfSingleRoomWithFoldingSofaTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        private void QuantityOfRequestsTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) || (e.Text[0] == '0' && firstFigureForQuantityOfRequests))
            {
                e.Handled = true;
            }
            if (Char.IsDigit(e.Text, 0) && e.Text[0] != '0')
            {
                firstFigureForQuantityOfRequests = false;
            }
        }
        #endregion
        #region OKButtons
        private void EmptyInputOnBothPageOfSettingsOKButtonClick(object sender, RoutedEventArgs e)
        {
            EmptyInputGrid.Visibility = Visibility.Collapsed;
            if (pageWithEmptyInput == 1)
            {
                SettingsSimulation1Grid.Visibility = Visibility.Visible;
            }
            if (pageWithEmptyInput == 2)
            {
                SettingsSimulation2Grid.Visibility = Visibility.Visible;
            }
        }
        private void IncorrectInputOnFirstPageOfSettingsOKButtonClick(object sender, RoutedEventArgs e)
        {
            SettingsSimulation1Grid.Visibility = Visibility.Visible;
            IncorrectInputGrid.Visibility = Visibility.Collapsed;
        }

        private void IncorrectInputOnSecondPageOfSettingsOKButtonClick(object sender, RoutedEventArgs e)
        {
            IncorrectSumGrid.Visibility = Visibility.Collapsed;
            SettingsSimulation2Grid.Visibility = Visibility.Visible;
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
                    roomInformation.TextBox_InformationAboutRoom.Text += "№" + i + "\r\n";
                    roomInformation.TextBox_InformationAboutRoom.Text += wholeInformationAboutBooking[i - 1].room.ToString() + "\r\n";
                    if (wholeInformationAboutBooking[i - 1].flagOfBooking && wholeInformationAboutBooking[i - 1].flagOfBusyness)
                    {
                        if(wholeInformationAboutBooking[i - 1].bookings.Last().typeOfBusyness)
                        {
                            roomInformation.TextBox_InformationAboutRoom.Text += wholeInformationAboutBooking[i - 1].bookings.Last().ToStringBusyness() + "\r\n";
                            roomInformation.TextBox_InformationAboutRoom.Text += wholeInformationAboutBooking[i - 1].bookings[wholeInformationAboutBooking[i - 1].bookings.Count-2].ToStringBooking();
                        }
                        else
                        {
                            roomInformation.TextBox_InformationAboutRoom.Text += wholeInformationAboutBooking[i - 1].bookings.Last().ToStringBooking() + "\r\n";
                            roomInformation.TextBox_InformationAboutRoom.Text += wholeInformationAboutBooking[i - 1].bookings[wholeInformationAboutBooking[i - 1].bookings.Count - 2].ToStringBusyness();
                        }
                        break;
                    }
                    if (wholeInformationAboutBooking[i - 1].flagOfBooking)
                    {
                        roomInformation.TextBox_InformationAboutRoom.Text += wholeInformationAboutBooking[i - 1].bookings.Last().ToStringBooking();
                        break;
                    }
                    if (wholeInformationAboutBooking[i - 1].flagOfBusyness)
                    {
                        roomInformation.TextBox_InformationAboutRoom.Text += wholeInformationAboutBooking[i - 1].bookings.Last().ToStringBusyness();
                        break;
                    }
                }
            }
            roomInformation.ShowDialog();
            //roomInformation.TextBox_InformationAboutRoom.Clear();
        }
        private void GeneratingRequestsButtonClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(QuantityOfRequestsTextBox.Text))
            {
                return;
            }
            for (int i = 0; i < int.Parse(QuantityOfRequestsTextBox.Text); i++)
            {
                intervalBetweenAppearanceOfTwoRequests = new Random().Next(1, 5);
                RH.RabotaNeWolkRabotaWork(RG.Generator(intervalBetweenAppearanceOfTwoRequests), wholeInformationAboutBooking, statisticCounter);
                pastTime += intervalBetweenAppearanceOfTwoRequests;
                dateInSimulation = dateInSimulation.AddHours(intervalBetweenAppearanceOfTwoRequests);
                ChangeOfFlags();
                if (pastTime >= quantityOfDaysOfSimulation * 24)
                {
                    HotelGrid.Visibility = Visibility.Collapsed;
                    GeneratingRequestsButton.Visibility = Visibility.Collapsed;
                    QuantityOfRequestsTextBox.Visibility = Visibility.Collapsed;
                    PutQuantityOfRequestTextBox.Visibility = Visibility.Collapsed;
                    ShowReportButton.Visibility = Visibility.Visible;
                    EndOfSimulationGrid.Visibility = Visibility.Visible;
                    break;
                }
            }
            TimeSimulationTextBox.Clear();
            TimeSimulationTextBox.Text = dateInSimulation.ToString();
            for (int i = 0; i < quantityOfRooms; i++)
            {
                if (wholeInformationAboutBooking[i].flagOfBooking)
                {
                    buttons[i].Background = new SolidColorBrush(Colors.Yellow);
                }
                if (wholeInformationAboutBooking[i].flagOfBusyness)
                {
                    buttons[i].Background = new SolidColorBrush(Colors.Orange);
                }
                if (wholeInformationAboutBooking[i].flagOfBusyness && wholeInformationAboutBooking[i].flagOfBooking)
                {
                    buttons[i].Background = new SolidColorBrush(Colors.Red);
                }

            }
        }
        private void BackToHotelButtonClick(object sender, RoutedEventArgs e)
        {
            EndOfSimulationGrid.Visibility = Visibility.Collapsed;
            HotelGrid.Visibility = Visibility.Visible;
        }
        private void ShowReportButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void ShowReportImmediatelyButtonClick(object sender, RoutedEventArgs e)
        {

        }
        private void ChangeOfFlags()//доделать этот ужас
        {
            for(int i =0;i<quantityOfRooms;i++)
            {
                if(wholeInformationAboutBooking[i].flagOfBooking)
                {
                    if(dateInSimulation >= wholeInformationAboutBooking[i].bookings.Last().startOfBooking)
                    {
                        wholeInformationAboutBooking[i].flagOfBooking = false;
                        wholeInformationAboutBooking[i].flagOfBusyness = true;
                    }
                }
                if(wholeInformationAboutBooking[i].flagOfBusyness)
                {
                    if (dateInSimulation >= wholeInformationAboutBooking[i].bookings.Last().endOfBooking)
                    {
                        wholeInformationAboutBooking[i].flagOfBusyness = false;
                    }
                }
            }
        }

    }
}