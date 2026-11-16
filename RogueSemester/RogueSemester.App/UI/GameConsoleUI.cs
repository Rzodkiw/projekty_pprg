using RogueSemester.Core.Characters;
using RogueSemester.Core.Items;

namespace RogueSemester.App.UI;

public static class GameConsoleUI
{
    public static Hero SelectCharacter()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("     KRAINA PRZYGÓD - WYBÓR POSTACI     ");
        Console.WriteLine("========================================");
        Console.WriteLine("Wybierz klasę postaci:");
        Console.WriteLine("1. Wojownik (Wysoki atak, średnie HP)");
        Console.WriteLine("2. Paladyn (Wysokie HP, mniejszy atak)");
        Console.WriteLine("3. Łotrzyk (Zbalansowany, szybki)");
        Console.Write("\nTwój wybór (1-3): ");

        string? input = Console.ReadLine();
        Console.Write("Podaj imię swojego bohatera: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) name = "Wiktor";

        Hero hero = input switch
        {
            "1" => new Hero(name, 90, 18),
            "2" => new Hero(name, 130, 12),
            _   => new Hero(name, 100, 15)
        };

        hero.Inventory.Add(new HealthPotion(20));
        return hero;
    }

    public static void ShowStatus(Hero hero)
    {
        Console.WriteLine("\n--- AKTUALNY STAN BOHATERA ---");
        Console.WriteLine($"Imię: {hero.Name} | HP: {hero.Health}/{hero.MaxHealth} | Atak: {hero.AttackPower} | Złoto: {hero.Gold}");
        Console.WriteLine($"Przedmioty w ekwipunku: {hero.Inventory.Count}");
        foreach (var item in hero.Inventory)
        {
            Console.WriteLine($" - {item.Name} ({item.Description})");
        }
        Console.WriteLine("------------------------------\n");
    }

    public static void ShowInventoryMenu(Hero hero)
    {
        if (hero.Inventory.Count == 0)
        {
            Console.WriteLine("Twój ekwipunek jest pusty.");
            return;
        }

        Console.WriteLine("\n--- EKWIPUNEK ---");
        for (int i = 0; i < hero.Inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {hero.Inventory[i].Name} - {hero.Inventory[i].Description}");
        }
        Console.WriteLine("0. Wróć");
        Console.Write("Wybierz przedmiot do użycia: ");

        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= hero.Inventory.Count)
        {
            var item = hero.Inventory[choice - 1];
            hero.UseItem(item);
            Console.WriteLine($"Użyto przedmiotu: {item.Name}!");
        }
    }
}