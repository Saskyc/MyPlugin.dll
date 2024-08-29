//Some useless shit for custom items
namespace MyPlugin.API
{
    using System;

    [Flags]
    public enum ExemptionType
    {
        RoundStart,
        Respawn,
        Revive,
    }
}