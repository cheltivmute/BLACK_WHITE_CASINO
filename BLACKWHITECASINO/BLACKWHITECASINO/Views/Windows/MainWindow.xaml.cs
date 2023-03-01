using BLACKWHITECASINO.ViewModels;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BLACKWHITECASINO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private static readonly MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        ////public MainWindowViewModel mwVM = mainWindowViewModel;
        //CircleEase easingFunction = new CircleEase();

        //private void Spin_Click(object sender, RoutedEventArgs e)
        //{
        //    ////анимация вращения
        //    //DoubleAnimation spin = new DoubleAnimation();
        //    //spin.From = mainWindowViewModel.AngleFrom;
        //    //spin.To = mainWindowViewModel.AngleTo;
        //    //spin.Duration = TimeSpan.FromSeconds(5);
        //    //easingFunction.EasingMode = EasingMode.EaseInOut;
        //    //spin.EasingFunction = easingFunction;
        //    //RotateImage.BeginAnimation(RotateTransform.AngleProperty, spin);
        //}
    }
}
