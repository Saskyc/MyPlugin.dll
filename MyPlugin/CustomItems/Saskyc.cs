using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Exiled.CustomItems.API.Features;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;

namespace MyPlugin.CustomItems
{
    [CustomItem(ItemType.Medkit)]
    public class Saskyc : CustomItem
    {
        public override uint Id { get; set; } = 999;
        public override string Name { get; set; } = "Saskyc";
        public override string Description { get; set; } = "Item used to test Saskyc item";
        public override float Weight { get; set; } = 1f;
        public override SpawnProperties SpawnProperties { get; set; } = new()
        {
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new()
                {
                        Location = Exiled.API.Enums.SpawnLocationType.InsideLczArmory,
                        Chance = 0
                }
            }
        };
        public override Vector3 Scale { get; set; } = new(1.5f, 1.5f, 1.5f);
        public override bool ShouldMessageOnGban => base.ShouldMessageOnGban;
        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.ChangedItem += OnChangedItem;
            Exiled.Events.Handlers.Player.InteractingDoor += OnInteractingDoor;
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.ChangedItem -= OnChangedItem;
            Exiled.Events.Handlers.Player.InteractingDoor -= OnInteractingDoor;
            base.UnsubscribeEvents();
        }
        
        private void OnChangedItem(Exiled.Events.EventArgs.Player.ChangedItemEventArgs ev)
        {
            if (ev.Item == null || ev.Player == null)
            {
                return;
            }

            string ownerName = ev.Item.Owner.DisplayNickname;

            var easyConfig = MyPlugin.Instance.Config.KeycardInfo;
            
            foreach (var keycardMessage in easyConfig.KeycardMessage)
            {
                foreach (var direct in keycardMessage)
                {
                    if (ev.Item.Type == direct.Key) 
                        ev.Player.ShowHint(direct.Value.Replace("%owner", ownerName), easyConfig.HintDuration);
                }
            }
        }

        private void OnInteractingDoor(Exiled.Events.EventArgs.Player.InteractingDoorEventArgs ev)
        {
            if (ev.IsAllowed == false)
                return;

            if (MyPlugin.Instance.Config.DoorButtonOpen.EnabledRaycast != true)
                return;
                
            if (!Physics.Raycast(ev.Player.CameraTransform.position, ev.Player.CameraTransform.forward, out RaycastHit raycastHit,
                   30, ~(1 << 1 | 1 << 13 | 1 << 16 | 1 << 28)))
            {
                if (raycastHit.collider.gameObject != null)
                {
                    ev.Player.Broadcast(new($"1 This {raycastHit.collider}", 5));
                }
                ev.Player.ShowHint(new("Nuh uh"));
            }

            else
            {
                Exiled.API.Features.Player.Get(raycastHit.collider);
                if (raycastHit.collider.gameObject == null) return;

                if (!(raycastHit.collider.gameObject.name.Contains("TouchScreenPanel") ||
                      raycastHit.collider.gameObject.name.Contains("collider")))
                {
                    ev.Player.ShowHint(MyPlugin.Instance.Config.DoorButtonOpen.NoDoorMessage, 5);
                    ev.IsAllowed = false;
                    return;
                }
                
                ev.Player.ShowHint(MyPlugin.Instance.Config.DoorButtonOpen.YesDoorMessage, 5);
                ev.IsAllowed = true;
            }
        }
    }
}
