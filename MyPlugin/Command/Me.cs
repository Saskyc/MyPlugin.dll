using System.Linq;
using System.Text;
using System;
using System.IO;
using CommandSystem;
using Exiled.API.Features;
using MapEditorReborn.API.Features;
using MapEditorReborn.API.Features.Objects;

namespace MyPlugin.Command
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Me : ICommand
    {

        public string Command { get; } = MyPlugin.Instance.Config.Emotes.CommandName;
        
        public string[] Aliases { get; } = {MyPlugin.Instance.Config.Emotes.CommandAlias};
        
        public string Description { get; } = MyPlugin.Instance.Config.Emotes.CommandDescription;
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);
            
            if (player == null)
            {
                response = "This command must be executed at the game level.";
                return false;
            }
            
            if (MyPlugin.Instance.SchematicsToDestroyCommand.TryGetValue(player, out SchematicObject schematic))
                if (schematic != null)
                    schematic.Destroy();
            
            if (arguments.IsEmpty())
            {
                var schematicsDir = Path.Combine(Paths.Configs, "MapEditorReborn", "Schematics");
                var builder = new StringBuilder();

                builder.Append(MyPlugin.Instance.Config.Emotes.ListOfAnimations);

                foreach (var directoryPath in Directory.GetDirectories(schematicsDir))
                {
                    // Filter JSON files that contain '!' in their name and do not contain '-'
                    foreach (var jsonFilePath in Directory.GetFiles(directoryPath)
                                                             .Where(x => x.EndsWith(".json") && x.Contains('!') && !x.Contains('-')))
                    {
                        // Get the file name without the extension
                        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(jsonFilePath);

                        // Append the name without the extension to the StringBuilder
                        builder.AppendLine();
                        builder.Append($"- {fileNameWithoutExtension}");
                    }
                }
                response = $"{MyPlugin.Instance.Config.Emotes.EmptyAnwer}\n\n{builder}: ";
                return false;
            }

            var myArguments = string.Join(" ", arguments);
            var laterArgumentUsage = string.Join(" ", arguments);
            
            MapUtils.GetSchematicDataByName(myArguments);

            foreach (var permissionCheckInDictionary in MyPlugin.Instance.Config.Emotes.Permission)
            {
                var exitLoop = false;

                foreach (var permission in permissionCheckInDictionary)
                {
                    if (!(myArguments.Contains(permission.Key) && player.Role.Type == permission.Value ||
                          myArguments.Contains("NONE"))) continue;
                    
                    exitLoop = true;
                    break;
                }

                if (!exitLoop)
                {
                    response = MyPlugin.Instance.Config.Emotes.NoPermission;
                    return false;
                }
            }
            
            var mySchematicsVar = ObjectSpawner.SpawnSchematic(myArguments, player.Position, player.Rotation, player.Scale, null!, false);
            mySchematicsVar.transform.parent = player.Transform;
            
            MyPlugin.Instance.SchematicsToDestroyCommand[player] = mySchematicsVar;
            
            response = $"{MyPlugin.Instance.Config.Emotes.PlayedAnimation}\n{laterArgumentUsage}";
            return true;
        }
    }
}