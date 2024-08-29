/*
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.CustomItems.API.Features;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using UnityStandardAssets.Effects;
using Exiled.API.Features.Spawn;
using Exiled.API.Enums;
using InventorySystem.Items.Usables;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.Handlers;
using PlayerRoles;

namespace MyPlugin.CustomItems
{
    [CustomItem(ItemType.GunCOM15)]
    public class Training : CustomItem
    {
        public override uint Id { get; set; } = 69;
        public override string Name { get; set; } = "Trénovací zbraň";
        public override string Description { get; set; } = "Střílí lasery, které ti řeknou jestli si trefil danou osobu.\nBere náboje!";
        public override float Weight { get; set; } = 1f;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            DynamicSpawnPoints = new List<DynamicSpawnPoint>()
            {
                new DynamicSpawnPoint()
                {
                        Location = Exiled.API.Enums.SpawnLocationType.InsideGr18,
                        Chance = 100                        
                }
            }
        };
        public override Vector3 Scale { get; set; } = new Vector3(5f, 5f, 5f);
        public override bool ShouldMessageOnGban => base.ShouldMessageOnGban;
        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.Shot += OnShot;
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.Shot -= OnShot;
            base.UnsubscribeEvents();
        }

        private void OnShot(Exiled.Events.EventArgs.Player.ShotEventArgs ev)
        {
            if (!Check(ev.Item))
            {
                return;
            }

            if (ev.Target == null)
            {
                return;
            }

            ev.CanHurt = false;
            if (ev.Target.Role.Team == Team.SCPs)
            {
                return;
            }
            ev.Target.Broadcast(new Exiled.API.Features.Broadcast($"Byl jsi trefen {ev.Player.DisplayNickname}\n(trénovací zbraň)", 2));
            ev.Player.Broadcast(new Exiled.API.Features.Broadcast($"Trefil jsi {ev.Target.DisplayNickname}\n(trénovací zbraň)", 2));

            //MyPlugin.Instance.TaserMode[ev.Item.Serial] = 1;
        }
    }
}
*/