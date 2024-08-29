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
using MapEditorReborn;
using CustomPlayerEffects;
using MEC;
using MapEditorReborn.API.Features.Objects;
using MapEditorReborn.API.Features.Serializable;
using MapEditorReborn.API.Features;

namespace MyPlugin.CustomItems
{
    [CustomItem(ItemType.Painkillers)]
    public class CustomItem1 : CustomItem
    {
        private static ItemType customItemType = MyPlugin.Instance.Config.CustomItem1.CustomItemType;
        private static uint customItemTypeId = MyPlugin.Instance.Config.CustomItem1.CustomItemTypeId;
        private static string CustomItemName = MyPlugin.Instance.Config.CustomItem1.CustomItemName;
        private static string CustomItemDs = MyPlugin.Instance.Config.CustomItem1.CustomItemDs;
        private static Vector3 CustomItemScale = MyPlugin.Instance.Config.CustomItem1.CustomItemScale;
        private static string ConfigModelName = MyPlugin.Instance.Config.CustomItem1.Model;
        private static string CustomItemBroadcastMesseage = MyPlugin.Instance.Config.CustomItem1.CustomItemBroadcastMesseage;
        private static ushort CustomItemBroadcastTime = MyPlugin.Instance.Config.CustomItem1.CustomItemBroadcastTime;
        private static EffectType[] CustomItemEffectTypes = MyPlugin.Instance.Config.CustomItem1.CustomItemEffectTypes;
        private static float[] CustomItemEffectTime = MyPlugin.Instance.Config.CustomItem1.CustomItemEffectTime;
        private static byte[] CustomItemEffectIntensity = MyPlugin.Instance.Config.CustomItem1.CustomItemEffectIntensity;
        private static bool[] CustomItemEffectAddDuration = MyPlugin.Instance.Config.CustomItem1.CustomItemEffectAddDuration;
        private static float[] CustomItemEffectAddLateDuration = MyPlugin.Instance.Config.CustomItem1.CustomItemEffectAddLateDuration;

        public override ItemType Type { get; set; } = customItemType;
        public override uint Id { get; set; } = customItemTypeId;

        public override string Name { get; set; } = CustomItemName;

        public override string Description { get; set; } = CustomItemDs;

        public override float Weight { get; set; } = 1f;

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            DynamicSpawnPoints = new List<DynamicSpawnPoint>() 
            {
                new DynamicSpawnPoint()
                {
                        Location = Exiled.API.Enums.SpawnLocationType.InsideLczArmory,
                        Chance = 0
                }
            }
        };
        public override Vector3 Scale { get; set; } = CustomItemScale;

        public override bool ShouldMessageOnGban => base.ShouldMessageOnGban;

        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsingItem += OnUsingItem;
            Exiled.Events.Handlers.Map.PickupAdded += OnPickupAdded;
            Exiled.Events.Handlers.Player.PickingUpItem += OnPickingUpItem;
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsingItem -= OnUsingItem;
            Exiled.Events.Handlers.Map.PickupAdded -= OnPickupAdded;
            Exiled.Events.Handlers.Player.PickingUpItem -= OnPickingUpItem;
            base.UnsubscribeEvents();
        }
        private void OnUsingItem(Exiled.Events.EventArgs.Player.UsingItemEventArgs ev) 
        {
            if (!Check(ev.Item))
            return;
            ev.Player.Broadcast(new Exiled.API.Features.Broadcast(CustomItemBroadcastMesseage, CustomItemBroadcastTime));

            //THIS WILL NEED TO BE CHANGED IK
            foreach (EffectType GiveEffect in CustomItemEffectTypes)
            {
                foreach(float EffectTime in CustomItemEffectTime)
                    foreach (byte EffectIntensity in CustomItemEffectIntensity)
                        foreach (bool EffectAddDuration in CustomItemEffectAddDuration)
                            foreach (float LateDuration in CustomItemEffectAddLateDuration)
                                Timing.CallDelayed(LateDuration, () => ev.Player.EnableEffect(GiveEffect, EffectIntensity, EffectTime, EffectAddDuration));
            }
            //new Effect(EffectType, float, int, byte)
        }

        private void OnPickingUpItem(Exiled.Events.EventArgs.Player.PickingUpItemEventArgs ev)
        {
            if (ev.Player == null || ev.Pickup == null) return;

            if (!Check(ev.Pickup)) return;

            if (MyPlugin.Instance.SchematicsToDestroy.TryGetValue(ev.Pickup.Serial, out SchematicObject schematic))
            {
                schematic?.Destroy();
            }
        }

        private void OnPickupAdded(Exiled.Events.EventArgs.Map.PickupAddedEventArgs ev)
        {
            if (ev.Pickup == null)
            {
                Log.Debug("OnPickupAdded: Pickup is null.");
                return;
            }

            if (!Check(ev.Pickup))
            {
                Log.Debug("OnPickupAdded: This is not the custom item");
                return;
            }

            //This is where I check if the name of schematic that I want later to spawn exists
            SchematicObjectDataList dataList = MapUtils.GetSchematicDataByName(ConfigModelName);
            if (dataList == null)
            {
                Log.Debug($"OnPickupAdded: Data list is null {dataList}");
                return;
            }

            //This is where I spawn the schematic
            SchematicObject mySchematicsVar = ObjectSpawner.SpawnSchematic(ConfigModelName, ev.Pickup.Position, Quaternion.Euler(0, 0, 0), new Vector3(1, 1, 1), null, false);
            Log.Debug($"OnPickupAdded: Created pickup\nmySchematicVar: {mySchematicsVar}");

            //This is where I attach the schematic to player
            mySchematicsVar.gameObject.transform.parent = ev.Pickup.GameObject.transform;
            Log.Debug($"OnPickupAdded: Attached pickup {ev.Pickup}");

            //This is where I add the schematic to dictionary so it can be later destroyed
            MyPlugin.Instance.SchematicsToDestroy[ev.Pickup.Serial] = mySchematicsVar;
            Log.Debug($"OnPickupAdded: Added pickup [{ev.Pickup}] to dictionary {MyPlugin.Instance.SchematicsToDestroy[ev.Pickup.Serial]}");
        }
    }
}
