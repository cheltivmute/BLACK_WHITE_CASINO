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
using System.Windows.Shapes;

namespace BLACKWHITECASINO.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AcceptPasswordWindow.xaml
    /// </summary>
    public partial class AcceptPasswordWindow : Window
    {
        public AcceptPasswordWindow()
        {
            InitializeComponent();
        }

        private void acceptPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).PasswordText = ((PasswordBox)sender).Password; }
        }
    }
}
