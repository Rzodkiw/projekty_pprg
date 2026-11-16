using RogueSemester.App.UI;
using RogueSemester.Core.Combat;
using RogueSemester.Core.Characters;
using RogueSemester.Core.Items;
using RogueSemester.Reporting.Reports;
using CombatLogger = RogueSemester.Core.Combat.ConsoleLogger;
using UiLogger = RogueSemester.App.UI.ConsoleLogger;

CombatLogger combatLog = new();
UiLogger uiLog = new();

uiLog.LogSystem("Inicjalizacja gry...");

Hero hero = GameConsoleUI.SelectCharacter();
CombatEngine combatEngine = new();

List<Monster> monsters = new()
{
    Monster.CreateMonsterByIndex(1),
    Monster.CreateMonsterByIndex(2),
    Monster.CreateMonsterByIndex(3)
};

bool exitRequested = false;
int completedBattles = 0;

for (int i = 0; i < monsters.Count; i++)
{
    var monster = monsters[i];
    Console.Clear();
    Console.WriteLine($"\n=== ETAP {i + 1} / {monsters.Count} ===");
    Console.WriteLine($"Napotkano przeciwnika: {monster.Name} (HP: {monster.Health}, Atak: {monster.AttackPower})");

    bool inStage = true;
    while (inStage)
    {
        Console.WriteLine("\nWybierz akcję:");
        Console.WriteLine("1. Atakuj przeciwnika");
        Console.WriteLine("2. Otwórz ekwipunek (użyj przedmiotu)");
        Console.WriteLine("3. Wyświetl raport stanu bohatera");
        Console.WriteLine("4. Zakończ wyprawę (Wyjdź)");
        Console.Write("Twój wybór: ");

        string? action = Console.ReadLine();
        if (action == "1")
        {
            bool won = combatEngine.Fight(hero, monster, msg => combatLog.LogCombat(msg));
            if (won)
            {
                completedBattles++;
                hero.Gold += monster.GoldReward;
                IItem foundItem = i % 2 == 0 ? new WeaponUpgrade() : new HealthPotion();
                hero.Inventory.Add(foundItem);
                uiLog.LogSystem($"Zdobyto łup: {foundItem.Name} oraz {monster.GoldReward} szt. złota!");
            }
            inStage = false;
        }
        else if (action == "2")
        {
            GameConsoleUI.ShowInventoryMenu(hero);
        }
        else if (action == "3")
        {
            GameConsoleUI.ShowStatus(hero);
        }
        else if (action == "4")
        {
            exitRequested = true;
            inStage = false;
        }
    }

    if (!hero.IsAlive || exitRequested)
    {
        break;
    }

    if (i < monsters.Count - 1)
    {
        Console.WriteLine("\nNaciśnij Enter, aby przejść do kolejnego przeciwnika...");
        Console.ReadLine();
    }
}

GameReport report = new GameReport(hero, hero.IsAlive && completedBattles == monsters.Count, monsters.Count);
report.PrintReport();

Console.WriteLine("\nKoniec gry. Naciśnij dowolny klawisz, aby wyjść.");
Console.ReadKey();