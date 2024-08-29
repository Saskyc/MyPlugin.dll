using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Interfaces;
using InventorySystem.Items.Coin;
using MyPlugin.CustomItems;
using UnityEngine;
using MyPlugin.API;

namespace MyPlugin
{

    public class Config : IConfig
    {
        [Description("If the plugin is enabled")]
        public bool IsEnabled { get; set; } = true;

        [Description("If the debug mode is enabled")]
        public bool Debug { get; set; } = true;

        public CustomItem1K CustomItem1 { get; set; } = new CustomItem1K();
        public Searchh Search { get; set; } = new Searchh();
        public SCP035S SCP035 { get; set; } = new SCP035S();
        public Taserr Taser { get; set; } = new Taserr();
        public Emotess Emotes { get; set; } = new Emotess();
        public DoorButtonOpenn DoorButtonOpen { get; set; } = new DoorButtonOpenn();
        public KeycardInfoo KeycardInfo { get; set; } = new KeycardInfoo();
        
        public class CustomItem1K
        {
            [Description("Item that will have ability of Custom Item (Item type)")]
            public ItemType CustomItemType { get; set; } = ItemType.Painkillers;

            [Description("ID Of Custom item Custom Item (uint type)")]
            public uint CustomItemTypeId { get; set; } = 1;

            [Description("Name Of Custom item Custom Item (string type)")]
            public string CustomItemName { get; set; } = "Amnestics Type A";

            [Description("Description Of Custom item Custom Item (string type)")]
            public string CustomItemDs { get; set; } = "Medicine that will make someone forget 6 - 10 hours";

            [Description("Scale Of Custom item Custom Item (Vector3 float type)")]
            public Vector3 CustomItemScale { get; set; } = new Vector3(1.5f, 1.5f, 1.5f);

            [Description("Broadcast messeage after consuming Custom Item (String type)")]
            public String CustomItemBroadcastMesseage { get; set; } = "You ate Amnestics A and forgot 6 - 10 hours";

            [Description("Broadcast time after consuming Custom Item (Ushort type)")]
            public ushort CustomItemBroadcastTime { get; set; } = 7;

            [Description("Effect type to give player after consuming Custom Item (Effect type)")]
            public EffectType[] CustomItemEffectTypes { get; set; } =
            {
                EffectType.Bleeding,
                EffectType.AmnesiaVision,
                EffectType.Deafened
            };

            [Description("Add effect time to effects you added before (Float type)")]
            public float[] CustomItemEffectTime { get; set; } =
            {
                3,
                3,
                8,
            };

            [Description("Add effect intensity to effects you added before (Byte type)")]
            public byte[] CustomItemEffectIntensity { get; set; } =
            {
                7,
                7,
                2,
            };

            [Description("If player alrady has effect you will add more time to it If yes true if not false (Bool type)")]
            public bool[] CustomItemEffectAddDuration { get; set; } =
            {
                false,
                false,
                true,
            };

            [Description("Add late time to this meaning it will execute in like: 0.5s [always add f] (Float type)")]
            public float[] CustomItemEffectAddLateDuration { get; set; } =
            {
                0f,
                0.5f,
                1f,
            };

            [Description("Custom MER model you want to use for your custom item (String type) (If you enter wrong schematic name it will just not be used)")]
            public string Model { get; set; } = "PlaceholderSchematicName";
        }

        public class SCP035S
        {
            [Description("Item that will have ability of Custom Item (Item type)")]
            public ItemType CustomItemType { get; set; } = ItemType.GunAK;

            [Description("ID Of Custom item Custom Item (uint type)")]
            public uint CustomItemTypeId { get; set; } = 30;

            [Description("Name Of Custom item Custom Item (string type)")]
            public string CustomItemName { get; set; } = "Amnestika Type A";

            [Description("Description Of Custom item Custom Item (string type)")]
            public string CustomItemDs { get; set; } = "<size=15> Pilulky na zapomenutí 6 - 12 hodin času.\nSložení:\nAmnestikum A-7\nNeurotransmiterový inhibitor G-23\nStabilizátor engramů P-12\nSyntetický modulátor paměti R-9</size>";

            [Description("Scale Of Custom item Custom Item (Vector3 float type)")]
            public Vector3 CustomItemScale { get; set; } = new Vector3(1.5f, 1.5f, 1.5f);

            [Description("Broadcast messeage after consuming Custom Item (String type)")]
            public String CustomItemBroadcastMesseage { get; set; } = "Pilule ti jdou do hrdla.\nNevíš kde jsi poslední informaci si pamatuješ před 9 hodinami.";

            [Description("Broadcast time after consuming Custom Item (Ushort type)")]
            public ushort CustomItemBroadcastTime { get; set; } = 5;

