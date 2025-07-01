using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syinergy_RP.API.CustomItems
{
    public abstract class CustomItem
    {
        public static List<CustomItem> Items = new List<CustomItem>();
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract uint Id { get; set; }
        public abstract ItemType Item {  get; set; }
        public static CustomItem Get(string Name)
        {
            return Items.Where(x=>x.Name == Name).FirstOrDefault();
        }
        public static CustomItem Get(uint id)
        {
            return Items.Where(x=> x.Id == id).FirstOrDefault();
        }
        protected virtual void RegisterEvents()
        {
            Exiled.Events.Handlers.Player.Dying += OnOwnerDying;
            Exiled.Events.Handlers.Player.DroppingItem += OnDropping;
            Exiled.Events.Handlers.Player.ChangingItem += OnChanging;
            Exiled.Events.Handlers.Player.PickingUpItem += OnPickingUp;
        }
        protected virtual void UnRegisterEvents()
        {
            Exiled.Events.Handlers.Player.Dying -= OnOwnerDying;
            Exiled.Events.Handlers.Player.DroppingItem -= OnDropping;
            Exiled.Events.Handlers.Player.ChangingItem -= OnChanging;
            Exiled.Events.Handlers.Player.PickingUpItem -= OnPickingUp;
        }
        protected virtual void OnOwnerDying(DyingEventArgs ev)
        {

        }
        protected virtual void OnDropping(DroppingItemEventArgs ev)
        {

        }
        protected virtual void OnChanging(ChangingItemEventArgs ev)
        {

        }
        protected virtual void OnPickingUp(PickingUpItemEventArgs ev)
        {

        }
    }
}
