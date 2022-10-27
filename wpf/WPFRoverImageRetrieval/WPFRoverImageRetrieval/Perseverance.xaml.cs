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

namespace WPFRoverImageRetrieval
    {
    /// <summary>
    /// Interaction logic for Perseverance.xaml
    /// </summary>
    public partial class Perseverance : Page
        {
        private int minNumber = 1;
        private int currentNumber = 1;

        public Perseverance()
            {
            InitializeComponent();
            ApiHelper.InitializeClient();

            }

        private async Task LoadPage(int pageNumber = 1)
            {
            var image = await ImageLoader.GetImage(pageNumber);

            if (pageNumber == 1)
                {
                minNumber == image.page;
                }
            currentNumber = image.page;
            var uriSource = new Uri(image.page, UriKind.Absolute);
            imagePage.Source = new BitmapImage(uriSource); 
            }
        }
    }
