using RogueSemester.Core.Characters;

namespace RogueSemester.Core.Combat;

public class CombatEngine
{
    public bool Fight(Hero hero, Monster monster, Action<string> logAction)
    {
        logAction($"--- Rozpoczyna się starcie: {hero.Name} vs {monster.Name} ---");

        while (hero.IsAlive && monster.IsAlive)
        {
            // Tura bohatera
            monster.TakeDamage(hero.AttackPower);
            logAction($"{hero.Name} zadaje {hero.AttackPower} obrażeń. {monster.Name} ma {monster.Health}/{monster.MaxHealth} HP.");

            if (!monster.IsAlive) break;

            // Tura potwora
            hero.TakeDamage(monster.AttackPower);
            logAction($"{monster.Name} kontratakuje i zadaje {monster.AttackPower} obrażeń. {hero.Name} ma {hero.Health}/{hero.MaxHealth} HP.");
        }

        if (hero.IsAlive)
        {
            logAction($"\nZwycięstwo! Pokonałeś potwora: {monster.Name}.\n");
            hero.BattlesWon++;
            return true;
        }
        else
        {
            logAction($"\nPorażka... {hero.Name} poległ w walce z {monster.Name}.\n");
            return false;
        }
    }
}