using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlugin.Commands
{
#pragma warning disable SA1402
    // Usings
    using System;
    using System.IO;
    using System.Reflection;
    using CommandSystem;
    using Exiled.API.Features;
    using Exiled.Permissions.Extensions; // Use this if you want to add perms
    using MapEditorReborn.API.Extensions;
    using MapEditorReborn.API.Features;
    using MapEditorReborn.API.Features.Objects;
    using MapEditorReborn.API.Features.Serializable;
    using PlayerRoles;
    using UnityEngine;

    /// <inheritdoc/>
    [CommandHandler(typeof(ClientCommandHandler))] // You can change the command handler
    public class ParentCommandExample : ParentCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParentCommandExample"/> class.
        /// </summary>
        public ParentCommandExample()
        {
            LoadGeneratedCommands();

            // Use this to load commands for the parent command
        }

        /// <inheritdoc />
        public override string Command { get; } = MyPlugin.Instance.Config.Emotes.CommandName;   // COMMAND

        /// <inheritdoc />
        public override string[] Aliases { get; } = {MyPlugin.Instance.Config.Emotes.CommandAlias};   // ALIASES, is dont necessary to add aliases, if you want to add a aliase just put = null;

        /// <inheritdoc />
        public override string Description { get; } = MyPlugin.Instance.Config.Emotes.CommandDescription;   // PARENT COMMAND DESC

        /// <inheritdoc />
        public override void LoadGeneratedCommands() // Put here your commands (the other commands dont need the [CommandHandler(typeof())]
        {
            //Ik this is not parent command but technically it is still registered as one
            //In next update I will look on how to turn this into normal command so I do not need this
            RegisterCommand(new Clipboard());
        }

        /// <inheritdoc />
        // Here starts your command code
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            /*
            // If you want to add permissions you need to use that
            if (!sender.CheckPermission("exiled.parenttest"))
            {
                response = "You dont have perms";
                return false;
            }
            */
            if (player == null)
            {
                response = "This command must be executed at the game level.";
                return false;
            }

            //Destroying the animations always when it is executed so players dont try to change emotes and breking
            //the whole server
            if (MyPlugin.Instance.SchematicsToDestroyCommand.TryGetValue(player, out SchematicObject schematic))
            {
                //player.Broadcast(1, "You picked up test item whooo");
                if (schematic != null)
                {
                    schematic.Destroy();
                }

            }

            //This fires when there is only .me or .m without any arguments
            //It tells player what animations can be used the usage and how to delete the animation
            if (arguments.IsEmpty())
            {
                string schematicsDir = Path.Combine(Paths.Configs, "MapEditorReborn", "Schematics");
                StringBuilder builder = new StringBuilder();

                builder.Append(MyPlugin.Instance.Config.Emotes.ListOfAnimations);

                foreach (string directoryPath in Directory.GetDirectories(schematicsDir))
                {
                    // Filter JSON files that contain '!' in their name and do not contain '-'
                    foreach (string jsonFilePath in Directory.GetFiles(directoryPath)
                                                             .Where(x => x.EndsWith(".json") && x.Contains('!') && !x.Contains('-')))
                    {
                        // Get the file name without the extension
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(jsonFilePath);

                        // Append the name without the extension to the StringBuilder
                        builder.AppendLine();
                        builder.Append($"- {fileNameWithoutExtension}");
                    }
                }
                response = $"{MyPlugin.Instance.Config.Emotes.EmptyAnwer}\n\n{builder.ToString()}: ";
                return false;
            }

            string myarguments = string.Join(" ", arguments);
            string laterargumentusage = string.Join(" ", arguments);
            bool myarguments2 = myarguments.Contains("!");

            //This part checks if player has inputed schematic that is in server
            SchematicObjectDataList dataList = MapUtils.GetSchematicDataByName(myarguments);
            if (dataList == null)
            {
                string schematicsDir = Path.Combine(Paths.Configs, "MapEditorReborn", "Schematics");
                StringBuilder builder = new StringBuilder();

                builder.Append(MyPlugin.Instance.Config.Emotes.ListOfAnimations);

                foreach (string directoryPath in Directory.GetDirectories(schematicsDir))
                {
                    Log.Debug($"[Me.cs] <Line 127> {Directory.GetDirectories(schematicsDir).Contains(directoryPath)}");
                    // Filter JSON files that contain '!' in their name and do not contain '-'
                    foreach (string jsonFilePath in Directory.GetFiles(directoryPath)
                                                             .Where(x => x.EndsWith(".json") && x.Contains('!') && !x.Contains('-')))
                    {
                        // Get the file name without the extension
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(jsonFilePath);

                        // Append the name without the extension to the StringBuilder
                        builder.AppendLine();
                        builder.Append($"- {fileNameWithoutExtension}");
                    }
                }
                
                response = $"{MyPlugin.Instance.Config.Emotes.EmptyAnwer}\n\n{builder.ToString()}: ";
                return false;
            }

            //myarguments2 is defined in the upper script
            //It is used to check if players argument included the key [!]
            if (myarguments2 == false)
            {
                response = MyPlugin.Instance.Config.Emotes.KeyNotIncluded;
                return false;
            }

            if (myarguments.Contains("NONE") == true && myarguments2 == true)
            {
                //goto was used because of a very good reason I tried to saving variable and than check smth like Variable == 1 but I just had skill issue
                //doing that so I just used goto for not spending more time for nothing in next updates I will go over code and clean it
                goto SchematicUtilisationOnyPlayer;
            }
            else if (myarguments.Contains("CD") == true && myarguments2 == true && (player.Role.Type == PlayerRoles.RoleTypeId.ClassD))
            {
                //goto was used because of a very good reason I tried to saving variable and than check smth like Variable == 1 but I just had skill issue
                //doing that so I just used goto for not spending more time for nothing in next updates I will go over code and clean it
                goto SchematicUtilisationOnyPlayer;
            }

            else if (myarguments.Contains("SC") == true && myarguments2 == true && (player.Role.Type == PlayerRoles.RoleTypeId.Scientist))
            {
                //goto was used because of a very good reason I tried to saving variable and than check smth like Variable == 1 but I just had skill issue
                //doing that so I just used goto for not spending more time for nothing in next updates I will go over code and clean it
                goto SchematicUtilisationOnyPlayer;
            }

            else if (myarguments.Contains("FG") == true && myarguments2 == true && (player.Role.Type == PlayerRoles.RoleTypeId.FacilityGuard))
            {
                //goto was used because of a very good reason I tried to saving variable and than check smth like Variable == 1 but I just had skill issue
                //doing that so I just used goto for not spending more time for nothing in next updates I will go over code and clean it
                goto SchematicUtilisationOnyPlayer;
            }

            else if (myarguments.Contains("NP") == true && myarguments2 == true && (player.Role.Type == PlayerRoles.RoleTypeId.NtfPrivate))
            {
                //goto was used because of a very good reason I tried to saving variable and than check smth like Variable == 1 but I just had skill issue
                //doing that so I just used goto for not spending more time for nothing in next updates I will go over code and clean it
                goto SchematicUtilisationOnyPlayer;
            }

            else if (myarguments.Contains("NSE") == true && myarguments2 == true && (player.Role.Type == PlayerRoles.RoleTypeId.NtfSergeant))
            {
                //goto was used because of a very good reason I tried to saving variable and than check smth like Variable == 1 but I just had skill issue
                //doing that so I just used goto for not spending more time for nothing in next updates I will go over code and clean it
                goto SchematicUtilisationOnyPlayer;
            }

            else if (myarguments.Contains("NSP") == true && myarguments2 == true && (player.Role.Type == PlayerRoles.RoleTypeId.NtfSpecialist))
            {
                //goto was used because of a very good reason I tried to saving variable and than check smth like Variable == 1 but I just had skill issue
                //doing that so I just used goto for not spending more time for nothing in next updates I will go over code and clean it
                goto SchematicUtilisationOnyPlayer;
            }

            else if (myarguments.Contains("NC") == true && myarguments2 == true && (player.Role.Type == PlayerRoles.RoleTypeId.NtfCaptain))
            {
                //goto was used because of a very good reason I tried to saving variable and than check smth like Variable == 1 but I just had skill issue
                //doing that so I just used goto for not spending more time for nothing in next updates I will go over code and clean it
                goto SchematicUtilisationOnyPlayer;
            }

            else if (myarguments.Contains("CC") == true && myarguments2 == true && (player.Role.Type == PlayerRoles.RoleTypeId.ChaosConscript))
            {
                //goto was used because of a very good reason I tried to saving variable and than check smth like Variable == 1 but I just had skill issue
                //doing that so I just used goto for not spending more time for nothing in next updates I will go over code and clean it
                goto SchematicUtilisationOnyPlayer;
            }

            else if (myarguments.Contains("CRI") == true && myarguments2 == true && (player.Role.Type == PlayerRoles.RoleTypeId.ChaosRifleman))
            {
                //goto was used because of a very good reason I tried to saving variable and than check smth like Variable == 1 but I just had skill issue
                //doing that so I just used goto for not spending more time for nothing in next updates I will go over code and clean it
                goto SchematicUtilisationOnyPlayer;
            }

            else if (myarguments.Contains("CM") == true && myarguments2 == true && (player.Role.Type == PlayerRoles.RoleTypeId.ChaosMarauder))
            {
                //goto was used because of a very good reason I tried to saving variable and than check smth like Variable == 1 but I just had skill issue
                //doing that so I just used goto for not spending more time for nothing in next updates I will go over code and clean it
                goto SchematicUtilisationOnyPlayer;
            }

            else if (myarguments.Contains("CRE") == true && myarguments2 == true && (player.Role.Type == PlayerRoles.RoleTypeId.ChaosRepressor))
            {
                //goto was used because of a very good reason I tried to saving variable and than check smth like Variable == 1 but I just had skill issue
                //doing that so I just used goto for not spending more time for nothing in next updates I will go over code and clean it
                goto SchematicUtilisationOnyPlayer;
            }

            else
            {
                response = MyPlugin.Instance.Config.Emotes.NoPermission;
                return false;
            }

            //Before telling me what the fuck did I did with adding a label
            //Read the note above
            SchematicUtilisationOnyPlayer:
            SchematicObject mySchematicsVar = ObjectSpawner.SpawnSchematic(myarguments, player.Position, player.Rotation, player.Scale, null, false);
            mySchematicsVar.transform.parent = player.Transform;
            MyPlugin.Instance.SchematicsToDestroyCommand[player] = mySchematicsVar;

            //This gives me the response when everything has been done and says what animation was played
            response = $"{MyPlugin.Instance.Config.Emotes.PlayedAnimation}\n{laterargumentusage}";
            return true;
        }
    }
}