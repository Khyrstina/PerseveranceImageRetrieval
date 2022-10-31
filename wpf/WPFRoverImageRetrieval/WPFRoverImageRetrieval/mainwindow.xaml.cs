using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using ThisisaLibrary;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input.Manipulations;
using System.Windows.Threading;
using System.ComponentModel;
using System.Threading;
using System.Windows.Controls.Primitives;

namespace WPFRoverImageRetrieval
{

    public partial class Perseverance : Window
    {
        private int arrayObjectNumber = 0;
        private int currentPageNumber = 1;
        private PerseveranceResultModel.Latest_Photos[] pageList;

        public Perseverance()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            PreviousImageButton.IsEnabled = false;
            aboutText.Visibility = Visibility.Hidden;
            HomeButton.Visibility = Visibility.Collapsed;
            DaysBox.Visibility = Visibility.Hidden;
            HoursBox.Visibility = Visibility.Hidden;
            MinutesBox.Visibility = Visibility.Hidden;
            SecondsBox.Visibility = Visibility.Hidden;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Next_Click(sender, e);
            pageList = await ImageLoader.CurrentPage(currentPageNumber);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        public async void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private async void Previous_Click(object sender, RoutedEventArgs e)
        {
            string newLine = Environment.NewLine;

            if (arrayObjectNumber >= 0)
            {
                //PreviousImageButton.IsEnabled = true;
                roverText.Text = $"Image {pageList[arrayObjectNumber].id} was taken by {pageList[arrayObjectNumber].rover.name} on the Earth date {pageList[arrayObjectNumber].earth_date} and Martian sol: {pageList[arrayObjectNumber].sol} for this rover." + newLine + $"This rover is currently {pageList[arrayObjectNumber].rover.status}.";
                var uriSource = new Uri(pageList[arrayObjectNumber].img_src, UriKind.Absolute);
                RoverImage.Source = new BitmapImage(uriSource);
                arrayObjectNumber -= 1;
            }
            else
            {
                currentPageNumber -= 1;
                pageList = await ImageLoader.CurrentPage(currentPageNumber);
                arrayObjectNumber = pageList.Length - 1;
                roverText.Text = $"Image {pageList[arrayObjectNumber].id} was taken by {pageList[arrayObjectNumber].rover.name} on the Earth date {pageList[arrayObjectNumber].earth_date} and Martian sol: {pageList[arrayObjectNumber].sol} for this rover." + newLine + $"This rover is currently {pageList[arrayObjectNumber].rover.status}.";
                var uriSource = new Uri(pageList[arrayObjectNumber].img_src, UriKind.Absolute);
                RoverImage.Source = new BitmapImage(uriSource);
            }
            if (currentPageNumber == 1 && arrayObjectNumber == 0)
            {
                PreviousImageButton.IsEnabled = false;
            }
            else
            {
                PreviousImageButton.IsEnabled = true;
            }
        }


