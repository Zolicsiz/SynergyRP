using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syinergy_RP.Commands.CassieCMD
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class RemoteBlock : ICommand
    {
        public string Command => "rmd";

        public string[] Aliases => new string[] { };

        public string Description => "Выключить удаленный доступ";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(sender);
            if (pl.Role.Team != PlayerRoles.Team.FoundationForces)
            {
                response = "Вам это не доступно";
                return false;
            }
            if (pl.Role.Type != PlayerRoles.RoleTypeId.NtfCaptain && pl.Role.Type != PlayerRoles.RoleTypeId.NtfPrivate && pl.Role.Type != PlayerRoles.RoleTypeId.NtfSergeant && pl.Role.Type != PlayerRoles.RoleTypeId.NtfSpecialist)
            {
                response = "Вам это не доступно";
                return false;
            }
            if (pl.CurrentRoom.Type != RoomType.EzIntercom)
            {
                response = "Ошибка";
                return false;
            }
            if (!Plugin.plugin.eventHandlers.IsRm)
            {
                response = "Удаленный доступ уже выключен";
                return false;
            }
            Door.Get(DoorType.GateA).Unlock();
            Door.Get(DoorType.GateB).Unlock();
            Cassie.MessageTranslated("Distance access disengaged .g1 .g1 .g1 .g1 .g1 .g1 .g1 .g1 .g1 .  Automatic lockdown of Gate NATO_A and Gate NATO_B disengaged .  CassieSystem ready for distance control reactivation .", "<size=22> <b> | Удаленный доступ отключен | Автоматическая блокировка Гермоворот <color=#e30071>[ALPHA]<color=white> и <color=#e30071>[BRAVO]<color=white> Снята | Система <color=#e30071>[C.A.S.S.I.E]<color=white> готова к повторному включению удаленного управления |");
            Plugin.plugin.eventHandlers.IsRm = false;
            response = "Успешно";
            return true;
        }
    }
}
