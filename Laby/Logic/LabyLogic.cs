using Laby.Renderer;
using MailChimp.Net.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using static Laby.Logic.LabyLogic;


namespace Laby.Logic
{
    public class LabyLogic : IGameModel, IGameControl 
    {
        public enum LabyItem 
        {
           ammunition, trap, player, shield, wall, floor, door, player2, player3,
           player4, player5, player6, player7, player8, playerL, player2L,
            player3L, player4L, player5L, player6L, player7L, player8L, tank, tankR,tankL, crater,award
        }

        public enum Directions
        {
            up, down, left, right
        }
        int ammo;
        bool hasshield;
        int lvlcounter;
        int craterDistance;
       public TimeSpan timeDiff;
        DateTime starttime;
        DateTime endtime;
        public string PlayerName;
        public bool EndOfGame;
        
        public LabyItem[,] GameMatrix { get; set; }

        private int Ammo;

        int IGameModel.ammo
        {
            get { return this.ammo; }
            set { Ammo = value; }
        }
        private bool Shield;

        public bool shield
        {
            get { return this.hasshield; }
            set { this.hasshield= value; }
        }


        private Queue<string> levels;

        public LabyLogic()
        {
            levels = new Queue<string>();
            var lvls = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Levels"),
                "*.lvl");
            foreach (var item in lvls)
            {
                levels.Enqueue(item);
            }
            LoadNext(levels.Dequeue());
            starttime = DateTime.UtcNow;
            
        }
        
