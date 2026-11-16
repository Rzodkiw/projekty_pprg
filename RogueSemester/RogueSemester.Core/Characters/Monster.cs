namespace RogueSemester.Core.Characters;

public class Monster : Character
{
    public int ExpReward { get; }
    public int GoldReward { get; }

    public Monster(string name, int maxHealth, int attackPower, int expReward, int goldReward) 
        : base(name, maxHealth, attackPower)
    {
        ExpReward = expReward;
        GoldReward = goldReward;
    }

    public static Monster CreateMonsterByIndex(int index)
    {
        return index switch
        {
            1 => new Monster("Leśny Goblin", 30, 8, 10, 15),
            2 => new Monster("Szkielet Wojownik", 45, 12, 20, 25),
            3 => new Monster("Mroczny Mag", 60, 16, 35, 40),
            _ => new Monster("Smok Cieni", 90, 22, 50, 100)
        };
    }
}