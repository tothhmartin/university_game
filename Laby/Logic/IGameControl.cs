using System.Windows.Input;
using static Laby.Logic.LabyLogic;

namespace Laby.Logic
{
    internal interface IGameControl
    {
        void Move(Directions direction);
        void Shoot(Key key);
        //void Change();
    }
}