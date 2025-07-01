using AudioInteract.API.Events.EventArgs;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Core;
using Exiled.API.Features.Doors;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using Exiled.API.Features.Roles;
using Exiled.API.Structs;
using Exiled.Events.Commands.Reload;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp106;
using Exiled.Events.EventArgs.Server;
using MapEditorReborn.API.Features;
using MapEditorReborn.API.Features.Objects;
using MapEditorReborn.Events.EventArgs;
using MapEditorReborn.Events.Handlers;
using MEC;
using Mirror;
using PlayerRoles;
using PlayerRoles.PlayableScps.Scp106;
using Syinergy_RP.API.Classes;
using Syinergy_RP.API.CustomItems;
using Syinergy_RP.API.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;
using Scp106Role = Exiled.API.Features.Roles.Scp106Role;

namespace Syinergy_RP
{
    public class EventHandlers
    {
        public bool tesla = true;
        public List<Item> customweapons = new List<Item>();
        public List<Pickup> customweaponspickup = new List<Pickup>();
        public bool Chaos = true;
        public bool Mtf = true;
        public List<Player> ClassD = new List<Player>();
        public List<Player> Scientists = new List<Player>();
        public List<Player> Guards = new List<Player>();
        public List<Player> Scps = new List<Player>();
        public bool kill106 = false;
        public CoroutineHandle coro = new CoroutineHandle();
        public PrimitiveObject schematic;
        public bool scp939 = false;
        public bool InPocket = false;
        public bool IsRm = false;
        public bool IsVirus = false;
        public bool IsLockDBlock = false;
        public EventHandlers()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers += OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded += OnRoundEnded;
            Exiled.Events.Handlers.Player.Dying += OnDying;
            Exiled.Events.Handlers.Player.DroppingItem += OnDroppingItem;
            Exiled.Events.Handlers.Player.PickingUpItem += OnPickingUpItem;
            Exiled.Events.Handlers.Player.ReloadingWeapon += OnReloadingWeapon;
            Exiled.Events.Handlers.Player.Shooting += OnShoting;
            Exiled.Events.Handlers.Player.InteractingDoor += OnUseDoor;
            Exiled.Events.Handlers.Player.Hurting += OnHurting;
            Exiled.Events.Handlers.Server.RespawningTeam += OnRespawningTeam;
            Exiled.Events.Handlers.Player.ChangingRole += OnChangingRole;
            Exiled.Events.Handlers.Player.Spawned += OnSpawned;
            MapEditorReborn.Events.Handlers.Schematic.SchematicSpawned += OnSpawnedSc;
            
