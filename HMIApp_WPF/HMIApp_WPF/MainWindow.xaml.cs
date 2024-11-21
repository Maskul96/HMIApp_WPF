using LiveCharts;
using LiveCharts.Wpf;
using System.ComponentModel;
using System.Windows;
using System.Collections.Generic;
using LiveCharts.Wpf.Charts.Base;
using System.Windows.Threading;
using System.Globalization;
using HMIApp_WPF.Resources;
using System.Windows.Controls;

namespace HMIApp_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static CultureInfo CurrentCulture { get; set; } = CultureInfo.CurrentCulture;
        public ChartValues<LiveCharts.Defaults.ObservablePoint> MyValues { get; set; }

        public MainWindow()
        {
            InitializeComponent();


            // Wartości X i Y
            var xValues = new List<double> { 1, 2, 3, 4, 5 };
            var yValues = new List<double> { 3, 5, 7, 4, 6 };

            // Łączenie X i Y w punkty (pary X, Y)
            var points = xValues.Zip(yValues, (x, y) => new { X = x, Y = y });

            // Przekształcanie punktów do formatu, który rozumie LiveCharts 0.9.7
            var chartValues = new ChartValues<LiveCharts.Defaults.ObservablePoint>();
            foreach (var point in points)
            {
                chartValues.Add(new LiveCharts.Defaults.ObservablePoint(point.X, point.Y));
            }

            // Tworzenie serii z danymi
            MyValues = chartValues;

            // Ustawienie DataContext
            DataContext = this;

        }

        public void ChangeLanguage(string languageCode)
        {
            var culture = new CultureInfo(languageCode);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            CurrentCulture = culture;

            // Zresetuj bindingi, aby odświeżyć widok
            var oldWindow = Application.Current.MainWindow;
            Application.Current.MainWindow = null;
            Application.Current.MainWindow = oldWindow;
        }

        private void OnLanguageChangeButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedLanguage = "pl"; // lub "pl", w zależności od wyboru użytkownika
            ChangeLanguage(selectedLanguage);
        }
    }
    
}