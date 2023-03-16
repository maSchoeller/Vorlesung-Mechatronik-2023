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

using BattleShip.Core;

namespace BattleShip.WpfHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GameLoop _gameLoop;
        private readonly Border[,] _fields;

        public MainWindow()
        {
            InitializeComponent();

            _fields = new Border[10, 10];
            _gameLoop = new GameLoop();

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    var border = new Border
                    {
                        Background = new SolidColorBrush(Colors.Blue)
                    };

                    Grid.SetColumn(border, x);
                    Grid.SetRow(border, y);
                    GameBoardGrid.Children.Add(border);
                    _fields[x, y] = border;
                }
            }

        }
    }
}
