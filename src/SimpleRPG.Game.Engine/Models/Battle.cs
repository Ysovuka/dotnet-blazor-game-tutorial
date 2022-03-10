using SimpleRPG.Game.Engine.Services;

namespace SimpleRPG.Game.Engine.Models;

public class Battle
{
    private readonly DisplayMessageBroker _messageBroker = DisplayMessageBroker.Instance;
    private readonly Action _onPlayerKilled;
    private readonly Action _onOpponentKilled;

    public Battle(Action onPlayerKilled, Action onOpponenetKilled)
    {
        _onPlayerKilled = onPlayerKilled;
        _onOpponentKilled = onOpponenetKilled;
    }

    public void Attack(Player player, Monster opponent)
    {
        _ = player ?? throw new ArgumentNullException(nameof(player));
        _ = opponent ?? throw new ArgumentNullException(nameof(opponent));

        AttackOpponent(player, opponent);
    }

    private void AttackOpponent(Player player, Monster opponent)
    {
        if (player.CurrentWeapon == null)
        {
            _messageBroker.RaiseMessage(
                new DisplayMessage("Combat Warning", "You must select a weapon, to attack."));
            return;
        }

        // player acts monster with weapon
        var message = player.UseCurrentWeaponOn(opponent);
        _messageBroker.RaiseMessage(message);

        // if monster is killed, collect rewards and loot
        if (opponent.IsDead)
        {
            OnOpponentKilled(player, opponent);
        }
        else
        {
            // if the monster is still alive, it attacks the player.
            AttackPlayer(player, opponent);
        }
    }

    private void AttackPlayer(Player player, Monster opponent)
    {
        // now the monster attacks the player
        var message = opponent.UseCurrentWeaponOn(player);
        _messageBroker.RaiseMessage(message);

        // if player is killed, move them back to their home and heal.
        if (player.IsDead)
        {
            OnPlayerKilled(player, opponent);
        }
    }

    private void OnPlayerKilled(Player player, Monster opponent)
    {
        _messageBroker.RaiseMessage(
            new DisplayMessage("Player Defeated", $"The {opponent.Name} killed you."));

        player.CompletelyHeal();  // Completely heal the player.
        _onPlayerKilled.Invoke();  // Action to reset player to home location.
    }

    private void OnOpponentKilled(Player player, Monster opponent)
    {
        var messageLines = new List<string>();
        messageLines.Add($"You defeated the {opponent.Name}!");

        player.AddExperience(opponent.RewardExperiencePoints);
        messageLines.Add($"You receive {opponent.RewardExperiencePoints} experience points.");

        player.ReceiveGold(opponent.Gold);
        messageLines.Add($"You receive {opponent.Gold} gold.");

        foreach (GameItem item in opponent.Inventory.Items)
        {
            player.Inventory.AddItem(item);
            messageLines.Add($"You received {item.Name}.");
        }

        _messageBroker.RaiseMessage(new DisplayMessage("Monster Defeated", messageLines));

        _onOpponentKilled.Invoke();  // Action to get another opponent.
    }
}
