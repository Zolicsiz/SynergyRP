using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Exiled.API.Interfaces;
using MapEditorReborn.Commands.ModifyingCommands.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Syinergy_RP.API.Methods
{
    public static class CustomItems
    {
        public static void CreateItems(Player pl)
        {
            Vector3 position049 = Room.Get(RoomType.Hcz049).Position;
            position049.y += 193.853f;
            position049.x -= 5.576f;
            position049.z -= 3.116f;
            FirearmPickup s049 = (FirearmPickup)FirearmPickup.CreateAndSpawn(ItemType.GunCOM15, position049, new Quaternion());
            s049.Ammo = 3;
            Plugin.plugin.eventHandlers.customweaponspickup.Add(s049);

            Vector3 position939 = Room.Get(RoomType.Hcz939).Position;
            position939.y -= -1.205f;
            position939.x -= 0.5f;
            position939.z += 1.27f;
            FirearmPickup s939 = (FirearmPickup)FirearmPickup.CreateAndSpawn(ItemType.GunCOM18, position939, new Quaternion());
            s939.Ammo = 3;
            Plugin.plugin.eventHandlers.customweaponspickup.Add(s939);
            
        }
    }
}
