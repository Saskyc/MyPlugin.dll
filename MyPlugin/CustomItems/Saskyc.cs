
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
using MapEditorReborn;
using MapEditorReborn.API.Features.Objects;
using MapEditorReborn.API.Features;
using MapEditorReborn.Commands.ModifyingCommands.Position;
using MapEditorReborn.Commands.ModifyingCommands.Rotation;
using System.IO;
using Discord;
using Exiled.Events.Commands.Reload;
using MapEditorReborn.Events.Handlers;
using YamlDotNet.Core;
using MapEditorObject = MapEditorReborn.API.Features.Objects.MapEditorObject;
using System.Net;
using YamlDotNet.Serialization;
using MapEditorReborn.API.Features.Serializable;
using NotAnAPI.Features.UI;
//using MyPlugin.CustomThings;
using NorthwoodLib.Pools;
//using NotAnAPI;
//using NotAnAPI.API.Extensions;
using MEC;

namespace MyPlugin.CustomItems
{
    [CustomItem(ItemType.Medkit)]
    public class Saskyc : CustomItem
    {
        public override uint Id { get; set; } = 999;
        public override string Name { get; set; } = "Saskyc";
        public override string Description { get; set; } = "Item used to test Saskyc item";
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
        public override Vector3 Scale { get; set; } = new Vector3(1.5f, 1.5f, 1.5f);
        public override bool ShouldMessageOnGban => base.ShouldMessageOnGban;
        protected override void SubscribeEvents()
        {
            /*
            Exiled.Events.Handlers.Player.UsingItem += OnUsingItem;
            Exiled.Events.Handlers.Player.TogglingNoClip += OnTogglingNoClip;
            Exiled.Events.Handlers.Player.DroppingItem += OnDroppingItem;
            Exiled.Events.Handlers.Player.PickingUpItem += OnPickingUpItem;
            Exiled.Events.Handlers.Map.PickupAdded += OnPickupAdded;
            Exiled.Events.Handlers.Player.Dying += OnDying;
            */
            Exiled.Events.Handlers.Player.ChangedItem += OnChangedItem;
            Exiled.Events.Handlers.Player.InteractingDoor += OnInteractingDoor;
            //Exiled.Events.Handlers.Player.ItemAdded += OnItemAdded;
            //Exiled.Events.Handlers.Map.FillingLocker += OnFillingLocker;
            //Exiled.Events.Handlers.Player.Verified += OnVerified;
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents()
        {
            /*
            Exiled.Events.Handlers.Player.UsingItem -= OnUsingItem;
            Exiled.Events.Handlers.Player.TogglingNoClip -= OnTogglingNoClip;
            Exiled.Events.Handlers.Player.DroppingItem -= OnDroppingItem;
            Exiled.Events.Handlers.Player.PickingUpItem -= OnPickingUpItem;
            Exiled.Events.Handlers.Map.PickupAdded -= OnPickupAdded;
            Exiled.Events.Handlers.Player.Dying -= OnDying;
            Exiled.Events.Handlers.Player.ChangedItem -= OnChangedItem;
            Exiled.Events.Handlers.Player.InteractingDoor -= OnInteractingDoor;
            */
            //Exiled.Events.Handlers.Player.ItemAdded -= OnItemAdded;
            //Exiled.Events.Handlers.Map.FillingLocker -= OnFillingLocker;
            //Exiled.Events.Handlers.Player.Verified -= OnVerified;
            base.UnsubscribeEvents();
        }
        /*
        private void OnVerified(Exiled.Events.EventArgs.Player.VerifiedEventArgs ev)
        {
            //BetterHint(PersonalElementDisplay, Time, Player, Messeage);
            PersonalElementDisplay display = new PersonalElementDisplay(StringBuilderPool.Shared.Rent());

            ev.Player.GameObject.AddComponent<UIManager>()._mainDisplay = display;


            Timing.CallDelayed(5f, () =>  
            {
                if (ev.Player.GameObject.TryGetComponent<UIManager>(out UIManager display2))
                {
                    PersonalElementDisplay elementsui = display2._mainDisplay as PersonalElementDisplay;
                    elementsui.Elements.RemoveAt(0);
                }
            });

            MyPlugin.Instance.SomeElement["MyEpicKey"] = $"Hello {ev.Player.DisplayNickname}";
            new HelloWorldElement();

            //ev.Player.ShowHint("Hint")
            //ev.Player.GameObject.GetComponent<UIManager>()._mainDisplay = display;
            //Timing.CallDelayed(5f, () => MyPlugin.Instance.SomeElement["MyEpicKey"] = "\t");

            //ev.Player.SendMessage(NotAnAPI.Features.UI.API.Enums.UIScreenZone.CenterBottom, "Text", 8);
            //ev.Player.SendMessage(NotAnAPI.Features.UI.API.Enums.UIScreenZone.CenterBottom, "Text 2", 8);
            //HelloWorldElement
        }
        
        /*
        private void OnUsingItem(Exiled.Events.EventArgs.Player.UsingItemEventArgs ev)
        {
            if (!Check(ev.Item))
            {
                return;
            }
            ev.Player.Broadcast(new Exiled.API.Features.Broadcast("You used the test item", 5));
        }
        
        private void OnPickingUpItem(Exiled.Events.EventArgs.Player.PickingUpItemEventArgs ev)
        {
            if (ev.Player == null || ev.Pickup == null) return;

            if (!Check(ev.Pickup)) return;

            if (MyPlugin.Instance.SchematicsToDestroy.TryGetValue(ev.Pickup.Serial, out SchematicObject schematic))
            {
                ev.Player.Broadcast(1, "You picked up test item whooo");
                schematic.Destroy();
            }

        }
        
        private void OnDroppingItem(Exiled.Events.EventArgs.Player.DroppingItemEventArgs ev)
        {
            if (!Check(ev.Item))
            {
                return;
            }

            ev.IsAllowed = false;

            if (!Physics.Raycast(ev.Player.CameraTransform.position, ev.Player.CameraTransform.forward, out RaycastHit raycastHit,
                   3, ~(1 << 1 | 1 << 13 | 1 << 16 | 1 << 28)))
            {
                if (raycastHit.collider.gameObject != null)
                {
                    

                    //ev.Player.Broadcast(new($"1 This {raycastHit.collider}, {builder.ToString()}", 5));
                }
                ev.Player.ShowHint(new("Nuh uh"));
                return;
            }

            else
            {
                Player raycastedPlayer = Exiled.API.Features.Player.Get(raycastHit.collider);
                if (raycastHit.collider.gameObject != null)
                {
                    string schematicsDir = Path.Combine(Paths.Configs, "MapEditorReborn", "Schematics");
                    StringBuilder builder = new StringBuilder();

                    builder.Append("<color=orange><b>List of schematics:</b></color>");

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
                            builder.Append($"- <color=yellow>{fileNameWithoutExtension}</color>");
                        }
                    }

                    // Assuming `ev.Player.ShowHint` is the method to display the results
                    ev.Player.ShowHint($"Test, {builder.ToString()}");



                    //response = builder.ToString();
                    //return true;
                    //ev.Player.ShowHint(new($"The players name you raycasted: {raycastedPlayer.DisplayNickname}"));
                }

                return;
            }
        }

        // Event triggered when a pickup is added to the map
        private void OnPickupAdded(Exiled.Events.EventArgs.Map.PickupAddedEventArgs ev)
        {
            if (ev.Pickup == null)
            {
                Log.Warn("OnPickupAdded: Pickup is null.");
                return;
            }

            if (!Check(ev.Pickup))
            {
                return;
            }


            //This is where I check if the name of schematic that I want later to spawn exists
            SchematicObjectDataList dataList = MapUtils.GetSchematicDataByName("PlaceHolderSchematic");
            if (dataList == null) 
            {
                return;
            }

            //This is where I spawn the schematic
            SchematicObject mySchematicsVar = ObjectSpawner.SpawnSchematic("PlaceHolderSchematic", ev.Pickup.Position, Quaternion.Euler(0, 0, 0), new Vector3(1, 1, 1), null, false);

            //This is where I attach the schematic to player
            mySchematicsVar.gameObject.transform.parent = ev.Pickup.GameObject.transform;

            //This is where I add the schematic to dictionary so it can be later destroyed
            MyPlugin.Instance.SchematicsToDestroy[ev.Pickup.Serial] = mySchematicsVar;
        }

        private void OnTogglingNoClip(Exiled.Events.EventArgs.Player.TogglingNoClipEventArgs ev)
        {
            if (ev.Player.CurrentItem == null)
            {
                return;
            }

            if (!Check(ev.Player.CurrentItem))
            {
                return;
            }

            if (MyPlugin.Instance.CustomItemMode.ContainsKey(ev.Player.CurrentItem.Serial) && MyPlugin.Instance.CustomItemMode[ev.Player.CurrentItem.Serial] == 1)
            {
                //code
                MyPlugin.Instance.CustomItemMode[ev.Player.CurrentItem.Serial] = 2;
                ev.Player.ShowHint("Mode was set to 2", 5);
                return;
            }

            else if (MyPlugin.Instance.CustomItemMode.ContainsKey(ev.Player.CurrentItem.Serial) && MyPlugin.Instance.CustomItemMode[ev.Player.CurrentItem.Serial] == 2)
            {
                MyPlugin.Instance.CustomItemMode[ev.Player.CurrentItem.Serial] = 1;
                ev.Player.ShowHint("Mode was set to 1", 5);
                return;
            }

            else
            {
                MyPlugin.Instance.CustomItemMode[ev.Player.CurrentItem.Serial] = 1;
                ev.Player.ShowHint("Mode was set to 1", 5);
                return;
            }
        }

        private void OnDying(Exiled.Events.EventArgs.Player.DyingEventArgs ev)
        {
            ev.Player.DropItems();
        }
        */
        private void OnChangedItem(Exiled.Events.EventArgs.Player.ChangedItemEventArgs ev)
        {
            if (ev.Item == null || ev.Player == null)
            {
                return;
            }

            string ownerName = ev.Item.Owner.DisplayNickname;

            if (ev.Item.Type == ItemType.KeycardJanitor)
            {
                ev.Player.ShowHint(MyPlugin.Instance.Config.KeycardInfo.JanitorMessage.Replace("%owner%", ownerName.ToString()), MyPlugin.Instance.Config.KeycardInfo.HintDuration);
            }

            else if (ev.Item.Type == ItemType.KeycardScientist)
            {
                ev.Player.ShowHint(MyPlugin.Instance.Config.KeycardInfo.ScientistMessage.Replace("%owner%", ownerName.ToString()), MyPlugin.Instance.Config.KeycardInfo.HintDuration);
            }

            else if (ev.Item.Type == ItemType.KeycardZoneManager)
            {
                ev.Player.ShowHint(MyPlugin.Instance.Config.KeycardInfo.ZoneManagerMessage.Replace("%owner%", ownerName.ToString()), MyPlugin.Instance.Config.KeycardInfo.HintDuration);
            }

            else if (ev.Item.Type == ItemType.KeycardResearchCoordinator)
            {
                ev.Player.ShowHint(MyPlugin.Instance.Config.KeycardInfo.ResearchCoordinatorMessage.Replace("%owner%", ownerName.ToString()), MyPlugin.Instance.Config.KeycardInfo.HintDuration);
            }

            else if (ev.Item.Type == ItemType.KeycardContainmentEngineer)
            {
                ev.Player.ShowHint(MyPlugin.Instance.Config.KeycardInfo.ContainmentEngineerMessage.Replace("%owner%", ownerName.ToString()), MyPlugin.Instance.Config.KeycardInfo.HintDuration);
            }

            else if (ev.Item.Type == ItemType.KeycardGuard)
            {
                ev.Player.ShowHint(MyPlugin.Instance.Config.KeycardInfo.GuardMessage.Replace("%owner%", ownerName.ToString()), MyPlugin.Instance.Config.KeycardInfo.HintDuration);
            }

            else if (ev.Item.Type == ItemType.KeycardMTFPrivate)
            {
                ev.Player.ShowHint(MyPlugin.Instance.Config.KeycardInfo.MTFPrivateMessage.Replace("%owner%", ownerName.ToString()), MyPlugin.Instance.Config.KeycardInfo.HintDuration);
            }

            else if (ev.Item.Type == ItemType.KeycardMTFOperative)
            {
                ev.Player.ShowHint(MyPlugin.Instance.Config.KeycardInfo.MTFOperativeMessage.Replace("%owner%", ownerName.ToString()), MyPlugin.Instance.Config.KeycardInfo.HintDuration);
            }

            else if (ev.Item.Type == ItemType.KeycardMTFCaptain)
            {
                ev.Player.ShowHint(MyPlugin.Instance.Config.KeycardInfo.MTFCaptainMessage.Replace("%owner%", ownerName.ToString()), MyPlugin.Instance.Config.KeycardInfo.HintDuration);
            }

            else if (ev.Item.Type == ItemType.KeycardFacilityManager)
            {
                ev.Player.ShowHint(MyPlugin.Instance.Config.KeycardInfo.FacilityManagerMessage.Replace("%owner%", ownerName.ToString()), MyPlugin.Instance.Config.KeycardInfo.HintDuration);
            }

            else if (ev.Item.Type == ItemType.KeycardChaosInsurgency)
            {
                ev.Player.ShowHint(MyPlugin.Instance.Config.KeycardInfo.ChaosInsurgencyMessage.Replace("%owner%", ownerName.ToString()), MyPlugin.Instance.Config.KeycardInfo.HintDuration);
            }

            else if (ev.Item.Type == ItemType.KeycardO5)
            {
                ev.Player.ShowHint(MyPlugin.Instance.Config.KeycardInfo.O5Message.Replace("%owner%", ownerName.ToString()), MyPlugin.Instance.Config.KeycardInfo.HintDuration);
            }

            else
            {
                return;
            }
        }

        private void OnInteractingDoor(Exiled.Events.EventArgs.Player.InteractingDoorEventArgs ev)
        {
            if (ev.IsAllowed == false)
            {
                return;
            }

            if (MyPlugin.Instance.Config.DoorButtonOpen.Enabled_Raycast != true)
            {
                return;
            }
                
            if (!Physics.Raycast(ev.Player.CameraTransform.position, ev.Player.CameraTransform.forward, out RaycastHit raycastHit,
                   30, ~(1 << 1 | 1 << 13 | 1 << 16 | 1 << 28)))
            {
                if (raycastHit.collider.gameObject != null)
                {
                    ev.Player.Broadcast(new($"1 This {raycastHit.collider}", 5));
                }
                ev.Player.ShowHint(new("Nuh uh"));
                return;
            }

            else
            {
                Player raycastedPlayer = Exiled.API.Features.Player.Get(raycastHit.collider);
                if (raycastHit.collider.gameObject == null) 
                {
                    return;  
                }
                //ev.Player.Broadcast(new($"{raycastHit.collider.gameObject.name}", 5));
                if (raycastHit.collider.gameObject.name.Contains("TouchScreenPanel") || raycastHit.collider.gameObject.name.Contains("collider"))
                    {
                    ev.Player.ShowHint(new(MyPlugin.Instance.Config.DoorButtonOpen.YesDoorMessage));
                    ev.IsAllowed = true;
                }
                else
                {
                    ev.Player.ShowHint(new(MyPlugin.Instance.Config.DoorButtonOpen.NoDoorMessage));
                    ev.IsAllowed = false;
                }
            }
        }
    }
}
