using ScottPlot.WPF;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HMIApp_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            double[] xs = { 1, 2, 3, 4, 5 };
            double[] ys = { 1, 4, 9, 16, 25 };

            var scatter = wpfPlot.Plot.Add.Scatter(xs, ys);
            //scatter.Color = System.Drawing.Color.Blue; // Ustaw kolor linii na niebieski
            //wpfPlot.Plot.Grid(enable: true, color: System.Drawing.Color.LightGray, lineStyle: ScottPlot.LineStyle.Dash);

            wpfPlot.Refresh();
        }
    }
}