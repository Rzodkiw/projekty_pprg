using RogueSemester.Core.Items;

namespace RogueSemester.Core.Characters;

public class Hero : Character
{
    public List<IItem> Inventory { get; } = new();
    public int Gold { get; set; } = 0;
    public int BattlesWon { get; set; } = 0;

    public Hero(string name, int maxHealth, int attackPower) : base(name, maxHealth, attackPower)
    {
    }

    public void UseItem(IItem item)
    {
        if (Inventory.Contains(item))
        {
            item.Use(this);
            Inventory.Remove(item);
        }
    }
}