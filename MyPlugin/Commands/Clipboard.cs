using CommandSystem;
using Exiled.API.Features.Pickups;
using System;

namespace MyPlugin.Commands
{
    using System;
    using System.Linq;
    using CommandSystem;

    using Exiled.API.Features;
    using Exiled.API.Features.Pickups;
    using MapEditorReborn.API.Features;
    using MapEditorReborn.API.Features.Objects;
    using UnityEngine;

    /// <summary>
    /// This is an example of how commands should be made.
    /// </summary>
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Clipboard : ICommand
{
    /// <inheritdoc/>
    public string Command { get; } = "clipboard";

    /// <inheritdoc/>
    public string[] Aliases { get; } = new[] { "cb" };

    /// <inheritdoc/>
    public string Description { get; } = "Animace clipboard";

    /// <inheritdoc/>
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
            //This serves only purpose for .me / .m registration and it does nothing
            //.me is meant to be alone normal command but I do not yet know how to do that
            //next update I will change this


            Player player = Player.Get(sender);
            /*
            

            if (player == null)
            {
                response = "This command must be from the game level.";
                return false;
            }

            if (MyPlugin.Instance.SchematicsToDestroyCommand.TryGetValue(player, out SchematicObject schematic))
            {
                //player.Broadcast(1, "You picked up test item whooo");
                if (schematic != null) 
                    {
                        schematic.Destroy();
                    }

            }

            SchematicObject mySchematicsVar = ObjectSpawner.SpawnSchematic("Clipboard", player.Position, player.Rotation, new Vector3(1, 1, 1), null, false);
            mySchematicsVar.transform.parent = player.Transform;
            MyPlugin.Instance.SchematicsToDestroyCommand[player] = mySchematicsVar;
            /O
            This will have all the arguments and I can check what the fuck is happening
            string myarguments = string.Join(" ", arguments);
            if (myarguments == "suspicous stew") { }
            O/
            //------------> 


            //-Return true if the command was executed successfully; otherwise, false.-
            //------------<
            */
            response = $"{player.Nickname} run alone .me";
            return true;
        }
    }
}