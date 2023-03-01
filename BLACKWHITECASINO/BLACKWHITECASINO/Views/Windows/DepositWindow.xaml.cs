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
    /// Логика взаимодействия для DepositWindow.xaml
    /// </summary>
    public partial class DepositWindow : Window
    {
        public DepositWindow()
        {
            InitializeComponent();
        }

        private void depwit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (depwit.Text == "99999")
                depwit.Clear();
            string str = "";
            foreach (var el in depwit.Text)
            {
                if (el >= '0' && el <= '9' && str.Length >= 0 && str.Length < 5)
                {
                    str += el;

                }
            }
            depwit.Text = str;
        }
    }
}