            [Description("Effect type to give player after consuming Custom Item (Effect type)")]
            public EffectType[] CustomItemEffectTypes { get; set; } =
            {
                EffectType.Bleeding,
                EffectType.AmnesiaVision
            };

            [Description("Add effect time to effects you added before (Float type)")]
            public float[] CustomItemEffectTime { get; set; } =
            {
                3,
                3
            };

            [Description("Add effect intensity to effects you added before (Byte type)")]
            public byte[] CustomItemEffectIntensity { get; set; } =
            {
                7,
                7
            };

            [Description("If player alrady has effect will you add more time to it? If yes true if not false (Bool type)")]
            public bool[] CustomItemEffectAddDuration { get; set; } =
            {
                false,
                false
            };

            [Description("Add late time to this meaning it will execute in like: 0.5s [always add f] (Float type)")]
            public float[] CustomItemEffectAddLateDuration { get; set; } =
            {
                0f,
                0.5f
            };

            [Description("Custom MER model you want to use for your custom item (String type) (If you enter wrong schematic name it will just not be used)")]
            public string Model { get; set; } = "PlaceholderSchematicName";
        }

        public class Searchh
        {
            [Description("Item that will be used as pickup for search (Item type)")]
            public ItemType CustomItemType { get; set; } = ItemType.Medkit;

            [Description("ID Of Custom pickup item (uint type)")]
            public uint CustomItemTypeId { get; set; } = 998;

            [Description("Name Of Custom pickup (string type)")]
            public string CustomItemName { get; set; } = "Search";

            [Description("Description Of Custom pickup (string type)")]
            public string CustomItemDs { get; set; } = "This is pickup item you will not have this";

            [Description("Scale Of the Custom item (Vector3 float type)")]
            public Vector3 CustomItemScale { get; set; } = new Vector3(1.3f, 1.3f, 1.3f);

            [Description("Items to add to the bin if you want some item to be added more than other just add it twice. (Item Type)")]
            public ItemType[] ItemToGive { get; set; } =
            {
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Painkillers,
                    ItemType.Medkit,
                    ItemType.Medkit,
                    ItemType.Medkit,
                    ItemType.Medkit,
                    ItemType.Medkit,
                    ItemType.Medkit,
                    ItemType.Medkit,
                    ItemType.Medkit,
                    ItemType.Medkit,
                    ItemType.Medkit,
                    ItemType.GunCOM15,
                    ItemType.GunCOM15,
                    ItemType.GunCOM15,
                    ItemType.GunCOM15,
                    ItemType.GunCOM15,
                    ItemType.GunCOM18,
                    ItemType.KeycardJanitor,
                    ItemType.KeycardJanitor,
                    ItemType.KeycardJanitor,
                    ItemType.KeycardScientist
            };

            [Description("Hint message to send to players when they are on cooldown (string type)")]
            public string CustomItemCooldownHint { get; set; } = "You are on cooldown";

            [Description($"The messeage will last [X] seconds (int type)")]
            public int CustomItemCooldownHintTime { get; set; } = 5;

            [Description("Hint that will be shown when Item was given to player (String type")]
            public string HintItemGiven { get; set; } = "You got %item%";

            [Description("How long will the message HintItemGiven last? (int type")]
            public int HintItemGivenTime { get; set; } = 5;
        }

        public class Taserr
        {
            [Description("Item that will have ability of Custom Item (Item type)")]
            public ItemType CustomItemType { get; set; } = ItemType.GunCOM15;

            [Description("ID Of Custom item Custom Item (uint type)")]
            public uint CustomItemTypeId { get; set; } = 33;

            [Description("Name Of Custom item Custom Item (string type)")]
            public string CustomItemName { get; set; } = "Taser";

            [Description("Description Of Custom item Custom Item (string type)")]
            public string CustomItemDs { get; set; } = "Taser that will stop someone for some time.";

            [Description("Scale Of Custom item Custom Item (Vector3 float type)")]
            public Vector3 CustomItemScale { get; set; } = new Vector3(1f, 1f, 1f);

            [Description("Effect type to give player after consuming Custom Item (Effect type)")]
            public EffectType[] CustomItemEffectTypes { get; set; } =
            {
                EffectType.Flashed,
                EffectType.Ensnared,
                EffectType.Blinded,
                EffectType.Deafened,
            };

            [Description("Add effect time to effects you added before (Float type)")]
            public float[] CustomItemEffectTime { get; set; } =
            {
                8,
                8,
                16,
                16,
            };

            [Description("Add effect intensity to effects you added before (Byte type)")]
            public byte[] CustomItemEffectIntensity { get; set; } =
            {
                3,
                3,
                3,
                3,
            };

            [Description("If player alrady has effect will you add more time to it? If yes true if not false (Bool type)")]
            public bool[] CustomItemEffectAddDuration { get; set; } =
            {
                false,
                false,
                false,
                false,
            };

