using Laby.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laby.Controller
{
    internal class GameController
    {
        IGameControl control;
        Key tempkey;
        public GameController(IGameControl control)
        {
            this.control = control;
        }

        public void KeyPressed(Key key)
        {
            switch (key)
            {
                case Key.Up:
                    System.Threading.Thread.Sleep(70);
                    control.Move(LabyLogic.Directions.up);
                    tempkey = Key.Up;
                    break;
                case Key.Down:
                    control.Move(LabyLogic.Directions.down);
                    tempkey = Key.Down;
                    break;
                case Key.Left:
                    System.Threading.Thread.Sleep(70);
                    control.Move(LabyLogic.Directions.left);
                    tempkey = Key.Left;
                    break;
                case Key.Right:
                    System.Threading.Thread.Sleep(70);
                    control.Move(LabyLogic.Directions.right);
                    tempkey = Key.Right;
                    break;
                case Key.Space:
                    control.Shoot(tempkey);
                    System.Threading.Thread.Sleep(80);
                   
                    break;
            }
        }
    }
}
