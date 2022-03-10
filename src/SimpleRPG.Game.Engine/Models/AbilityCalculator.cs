namespace SimpleRPG.Game.Engine.Models;

public static class AbilityCalculator
{
    private const int _defaultAbilityScore = 10;

    public static int CalculateBonus(int score) =>
        (int)Math.Floor((score - _defaultAbilityScore) / 2.0);
}
