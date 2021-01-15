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

namespace TicTacToe
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

        public byte MatrixDimensions { get; private set; }
        private readonly List<List<bool?>> matrix = new List<List<bool?>>();
        private bool player1 = true;

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            GameStartLogic();
        }

        public void GameStartLogic()
        {
            var childWindow = new AskDimensions(this);
            childWindow.Show();
            childWindow.Focus();
        }

        public void GotDimension(byte dimensions)
        {
            this.MatrixDimensions = dimensions;
            for (var col = 0; col < MatrixDimensions; col++)
            {
                var temp = new List<bool?>();
                for (var row = 0; row < MatrixDimensions; row++)
                {
                    temp.Add(null);    
                }
                matrix.Add(temp);
            }
            RenderMap();
        }

        private void RenderMap()
        {
            for (var col = 0; col < MatrixDimensions; col++)
            {
                GameContainer.ColumnDefinitions.Add(new ColumnDefinition());
                for (var row = 0; row < MatrixDimensions; row++)
                {
                    GameContainer.RowDefinitions.Add(new RowDefinition());
                    var temp = new Button
                    {
                        Content = "  ",
                        Padding = new Thickness(6,0,6,0)
                    };
                    var row2 = row;
                    var col2 = col;
                    temp.Click += (sender, e) => UserClick(temp, row2, col2);
                    GameContainer.Children.Add(temp);
                    Grid.SetRow(temp, row);
                    Grid.SetColumn(temp, col);
                }
            }
        }

        private void UserClick(Button btn, int row, int col)
        {
            btn.Content = player1 ? "X" : "O";
            btn.IsEnabled = false;
            matrix[col][row] = player1;
            player1 = !player1;
            CheckWin();
        }

        private void CheckWin()
        {
            CheckRow();
            CheckCol();
            CheckDiagonal();
            CheckInvDiagonal();
        }

        private void CheckRow()
        {
            for (int col = 0; col < MatrixDimensions; col++)
            {
                var rowSum = 0;
                for (int row = 0; row < MatrixDimensions; row++)
                {
                    switch (matrix[row][col])
                    {
                        case true:
                            rowSum++;
                            break;
                        case false:
                            rowSum--;
                            break;
                    }
                }

                if (rowSum == MatrixDimensions)
                    MessageBox.Show("The winner is Player1!", "It's a Winner!", MessageBoxButton.OK, MessageBoxImage.Information);
                else if(rowSum == -MatrixDimensions)
                    MessageBox.Show("The winner is Player2!", "It's a Winner!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
        private void CheckCol()
        {
            for (int col = 0; col < MatrixDimensions; col++)
            {
                var colSum = 0;
                for (int row = 0; row < MatrixDimensions; row++)
                {
                    switch (matrix[col][row])
                    {
                        case true:
                            colSum++;
                            break;
                        case false:
                            colSum--;
                            break;
                    }
                }

                if (colSum == MatrixDimensions)
                    MessageBox.Show("The winner is Player1!", "It's a Winner!", MessageBoxButton.OK, MessageBoxImage.Information);
                else if (colSum == -MatrixDimensions)
                    MessageBox.Show("The winner is Player2!", "It's a Winner!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
        private void CheckDiagonal()
        {
            var sumDiagon = 0;
            for (int i = 0; i < MatrixDimensions; i++)
            {
                switch (matrix[i][i])
                {
                    case true:
                        sumDiagon++;
                        break;
                    case false:
                        sumDiagon--;
                        break;
                }
                
            }
            if (sumDiagon == MatrixDimensions)
                MessageBox.Show("The winner is Player1!", "It's a Winner!", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (sumDiagon == -MatrixDimensions)
                MessageBox.Show("The winner is Player2!", "It's a Winner!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CheckInvDiagonal()
        {
            var sumInvDiagon = 0;
            for (int i = 0; i < MatrixDimensions; i++)
            {
                switch (matrix[MatrixDimensions-1-i][i])
                {
                    case true:
                        sumInvDiagon++;
                        break;
                    case false:
                        sumInvDiagon--;
                        break;
                }

            }
            if (sumInvDiagon == MatrixDimensions)
                MessageBox.Show("The winner is Player1!", "It's a Winner!", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (sumInvDiagon == -MatrixDimensions)
                MessageBox.Show("The winner is Player2!", "It's a Winner!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
