using RogueSemester.Core.Characters;

namespace RogueSemester.Core.Items;

public interface IItem
{
    string Name { get; }
    string Description { get; }
    void Use(Hero hero);
}