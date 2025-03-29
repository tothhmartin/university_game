using static Laby.Logic.LabyLogic;

namespace Laby.Logic
{
    public interface IGameModel
    {
        LabyItem[,] GameMatrix { get; set; }
        int ammo { get; set; }
        bool shield { get; set; }
    }
}