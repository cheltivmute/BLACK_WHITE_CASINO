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
    /// Логика взаимодействия для CountWindow.xaml
    /// </summary>
    public partial class CountWindow : Window
    {
        public CountWindow()
        {
            InitializeComponent();
        }

        private void countText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (countText.Text == "99999")
                countText.Clear();
            string str = "";
            foreach (var el in countText.Text)
            {
                if (el >= '0' && el <= '9' && str.Length >= 0 && str.Length < 5)
                {
                    str += el;

                }
            }
            countText.Text = str;
        }
    }
}