        private async void Next_Click(object sender, RoutedEventArgs e)
        {
            referencesText.Visibility = Visibility.Collapsed;
            pageList = await ImageLoader.CurrentPage(currentPageNumber);
            string newLine = Environment.NewLine;
            if (arrayObjectNumber < pageList.Length)
            {
                roverText.Text = $"Image {pageList[arrayObjectNumber].id} was taken by {pageList[arrayObjectNumber].rover.name} on the Earth date {pageList[arrayObjectNumber].earth_date} and Martian sol: {pageList[arrayObjectNumber].sol} for this rover." + newLine + $"This rover is currently {pageList[arrayObjectNumber].rover.status}.";
                var uriSource = new Uri(pageList[arrayObjectNumber].img_src, UriKind.Absolute);
                RoverImage.Source = new BitmapImage(uriSource);
                arrayObjectNumber += 1;
            }

            else
            {
                arrayObjectNumber = 0;
                currentPageNumber += 1;
                pageList = await ImageLoader.CurrentPage(currentPageNumber);
                roverText.Text = $"Image {pageList[arrayObjectNumber].id} was taken by {pageList[arrayObjectNumber].rover.name} on the Earth date {pageList[arrayObjectNumber].earth_date} and Martian sol: {pageList[arrayObjectNumber].sol} for this rover." + newLine + $"This rover is currently {pageList[arrayObjectNumber].rover.status}.";
                var uriSource = new Uri(pageList[arrayObjectNumber].img_src, UriKind.Absolute);
                RoverImage.Source = new BitmapImage(uriSource);
            }
            if (currentPageNumber == 1 && arrayObjectNumber == 0)
            {
                PreviousImageButton.IsEnabled = false;
            }
            else
            {
                PreviousImageButton.IsEnabled = true;
            }
        }
        public System.DateTime d1 = new System.DateTime(2021, 02, 18, 20, 55, 0);
        public System.DateTime d2 = System.DateTime.UtcNow;
        public async void Perseverance_Click(object sender, RoutedEventArgs e)
        {
            aboutText.Visibility = Visibility.Visible;
            roverText.Visibility = Visibility.Collapsed;
            RoverImage.Visibility = Visibility.Collapsed;
            HomeButton.Visibility = Visibility.Visible;
            DaysBox.Visibility = Visibility.Visible;
            HoursBox.Visibility = Visibility.Visible;
            MinutesBox.Visibility = Visibility.Visible;
            SecondsBox.Visibility = Visibility.Visible;
            referencesText.Visibility = Visibility.Collapsed;
            NextImageButton.Visibility = Visibility.Collapsed;
            PreviousImageButton.Visibility= Visibility.Collapsed;

            var timePassed = TimeOnMars.calculateTimeOnMars(d1, d2);

            aboutText.Text = "Perseverance has been on Mars for:";
            DaysBox.Text = $"{timePassed.Days} Days";
            HoursBox.Text = $"{timePassed.Hours} Hours";
            MinutesBox.Text = $"{timePassed.Minutes} Minutes";
            SecondsBox.Text = $"{timePassed.Seconds} Seconds";

        }
        public async void Home_Click(object sender, RoutedEventArgs e)
        {
            string newLine = Environment.NewLine;
            aboutText.Visibility= Visibility.Collapsed;
            roverText.Visibility = Visibility.Visible;
            RoverImage.Visibility= Visibility.Visible;
            HomeButton.Visibility = Visibility.Collapsed;
            DaysBox.Visibility = Visibility.Hidden;
            referencesText.Visibility = Visibility.Collapsed;
            PreviousImageButton.Visibility = Visibility.Visible;
            NextImageButton.Visibility = Visibility.Visible;
            roverText.Visibility = Visibility.Visible;

            pageList = await ImageLoader.CurrentPage(currentPageNumber);
            roverText.Text = $"Image {pageList[arrayObjectNumber].id} was taken by {pageList[arrayObjectNumber].rover.name} on the Earth date {pageList[arrayObjectNumber].earth_date} and Martian sol: {pageList[arrayObjectNumber].sol} for this rover." + newLine + $"This rover is currently {pageList[arrayObjectNumber].rover.status}.";
            var uriSource = new Uri(pageList[arrayObjectNumber].img_src, UriKind.Absolute);
            RoverImage.Source = new BitmapImage(uriSource);

        }
        public async void Reference_Click(object sender, RoutedEventArgs e)
        {
            string newLine = Environment.NewLine;
            RoverImage.Visibility= Visibility.Collapsed;
            aboutText.Visibility = Visibility.Collapsed;
            roverText.Visibility = Visibility.Collapsed;
            HomeButton.Visibility = Visibility.Visible;
            referencesText.Visibility = Visibility.Visible;
            DaysBox.Visibility = Visibility.Collapsed;
            HoursBox.Visibility = Visibility.Collapsed;
            MinutesBox.Visibility = Visibility.Collapsed;
            SecondsBox.Visibility = Visibility.Collapsed;
            PreviousImageButton.Visibility = Visibility.Collapsed;
            NextImageButton.Visibility = Visibility.Collapsed;

            referencesText.Text = "To get your own key for this NASA API or others you can visit their website here:" +newLine + "https://api.nasa.gov/" + newLine + "    "
                + newLine + "This API is maintained by Chris Cerami, you can find more information here:" +newLine + "https://github.com/chrisccerami/mars-photo-api" +newLine + "    "
                + newLine + "The font used in this application can be found here:" + newLine + "https://fonts.google.com/specimen/Genos" + newLine + "    "
                + newLine+ "You can find more things I've worked on Here:" + newLine + "https://github.com/Khyrstina"; 

        }

    }
}

