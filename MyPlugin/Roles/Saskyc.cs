/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using UnityEngine;
using MEC;
using Exiled.CustomItems;
using PlayerRoles;
using Exiled.API.Enums;
using MyPlugin.API;
using Exiled.API.Features.Pickups;
using MapEditorReborn.API.Features.Objects;
using MapEditorReborn.API.Features;
using System.Runtime.Remoting.Messaging;

namespace MyPlugin.Roles
{
    [CustomRole(RoleTypeId.None)]
    public class Saskyc : CustomRole
    {
    public int Chance { get; set; } = 0;

        public StartTeam StartTeam { get; set; } = StartTeam.Ntf;

        public override uint Id { get; set; } = 128;

        public override RoleTypeId Role { get; set; } = RoleTypeId.FacilityGuard;

        public override int MaxHealth { get; set; } = 120;

        public override string Name { get; set; } = "Saskyc";

        public override string Description { get; set; } =
            "Custom role for testing named Saskyc";

        public override string CustomInfo { get; set; } = "Saskyc";

        public override bool KeepInventoryOnSpawn { get; set; } = true;

        public override bool KeepRoleOnDeath { get; set; } = false;

        public override bool RemovalKillsPlayer { get; set; } = false;

        public override SpawnProperties SpawnProperties { get; set; } = new()
        {
            Limit = 1,
        };

        protected override void RoleAdded(Player player)
        {
            //Timing.CallDelayed(2.5f, () => player.Scale = new Vector3(0.75f, 0.75f, 0.75f));
            Timing.CallDelayed(0.5f, () => player.Teleport(RoomType.LczArmory));
            Timing.CallDelayed(0.5f, () => player.ClearInventory(true));
            Timing.CallDelayed(0.5f, () => player.AddItem(ItemType.GunE11SR));
            player.IsUsingStamina = false;
            
            SchematicObject mySchematicsVar = ObjectSpawner.SpawnSchematic("TestSkin", player.Position, Quaternion.Euler(0, 0, 0), new Vector3(1, 1, 1), null, false);
            mySchematicsVar.transform.parent = player.Transform;

            MyPlugin.Instance.SchematicsToDestroyRole[player] = mySchematicsVar;

        }

        protected override void RoleRemoved(Player player)
        {
            player.IsUsingStamina = true;
            //player.Scale = Vector3.one;

            if (MyPlugin.Instance.SchematicsToDestroyRole.TryGetValue(player, out SchematicObject schematic))
            {
                //player.Broadcast(1, "You picked up test item whooo");
                schematic.Destroy();
            }
        }
    }

}

*/