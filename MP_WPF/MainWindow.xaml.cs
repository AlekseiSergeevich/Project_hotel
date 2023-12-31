﻿using MP_WPF;
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
        RequestGenerator requestGenerator = new RequestGenerator();
        RequestHandler requestHandler = new RequestHandler();
        List<BookingRequest> BookingRequestsList = new List<BookingRequest>();
        Bill Bill = new Bill();
        StatisticWriter statisticWriter = new StatisticWriter();
        AnswerAboutBooking Answer = new AnswerAboutBooking();
        BookingConfirmation BookingConfirmation = new BookingConfirmation();
        RequestWriter RW= new RequestWriter();
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
            else if (int.Parse(QuantityOfLuxeTextBox.Text) + int.Parse(QuantityOfJuniorSuiteTextBox.Text) + int.Parse(QuantityOfSingleRoomTextBox.Text) + int.Parse(QuantityOfDoubleRoomTextBox.Text) + int.Parse(QuantityOfDoubleRoomWithFoldingSofaTextBox.Text) != quantityOfRooms)
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
                    if (wholeInformationAboutBooking[i - 1].bookings.Count != 0)
                    {
                        for (int j = 0; j < wholeInformationAboutBooking[i - 1].bookings.Count; j++)
                        {
                            if (dateInSimulation >= wholeInformationAboutBooking[i - 1].bookings[j].StartOfBooking && dateInSimulation < wholeInformationAboutBooking[i - 1].bookings[j].EndOfBooking)
                            {
                                roomInformation.TextBox_InformationAboutRoom.Text += wholeInformationAboutBooking[i - 1].bookings[j].ToStringBusyness() + "\r\n";
                            }
                            if (dateInSimulation < wholeInformationAboutBooking[i - 1].bookings[j].StartOfBooking)
                            {
                                roomInformation.TextBox_InformationAboutRoom.Text += wholeInformationAboutBooking[i - 1].bookings[j].ToStringBooking() + "\r\n";
                            }
                        }
                    }
                }
            }
            roomInformation.ShowDialog();
        }
        private void GeneratingRequestsButtonClick(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            if (string.IsNullOrWhiteSpace(QuantityOfRequestsTextBox.Text))
            {
                return;
            }
            for (int i = 0; i < int.Parse(QuantityOfRequestsTextBox.Text); i++)
            {
                intervalBetweenAppearanceOfTwoRequests = rand.Next(1, 5);
                Answer = requestHandler.RabotaNeWolkRabotaWork(requestGenerator.Generator(intervalBetweenAppearanceOfTwoRequests), wholeInformationAboutBooking, BookingRequestsList);
                if (Answer.ResultOfBookibg == true)
                {
                    if (Answer.Discount == true)
                    {
                        statisticCounter.AddToGlobalProfitWithDiscount(Answer.request.room);
                        BookingConfirmation.Write(Answer.request);
                    }
                    else
                    {
                        statisticCounter.AddToGlobalProfit(Answer.request.room);
                    }
                    RW.Write(Answer.request);
                }
                else RW.Write(Answer.request);
                pastTime += intervalBetweenAppearanceOfTwoRequests;
                dateInSimulation = dateInSimulation.AddHours(intervalBetweenAppearanceOfTwoRequests);
                //проверь это чтобы все работало корректно
                for (int j = 0; j < BookingRequestsList.Count; j++)
                {
                    if (BookingRequestsList[j] != null && dateInSimulation.Day >= BookingRequestsList[j].EndOfBooking.Day)
                    {
                        Bill.Write(BookingRequestsList[j]);
                        BookingRequestsList[j] = null;
                    }
                }
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
                if (!wholeInformationAboutBooking[i].FlagOfBooking && !wholeInformationAboutBooking[i].FlagOfBusyness)
                {
                    buttons[i].Background = new SolidColorBrush(Colors.LightGreen);
                }
                if (wholeInformationAboutBooking[i].FlagOfBooking)
                {
                    buttons[i].Background = new SolidColorBrush(Colors.Yellow);
                }
                if (wholeInformationAboutBooking[i].FlagOfBusyness)
                {
                    buttons[i].Background = new SolidColorBrush(Colors.Orange);
                }
                if (wholeInformationAboutBooking[i].FlagOfBusyness && wholeInformationAboutBooking[i].FlagOfBooking)
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
            statisticWriter.Write(statisticCounter);
            FileInfo fi = new FileInfo("Statistic.txt");
            List<int> numbersOfReports = new List<int>();
            int numberOfReport = Directory.GetFiles(Environment.CurrentDirectory + "//Reports", "*", SearchOption.AllDirectories).Length + 1;
            fi.CopyTo(Environment.CurrentDirectory + "\\Reports" + "\\Отчет№" + numberOfReport + ".txt");
            System.Diagnostics.Process.Start("Statistic.txt");
            Close();
        }
        private void ShowReportImmediatelyButtonClick(object sender, RoutedEventArgs e)
        {
            statisticWriter.Write(statisticCounter);
            FileInfo fi = new FileInfo("Statistic.txt");
            List<int> numbersOfReports = new List<int>();
            int numberOfReport = Directory.GetFiles(Environment.CurrentDirectory + "//Reports", "*", SearchOption.AllDirectories).Length + 1;
            fi.CopyTo(Environment.CurrentDirectory + "\\Reports" + "\\Отчет№" + numberOfReport + ".txt");
            System.Diagnostics.Process.Start("Statistic.txt");
            Close();
        }
        private void ChangeOfFlags()
        {

            for (int i = 0; i < quantityOfRooms; i++)
            {
                bool checkBusy = false;
                bool checkBooking = false;
                if (wholeInformationAboutBooking[i].bookings.Count != 0)
                {
                    for (int j = 0; j < wholeInformationAboutBooking[i].bookings.Count; j++)
                    {
                        if (dateInSimulation >= wholeInformationAboutBooking[i].bookings[j].StartOfBooking && dateInSimulation < wholeInformationAboutBooking[i].bookings[j].EndOfBooking)
                        {
                            checkBusy = true;
                        }
                        if (dateInSimulation < wholeInformationAboutBooking[i].bookings[j].StartOfBooking)
                        {
                            checkBooking = true;
                        }

                    }
                }
                if (checkBusy && checkBooking)
                {
                    wholeInformationAboutBooking[i].FlagOfBusyness = true;
                    wholeInformationAboutBooking[i].FlagOfBooking = true;
                }
                if (checkBusy && !checkBooking)
                {
                    wholeInformationAboutBooking[i].FlagOfBusyness = true;
                    wholeInformationAboutBooking[i].FlagOfBooking = false;
                }
                if (!checkBusy && checkBooking)
                {
                    wholeInformationAboutBooking[i].FlagOfBusyness = false;
                    wholeInformationAboutBooking[i].FlagOfBooking = true;
                }
                if (!checkBusy && !checkBooking)
                {
                    wholeInformationAboutBooking[i].FlagOfBusyness = false;
                    wholeInformationAboutBooking[i].FlagOfBooking = false;
                }

            }
        }

    }
}