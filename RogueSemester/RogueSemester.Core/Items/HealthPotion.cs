using RogueSemester.Core.Characters;

namespace RogueSemester.Core.Items;

public class HealthPotion : IItem
{
    public string Name => "Mikstura Zdrowia";
    public string Description => "Przywraca 25 punktów zdrowia.";
    private readonly int _healAmount;

    public HealthPotion(int healAmount = 25)
    {
        _healAmount = healAmount;
    }

    public void Use(Hero hero)
    {
        hero.Health = Math.Min(hero.MaxHealth, hero.Health + _healAmount);
    }
}