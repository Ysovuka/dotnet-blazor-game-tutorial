namespace SimpleRPG.Game.Engine.Models;

public class Player : LivingEntity
{
    public string CharacterClass { get; set; } = string.Empty;

    public int ExperiencePoints { get; set; }
}
