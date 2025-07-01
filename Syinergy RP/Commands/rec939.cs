using CommandSystem;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syinergy_RP.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class rec939 : ICommand
    {
        public string Command => "rec939";

        public string[] Aliases => new string[] { };

        public string Description => "Реконтейм SCP 939";
        public bool SanitizeResponse => true;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(sender);
            Player scp = Player.List.Where(x => x.Role.Type == PlayerRoles.RoleTypeId.Scp939).FirstOrDefault();
            if (scp == null)
            {
                response = "SCP 939 не найден";
                return false;
            }
            if (pl.Role.Team != PlayerRoles.Team.ClassD && pl.Role.Team != PlayerRoles.Team.Dead && pl.Role.Team != PlayerRoles.Team.SCPs)
            {
                if (pl.CurrentRoom.Type == scp.CurrentRoom.Type)
                {
                    Cassie.MessageTranslated("Bell_start pitch_0.98 Attention to all personnel . SCP 9 3 9 class Keter successfully recontained  Bell_end </size>", "<size=21><b><color=#8B8B05>ВНИМАНИЕ</color> | Всему персоналу: <color=#9A1010>SCP-939</color> класса «<color=red>Кетер</color>» был успешно сдержан.");
                    scp.Role.Set(PlayerRoles.RoleTypeId.Spectator);
                    response = "Успешно";
                    return false;
                }
            }
            response = "...";
            return false;
        }
    }
}
