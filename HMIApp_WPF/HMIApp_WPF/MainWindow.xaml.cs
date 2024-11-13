using LiveCharts;
using LiveCharts.Wpf;
using System.ComponentModel;
using System.Windows;
using System.Collections.Generic;
using LiveCharts.Wpf.Charts.Base;
using System.Windows.Threading;

namespace HMIApp_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

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
    }
    
}