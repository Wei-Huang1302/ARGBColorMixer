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

namespace ColorMixer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //minimum and maximum bytes of colors;
        const byte COLOR_BYTE_MAX = (byte)255;
        const byte COLOR_BYTE_MIN = (byte)0;
        private byte red = 0;
        private byte green = 0;
        private byte blue = 0;
        private int checkpoint = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        //switch between standard and customized to enable or disable each function
        private void Standard_Checked(object sender, RoutedEventArgs e)
        {
            FirstColor.IsEnabled = true;
            SecondColor.IsEnabled = true;
            AlphaRedStackpanel.IsEnabled = false;
            AlphaRedDisplay.IsEnabled = false;
            GreenBlueStackpanel.IsEnabled = false;
            GreenBlueDisplay.IsEnabled = false;
        }
        private void Custom_Checked(object sender, RoutedEventArgs e)
        {
            AlphaRedStackpanel.IsEnabled = true;
            AlphaRedDisplay.IsEnabled = true;
            GreenBlueStackpanel.IsEnabled = true;
            GreenBlueDisplay.IsEnabled = true;
            FirstColor.IsEnabled = false;
            SecondColor.IsEnabled = false;
        }
        //adjusting sliders will show selected colors for preview;
        private void AlphaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            AlphaDisplay.Fill = new SolidColorBrush(Color.FromArgb((byte)AlphaSlider.Value, COLOR_BYTE_MIN, COLOR_BYTE_MIN, COLOR_BYTE_MIN));
        }
        private void RedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RedDisplay.Fill = new SolidColorBrush(Color.FromArgb(COLOR_BYTE_MAX, (byte)RedSlider.Value, COLOR_BYTE_MIN, COLOR_BYTE_MIN));
        }
        private void GreenSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GreenDisplay.Fill = new SolidColorBrush(Color.FromArgb(COLOR_BYTE_MAX, COLOR_BYTE_MIN, (byte)GreenSlider.Value, COLOR_BYTE_MIN));
        }
        private void BlueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            BlueDisplay.Fill = new SolidColorBrush(Color.FromArgb(COLOR_BYTE_MAX, COLOR_BYTE_MIN, COLOR_BYTE_MIN, (byte)BlueSlider.Value));
        }
        //click mix button will do mixing function
        private void BtnMix_Click(object sender, RoutedEventArgs e)
        {
            red = 0;
            green = 0;
            blue = 0;
            checkpoint = 0;
            if (Standard.IsChecked == true)
            {
                if (FirstRed.IsChecked == true || SecondRed.IsChecked == true)
                {
                    red = COLOR_BYTE_MAX; checkpoint++;
                }
                if (FirstGreen.IsChecked == true || SecondGreen.IsChecked == true)
                {
                    green = COLOR_BYTE_MAX; checkpoint++;
                }
                if (FirstBlue.IsChecked == true || SecondBlue.IsChecked == true)
                {
                    blue = COLOR_BYTE_MAX; checkpoint++;
                }
                if (checkpoint>=1)
                    ColorMixer.Background = new SolidColorBrush(Color.FromArgb(COLOR_BYTE_MAX, red, green, blue));
                else
                    MessageBox.Show("Please select one color from each set", "Reminder", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Custom.IsChecked == true)
            {
                ColorMixer.Background = new SolidColorBrush(Color.FromArgb((byte)AlphaSlider.Value, (byte)RedSlider.Value, (byte)GreenSlider.Value, (byte)BlueSlider.Value));
            }
        }
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            //Reset everything!
            AlphaSlider.Value = AlphaSlider.Minimum;
            RedSlider.Value = RedSlider.Minimum;
            BlueSlider.Value = BlueSlider.Minimum;
            GreenSlider.Value = GreenSlider.Minimum;
            AlphaDisplay.Fill = new SolidColorBrush(Color.FromArgb(COLOR_BYTE_MIN, COLOR_BYTE_MIN, COLOR_BYTE_MIN, COLOR_BYTE_MIN));
            RedDisplay.Fill = new SolidColorBrush(Color.FromArgb(COLOR_BYTE_MIN, COLOR_BYTE_MIN, COLOR_BYTE_MIN, COLOR_BYTE_MIN));
            GreenDisplay.Fill = new SolidColorBrush(Color.FromArgb(COLOR_BYTE_MIN, COLOR_BYTE_MIN, COLOR_BYTE_MIN, COLOR_BYTE_MIN));
            BlueDisplay.Fill = new SolidColorBrush(Color.FromArgb(COLOR_BYTE_MIN, COLOR_BYTE_MIN, COLOR_BYTE_MIN, COLOR_BYTE_MIN));
            ColorMixer.Background = new SolidColorBrush(Color.FromArgb(COLOR_BYTE_MIN, COLOR_BYTE_MIN, COLOR_BYTE_MIN, COLOR_BYTE_MIN));
            FirstRed.IsChecked = false;
            FirstGreen.IsChecked = false;
            FirstBlue.IsChecked = false;
            SecondRed.IsChecked = false;
            SecondGreen.IsChecked = false;
            SecondBlue.IsChecked = false;
            FirstColor.IsEnabled = false;
            SecondColor.IsEnabled = false;
            AlphaRedStackpanel.IsEnabled = false;
            AlphaRedDisplay.IsEnabled = false;
            GreenBlueStackpanel.IsEnabled = false;
            GreenBlueDisplay.IsEnabled = false;
            Standard.IsChecked = false;
            Custom.IsChecked = false;
        }
    }
}
