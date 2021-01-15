using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for AskDimensions.xaml
    /// </summary>
    public partial class AskDimensions : Window
    {
        public MainWindow ParentWindow { get; set; }

        public AskDimensions()
        {
            InitializeComponent();
        }

        public AskDimensions(MainWindow mainWindow) : this()
        {
            this.ParentWindow = mainWindow;
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ParentWindow.GotDimension(byte.Parse(inp_Matrix.Text));
            this.Close();
        }
    }
}
