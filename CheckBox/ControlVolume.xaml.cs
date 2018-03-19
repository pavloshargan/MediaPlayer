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
using System.Threading;
namespace CheckBox
{
    /// <summary>
    /// Interaction logic for ControlVolume.xaml
    /// </summary>
    public partial class ControlVolume : UserControl
    {
        public event EventHandler VolChange;
        public event EventHandler VolClick;
        public static readonly DependencyProperty ValueOfSliderProperty  = DependencyProperty.Register("ValueOfSlider", typeof(double), typeof(ControlVolume));
        public static readonly DependencyProperty value_before_muted_property = DependencyProperty.Register("value_before_muted", typeof(double), typeof(ControlVolume));
        public static readonly DependencyProperty Muted_property = DependencyProperty.Register("Muted", typeof(bool), typeof(ControlVolume));
        public double ValueOfSlider
        {
            get { return(double)GetValue(ValueOfSliderProperty); }
            set {  SetValue(ValueOfSliderProperty,value); }
        }
        public double value_before_muted
        {
            get { return (double)GetValue(value_before_muted_property); }
            set { SetValue(value_before_muted_property, value); }
        }
        public  bool  Muted
        {
            get { return (bool)GetValue(Muted_property); }
            set { SetValue(Muted_property, value); }
        }
        public ControlVolume()
        {
            InitializeComponent();
            ValueOfSlider = 50;
           value_before_muted = VolSl.Value;
            Muted = false;
        }
        private void VolumeClick(object sender, EventArgs e)
        {
            if (Muted)
                vol.Source = new BitmapImage(new Uri(@"C:\Users\Poul\Downloads\PlayerImages\unnamed.png"));
            else
            vol.Source = new BitmapImage(new Uri(@"C:\Users\Poul\Downloads\PlayerImages\unnamed1.png"));

            VolClick(this, EventArgs.Empty);
        }
        private void VC(object sender, RoutedPropertyChangedEventArgs<double> e)
        { 
            ValueOfSlider = VolSl.Value;
            if(VolChange!=null)
            VolChange(this, EventArgs.Empty);
        }
    }
}
