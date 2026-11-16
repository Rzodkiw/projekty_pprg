using RogueSemester.Core.Characters;

namespace RogueSemester.Reporting.Reports;

public class GameReport
{
    public Hero Hero { get; }
    public bool IsVictory { get; }
    public int TotalEncounters { get; }
    public DateTime Timestamp { get; } = DateTime.Now;

    public GameReport(Hero hero, bool isVictory, int totalEncounters)
    {
        Hero = hero;
        IsVictory = isVictory;
        TotalEncounters = totalEncounters;
    }

    public void PrintReport()
    {
        Console.WriteLine("\n==========================================");
        Console.WriteLine("          RAPORT KOŃCOWY WYPRAWY          ");
        Console.WriteLine("==========================================");
        Console.WriteLine($"Czas raportu: {Timestamp:yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine($"Bohater:      {Hero.Name}");
        Console.WriteLine($"Status:       {(IsVictory ? "SUKCES (Wyprawa ukończona)" : "PORAŻKA (Bohater poległ lub wyjście z gry)")}");
        Console.WriteLine($"Wygrane walki:{Hero.BattlesWon} / {TotalEncounters}");
        Console.WriteLine($"Końcowe HP:   {Hero.Health} / {Hero.MaxHealth}");
        Console.WriteLine($"Złoto:        {Hero.Gold} szt. złota");
        Console.WriteLine($"Siła ataku:   {Hero.AttackPower}");
        Console.WriteLine("Przedmioty w ekwipunku:");
        if (Hero.Inventory.Count == 0)
        {
            Console.WriteLine(" - Brak przedmiotów");
        }
        else
        {
            // Użycie pełnej nazwy typu zamiast dyrektywy using, aby w jednym miejscu pokazać bezpośrednie pochodzenie interfejsu z modułu Core.Items
            foreach (RogueSemester.Core.Items.IItem item in Hero.Inventory)
            {
                Console.WriteLine($" - {item.Name}: {item.Description}");
            }
        }
        Console.WriteLine("==========================================");
    }
}