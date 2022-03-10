namespace SimpleRPG.Game.Engine.Models;

public abstract class LivingEntity
{
    public string Name { get; set; } = string.Empty;

    public int CurrentHitPoints { get; set; }

    public int MaximumHitPoints { get; set; }

    public int Gold { get; set; }

    public int Level { get; set; }

    public Inventory Inventory { get; } = new Inventory();

    public bool IsDead => CurrentHitPoints <= 0;

    public void TakeDamage(int hitPointsOfDamage)
    {
        if (hitPointsOfDamage > 0)
        {
            CurrentHitPoints -= hitPointsOfDamage;
        }
    }

    public void Heal(int hitPointsToHeal)
    {
        if (hitPointsToHeal > 0)
        {
            CurrentHitPoints += hitPointsToHeal;

            if (CurrentHitPoints > MaximumHitPoints)
            {
                CurrentHitPoints = MaximumHitPoints;
            }
        }
    }

    public void CompletelyHeal()
    {
        CurrentHitPoints = MaximumHitPoints;
    }

    public void ReceiveGold(int amountOfGold)
    {
        if (amountOfGold > 0)
        {
            Gold += amountOfGold;
        }
    }

    public void SpendGold(int amountOfGold)
    {
        if (amountOfGold > Gold)
        {
            throw new ArgumentOutOfRangeException(nameof(amountOfGold), $"{Name} only has {Gold} gold, and cannot spend {amountOfGold} gold");
        }

        if (amountOfGold > 0)
        {
            Gold -= amountOfGold;
        }
    }
}
