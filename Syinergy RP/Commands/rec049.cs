using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syinergy_RP.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class rec049 : ICommand
    {
        public string Command => "rec049";

        public string[] Aliases => new string[] { };

        public string Description => "Реконтейм SCP 049";
        public bool SanitizeResponse => true;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(sender);
            Player scp = Player.List.Where(x=>x.Role.Type == PlayerRoles.RoleTypeId.Scp049).FirstOrDefault();
            if(scp == null)
            {
                response = "SCP 049 не найден";
                return false;
            }
            if(pl.Role.Team != PlayerRoles.Team.ClassD && pl.Role.Team != PlayerRoles.Team.Dead && pl.Role.Team != PlayerRoles.Team.SCPs)
            {
                if (pl.CurrentRoom.Type == Exiled.API.Enums.RoomType.Hcz049)
                {
                    if (pl.CurrentRoom.Type == scp.CurrentRoom.Type)
                    {
                        Door.Get(DoorType.Scp049Gate).IsOpen = false;
                        Door.Get(DoorType.Scp049Gate).Lock(9999999f, DoorLockType.AdminCommand);
                        scp.Role.Set(PlayerRoles.RoleTypeId.Spectator);
                        Cassie.Clear();
                        Cassie.MessageTranslated("Bell_start pitch_0.98 Attention to all personnel . SCP 0 4 9 class Euclid successfully recontained Bell_end", "<size=21><b><color=#8B8B05>ВНИМАНИЕ</color> | Всему персоналу: <color=#9A1010>SCP-049</color> класса «<color=yellow>Евклид</color>» был успешно сдержан. ");
                        response = "Успешно";
                        return true;
                    }
                }
            }
            
            response = "Ошибка";
            return false;
        }
    }
}
