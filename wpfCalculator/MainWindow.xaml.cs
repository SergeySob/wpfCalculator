using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
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

namespace wpfCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement el in GroupButton.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
            }
        }

        private void ButtonClick(Object sender, RoutedEventArgs e)
        {

            try
            {
                string textButton = ((Button)e.OriginalSource).Content.ToString();

                if (textButton == "C")
                {
                    tb_calc.Clear();
                }
                else if (textButton == "X")
                {
                    tb_calc.Text = tb_calc.Text.Substring(0, tb_calc.Text.Length - 1);
                }
                else if (textButton == "=")
                {
                    tb_calc.Text = new DataTable().Compute(tb_calc.Text, null).ToString();
                }
                else tb_calc.Text += textButton;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
