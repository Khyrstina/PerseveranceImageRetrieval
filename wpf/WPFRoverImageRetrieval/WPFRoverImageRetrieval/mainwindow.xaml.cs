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

namespace WPFRoverImageRetrieval
{
    /// <summary>
    /// Interaction logic for Perseverance.xaml
    /// </summary>
    public partial class Perseverance : Page
    {
        private int arrayObjectNumber = 0;
        private int currentPageNumber = 1;
        private int minPageNumber = 1;
        private PerseveranceResultModel.Latest_Photos[] pageList;
        public Perseverance()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            PreviousImageButton.IsEnabled = false;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
             Perseverance_Click(sender, e);
            pageList = await ImageLoader.CurrentPage(currentPageNumber);
        }


        public async void Perseverance_Click(object sender, RoutedEventArgs e)
        {

            var pageList = await ImageLoader.CurrentPage(currentPageNumber);


            //use +newLine+ to make a new line in a TextBox
            string newLine = Environment.NewLine;
            roverText.Text = $"Image {pageList[arrayObjectNumber].id} was taken by {pageList[arrayObjectNumber].rover.name} on the Earth date {pageList[0].earth_date} and Martian sol: {pageList[arrayObjectNumber].sol} for this rover." + newLine + $"This rover is currently {pageList[arrayObjectNumber].rover.status}.";

            var uriSource = new Uri(pageList[arrayObjectNumber].img_src, UriKind.Absolute);
            RoverImage.Source = new BitmapImage(uriSource);
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
                    arrayObjectNumber = pageList.Length;
                    roverText.Text = $"Image {pageList[arrayObjectNumber].id} was taken by {pageList[arrayObjectNumber].rover.name} on the Earth date {pageList[arrayObjectNumber].earth_date} and Martian sol: {pageList[arrayObjectNumber].sol} for this rover." + newLine + $"This rover is currently {pageList[arrayObjectNumber].rover.status}.";
                    var uriSource = new Uri(pageList[arrayObjectNumber].img_src, UriKind.Absolute);
                    RoverImage.Source = new BitmapImage(uriSource);
                }
        }




            private async void Next_Click(object sender, RoutedEventArgs e)
            {
           
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
            if (currentPageNumber >= 2)
            {
                PreviousImageButton.IsEnabled = true;
            }
            else
            {
                PreviousImageButton.IsEnabled= false;
            }
        }
      }
   }

