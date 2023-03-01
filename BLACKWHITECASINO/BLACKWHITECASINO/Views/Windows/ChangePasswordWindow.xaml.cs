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
    /// Логика взаимодействия для ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void forgotqwe_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = "";
            foreach (var el in forgotqwe.Text)
            {
                if (el >= '0' && el <= '9' && str.Length >= 0 && str.Length < 4)
                {
                    str += el;

                }
            }
            forgotqwe.Text = str;
        }
    }
}
