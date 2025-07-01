using Exiled.API.Enums;
using Exiled.API.Features;
using MEC;
using Syinergy_RP.API.Audio;
using Syinergy_RP.API.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VoiceChat;
using Random = UnityEngine.Random;

namespace Syinergy_RP.API.Methods
{
    public static class Extension
    {
        public static bool audio = false;
        public static void StartAudio()
        {
            if(!audio)
            {
                audio= true;    
                Audio.Audio.PlayAudio("???", PlayerRoles.RoleTypeId.Tutorial, $"{Path.Combine(Path.Combine(Paths.Configs, "RP/Music/SCP-Containment-Breach-Femur-Breaker-Sounds.ogg"))}", VoiceChatChannel.Intercom, 70);
            }
        }
        public static bool Check106Pos()
        {
            var pos = Room.Get(RoomType.Hcz106).Position;
            pos.x += 23.75f;
            pos.y += 0.435f;
            pos.z -= 10.136f;
            Player p = Player.List.Where(x => Vector3.Distance(x.Position, pos) <= 3f).FirstOrDefault();
            if(p != null)
            {
                return true;
            }
            return false;
        }
        public static void AddRoleScientists(Player pl)
        {
            var rn = Random.Range(0, Plugin.plugin.Config.ScientistsNames.Count - 1);
            var name = Plugin.plugin.Config.ScientistsNames[rn];
            var cinforn = Random.Range(0, Plugin.plugin.Config.SCCinfo.Count - 1);
            var cinfo = Plugin.plugin.Config.SCCinfo[cinforn];
            pl.ClearInventory();
            if(cinforn == 0)
            {
                pl.AddItem(ItemType.KeycardResearchCoordinator);
                pl.AddItem(ItemType.Flashlight);
                pl.AddItem(ItemType.Medkit);
                pl.AddItem(ItemType.Radio);
            }
            else if(cinforn == 1) 
            {
                pl.AddItem(ItemType.KeycardContainmentEngineer);
                pl.AddItem(ItemType.Flashlight);
                pl.AddItem(ItemType.Medkit);
                pl.AddItem(ItemType.Radio);
            }
            else if(cinforn == 2)
            {
                pl.AddItem(ItemType.KeycardJanitor);
                pl.AddItem(ItemType.Flashlight);
                pl.AddItem(ItemType.Medkit);
                pl.AddItem(ItemType.Medkit);
                pl.AddItem(ItemType.Radio);
                pl.AddItem(ItemType.Painkillers);
            }
            else if(cinforn == 3)
            {
                pl.AddItem(ItemType.KeycardScientist);
                pl.AddItem(ItemType.Flashlight);
                pl.AddItem(ItemType.Painkillers);
            }
            else
            {
                pl.AddItem(ItemType.KeycardJanitor);
                pl.AddItem(ItemType.Flashlight);
                pl.AddItem(ItemType.Painkillers);
            }
            pl.CustomInfo = cinfo;
            pl.DisplayNickname = $"[{pl.Id}] | {name}";
        }
        public static void AddBleedingLevel(Player pl)
        {
            var level = 0;
            var rnd = UnityEngine.Random.Range(0, 100);
            if(rnd <= 33)
            {
                level = 1;
            }
            else if(rnd > 33 && rnd <= 67)
            {
                level = 2;
            }
            else if(rnd > 67 && rnd <= 100)
            {
                level = 3;
            }
            
        }
    }
}
