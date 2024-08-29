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
using MapEditorReborn.API.Features.Objects;

namespace MyPlugin.CustomItems
{
    [CustomItem(ItemType.Medkit)]
    public class Search : CustomItem
    {
        public override ItemType Type { get; set; } = MyPlugin.Instance.Config.Search.CustomItemType;
        public override uint Id { get; set; } = MyPlugin.Instance.Config.Search.CustomItemTypeId;
        public override string Name { get; set; } = MyPlugin.Instance.Config.Search.CustomItemName;
        public override string Description { get; set; } = MyPlugin.Instance.Config.Search.CustomItemDs;
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

        public override Vector3 Scale { get; set; } = (MyPlugin.Instance.Config.Search.CustomItemScale);
        public override bool ShouldMessageOnGban => base.ShouldMessageOnGban;
        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.PickingUpItem += OnPickingUpItem;
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.PickingUpItem -= OnPickingUpItem;
            base.UnsubscribeEvents();
        }

        private void OnPickingUpItem(Exiled.Events.EventArgs.Player.PickingUpItemEventArgs ev)
        {
            if (ev.Player == null || ev.Pickup == null)
            {
                Log.Debug($"[Search.cs] Warning\nPlayer or Pickup was null\nPickup: {ev.Pickup}\nPlayer: {ev.Player}");
                return;
            }

            if (!Check(ev.Pickup))
            {
                Log.Debug($"[Search.cs] Warning\nPickup was not custom item\nPickup id: {ev.Pickup}");
                return;
            }

            ev.IsAllowed = false;
            Log.Debug($"[Search.cs] Checking ev.IsAllowed: {ev.IsAllowed}");
            float seconds = (float)Round.ElapsedTime.TotalSeconds;
            Log.Debug($"[Search.cs] Checking Round.ElapsedTime.TotalSeconds: {(float)Round.ElapsedTime.TotalSeconds}\nChecking seconds: {seconds}");
            int seconds2 = (int)seconds;
            Log.Debug($"[Search.cs] Checking seconds2 variable: {seconds2}\nChecking int of seconds: {(int)seconds}");
            int seconds3 = seconds2 + 35;

            if (!(MyPlugin.Instance.BinCooldown.ContainsKey(ev.Player)))
            {
                Log.Debug($"[Search.cs] The condition was fired\nCondition(!(MyPlugin.Instance.BinCooldown.ContainsKey(ev.Player)))\nPlayer supposed to be added {ev.Player}");
                MyPlugin.Instance.BinCooldown[ev.Player] = seconds3;
                Log.Debug($"[Search.cs] Added ev.Player to dictionary named BinCooldown\nPlayer added: {ev.Player}\nValue added {seconds3}");
            }

            int CooldownLeft = seconds3 - MyPlugin.Instance.BinCooldown[ev.Player];

            if (CooldownLeft <= 35)
            {
                Log.Debug($"[Search.cs] The condition CooldownLeft <= 35 was executed\nCooldownLeft variable: {CooldownLeft}");
                //BetterCooldown, CooldownLeft
                int BetterCooldown = 35 - CooldownLeft;
                Log.Debug($"[Search.cs] Better Cooldown was saved\nValue: {BetterCooldown}");
                ev.Player.ShowHint($"{MyPlugin.Instance.Config.Search.CustomItemCooldownHint} {BetterCooldown}", MyPlugin.Instance.Config.Search.CustomItemCooldownHintTime);
                Log.Debug($"[Search.cs] Message sent\nValue: Jsi na cooldownu {BetterCooldown}");
                return;
            }
            else
            {
                Log.Debug($"[Search.cs] condition was not fired but else was fired.");
                //This will allow people to set all items they want to give to people after searching
                Log.Debug($"[Search.cs] Choosing random item that will be added to {ev.Player.Nickname}");
                ItemType item = MyPlugin.Instance.Config.Search.ItemToGive.RandomItem();
                Log.Debug($"[Search.cs] Chosed random item that is being added to {ev.Player.Nickname}\nItem is {item}");
                ev.Player.AddItem(item);

                //%item% is placeholder in the config you do InstanceShit.Replace(%placeholder%, variable.ToString)
                Log.Debug($"[Search.cs] Sending Hint to\nPlayer: {ev.Player}\nShowing Item in hint {MyPlugin.Instance.Config.Search.HintItemGiven.Replace("%item%", item.ToString())}");
                ev.Player.ShowHint(MyPlugin.Instance.Config.Search.HintItemGiven.Replace("%item%", item.ToString()), MyPlugin.Instance.Config.Search.HintItemGivenTime);

                //Adding his cooldown
                Log.Debug($"[Search.cs] Adding {ev.Player.Nickname} to dictionary named BinCooldown\nValue that is being added {seconds3}");
                MyPlugin.Instance.BinCooldown[ev.Player] = seconds3;
                Log.Debug($"[Search.cs] Added {ev.Player.Nickname} to dictionary named BinCooldown\nValue that is added {seconds3}\nDictionary value: {MyPlugin.Instance.BinCooldown[ev.Player]}");
                return;
            }
            Log.Debug("[Search.cs] For some reason this was not returned");
        }
    }
}