            AudioInteract.Features.Events.Track.TrackFinished += OnStopAudio;
            Exiled.Events.Handlers.Player.Escaping += OnEscaping;
            Exiled.Events.Handlers.Player.UsedItem += OnUsedItem; 
            Exiled.Events.Handlers.Server.RespawningTeam += OnRespawningteam;
            Exiled.Events.Handlers.Scp106.Stalking += OnStalking;
            
        }
        public void OnStopAudio(TrackFinishedEventArgs ev)
        {
            AudioInteract.Features.API.DestroyNPC(ev.MusicInstance);
        }
        public void OnWaitingForPlayers()
        {
            IsRm = false;
            InPocket = false;
        }
        public void OnRoundStarted()
        {
            Vector3 pos = new Vector3(85.235f, -999.106f, 157.692f);
            coro = Timing.RunCoroutine(handle106());
            foreach (Player pl in Player.List)
            {
                
                if(pl.Role.Team == PlayerRoles.Team.ClassD)
                {
                    ClassD.Add(pl);
                }
                else if(pl.Role.Team == PlayerRoles.Team.Scientists)
                {
                    Scientists.Add(pl);
                }
                else if(pl.Role.Team == PlayerRoles.Team.FoundationForces)
                {
                    Guards.Add(pl);
                }
                else if(pl.Role.Team == PlayerRoles.Team.SCPs)
                {
                    Scps.Add(pl);
                }
            }
            foreach(Player item in ClassD)
            {
                var rnd = Random.Range(0001, 9999);
                item.DisplayNickname = $"[{item.Id}] | D-{rnd}";
            }
            foreach(Player item3 in Scps)
            {
                item3.DisplayNickname = $"[{item3.Id}] | ...";
                if(item3.Role.Type == RoleTypeId.Scp049)
                {
                    item3.Health = 500f;
                }
                else if(item3.Role.Type == RoleTypeId.Scp173)
                {
                    item3.Health = 65355f;
                }
                else if (item3.Role.Type == RoleTypeId.Scp106)
                {
                    item3.Health = 65355f;
                }
                else if (item3.Role.Type == RoleTypeId.Scp939)
                {
                    item3.Health = 2000f;
                }
                else if (item3.Role.Type == RoleTypeId.Scp096)
                {
                    item3.Health = 65355f;
                }
            }
            int a = 0;
            foreach(Player item2 in Scientists)
            {
                item2.ClearInventory();
                var rn = Random.Range(0, Plugin.plugin.Config.ScientistsNames.Count - 1);
                var name = Plugin.plugin.Config.ScientistsNames[rn];
                if (a == 0)
                {
                    item2.DisplayNickname = $"[{item2.Id}] | Д-р {name}";
                    item2.CustomInfo = "<color=#00FFFF>| Старший Исследователь |</color>";
                    item2.AddItem(ItemType.KeycardResearchCoordinator);
                    item2.AddItem(ItemType.Flashlight);
                    item2.AddItem(ItemType.Medkit);
                    item2.AddItem(ItemType.Radio);
                }
                else if (a == 1) 
                {
                    item2.DisplayNickname = $"[{item2.Id}] | Д-р {name}";
                    item2.CustomInfo = "<color=#00FFFF>| Инженер Камер Содержаний|</color>";
                    item2.AddItem(ItemType.KeycardContainmentEngineer);
                    item2.AddItem(ItemType.Flashlight);
                    item2.AddItem(ItemType.Medkit);
                    item2.AddItem(ItemType.Radio);
                }
                else if (a == 2)
                {
                    item2.DisplayNickname = $"[{item2.Id}] | Д-р {name}";
                    item2.CustomInfo = "<color=#00FFFF>| Штатный Медик |</color>";
                    item2.AddItem(ItemType.KeycardJanitor);
                    item2.AddItem(ItemType.Flashlight);
                    item2.AddItem(ItemType.Medkit);
                    item2.AddItem(ItemType.Medkit);
                    item2.AddItem(ItemType.Radio);
                    item2.AddItem(ItemType.Painkillers);
                }
                else if(a == 3)
                {
                    item2.DisplayNickname = $"[{item2.Id}] | Д-р {name}";
                    item2.CustomInfo = "<color=#00FFFF>| Рядовой Исследователь |</color>";
                    item2.AddItem(ItemType.KeycardScientist);
                    item2.AddItem(ItemType.Flashlight);
                    item2.AddItem(ItemType.Painkillers);
                }
                else 
                {
                    item2.DisplayNickname = $"[{item2.Id}] | Д-р {name}";
                    item2.CustomInfo = "<color=#00FFFF>| Лаборант |</color>";
                    item2.AddItem(ItemType.KeycardJanitor);
                    item2.AddItem(ItemType.Flashlight);
                    item2.AddItem(ItemType.Painkillers);
                }
                a++;
            }
            foreach(Player player in Guards)
            {
                var rn = Random.Range(0, Plugin.plugin.Config.GuardsNames.Count - 1);
                var name = Plugin.plugin.Config.GuardsNames[rn];
                player.ClearInventory();
                player.DisplayNickname = $"[{player.Id}] | {name}";
                player.AddItem(ItemType.KeycardGuard);
                player.AddItem(ItemType.Radio);
                player.AddItem(ItemType.Medkit);
                player.AddItem(ItemType.GunFSP9);
                player.AddItem(ItemType.GrenadeFlash);
                player.SetAmmo(AmmoType.Nato9, 60);
                player.AddItem(ItemType.GunCOM18);
                player.AddItem(ItemType.ArmorLight);
                player.CustomInfo = "<color=#00FFFF>| Одет в Бронежилет VISION, Шлем Riot-XTAC с Забралом, на поясе кобура | На правом плече шеврон организации \"SCP\", на левом плече шеврон \"Службы Безопасности: Комендантский Отряд\" | На плечах патчи \"Рядовой\" |</color>\r\n";
            }
            UserClass.List.Clear();
            CustomItems.CreateItems(Player.List.FirstOrDefault());
            Timing.CallDelayed(15f, () =>
            {
                Server.ExecuteCommand("Cassie_sl <size=24> Система <color=#e30071>[C.A.S.S.I.E.] <color=white>стабильна и готова к работе. <size=0> System Cassie stable and ready to work . <split> <size=24> Добро пожаловать персонал <color=#e30071>Учреждения №97<color=white>. <size=0> Welcome Personnel facility 97 . <split> <size=24> Текущая температура в <color=#e30071>Учреждении [-23 Цельсия]<color=white>. <size=0> Current temperature in facility is Minus 23 Celsius . <split> <size=24> Текущее местное время <color=#e30071>[4:00 A.M.]<color=white>. <size=0> Current location time is 4 hour A M . <split> <size=24> <color=#fcf400>Научный персонал <color=white>и <color=#fcf400>Медицинский персонал<color=white>. Начинайте свою работу. <size=0> Science Personnel and Medical personnel . Start your work . <split> <size=24> <color=#adadad>Служба Безопасности <color=white>немедленно пройдите к <color=#e30071>[INTERCOM] <color=white>и ожидайте старшего бойца по званию. <size=0> Security Service immediately move to Intercom and wait senior unit by  rank . <split> <size=24> <color=#61ff76>[Напоминание] <color=white>Персонал <color=#e30071>Учреждения №97<color=white> всегда храните свои карты доступа. <size=0> Personnel facility 97 . Always keep your access card . <split> <size=24> <color=#d6004f>[S] - Sеcure<color=white>. <color=#ad0040>[C] - Сontain<color=white>. <color=#700029>[P] - Prоtect<color=white>. <size=0> Pitch_1,00 S Secure . Pitch_0,90 C Contain . Pitch_0,80 P Protect . jam_049_9 .G4 .");
            });
            
            Log.Info("Accepted");
        }
        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            Timing.KillCoroutines(coro);
            Server.ExecuteCommand("rnr");
        }
        public void OnStalking(StalkingEventArgs ev)
        {
            
        }


        public void OnRespawningteam(RespawningTeamEventArgs ev)
        {
            if(ev.NextKnownTeam == Respawning.SpawnableTeamType.ChaosInsurgency)
            {
                Cassie.MessageTranslated("Pitch_0.15 .g4 Pitch_0.16 .g4 Pitch_0.15 Pitch_0.15 .g4 .g4 pitch_0.16 .g4 pitch_0.94 . attention to all personnel . . zone was attacked by unknown military unit . code white has been activated yd_1 and gates was lockdownd . . personnel are advised to report in the nearest safe location and wait until the facility have been secured from all possible threats . Pitch_0.8 .g5 .g5 pitch_0.3 .g5", "<size=21><b><color=#8B0000>ТРЕВОГА</color> | Всему персоналу: Зона была атакована неизвестным вооружённым формированием. Код \"Белый\" был <color=#6ccc23>активирован</color> и гермозатворы были заблокированы. Персоналу требуется пройти в ближайшее безопасное место и ждать пока комплекс не будет зачищен от всех возможных <color=#f70c0c>угроз</color>.");
            }
        }
        public void OnUsedItem(UsedItemEventArgs ev)
        {
            if(ev.Item.Type == ItemType.Painkillers || ev.Item.Type == ItemType.Adrenaline)
            {
                if(UserClass.Get(ev.Player.UserId) == null)
                {
                    new UserClass(ev.Player.UserId);
                    UserClass.Get(ev.Player.UserId).Painkillers++;
                }
                UserClass.Get(ev.Player.UserId).Painkillers++;
                if(UserClass.Get(ev.Player.UserId).Painkillers >= 2)
                {
                    ev.Player.Kill("Передозировка лекарствами...");
                    var user = UserClass.Get(ev.Player.UserId);
                    UserClass.List.Remove(user);
                }

            }

        }
        public void OnSpawned(SpawnedEventArgs ev)
        {
            if(ev.Reason == SpawnReason.Escaped)
            {
                ev.Player.ClearInventory();
                ev.Player.Role.Set(RoleTypeId.Spectator);
            }
            if (ev.Player.Role.Type == PlayerRoles.RoleTypeId.NtfCaptain)
            {
                var rn = Random.Range(0, Plugin.plugin.Config.MTFNames.Count - 1);
                var name = Plugin.plugin.Config.MTFNames[rn];
                ev.Player.DisplayNickname = $"[{ev.Player.Id}] | {name}";
                ev.Player.ClearInventory();
                ev.Player.AddItem(ItemType.KeycardMTFCaptain);
                ev.Player.AddItem(ItemType.Radio);
                ev.Player.AddItem(ItemType.Medkit);
                ev.Player.AddItem(ItemType.GunE11SR);
                ev.Player.SetAmmo(AmmoType.Nato556, 80);
                ev.Player.AddItem(ItemType.GrenadeFlash);
                ev.Player.SetAmmo(AmmoType.Nato9, 60);
                ev.Player.AddItem(ItemType.GunCOM18);
                ev.Player.AddItem(ItemType.ArmorCombat);
                ev.Player.CustomInfo = "| На теле надет Модульный бронежилет 6Б43 | На голове надет Шлем Ulbricht AM95 C Забралом | На левом плече эмблема организации \"Фонд SCP\", а на правом плече эмблема подразделения \"Девятихвостая лиса\" | На плечах имеется патчи \"Капитан\" |\r\n";

            }
            else if (ev.Player.Role.Type == PlayerRoles.RoleTypeId.NtfSergeant)
            {
                var rn = Random.Range(0, Plugin.plugin.Config.MTFNames.Count - 1);
                var name = Plugin.plugin.Config.MTFNames[rn];
                ev.Player.DisplayNickname = $"[{ev.Player.Id}] | {name}";
                ev.Player.ClearInventory();
                ev.Player.AddItem(ItemType.KeycardMTFOperative);
                ev.Player.AddItem(ItemType.Radio);
                ev.Player.AddItem(ItemType.Medkit);
                ev.Player.AddItem(ItemType.GunE11SR);
                ev.Player.SetAmmo(AmmoType.Nato556, 80);
                ev.Player.AddItem(ItemType.GrenadeFlash);
                ev.Player.SetAmmo(AmmoType.Nato9, 60);
                ev.Player.AddItem(ItemType.GunCOM18);
                ev.Player.AddItem(ItemType.ArmorCombat);
                ev.Player.CustomInfo = "<color=#00B7EB>| На теле надет Модульный бронежилет 6Б43  | На голове надет  Шлем Ulbricht AM95 C Забралом | На левом плече изображена эмблема организации \"Фонд SCP\", а на правом плече изображена эмблема подразделения \"Девятихвостая лиса\" | На плечах имеется патчи \"Сержант\" |</color>";
            }
            else if (ev.Player.Role.Type == PlayerRoles.RoleTypeId.NtfSpecialist)
            {
                var rn = Random.Range(0, Plugin.plugin.Config.MTFNames.Count - 1);
                var name = Plugin.plugin.Config.MTFNames[rn];
                ev.Player.DisplayNickname = $"[{ev.Player.Id}] | {name}";
                ev.Player.ClearInventory();
                ev.Player.AddItem(ItemType.KeycardMTFOperative);
                ev.Player.AddItem(ItemType.Radio);
                ev.Player.AddItem(ItemType.Medkit);
                ev.Player.AddItem(ItemType.GunE11SR);
                ev.Player.SetAmmo(AmmoType.Nato556, 80);
                ev.Player.AddItem(ItemType.GrenadeFlash);
                ev.Player.SetAmmo(AmmoType.Nato9, 60);
                ev.Player.AddItem(ItemType.GunCOM18);
                ev.Player.AddItem(ItemType.ArmorCombat);
                ev.Player.CustomInfo = "<color=#00B7EB>| На теле надет Модульный бронежилет 6Б43  | На голове надет  Шлем Ulbricht AM95 C Забралом | На левом плече изображена эмблема организации \"Фонд SCP\", а на правом плече изображена эмблема подразделения \"Девятихвостая лиса\" | На плечах имеется патчи \"Сержант\" |</color>";
            }
            else if (ev.Player.Role.Type == PlayerRoles.RoleTypeId.NtfPrivate)
            {
                var rn = Random.Range(0, Plugin.plugin.Config.MTFNames.Count - 1);
                var name = Plugin.plugin.Config.MTFNames[rn];
                ev.Player.DisplayNickname = $"[{ev.Player.Id}] | {name}";
                ev.Player.ClearInventory();
                ev.Player.AddItem(ItemType.KeycardMTFOperative);
                ev.Player.AddItem(ItemType.Radio);
                ev.Player.AddItem(ItemType.Medkit);
                ev.Player.AddItem(ItemType.GunE11SR);
                ev.Player.SetAmmo(AmmoType.Nato556, 80);
                ev.Player.AddItem(ItemType.GrenadeFlash);
                ev.Player.SetAmmo(AmmoType.Nato9, 60);
                ev.Player.AddItem(ItemType.GunCOM18);
                ev.Player.AddItem(ItemType.ArmorCombat);
                ev.Player.CustomInfo = "<color=#00B7EB>| На теле надет Модульный бронежилет 6Б43  | На голове надет  Шлем Ulbricht AM95 C Забралом | На левом плече изображена эмблема организации \"Фонд SCP\", а на правом плече изображена эмблема подразделения \"Девятихвостая лиса\" | На плечах имеется патчи \"Рядовой\" |</color>";
            }
            else if (ev.Player.Role.Team == PlayerRoles.Team.ChaosInsurgency)
            {
                var rn = Random.Range(0, Plugin.plugin.Config.CHNames.Count - 1);
                var name = Plugin.plugin.Config.CHNames[rn];
                ev.Player.ClearInventory();
                ev.Player.DisplayNickname = $"[{ev.Player.Id}] | {name}";
                ev.Player.AddItem(ItemType.KeycardChaosInsurgency);
                ev.Player.AddItem(ItemType.Medkit);
                ev.Player.AddItem(ItemType.GrenadeFlash);
                ev.Player.SetAmmo(AmmoType.Nato762, 120);
                ev.Player.AddItem(ItemType.ArmorHeavy);
                ev.Player.AddItem(ItemType.GunAK);

            }
            else if(ev.Reason != SpawnReason.RoundStart)
            {
                if (ev.Player.Role.Type == RoleTypeId.ClassD)
                {
                    var rnd = Random.Range(0001, 9999);
                    ev.Player.DisplayNickname = $"[{ev.Player.Id}] | D-{rnd}";
                    ev.Player.ReferenceHub.nicknameSync.Network_customPlayerInfoString = "";
                }
                else if (ev.Player.Role.Type == PlayerRoles.RoleTypeId.Scientist)
                {
                    Timing.CallDelayed(0.2f, () =>
                    {
                        var rn = Random.Range(0, Plugin.plugin.Config.ScientistsNames.Count - 1);
                        var name = Plugin.plugin.Config.ScientistsNames[rn];
                        
                        ev.Player.ReferenceHub.nicknameSync.Network_customPlayerInfoString = "";
                        Extension.AddRoleScientists(ev.Player);
                    });

                }
                else if (ev.Player.Role.Type == PlayerRoles.RoleTypeId.FacilityGuard)
                {
                    var rn = Random.Range(0, Plugin.plugin.Config.GuardsNames.Count - 1);
                    var name = Plugin.plugin.Config.GuardsNames[rn];
                    ev.Player.DisplayNickname = $"[{ev.Player.Id}] | {name}";
                    ev.Player.ReferenceHub.nicknameSync.Network_customPlayerInfoString = "<color=#00FFFF>| Одет в Бронежилет VISION, Шлем Riot-XTAC с Забралом, на поясе кобура | На правом плече шеврон организации \"SCP\", на левом плече шеврон \"Службы Безопасности: Комендантский Отряд\" | На плечах патчи \"Рядовой\" |</color>\r\n";
                }
                else if(ev.Player.Role.Team == Team.SCPs)
                {
                    ev.Player.DisplayNickname = $"[{ev.Player.Id}] | ...";
                    ev.Player.ReferenceHub.nicknameSync.Network_customPlayerInfoString = "";
                    if (ev.Player.Role.Type == RoleTypeId.Scp049)
                    {
                        ev.Player.Health = 500f;
                    }
                    else if (ev.Player.Role.Type == RoleTypeId.Scp173)
                    {
                        ev.Player.Health = 65355f;
                    }
                    else if (ev.Player.Role.Type == RoleTypeId.Scp106)
                    {
                        ev.Player.Health = 65355f;
                    }
                    else if (ev.Player.Role.Type == RoleTypeId.Scp939)
                    {
                        ev.Player.Health = 2000f;
                    }
                    else if (ev.Player.Role.Type == RoleTypeId.Scp096)
                    {
                        ev.Player.Health = 65355f;
                    }
                    else if(ev.Player.Role.Type == RoleTypeId.Scp0492)
                    {
                        ev.Player.Health = 100f;

                    }
                }
                else if(ev.Player.Role.Type== RoleTypeId.Tutorial)
                {
                    ev.Player.DisplayNickname = $"[{ev.Player.Id}] | {ev.Player.Nickname}"; ;
                    ev.Player.ReferenceHub.nicknameSync.Network_customPlayerInfoString = "";
                }
            }
            
        }
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            try
            {
                if (ev.NewRole == PlayerRoles.RoleTypeId.Spectator || ev.NewRole == PlayerRoles.RoleTypeId.Filmmaker || ev.NewRole == PlayerRoles.RoleTypeId.Overwatch)
                {
                    ev.Player.DisplayNickname = null;
                    if (ev.Player.CustomInfo != null)
                    {
                        ev.Player.CustomInfo = default;
                    }
                }
            }
            catch {

            }
            
        }
        public void OnEscaping(EscapingEventArgs ev)
        {
            ev.Player.Role.Set(RoleTypeId.Spectator);
        }
        public void OnDying(DyingEventArgs ev)
        {
            foreach (Item item in ev.Player.Items.ToList())
            {
                if (item.Type == ItemType.GunCOM15)
                {
                    item.Is(out Exiled.API.Features.Items.Firearm firearm);
                    byte ammo = firearm.Ammo;
                    customweapons.Remove(item);
                    item.Destroy();
                    Exiled.API.Features.Pickups.FirearmPickup grenademetpickup = (Exiled.API.Features.Pickups.FirearmPickup)Pickup.Create(ItemType.GunCOM15);
                    grenademetpickup.Ammo = ammo;
                    grenademetpickup.Spawn(ev.Player.Position, new Quaternion());
                    customweaponspickup.Add(grenademetpickup);
                    ev.IsAllowed = false;
                }
                if (item.Type == ItemType.GunCOM18)
                {
                    item.Is(out Exiled.API.Features.Items.Firearm firearm);
                    byte ammo = firearm.Ammo;
                    customweapons.Remove(item);
                    item.Destroy();
                    Exiled.API.Features.Pickups.FirearmPickup grenademetpickup = (Exiled.API.Features.Pickups.FirearmPickup)Pickup.Create(ItemType.GunCOM18);
                    grenademetpickup.Ammo = ammo;
                    grenademetpickup.Spawn(ev.Player.Position, new Quaternion());
                    customweaponspickup.Add(grenademetpickup);
                    ev.IsAllowed = false;
                }
            }
        }
        public void OnDroppingItem(DroppingItemEventArgs ev)
        {
            if(customweapons.Contains(ev.Item))
            {
                if (ev.Item.Type == ItemType.GunCOM15)
                {
                    ev.Item.Is(out Exiled.API.Features.Items.Firearm firearm);
                    byte ammo = firearm.Ammo;
                    customweapons.Remove(ev.Item);
                    ev.Item.Destroy();
                    Exiled.API.Features.Pickups.FirearmPickup grenademetpickup = (Exiled.API.Features.Pickups.FirearmPickup)Pickup.Create(ItemType.GunCOM15);
                    grenademetpickup.Ammo = ammo;
                    grenademetpickup.Spawn(ev.Player.Position, new Quaternion());
                    customweaponspickup.Add(grenademetpickup);
                    ev.IsAllowed = false;
                }
                if (ev.Item.Type == ItemType.GunCOM18)
                {
                    ev.Item.Is(out Exiled.API.Features.Items.Firearm firearm);
                    byte ammo = firearm.Ammo;
                    customweapons.Remove(ev.Item);
                    ev.Item.Destroy();
                    Exiled.API.Features.Pickups.FirearmPickup grenademetpickup = (Exiled.API.Features.Pickups.FirearmPickup)Pickup.Create(ItemType.GunCOM18);
                    grenademetpickup.Ammo = ammo;
                    grenademetpickup.Spawn(ev.Player.Position, new Quaternion());
                    customweaponspickup.Add(grenademetpickup);
                    ev.IsAllowed = false;
                }
            }
        }
        public void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (customweaponspickup.Contains(ev.Pickup))
            {
                if(ev.Pickup.Type == ItemType.GunCOM15)
                {
                    ev.Pickup.Is<Exiled.API.Features.Pickups.FirearmPickup>(out Exiled.API.Features.Pickups.FirearmPickup fpp);
                    
                    byte ammo = fpp.Ammo;
                    customweaponspickup.Remove(ev.Pickup);
                    ev.Pickup.Destroy();
                    Exiled.API.Features.Items.Firearm firearm = (Exiled.API.Features.Items.Firearm)Item.Create(ItemType.GunCOM15);
                    firearm.Ammo = ammo;
                    ev.Player.AddItem(firearm);
                    customweapons.Add(firearm);
                    ev.IsAllowed = false;
                }
                if(ev.Pickup.Type == ItemType.GunCOM18)
                {
                    ev.Pickup.Is<Exiled.API.Features.Pickups.FirearmPickup>(out Exiled.API.Features.Pickups.FirearmPickup fpp);
                    byte ammo = fpp.Ammo;
                    customweaponspickup.Remove(ev.Pickup);
                    ev.Pickup.Destroy();
                    Exiled.API.Features.Items.Firearm firearm = (Exiled.API.Features.Items.Firearm)Item.Create(ItemType.GunCOM18);
                    firearm.Ammo = ammo;
                    ev.Player.AddItem(firearm);
                    customweapons.Add(firearm);
                    ev.IsAllowed = false;
                }
            }
        }
        public void OnHurting(HurtingEventArgs ev)
        {
            if (ev.DamageHandler.Type == null) return;
            if (ev.Attacker == null) return;
            if (ev.Player == null) return;
            if(customweapons.Contains(ev.Attacker.CurrentItem))
            {
                if(ev.Player.Role.Type == PlayerRoles.RoleTypeId.Scp049)
                {
                    if(ev.Attacker.CurrentItem.Type == ItemType.GunCOM15)
                    {
                        Vector3 pos = ev.Player.Position;
                        var ragdoll = Ragdoll.CreateAndSpawn(PlayerRoles.RoleTypeId.Scp049, "???", "???", pos, new Quaternion());
                        ev.Player.EnableEffect(EffectType.Invisible, 30f);
                        ev.Player.EnableEffect(EffectType.Flashed, 30f);
                        ev.Player.EnableEffect(EffectType.Ensnared, 30f);
                        Timing.CallDelayed(30f, () =>
                        {
                            ragdoll.Destroy();
                        });
                    }
                }
                if(ev.Player.Role.Type == PlayerRoles.RoleTypeId.Scp939)
                {
                    if(ev.Attacker.CurrentItem.Type == ItemType.GunCOM18)
                    {
                        scp939 = true;
                        Vector3 pos = ev.Player.Position;
                        var ragdoll = Ragdoll.CreateAndSpawn(PlayerRoles.RoleTypeId.Scp939, "???", "???", pos, new Quaternion());
                        ev.Player.EnableEffect(EffectType.Invisible, 60f);
                        ev.Player.EnableEffect(EffectType.Flashed, 60f);
                        ev.Player.EnableEffect(EffectType.Ensnared, 60f);
                        Timing.CallDelayed(60f, () =>
                        {
                            ragdoll.Destroy();
                            ev.Player.Teleport(pos);
                            scp939 = false;
                        });
                    }
                }
            }
            if(scp939)
            {
                if(ev.Attacker.Role.Type == RoleTypeId.Scp939)
                {
                    ev.IsAllowed = false;
                }
            }
            if(ev.Attacker.Role.Type == RoleTypeId.Scp049)
            {
                ev.Player.Kill("Излечен поветрием..");
            }
        }
        
        public void OnReloadingWeapon(ReloadingWeaponEventArgs ev)
        {

        }
        public void OnShoting(ShootingEventArgs ev)
        {

        }
        public void OnUseDoor(InteractingDoorEventArgs ev)
        {
            try
            {
                if(ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency)
                {
                    if(ev.Door.IsKeycardDoor)
                    {
                        ev.IsAllowed = false;
                        Vector3 pos1 = ev.Player.Position;
                        try
                        {

                            Timing.CallDelayed(1.01f, () =>
                            {
                                ev.Player.ShowHint("Процесс взлома. Осталось:<br><mark=#00FF00>|</mark><mark=#00008B>||||||||||||</mark>", 1f);
                                Timing.CallDelayed(1.01f, () =>
                                {
                                    if (Vector3.Distance(ev.Player.Position, pos1) <= 1 && ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency)
                                    {
                                        ev.Player.ShowHint("Процесс взлома. Осталось:<br><mark=#00FF00>||</mark><mark=#00008B>|||||||||||</mark></color>", 1f);
                                        Timing.CallDelayed(1.01f, () =>
                                        {
                                            if (Vector3.Distance(ev.Player.Position, pos1) <= 1 && ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency)
                                            {
                                                ev.Player.ShowHint("Процесс взлома. Осталось:<br><mark=#00FF00>|||</mark><mark=#00008B>||||||||||</mark></color>", 1f);
                                                Timing.CallDelayed(1.01f, () =>
                                                {
                                                    if (Vector3.Distance(ev.Player.Position, pos1) <= 1 && ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency)
                                                    {
                                                        ev.Player.ShowHint("Процесс взлома. Осталось:<br><mark=#00FF00>||||</mark><mark=#00008B>|||||||||</mark></color>", 1f);
                                                        Timing.CallDelayed(1.01f, () =>
                                                        {
                                                            if (Vector3.Distance(ev.Player.Position, pos1) <= 1 && ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency)
                                                            {
                                                                ev.Player.ShowHint("Процесс взлома. Осталось:<br><mark=#00FF00>|||||</mark><mark=#00008B>||||||||</mark></color>", 1f);
                                                                Timing.CallDelayed(1.01f, () =>
                                                                {
                                                                    if (Vector3.Distance(ev.Player.Position, pos1) <= 1 && ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency)
                                                                    {
                                                                        ev.Player.ShowHint("Процесс взлома. Осталось:<br><mark=#00FF00>||||||</mark><mark=#00008B>|||||||</mark></color>", 1f);
                                                                        Timing.CallDelayed(1.01f, () =>
                                                                        {
                                                                            if (Vector3.Distance(ev.Player.Position, pos1) <= 1 && ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency)
                                                                            {
                                                                                ev.Player.ShowHint("Процесс взлома. Осталось:<br><mark=#00FF00>|||||||</mark><mark=#00008B>||||||</mark></color>", 1f);
                                                                                Timing.CallDelayed(1.01f, () =>
                                                                                {
                                                                                    if (Vector3.Distance(ev.Player.Position, pos1) <= 1 && ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency)
                                                                                    {
                                                                                        ev.Player.ShowHint("Процесс взлома. Осталось:<br><mark=#00FF00>||||||||</mark><mark=#00008B>|||||</mark></color>", 1f);
                                                                                        if (Vector3.Distance(ev.Player.Position, pos1) <= 1 && ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency)
                                                                                        {
                                                                                            ev.Player.ShowHint("Процесс взлома. Осталось:<br><mark=#00FF00>|||||||||</mark><mark=#00008B>||||</mark></color>", 1f);
                                                                                            if (Vector3.Distance(ev.Player.Position, pos1) <= 1 && ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency)
                                                                                            {
                                                                                                ev.Player.ShowHint("Процесс взлома. Осталось:<br><mark=#00FF00>||||||||||</mark><mark=#00008B>|||</mark></color>", 1f);
                                                                                                if (Vector3.Distance(ev.Player.Position, pos1) <= 1 && ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency)
                                                                                                {
                                                                                                    ev.Player.ShowHint("Процесс взлома. Осталось:<br><mark=#00FF00>|||||||||||</mark><mark=#00008B>||</mark></color>", 1f);
                                                                                                    if (Vector3.Distance(ev.Player.Position, pos1) <= 1 && ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency)
                                                                                                    {
                                                                                                        ev.Player.ShowHint("Процесс взлома. Осталось:<br><mark=#00FF00>||||||||||||</mark><mark=#00008B>|</mark></color>", 1f);
                                                                                                        if (Vector3.Distance(ev.Player.Position, pos1) <= 1 && ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency)
                                                                                                        {
                                                                                                            ev.Player.ShowHint("Процесс взлома. Осталось:<br><mark=#00FF00>|||||||||||||</mark><mark=#00008B></mark></color>", 1f);
                                                                                                            ev.Door.IsOpen = true;
                                                                                                            if(ev.Door.Type == DoorType.GateB)
                                                                                                            {
                                                                                                                Cassie.MessageTranslated("pitch_1 attention . unauthorized access in gates system . loading unknown software . pitch_3.5 .g1 .g1 .g1 .g1 .g1 .g1 . . .g2 .g2 .g2 .g2 .g2 .g2 . . .g3 .g3 .g3 .g3 .g3 pitch_1 . loading completed . . gate nato_b open and deactivated . . reactivation of gate nato_b system . pitch_2 .g3 pitch_1 . pitch_2 .g3 pitch_1 . pitch_2 .g3 pitch_1 . pitch_2 .g3 pitch_1 . failure . attention to engine squad . report to gate nato_b for check system", "<color=#FBBC13><b>Внимание! </b>| </color>Неавторизованный доступ к системе ворот | <color=#237F0A>Загрузка </color><b>неизвестного программного обеспечения </b>| . . . | Загрузка <color=#237F0A><b>заверена </b></color>| Ворота Браво <color=#237F0A><b>открыты </b></color>и <color=#A30505><b>отключены </b></color>| Перезапуск системы ворот Браво | <color=#A30505><b>Ошибка </b></color>| <color=#FBBC13><b>Внимание </b></color><color=orange>инженерному </color>отряду, направляйтесь к воротам Браво для проверки систем");

                                                                                                            }
                                                                                                            else if(ev.Door.Type == DoorType.GateA)
                                                                                                            {
                                                                                                                Cassie.MessageTranslated("pitch_1 attention . unauthorized access in gates system . loading unknown software . pitch_3.5 .g1 .g1 .g1 .g1 .g1 .g1 . . .g2 .g2 .g2 .g2 .g2 .g2 . . .g3 .g3 .g3 .g3 .g3 pitch_1 . loading completed . . gate nato_a open and deactivated . . reactivation of gate nato_a system . pitch_2 .g3 pitch_1 . pitch_2 .g3 pitch_1 . pitch_2 .g3 pitch_1 . pitch_2 .g3 pitch_1 . failure . attention to engine squad . report to gate nato_a for check system", "<color=#FBBC13><b>Внимание! </b>| </color>Неавторизованный доступ к системе ворот | <color=#237F0A>Загрузка </color><b>неизвестного программного обеспечения </b>| . . . | Загрузка <color=#237F0A><b>заверена </b></color>| Ворота Альфа <color=#237F0A><b>открыты </b></color>и <color=#A30505><b>отключены </b></color>| Перезапуск системы ворот Альфа | <color=#A30505><b>Ошибка </b></color>| <color=#FBBC13><b>Внимание </b></color><color=orange>инженерному </color>отряду, направляйтесь к воротам Альфа для проверки систем");
                                                                                                                
                                                                                                            }
                                                                                                            else if(ev.Door.Type == DoorType.HczArmory)
                                                                                                            {
                                                                                                                Cassie.MessageTranslated("pitch_0.15 .g4 . .g4 . pitch_1 attention . unauthorized access to the armory of the heavy containment zone was detected .", "<color=yellow><size=25><b>[ВНИМАНИЕ]</color> Обнаружен несанкционированный доступ к помещению вооружения <color=#8B0000>Тяжелой Зоны Содержания</color>.</b>");
                                                                                                            }
                                                                                                            else if(ev.Door.Type == DoorType.LczArmory)
                                                                                                            {
                                                                                                                Cassie.MessageTranslated("pitch_0.15 .g4 . .g4 . pitch_1 attention . unauthorized access to the armory of the light containment zone was detected .", "<color=yellow><size=25><b>[ВНИМАНИЕ]</color> Обнаружен несанкционированный доступ к помещению вооружения <color=#8B0000>Легкой зоны содержания</color>.</b>");
                                                                                                            }
                                                                                                            else if(ev.Door.Type == DoorType.HID)
                                                                                                            {
                                                                                                                Cassie.MessageTranslated("pitch_0.15 .g4 . .g4 . pitch_1 attention . unauthorized access to micro H I D was detected . ", "<color=yellow><size=25><b>[ВНИМАНИЕ]</color> Обнаружен несанкционированный доступ к помещению <color=#8B0000>[Micro-HID]</color>.</b>");
                                                                                                            }
                                                                                                            else if (ev.Door.Type == DoorType.Intercom)
                                                                                                            {
                                                                                                                Cassie.MessageTranslated("pitch_0.15 .g4 . .g4 . pitch_1 attention . unauthorized access to intercom was detected . ", "<color=yellow><size=25><b>[ВНИМАНИЕ]</color> Обнаружен несанкционированный доступ к помещению <color=#8B0000>[Intercom]</color>.</b>");
                                                                                                            }
                                                                                                            else if(ev.Door.Type == DoorType.Scp106Primary || ev.Door.Type == DoorType.Scp106Secondary)
                                                                                                            {
                                                                                                                Cassie.MessageTranslated("pitch_0.15 .g4 . .g4 . pitch_1 attention . unauthorized access to remote control room of scp 106 chamber was detected .\r\n", "<color=yellow><size=25><b>[ВНИМАНИЕ]</color> Обнаружен несанкционированный доступ к диспетчерской камеры объекта <color=#8B0000>[SCP-106]</color>.</b>");
                                                                                                            }
                                                                                                        }

                                                                                                    }

                                                                                                }

                                                                                            }

                                                                                        }

                                                                                    }

                                                                                });
                                                                            }

                                                                        });
                                                                    }

                                                                });
                                                            }

                                                        });
                                                    }

                                                });
                                            }

                                        });
                                    }

                                });
                            });
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex);
                        }
                    }
                }
                if (ev.Door.Type == DoorType.GR18Gate)
                {

                    if (ev.Player.CurrentItem == null)
                    {
                        ev.IsAllowed = false;
                    }
                    else if (!ev.Player.CurrentItem.IsKeycard)
                    {
                        ev.IsAllowed = false;

                    }

                }
                else if (ev.Door.Type == DoorType.LczCafe)
                {

                    if (ev.Player.CurrentItem == null)
                    {
                        ev.IsAllowed = false;
                    }
                    else if (!ev.Player.CurrentItem.IsKeycard)
                    {
                        ev.IsAllowed = false;

                    }
                }
                else if (ev.Door.Type == DoorType.Intercom && !ev.Door.IsLocked)
                {
                    if (ev.Player.CurrentItem.Type == ItemType.KeycardMTFPrivate || ev.Player.CurrentItem.Type == ItemType.KeycardContainmentEngineer || ev.Player.CurrentItem.Type == ItemType.KeycardMTFOperative || ev.Player.CurrentItem.Type == ItemType.KeycardMTFCaptain || ev.Player.CurrentItem.Type == ItemType.KeycardFacilityManager || ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency || ev.Player.CurrentItem.Type == ItemType.KeycardO5)
                    {
                        ev.IsAllowed = true;
                    }
                    else
                    {
                        ev.IsAllowed = false;
                    }
                }
                else if (ev.Door.Type == DoorType.PrisonDoor && !ev.Door.IsLocked)
                {
                    if (ev.Player.CurrentItem == null)
                    {
                        ev.IsAllowed = false;
                    }
                    if (ev.Player.CurrentItem.Type == ItemType.KeycardGuard || ev.Player.CurrentItem.Type == ItemType.KeycardMTFPrivate || ev.Player.CurrentItem.Type == ItemType.KeycardContainmentEngineer || ev.Player.CurrentItem.Type == ItemType.KeycardMTFOperative || ev.Player.CurrentItem.Type == ItemType.KeycardMTFCaptain || ev.Player.CurrentItem.Type == ItemType.KeycardFacilityManager || ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency || ev.Player.CurrentItem.Type == ItemType.KeycardO5)
                    {
                        ev.IsAllowed = true;
                    }
                    else
                    {
                        ev.IsAllowed = false;
                    }
                }
            }
            catch
            {

            }
        }
        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if(!Mtf)
            {
                if(ev.NextKnownTeam == Respawning.SpawnableTeamType.NineTailedFox)
                {
                    ev.IsAllowed = false;
                }
            }
            if(!Chaos)
            {
                if(ev.NextKnownTeam == Respawning.SpawnableTeamType.ChaosInsurgency)
                {
                    ev.IsAllowed = false;
                }
            }
        }
        public void OnSpawnedSc(SchematicSpawnedEventArgs ev)
        {
            if(ev.Schematic.name == "RP-106-N")
            {
                
            }
        }
        public IEnumerator<float> handle106()
        {
            while(true)
            {
                var scp106 = Player.List.Where(x => x.Role.Type == RoleTypeId.Scp106).FirstOrDefault();
                if(scp106 != null)
                {
                    if(scp106.Role is Scp106Role role)
                    {
                        if(role.Vigor <100)
                        {
                            role.Vigor++;
                        }
                    }
                }
                yield return Timing.WaitForSeconds(1f);
            }
        }
        public IEnumerator<float> WeaponHandle()
        {
            while(true)
            {
                foreach(Player pl in Player.List)
                {
                    
                }
                yield return Timing.WaitForSeconds(1f);
            }
        }
        
    }
}
