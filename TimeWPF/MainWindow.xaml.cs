using System;
using System.Collections.Generic;
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
using System.Timers;
using TimeProject;

namespace TimeWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Time simpleClockTime = new Time(0,0,0);
        Timer simpleClockUpdateTimer = new Timer();

        Time timeTP1 = new Time(0, 0, 0);
        Time timeTP2 = new Time(0, 0, 0);

        TimePeriod TimeFromTP = new TimePeriod("0000:00:00");
        public MainWindow()
        {
            InitializeComponent();
            simpleClockUpdateTimer.AutoReset = true;
            simpleClockUpdateTimer.Interval = 1000;
            simpleClockUpdateTimer.Enabled = true;
            simpleClockUpdateTimer.Elapsed += SimpleClockUpdate;
            simpleClockUpdateTimer.Start();
        }

        private void SimpleClockUpdate(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                simpleClockTime += new Time(0, 0, 1);
                SimpleClockValueLabel.Content = simpleClockTime.ToString();
            });            
        }

        private void TimePeriodSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            //tp1 = new TimePeriod((short)TimePeriodSlider.Value, (short)TimePeriodSlider_Mins.Value, (short)TimePeriodSlider_Sec.Value);
            timeTP1 = new Time((byte)TimePeriodSlider.Value, (byte)TimePeriodSlider_Mins.Value, (byte)TimePeriodSlider_Sec.Value);
            TimePeriod1ValueLabel.Content = timeTP1.ToString();

            try
            {
                TimeFromTP = new TimePeriod(timeTP2, timeTP1);
                TimeFromTPS_Label.Content = TimeFromTP.ToString();
            }
            catch(ArithmeticException ao)
            {
                TimeFromTPS_Label.Content = "[Wyjątek] okres czasu nie może być ujemny.";
            }
            
        }

        private void TimePeriod2_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            //tp2 = new TimePeriod((short)TimePeriod2Slider_Hours.Value, (short)TimePeriod2Slider_Mins.Value, (short)TimePeriod2Slider_Sec.Value);
            timeTP2 = new Time((byte)TimePeriod2Slider_Hours.Value, (byte)TimePeriod2Slider_Mins.Value, (byte)TimePeriod2Slider_Sec.Value);
            TimePeriod2Value_Label.Content = timeTP2.ToString();

            try
            {
                TimeFromTP = new TimePeriod(timeTP2, timeTP1);
                TimeFromTPS_Label.Content = TimeFromTP.ToString();
            }
            catch (ArithmeticException ao)
            {
                TimeFromTPS_Label.Content = "[Wyjątek] okres czasu nie może być ujemny.";
            }
        }

    }
}
