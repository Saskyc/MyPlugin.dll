using System.Data.Common;
using UnityEngine;

namespace MyPlugin.EventHandlers;

public static class PlayerEv
{
    public static void Subscribe()
    {
        Exiled.Events.Handlers.Player.ChangedItem += OnChangedItem;
        Exiled.Events.Handlers.Player.InteractingDoor += OnInteractingDoor;
    }
    
    public static void Unsubscribe()
    {
        Exiled.Events.Handlers.Player.ChangedItem -= OnChangedItem;
        Exiled.Events.Handlers.Player.InteractingDoor -= OnInteractingDoor;
    }
    
    private static void OnChangedItem(Exiled.Events.EventArgs.Player.ChangedItemEventArgs ev)
    {
        if (ev.Item == null || ev.Player == null) return;

        var config = MyPlugin.Instance.Config.keycardInfo;
            
        foreach (var keycardMessage in config.KeycardMessage)
        {
            foreach (var direct in keycardMessage)
            {
                if (ev.Item.Type == direct.Key) 
                    ev.Player.ShowHint(direct.Value.Replace("%owner", ev.Item.Owner.DisplayNickname), config.HintDuration);
            }
        }
    }

    private static void OnInteractingDoor(Exiled.Events.EventArgs.Player.InteractingDoorEventArgs ev)
    {
        if (ev.IsAllowed == false) return;

        if (!MyPlugin.Instance.Config.doorButtonOpen.EnabledRaycast) return;

        if (!Physics.Raycast(ev.Player.CameraTransform.position, ev.Player.CameraTransform.forward,
                out var raycastHit,
                30, ~(1 << 1 | 1 << 13 | 1 << 16 | 1 << 28))) return;
        
        Exiled.API.Features.Player.Get(raycastHit.collider);
        if (raycastHit.collider.gameObject == null) return;

        ev.IsAllowed = raycastHit.collider.gameObject.name.Contains("TouchScreenPanel") ||
                       raycastHit.collider.gameObject.name.Contains("collider");

        if (ev.IsAllowed)
        {
            ev.Player.ShowHint(MyPlugin.Instance.Config.doorButtonOpen.SuccessMessage, 5);
            return;
        }
        
        ev.Player.ShowHint(MyPlugin.Instance.Config.doorButtonOpen.DeclineMessage, 5);
    }
}