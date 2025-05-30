//Some useless shit for custom items
namespace MyPlugin.API
{
    public interface ICustomRole
    {
        public StartTeam StartTeam { get; set; }

        public int Chance { get; set; }
    }
}