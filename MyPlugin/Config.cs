using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;
using PlayerRoles;

namespace MyPlugin;

public class Config : IConfig
{
    [Description("If the plugin is enabled")]
    public bool IsEnabled { get; set; } = true;

    [Description("If the debug mode is enabled")]
    public bool Debug { get; set; } = true;

    public Emotes emotes { get; set; } = new();
    public DoorButtonOpen doorButtonOpen { get; set; } = new();
    public KeycardInfo keycardInfo { get; set; } = new();

    public class Emotes
    {
        [Description("How will the command be named by default it is me (String type)")]
        public string CommandName { get; set; } = "me";

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
        public string NoPermission { get; set; } =
            "No permission for this animation\nIf you write something which has in it CD and you are ClassD than you can use the animation\nFor more info .me without arguments";

        [Description("When person sucessfully plays animation it will tell them (String type)")]
        public string PlayedAnimation { get; set; } = "You played animation named:";

        [Description(
            "List of dictionaries with the permission and role after. Example I want only guards to use schematics that have in name FG")]
        public List<Dictionary<string, RoleTypeId>> Permission = new List<Dictionary<string, RoleTypeId>>
        {
            new Dictionary<string, RoleTypeId>
            {
                { "NONE", RoleTypeId.None },
                { "FG", RoleTypeId.FacilityGuard },
                { "SC", RoleTypeId.Scientist }
            },
        };
    }

    public class DoorButtonOpen
    {
        [Description("If disabled, you don't need to look at door button to open doors.")]
        public bool EnabledRaycast => false;

        [Description("Message to show when the player sucesfully opened door (String type)")]
        public string SuccessMessage => "The door opened";

        [Description("Message to show when the player was not looking at door button (String type)")]
        public string DeclineMessage => "Look at the button";
    }

    public class KeycardInfo
    {
        public readonly List<Dictionary<ItemType, string>> KeycardMessage = new List<Dictionary<ItemType, string>>
        {
            new Dictionary<ItemType, string>
            {
                { ItemType.KeycardJanitor, "<color=#B200FF>Owner: %owner%\nDepartment of Owner: Janitor</color>" },
                { ItemType.KeycardScientist, "<color=#F9FF71>Owner: %owner%\nDepartment of Owner: Scientific</color>" },
                {
                    ItemType.KeycardZoneManager,
                    "<color=#00FF0C>Owner: %owner%\nDepartment of Owner: Administritive</color>"
                },
                {
                    ItemType.KeycardResearchCoordinator,
                    "<color=#F3FF00>Owner: %owner%\nDepartment of Owner: Scientific</color>"
                },
                {
                    ItemType.KeycardContainmentEngineer,
                    "<color=#AD7B36>Owner: %owner%\nDepartment of Owner: Scientific/Techinician</color>"
                },
                { ItemType.KeycardGuard, "<color=#5D5D5D>Owner: %owner%\nDepartment of Owner: OSS</color>" },
                { ItemType.KeycardMTFPrivate, "<color=#00FBFF>Owner: %owner%\nDepartment of Owner: MTF</color>" },
                { ItemType.KeycardMTFOperative, "<color=#0087FF>Owner: %owner%\nDepartment of Owner: MTF</color>" },
                { ItemType.KeycardMTFCaptain, "<color=#002BFF>Owner: %owner%\nDepartment of Owner: MTF</color>" },
                {
                    ItemType.KeycardFacilityManager,
                    "<color=#FF0000>Owner: %owner%\nDepartment of Owner: Administrative</color>"
                },
                { ItemType.KeycardChaosInsurgency, "<color=#003B01>Owner: ???\nDepartment of Owner: ???</color>" },
                { ItemType.KeycardO5, "<color=#000000>Owner: ???\nDepartment of Owner: ???</color>" },
            },
        };

        public int HintDuration { get; set; } = 5;
    }
}