        public void GetSound(string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Sounds\", fileName);
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(path);
            player.Play();
        }
        public void Shoot(Key key)
        {
            var coords = WhereAmI();
            int i = coords[0];
            int j = coords[1];
            int old = i;
            int old2 = j;
            if (ammo > 0)
            {

                ammo--;
                //GameMatrix[i, j] = LabyItem.ammunition;
                GetSound("shoot.wav");
                if (key == Key.Down)
                {
                    while (i + 1 < GameMatrix.GetLength(0) && GameMatrix[i + 1, j] != LabyItem.wall && i + 1 < GameMatrix.GetLength(0))
                    {
                        if (GameMatrix[i + 1, j] != LabyItem.door)
                        {
                           
                            i++;
                        }
                        break;
                    }
                    if (i + 1 < GameMatrix.GetLength(0))
                    {
                        GameMatrix[i + 1, j] = LabyItem.floor;
                    }
                }
                else if (key == Key.Up)
                {
                    while (i - 1 < GameMatrix.GetLength(0) && GameMatrix[i - 1, j] != LabyItem.wall && i - 1 > 0 && GameMatrix[i - 1, j]
                         != LabyItem.door)
                    {
                        if (GameMatrix[i - 1, j] != LabyItem.door)
                        {
                            
                            i--;
                        }
                        break;
                    }
                    if (i - 1 < GameMatrix.GetLength(1))
                    {
                        GameMatrix[i - 1, j] = LabyItem.floor;
                    }
                }
                else if (key == Key.Right)
                {
                    while (j + 1 < GameMatrix.GetLength(1) && GameMatrix[i, j + 1] != LabyItem.wall)
                    {
                        if (GameMatrix[i, j + 1] != LabyItem.door)
                        {
                           
                            j++;
                        }
                        break;
                    }
                    if (j + 1 < GameMatrix.GetLength(1))
                    {
                        GameMatrix[i, j + 1] = LabyItem.floor;
                    }

                }
                else if (key == Key.Left)
                {
                    while (j - 1 < GameMatrix.GetLength(1) && GameMatrix[i, j - 1] != LabyItem.wall && j - 1 > 0 && GameMatrix[i, j - 1]
                         != LabyItem.door)
                    {
                        if (GameMatrix[i, j - 1] != LabyItem.door)
                        {
                            
                            j--;
                        }
                        break;
                    }
                    if (j - 1 < GameMatrix.GetLength(1))
                    {
                        GameMatrix[i, j - 1] = LabyItem.floor;
                    }
                }
            }
            

        }
        public void Explode(int i, int j, Directions directions)
        {
            GetSound("explosion.wav");
            if (hasshield == true)
            {
                hasshield = false;
                GameMatrix[i, j] = LabyItem.crater;
            }
            else
            {
                GameMatrix[i, j] = LabyItem.crater;
                if (directions == Directions.down)
                {
                    GameMatrix[i - 1, j] = LabyItem.floor;
                    GameMatrix[1, 1] = LabyItem.player;
                }
               else if (directions == Directions.up)
                {
                    GameMatrix[i + 1, j] = LabyItem.floor;
                    GameMatrix[1, 1] = LabyItem.player;
                }
                else if (directions == Directions.right)
                {
                    GameMatrix[i, j - 1] = LabyItem.floor;
                    GameMatrix[1, 1] = LabyItem.player;
                }
                else if (directions == Directions.left)
                {
                    GameMatrix[i, j + 1] = LabyItem.floor;
                    GameMatrix[1, 1] = LabyItem.player;
                }

            }
        }
        public void Move(Directions direction)
        {
            var coords = WhereAmI();
            int i = coords[0];
            int j = coords[1];
            int old_i = i;
            int old_j = j;
            switch (direction)
            {
                case Directions.up:
                    if (i - 1 >= 0)
                    {
                        i--;
                    }
                    break;
                case Directions.down:
                    if (i + 1 < GameMatrix.GetLength(0))
                    {
                        i++;
                    }
                    break;
                case Directions.left:
                    if (j - 1 >= 0)
                    {
                        j--;
                    }
                    break;
                case Directions.right:
                    if (j + 1 < GameMatrix.GetLength(1))
                    {
                        j++;
                    }
                    break;
                default:
                    break;
            }
            if (GameMatrix[i, j] == LabyItem.floor || GameMatrix[i, j] == LabyItem.crater)
            {
                if (ImWithTank(i, j))
                {
                    ThroughCrater(i, j, old_i, old_j);
                    if (direction is LabyLogic.Directions.left)
                    {
                        GameMatrix[i, j] = LabyItem.tankL;
                        
                    }
                    else 
                    {
                        GameMatrix[i, j] = LabyItem.tankR;
                    }                   
                    
                }
                else if(GameMatrix[i, j] == LabyItem.floor /*&& GameMatrix[i,j]!=LabyItem.tankR && GameMatrix[i,j]!= LabyItem.tankL */|| GameMatrix[i, j] == LabyItem.crater)
                {
                    Random r = new Random();
                    int d = r.Next(1, 9);
                    ThroughCrater(i, j, old_i, old_j);
                    if (direction is LabyLogic.Directions.left)
                    {
                        if (d == 1)
                        {
                            GameMatrix[i, j] = LabyItem.playerL;
                        }
                        else if (d == 2)
                        {
                            GameMatrix[i, j] = LabyItem.player2L;
                        }
                        else if (d == 3)
                        {
                            GameMatrix[i, j] = LabyItem.player3L;
                        }
                        else if (d == 4)
                        {
                            GameMatrix[i, j] = LabyItem.player4L;
                        }
                        else if (d == 5)
                        {
                            GameMatrix[i, j] = LabyItem.player5L;
                        }
                        else if (d == 6)
                        {
                            GameMatrix[i, j] = LabyItem.player6L;
                        }
                        else if (d == 7)
                        {
                            GameMatrix[i, j] = LabyItem.player7L;
                        }
                        else if (d == 8)
                        {
                            GameMatrix[i, j] = LabyItem.player8L;
                        }
                    }
                    else
                    {
                        if (d == 1)
                        {
                            GameMatrix[i, j] = LabyItem.player2;
                        }
                        else if (d == 2)
                        {
                            GameMatrix[i, j] = LabyItem.player3;
                        }
                        else if (d == 3)
                        {
                            GameMatrix[i, j] = LabyItem.player4;
                        }
                        else if (d == 4)
                        {
                            GameMatrix[i, j] = LabyItem.player5;
                        }
                        else if (d == 5)
                        {
                            GameMatrix[i, j] = LabyItem.player6;
                        }
                        else if (d == 6)
                        {
                            GameMatrix[i, j] = LabyItem.player7;
                        }
                        else if (d == 7)
                        {
                            GameMatrix[i, j] = LabyItem.player8;
                        }
                        else if (d == 8)
                        {
                            GameMatrix[i, j] = LabyItem.player;
                        }                     
                    }
                }
            }
            else if (GameMatrix[i, j] == LabyItem.door)
            {
                lvlcounter++;
                //todo level vége
                
                if (levels.Count > 0)
                {
                    LoadNext(levels.Dequeue());
                }

            }
            else if (GameMatrix[i, j] == LabyItem.tank)
            {
                GetAmmo(i, j,old_i,old_j);
            }
            else if (GameMatrix[i, j] == LabyItem.trap)
            {
                if (direction == Directions.down)
                {
                    Explode(i, j,direction);
                }
               else if (direction == Directions.up)
                {
                    Explode(i, j, direction);
                }
                if (direction == Directions.right)
                {
                    Explode(i, j, direction);
                }
                else if (direction == Directions.left)
                {
                    Explode(i, j, direction);
                }
                

            }
            else if (GameMatrix[i, j] == LabyItem.shield)
            {
                GetShield(i, j);
                GameMatrix[old_i, old_j] = LabyItem.floor;
            }
            else if (GameMatrix[i, j] == LabyItem.award)
            {
              
                    endtime = DateTime.UtcNow;
                    timeDiff = endtime - starttime;
                    WriteText();
                EndOfGame = true;
            }
        }

