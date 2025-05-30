using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using UnityEngine;
using MEC;
using PlayerRoles;
using Exiled.API.Enums;
using Exiled.CustomItems.API.Features;

namespace MyPlugin.Roles
{
    [CustomRole(RoleTypeId.None)]
    public class SCP035 : CustomRole
    {
        //public int Chance { get; set; } = 0;

        public override uint Id { get; set; } = 129;

        public override RoleTypeId Role { get; set; } = RoleTypeId.None;

        public override int MaxHealth { get; set; } = 1000;

        public override string Name { get; set; } = "SCP-035";

        public override string Description { get; set; } =
            "Jsi SCP-035\nVysoce korozivní viskózní tekutina neustále vytéká z děr pro oči a ústa SCP-035.\nJsi velmi agresivní vůči ostatnímu personálu.";

        public override string CustomInfo { get; set; } = "SCP-035";

        public override bool KeepInventoryOnSpawn { get; set; } = true;

        public override bool KeepRoleOnDeath { get; set; } = false;

        public override bool RemovalKillsPlayer { get; set; } = false;

        public override SpawnProperties SpawnProperties { get; set; } //= new()
        //{
          //  Limit = 1,
        //};
        
        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.Dying += OnDying;
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.Dying -= OnDying;
            base.UnsubscribeEvents();
        }

        private void OnDying(Exiled.Events.EventArgs.Player.DyingEventArgs ev)
        {
            if (!Check(ev.Player))
                return;
            CustomItem.Get((uint)20).Spawn(ev.Player.Position + new Vector3(0, 1f, 0));
        }

        protected override void RoleAdded(Exiled.API.Features.Player player)
        {
            //Timing.CallDelayed(2.5f, () => player.Scale = new Vector3(1.3f, 1.3f, 1.3f));
            Timing.CallDelayed(0.5f, () => player.EnableEffect(EffectType.Corroding, 255, 1000, true));
            Timing.CallDelayed(0.5f, () => player.EnableEffect(EffectType.Poisoned, 255, 1000, true));

            player.IsUsingStamina = true;

        }

        protected override void RoleRemoved(Exiled.API.Features.Player player)
        {
            player.IsUsingStamina = true;
            player.Scale = Vector3.one;
        }
    }
}