            [Description("Add late time to this meaning it will execute in like: 0.5s [always add f] (Float type)")]
            public float[] CustomItemEffectAddLateDuration { get; set; } =
            {
                0f,
                0f,
                0f,
                0f,
            };

            [Description("Custom MER model you want to use for your custom item (String type) (If you enter wrong schematic name it will just not be used)")]
            public string Model { get; set; } = "PlaceholderSchematicName";
        }
    }

    public class Emotess
    {
        [Description("How will the command be named by default it is .me (String type)")]
        public string CommandName { get; set; } = ".me";

        [Description("What aliases will the command name have defaultly .m (String type)")]
        public string CommandAlias { get; set; } = ".m";

        [Description("What description will this command have (String type)")]
        public string CommandDescription { get; set; } = "Play emotes";

        [Description("The text that it will show in console when showing list of animations (String type)")]
        public string ListOfAnimations { get; set; } = "List of animations";

        [Description("When arguments are empty this will be the answer: (String type)")]
        public string EmptyAnwer { get; set; } = "\nAlone .me deletes selected emote\nUsage: .me !Animation";

        [Description("When arguments do not have the key [!] it will tell the player to include it: (String type)")]
        public string KeyNotIncluded { get; set; } = "The command must include the key[!]";

        [Description("When person does not have permission to use emote more explained in github README (String type)")]
        public string NoPermission { get; set; } = "No permission for this animation\nIf you write something which has in it CD and you are ClassD than you can use the animation\nFor more info .me without arguments";

        [Description("When person sucessfully plays animation it will tell them (String type)")]
        public string PlayedAnimation { get; set; } = "You played animation named:";

    }

    public class DoorButtonOpenn
    {
        [Description("Should this feature be enabled (String type)")]
        public bool Enabled_Raycast { get; set; } = true;

        [Description("Message to show when the player sucesfully opened door (String type)")]
        public string YesDoorMessage { get; set; } = "The door opened";

        [Description("Message to show when the player was not looking at door button (String type)")]
        public string NoDoorMessage { get; set; } = "Look at the button";
    }

    public class KeycardInfoo
    {
        [Description("Message to show when the player holds a Janitor keycard (string type)")]
        public string JanitorMessage { get; set; } = "<color=#B200FF>Owner: %owner%\nDepartment of Owner: Janitor</color>";

        [Description("Message to show when the player holds a Scientist keycard (string type)")]
        public string ScientistMessage { get; set; } = "<color=#F9FF71>Owner: %owner%\nDepartment of Owner: Scientific</color>";

        [Description("Message to show when the player holds a Zone Manager keycard (string type)")]
        public string ZoneManagerMessage { get; set; } = "<color=#00FF0C>Owner: %owner%\nDepartment of Owner: Administritive</color>";

        [Description("Message to show when the player holds a Research Coordinator keycard (string type)")]
        public string ResearchCoordinatorMessage { get; set; } = "<color=#F3FF00>Owner: %owner%\nDepartment of Owner: Scientific</color>";

        [Description("Message to show when the player holds a Containment Engineer keycard (string type)")]
        public string ContainmentEngineerMessage { get; set; } = "<color=#AD7B36>Owner: %owner%\nDepartment of Owner: Scientific/Techinician</color>";

        [Description("Message to show when the player holds a Guard keycard (string type)")]
        public string GuardMessage { get; set; } = "<color=#5D5D5D>Owner: %owner%\nDepartment of Owner: OSS</color>";

        [Description("Message to show when the player holds an MTF Private keycard (string type)")]
        public string MTFPrivateMessage { get; set; } = "<color=#00FBFF>Owner: %owner%\nDepartment of Owner: MTF</color>";

        [Description("Message to show when the player holds an MTF Operative keycard (string type)")]
        public string MTFOperativeMessage { get; set; } = "<color=#0087FF>Owner: %owner%\nDepartment of Owner: MTF</color>";

        [Description("Message to show when the player holds an MTF Captain keycard (string type)")]
        public string MTFCaptainMessage { get; set; } = "<color=#002BFF>Owner: %owner%\nDepartment of Owner: MTF</color>";

        [Description("Message to show when the player holds a Facility Manager keycard (string type)")]
        public string FacilityManagerMessage { get; set; } = "<color=#FF0000>Owner: %owner%\nDepartment of Owner: Administrative</color>";

        [Description("Message to show when the player holds a Chaos Insurgency keycard (string type)")]
        public string ChaosInsurgencyMessage { get; set; } = "<color=#003B01>Owner: ???\nDepartment of Owner: ???</color>";

        [Description("Message to show when the player holds an O5 keycard (string type)")]
        public string O5Message { get; set; } = "<color=#000000>Owner: ???\nDepartment of Owner: ???</color>";

        [Description("Duration of the hint message in seconds (int type)")]
        public int HintDuration { get; set; } = 5;
    }
}
