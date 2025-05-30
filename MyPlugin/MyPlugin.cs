using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.CustomItems;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using System.Reflection;
using CommandSystem;
using Exiled.CustomRoles;
using Exiled.API.Enums;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Exiled.Events;
//using MyPlugin.CustomThings;
using Exiled.Events.EventArgs.Player;
using MyPlugin.EventHandlers;
using ProjectMER.Features.Objects;

namespace MyPlugin
{
    public class MyPlugin : Exiled.API.Features.Plugin<Config>
    {
        public Dictionary<Player, int> DictionaryName = new();
        //Use this to edit it after
        //If (MyPluginDict[ev.Player] == 1)
        //MyPluginDict[ev.Player] = 0;
        public Dictionary<ushort, int> TaserMode = new();
        public Dictionary<ushort, int> CustomItemMode = new();
        public Dictionary<ushort, string> CustomItemOwner = new();
        public Dictionary<ushort, SchematicObject> SchematicsToDestroy = new();

        public Dictionary<Player, int> CustomItemModeRole = new();
        public Dictionary<Player, SchematicObject> SchematicsToDestroyRole = new();
        public Dictionary<Player, SchematicObject> SchematicsToDestroyCommand = new();
        public Dictionary<string, string> SomeElement = new();
        public Dictionary<Player, int> BinCooldown = new();
        public static MyPlugin Instance;
        public override void OnEnabled()
        {
            Instance = this;
            Exiled.CustomItems.API.Features.CustomItem.RegisterItems();
            Exiled.CustomRoles.API.Features.CustomRole.RegisterRoles(false, null);
            PlayerEv.Subscribe();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            Exiled.CustomItems.API.Features.CustomItem.UnregisterItems();
            Exiled.CustomRoles.API.Features.CustomRole.UnregisterRoles();
            PlayerEv.Unsubscribe();
            base.OnDisabled();
            //ChangingItem
        }
    }
    
}
