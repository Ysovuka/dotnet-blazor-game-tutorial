using D20Tek.DiceNotation;
using D20Tek.DiceNotation.DieRoller;

namespace SimpleRPG.Game.Engine;

public interface IDiceService
{
    public enum RollerType
    {
        Random = 0,
        Crypto = 1,
        MathNet = 2
    }

    IDice Dice { get; }

    IDiceConfiguration Configuration { get; }

    IDieRollTracker? RollTracker { get; }

    void Configure(RollerType rollerType, bool enableTracker = false);

    DiceResult Roll();

    DiceResult Roll(string diceNotation);
}
