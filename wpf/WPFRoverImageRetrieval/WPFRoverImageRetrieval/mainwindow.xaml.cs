using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ThisisaLibrary;

namespace WPFRoverImageRetrieval
{

    public partial class Perseverance : Window
    {

        public static System.DateTime d1 = new System.DateTime(2021, 02, 18, 20, 55, 0);
        public static System.DateTime d2 = System.DateTime.UtcNow;
        public static int sol = DaysToSols.solsSearched(d1, d2);
        private int arrayObjectNumber = 0;
        private PerseveranceResultModel.Photos[] pageList;
        private int currentSolNumber = sol;
        private const int maxImagesPerSol = 20;

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
            pageList = await ImageLoader.CurrentSol(currentSolNumber);
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
            pageList = await ImageLoader.CurrentSol(currentSolNumber);
            string newLine = Environment.NewLine;
            if (arrayObjectNumber >= 1 && pageList.Length > 0)
            {
                roverText.Text = $"Image {pageList[arrayObjectNumber].id} was taken by {pageList[arrayObjectNumber].rover.name} on the Earth date {pageList[arrayObjectNumber].earth_date} and Martian sol: {pageList[arrayObjectNumber].sol} for this rover." + newLine + $"This rover is currently {pageList[arrayObjectNumber].rover.status}.";
                var uriSource = new Uri(pageList[arrayObjectNumber].img_src, UriKind.Absolute);
                RoverImage.Source = new BitmapImage(uriSource);
                arrayObjectNumber -= 1;
            }
            else 
            {
                currentSolNumber += 1;
                pageList = await ImageLoader.CurrentSol(currentSolNumber);

                if (pageList.Length > 0)
                {
                    // Checks if pageList is less than 20, if less than 20 the length is that length, if it is longer then the length is 20 
                    arrayObjectNumber = pageList.Length < maxImagesPerSol ? pageList.Length : maxImagesPerSol;
                    roverText.Text = $"Image {pageList[arrayObjectNumber].id} was taken by {pageList[arrayObjectNumber].rover.name} on the Earth date {pageList[arrayObjectNumber].earth_date} and Martian sol: {pageList[arrayObjectNumber].sol} for this rover." + newLine + $"This rover is currently {pageList[arrayObjectNumber].rover.status}.";
                    var uriSource = new Uri(pageList[arrayObjectNumber].img_src, UriKind.Absolute);
                    RoverImage.Source = new BitmapImage(uriSource);
                }
            }
            if (currentSolNumber == sol && arrayObjectNumber == 0)
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
            pageList = await ImageLoader.CurrentSol(currentSolNumber);
            string newLine = Environment.NewLine;
            if (arrayObjectNumber < maxImagesPerSol && pageList.Length > 0)
            {
                roverText.Text = $"Image {pageList[arrayObjectNumber].id} was taken by {pageList[arrayObjectNumber].rover.name} on the Earth date {pageList[arrayObjectNumber].earth_date} and Martian sol: {pageList[arrayObjectNumber].sol} for this rover." + newLine + $"This rover is currently {pageList[arrayObjectNumber].rover.status}.";
                var uriSource = new Uri(pageList[arrayObjectNumber].img_src, UriKind.Absolute);
                RoverImage.Source = new BitmapImage(uriSource);
                arrayObjectNumber += 1;
            }

            else
            {
                arrayObjectNumber = 0;
                currentSolNumber -= 1;

            }
            if (currentSolNumber == sol && arrayObjectNumber == 0)
            {
                PreviousImageButton.IsEnabled = false;
            }
            else
            {
                PreviousImageButton.IsEnabled = true;
            }
        }

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

        System.DateTime d2 = System.DateTime.UtcNow;

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

            pageList = await ImageLoader.CurrentSol(currentSolNumber);
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

