using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Features;
using MapEditorReborn.API.Features.Objects;
using MEC;
using Syinergy_RP.API.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Syinergy_RP.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class rec106 : ICommand
    {
        public string Command => "rec106";

        public string[] Aliases => new string[] { };

        public string Description => "Реконтейм 106";
        public bool SanitizeResponse => true;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(sender);
            Player scp = Player.List.Where(x => x.Role.Type == PlayerRoles.RoleTypeId.Scp106).FirstOrDefault();
            if (scp == null)
            {
                response = "SCP 106 не найден";
                return false;
            }
            if(!Plugin.plugin.eventHandlers.kill106)
            {
                
                try
                {
                    if(pl.CurrentRoom.Type == RoomType.Hcz106)
                    {
                        Vector3 pos = new Vector3(85.235f, -999.106f, 157.692f);
                        Player player = null;
                        var plist = Player.List.Where(x => Vector3.Distance(x.Position, pos) <= 10f).ToList();
                        foreach(Player x in plist)
                        {
                            if(x.Role.Type == PlayerRoles.RoleTypeId.ClassD)
                            {
                                player = x;
                                
                            }
                        }
                        if (player == null)
                        {
                            response = "Жертва для 106 не принесена";
                            return false;
                        }
                        else
                        {
                            if (player.Role.Type == PlayerRoles.RoleTypeId.ClassD)
                            {
                                player.Role.Set(PlayerRoles.RoleTypeId.Spectator);
                                Plugin.plugin.eventHandlers.kill106 = true;
                                response = "Жертва для 106 принесена";
                                return false;
                            }
                            response = "D class не найден";
                            return false;
                        }
                    }
                    
                }
                catch(Exception e) 
                {
                    Log.Info(e.ToString());
                }
                
                response = "Жертва для 106 не принесена";
                return false;
            }
            
            else
            {
                if(pl.CurrentRoom.Type == RoomType.Hcz106)
                {
                    pl.Broadcast(15, "\n\n<size=32><b><color=orange>[RP]<color=white> Отключение Системы Магнитов<color=orange> [RP]</size>");
                    Timing.CallDelayed(15, () =>
                    {
                        pl.Broadcast(15, "\n\n<size=32><b><color=orange>[RP]<color=white> Включение Системы Центра Голосового Вещания<color=orange> [RP]</size>");
                        Timing.CallDelayed(15, () =>
                        {
                            pl.Broadcast(10, "\n\n<size=32><b><color=orange>[RP]<color=white> Подключение Системы Ломания Бедренной Кости<color=orange> [RP]</size>");
                            Timing.CallDelayed(15, () =>
                            {

                                API.Methods.Extension.StartAudio();
                                pl.Broadcast(10, "\n\n<size=32><b><color=orange>[RP]<color=white> Протокол RP-106-N<color=orange> [RP]</size>");
                                Timing.CallDelayed(70f, () =>
                                {
                                    pl.Broadcast(15, "\n\n<size=32><b><color=orange>[RP]<color=white> Включение Системы Магнитов<color=orange> [RP]</size>");
                                    scp.Role.Set(PlayerRoles.RoleTypeId.Spectator);
                                    Timing.CallDelayed(15f, () =>
                                    {
                                        Cassie.MessageTranslated("Bell_start pitch_0.98 Attention to all personnel . SCP 1 0 6 class Keter successfully recontained . . Recontainment by .  Bell_end", "<size=21><b><color=#8B8B05>ВНИМАНИЕ</color> | Всему персоналу: <color=#9A1010>SCP-106</color> класса «<color=red>Кетер</color>» был успешно сдержан.");
                                    });
                                });
                            });
                        });
                    });
                }
                
            }
            
            response = "Успешно";
            return true;
            
        }
    }
}
