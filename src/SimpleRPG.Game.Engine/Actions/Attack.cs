using SimpleRPG.Game.Engine.Models;
using SimpleRPG.Game.Engine.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG.Game.Engine.Actions
{
    public class Attack : IAction
    {
        private readonly GameItem _itemInUse;
        private readonly IDiceService _diceService;
        private readonly string _damageDice;

        public Attack(GameItem itemInUse, string damageDice, IDiceService? diceService = null)
        {
            _itemInUse = itemInUse ?? throw new ArgumentNullException(nameof(itemInUse));
            _diceService = diceService ?? DiceService.Instance;

            if (itemInUse.Category != GameItem.ItemCategory.Weapon)
            {
                throw new ArgumentException($"{itemInUse.Name} is not a weapon");
            }

            if (string.IsNullOrWhiteSpace(damageDice))
            {
                throw new ArgumentException("damageDice must be valid dice notation");
            }

            _damageDice = damageDice;
        }

        public DisplayMessage Execute(LivingEntity actor, LivingEntity target)
        {
            _ = actor ?? throw new ArgumentNullException(nameof(actor));
            _ = target ?? throw new ArgumentNullException(nameof(target));

            string actorName = (actor is Player) ? "You" : $"The {actor.Name.ToLower()}";
            string targetName = (target is Player) ? "you" : $"the {target.Name.ToLower()}";
            string title = (actor is Player) ? "Player Combat" : "Monster Combat";

            int damage = _diceService.Roll(_damageDice).Value;
            string message;

            if (damage == 0)
            {
                message = $"{actorName} missed {targetName}.";
            }
            else
            {
                target.TakeDamage(damage);
                message = $"{actorName} hit {targetName} for {damage} point{(damage > 1 ? "s" : "")}.";
            }

            return new DisplayMessage(title, message);
        }
    }
}
