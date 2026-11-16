namespace RogueSemester.Core.Characters;

public interface ICharacter
{
    string Name { get; }
    int Health { get; set; }
    int MaxHealth { get; }
    int AttackPower { get; set; }
    bool IsAlive { get; }
    void TakeDamage(int damage);
}