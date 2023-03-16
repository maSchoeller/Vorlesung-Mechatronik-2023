using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
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
        private readonly Button[,] _fields;

        public MainWindow()
        {
            InitializeComponent();

            _fields = new Button[10, 10];
            _gameLoop = new GameLoop();
            var player = new RandomPlayer();
            var wpfPlayer = new WpfPlayer();
            _gameLoop.Start(player, new[] { 3, 3, 2, 2, 4, 4, 2, 1, 1 });

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    var border = new Button
                    {
                        Background = new SolidColorBrush(Colors.Blue)
                    };

                    border.Click += Border_Click;
                    Grid.SetColumn(border, x);
                    Grid.SetRow(border, y);
                    GameBoardGrid.Children.Add(border);
                    _fields[x, y] = border;
                }
            }
            while (!_gameLoop.PlayRound())
            {
            }
            PrintGameBoard();

        }

        private void Border_Click(object sender, RoutedEventArgs e)
        {
            if (sender is UIElement uiE)
            {
                var x = Grid.GetColumn(uiE);
                var y = Grid.GetRow(uiE);

            }
        }

        private void PrintGameBoard()
        {
            var board = _gameLoop.GameBoard as GameBoard;
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    var color = board[x, y] switch
                    {
                        { FieldType: FieldType.Water, IsShot: false } => Colors.Blue,
                        { FieldType: FieldType.Water, IsShot: true } => Colors.DarkGray,
                        { FieldType: FieldType.Ship, IsShot: false } => Colors.Green,
                        { FieldType: FieldType.Ship, IsShot: true } => Colors.DarkRed,
                        _ => throw new InvalidOperationException()
                    };
                    _fields[x, y].Background = new SolidColorBrush(color);
                }
            }
        }
    }

    public class WpfPlayer : IPlayer
    {
        public Shoot ShootRound(IReadOnlyGameBoard board)
        {
            //TODO..
            return new Shoot(0,0);
        }
    }
}
