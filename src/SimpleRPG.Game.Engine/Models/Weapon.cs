using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG.Game.Engine.Models;

public class Weapon : GameItem
{
    public Weapon(int itemTypeID, string name, int price, string damageRoll)
        : base(itemTypeID, ItemCategory.Weapon, name, price, true)
    {
        DamageRoll = damageRoll;
    }

    public string DamageRoll { get; set; } = string.Empty;

    public override GameItem Clone() =>
        new Weapon(ItemTypeID, Name, Price, DamageRoll);
}
