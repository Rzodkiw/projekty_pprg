using RogueSemester.Core.Characters;

namespace RogueSemester.Core.Items;

public class WeaponUpgrade : IItem
{
    public string Name => "Ostrze z Meteorytowej Stali";
    public string Description => "Zwiększa siłę ataku o 4.";
    private readonly int _bonusAttack;

    public WeaponUpgrade(int bonusAttack = 4)
    {
        _bonusAttack = bonusAttack;
    }

    public void Use(Hero hero)
    {
        hero.AttackPower += _bonusAttack;
    }
}