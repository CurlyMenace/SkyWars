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

namespace BattleduckGalactica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameCharacters.Player NewPlayer = new GameCharacters.Player();

        Dictionary<string, GameCharacters.Quacklon> Quackers = new Dictionary<string, GameCharacters.Quacklon>();
 
        int XGridSize = 4;
        int YGridSize = 4;
        int IterateTheName = 0;
        int IterateEnemies = 0;

        public MainWindow()
        {
            InitializeComponent();
            CreateAGrid();
            NewPlayer.MakeMove();
            DisplayPlayer();
        }

        private void CreateAGrid()
        {


            for(int y = 0; y < YGridSize; y++)
            {
                SpehhsGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for(int x = 0; x < XGridSize; x++)
            {
                SpehhsGrid.RowDefinitions.Add(new RowDefinition());
            }

        }
        private void ClearGrid(int xval, int yval)
        {
            //Image CellToRemove = (Image)SpehhsGrid.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == xval && Grid.GetColumn(e) == yval);

            //SpehhsGrid.Children.Remove(CellToRemove);
            var Ground = System.Reflection.Assembly.GetExecutingAssembly().Location + "\\..\\..\\..\\Resources\\Background.png";



            Image EmptyImage = new Image();
            EmptyImage.Source = new BitmapImage(new Uri(Ground));
            EmptyImage.Name = "Ground" + IterateTheName;
            Grid.SetColumn(EmptyImage, xval);
            Grid.SetRow(EmptyImage, yval);
            SpehhsGrid.Children.Add(EmptyImage);
            IterateTheName++;
        }

        private void DrawEnemy(string dir, int x, int y)
        {


            Image Enemy = new Image();
            Enemy.Source = new BitmapImage(new Uri(dir));
            Enemy.Name = "Enemy" + IterateEnemies;
            Grid.SetColumn(Enemy, x);
            Grid.SetRow(Enemy, y);
            SpehhsGrid.Children.Add(Enemy);
            IterateEnemies++;


        }

        

        private void SpawnEnemies()
        {
            var BattleCruiser = System.Reflection.Assembly.GetExecutingAssembly().Location + "\\..\\..\\..\\Resources\\Battlecruiser.png";
            var BattleStar = System.Reflection.Assembly.GetExecutingAssembly().Location + "\\..\\..\\..\\Resources\\Battlestar.PNG";
            var Raider = System.Reflection.Assembly.GetExecutingAssembly().Location + "\\..\\..\\..\\Resources\\Raider.png";
            GameCharacters.Quacklon Quack = new GameCharacters.Quacklon();
            Quack.SetQuacklonDefaultPos();
            Quack.SetShipType();
            if(Quack.EnemyShipType == "Quacklon Battlecruiser")
            {

                int id = Quackers.Count + 1;
                Quack.ID = "Quack" + id;
                Quackers.Add(Quack.ID, Quack);
                DrawEnemy(BattleCruiser, 0, 0);
            }

            else if(Quack.EnemyShipType == "Quacklon Battlestar")
            {
                int id = Quackers.Count + 1;
                Quack.ID = "Quack" + id; 
                Quackers.Add(Quack.ID, Quack);
                DrawEnemy(BattleStar, 0, 0);
            }

            else if(Quack.EnemyShipType == "Quacklon Raider")
            {
                int id = Quackers.Count + 1;
                Quack.ID = "Quack" + id; 
                Quackers.Add(Quack.ID, Quack);
                DrawEnemy(Raider, 0, 0);
            }
     
        }
        private void DisplayEnemy(GameCharacters.Quacklon Quack)
        {
            var BattleCruiser = System.Reflection.Assembly.GetExecutingAssembly().Location + "\\..\\..\\..\\Resources\\Battlecruiser.png";
            var BattleStar = System.Reflection.Assembly.GetExecutingAssembly().Location + "\\..\\..\\..\\Resources\\Battlestar.PNG";
            var Raider = System.Reflection.Assembly.GetExecutingAssembly().Location + "\\..\\..\\..\\Resources\\Raider.png";
         
            
            if(Quack.EnemyShipType == "Quacklon Battlecruiser")
            {
                DrawEnemy(BattleCruiser, Quack.CurrentLocation.XCoordinate, Quack.CurrentLocation.YCoordinate);
            }

            else if(Quack.EnemyShipType == "Quacklon Battlestar")
            {
                DrawEnemy(BattleStar, Quack.CurrentLocation.XCoordinate, Quack.CurrentLocation.YCoordinate);
            }

            else if(Quack.EnemyShipType == "Quacklon Raider")
            {
                DrawEnemy(Raider, Quack.CurrentLocation.XCoordinate, Quack.CurrentLocation.YCoordinate);
            }
        }
        private void DisplayPlayer()
        {
            var PlayerTile = System.Reflection.Assembly.GetExecutingAssembly().Location + "\\..\\..\\..\\Resources\\battleduck.png";

            int x = NewPlayer.CurrentLocation.XCoordinate;
            int y = NewPlayer.CurrentLocation.YCoordinate;
            Image Player = new Image();
            Player.Source = new BitmapImage(new Uri(PlayerTile));
            Player.Name = "Player";
            Grid.SetColumn(Player, x);
            Grid.SetRow(Player, y);
            SpehhsGrid.Children.Add(Player);
        }
        private void PlayerMovement()
        {
            int x = NewPlayer.CurrentLocation.XCoordinate;
            int y = NewPlayer.CurrentLocation.YCoordinate;
            ClearGrid(x, y);
            NewPlayer.MakeMove();
            DisplayPlayer();
            NewPlayer.MoveCounter = NewPlayer.MoveCounter + 1;
        }
        private void EnemyMovement()
        {
            try
            {
                foreach (KeyValuePair<string, GameCharacters.Quacklon> Quack in Quackers)
                {
                    int x = Quack.Value.CurrentLocation.XCoordinate;
                    int y = Quack.Value.CurrentLocation.YCoordinate;
                    ClearGrid(x, y);
                    var last = Quackers.Values.Last();

                    if (Quack.Value != last)
                    {
                        Quack.Value.MakeMove();
                        DisplayEnemy(Quack.Value);
                    }
               
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void DefensiveModeBtn_Click(object sender, RoutedEventArgs e)
        {
            NewPlayer.SetShipMode(0);
            ModeBox.Text = NewPlayer.PlayerMode;
        }

        private void OffensiveModeBtn_Click(object sender, RoutedEventArgs e)
        {
            NewPlayer.SetShipMode(1);
            ModeBox.Text = NewPlayer.PlayerMode;
        }

        private void MoveBtn_Click(object sender, RoutedEventArgs e)
        {
            bool CanProceed = false;
            PlayerMovement();
            if (NewPlayer.MoveCounter % 2 == 1)
            {
                SpawnEnemies();
                CanProceed = true;
            }
            if (CanProceed == true)
            {
                EnemyMovement();
            }
        }
    }
}
