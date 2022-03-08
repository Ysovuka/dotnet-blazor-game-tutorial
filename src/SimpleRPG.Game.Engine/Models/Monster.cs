namespace SimpleRPG.Game.Engine.Models
{
    public class Monster : LivingEntity
    {
        public string ImageName { get; set; } = string.Empty;

        public int RewardExperiencePoints { get; set; }
    }
}