        public void WriteText()
        {

            
            string playerpath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Score\player.txt");
            string palyer = File.ReadAllText(playerpath);
            //double time = Math.Round(double.Parse(timeDiff.ToString()));
            string time = timeDiff.ToString();
            string time2 = "";
            int i = 3;
            while (i < 10)
            {
                time2 += time[i];
                i++;
            }
            string data = palyer + " " + time2;
            string path =System.IO.Path.Combine(Environment.CurrentDirectory, @"Score\data.txt");
            string startdata = File.ReadAllText(path);
            data = startdata + "\r" + data;
            File.WriteAllText(path, data);
        }
        public void GetAmmo(int i, int j, int old_i, int old_j)
        {
            GameMatrix[i, j] = LabyItem.tankR;
            GameMatrix[old_i, old_j] = LabyItem.floor;
            ammo = 4;
            
        }

        public void GetShield(int i, int j)
        {
            GetSound("shield.wav");
            if (ImWithTank(i,j))
            {
                GameMatrix[i, j] = LabyItem.tankL;
            }
            else
            {
                GameMatrix[i, j] = LabyItem.player2;
            }      
            hasshield = true;
            
        }
        public bool ImWithTank(int i, int j)
        {
            if (ammo>0)
            {
                return true;
            }
            return false;
        }
        private int[] WhereAmI()
        {
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    //if (/*GameMatrix[i,j] == LabyItem.player || GameMatrix[i, j] == LabyItem.player2 || GameMatrix[i, j] == LabyItem.player3 || GameMatrix[i, j] == LabyItem.player4 || GameMatrix[i, j] == LabyItem.player5 || GameMatrix[i, j] == LabyItem.player6 || GameMatrix[i, j] == LabyItem.player7 || GameMatrix[i, j] == LabyItem.player8*/)
                    //{
                    //    return new int[] { i, j };
                    //}
                    if ((GameMatrix[i,j] != LabyItem.wall && GameMatrix[i, j] != LabyItem.floor &&
                        GameMatrix[i, j] != LabyItem.door && GameMatrix[i,j] != LabyItem.ammunition &&
                        GameMatrix[i, j] != LabyItem.trap &&GameMatrix[i,j] != LabyItem.shield &&GameMatrix[i,j] != LabyItem.tank
                        && GameMatrix[i, j] != LabyItem.crater && GameMatrix[i, j] != LabyItem.award))
                    {
                        return new int[] { i, j };
                    }
                }
            }
                 return new int[] { -1, -1 };
        }

        private void LoadNext(string path)
        {
            ammo = 0;
            hasshield = false;
            string[] lines = File.ReadAllLines(path);
            GameMatrix = new LabyItem[int.Parse(lines[1]), int.Parse(lines[0])];
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    GameMatrix[i, j] = ConvertToEnum(lines[i + 2][j]);
                }
            }
            
        }

        private LabyItem ConvertToEnum(char v)
        {
            switch (v)
            {
                case 'e': return LabyItem.wall;
                case 'S': return LabyItem.player;
                case 'F': return LabyItem.door;
               case 'x': return LabyItem.award;
                case 't': return LabyItem.trap;
                case 's': return LabyItem.shield;
                case 'T': return LabyItem.tank;
                default:
                    return LabyItem.floor;
            }
        }
        private void ThroughCrater(int i,int j, int old_i,int old_j)
        {
            if (craterDistance == 1)
            {
                GameMatrix[old_i, old_j] = LabyItem.crater;

            }
            if (craterDistance != 1)
            {
                GameMatrix[old_i, old_j] = LabyItem.floor;
            }
            craterDistance = 0;
            if (GameMatrix[i, j] == LabyItem.crater)
            {
                craterDistance = 1;
                GameMatrix[old_i, old_j] = LabyItem.floor;
            }
        }

        
    }
}
