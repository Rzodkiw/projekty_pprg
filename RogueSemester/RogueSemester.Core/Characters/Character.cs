namespace RogueSemester.Core.Characters;

public abstract class Character : ICharacter
{
    public string Name { get; protected set; }
    public int Health { get; set; }
    public int MaxHealth { get; protected set; }
    public int AttackPower { get; set; }
    public bool IsAlive => Health > 0;

    protected Character(string name, int maxHealth, int attackPower)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        AttackPower = attackPower;
    }

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) 
        {
            Health = 0;
        }
    }
}