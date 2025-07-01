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
    public class Remote : ICommand
    {
        public string Command => "rm";

        public string[] Aliases => new string[] { };

        public string Description => "Включить удаленный доступ";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(sender);
            if(pl.Role.Team != PlayerRoles.Team.FoundationForces)
            {
                response = "Вам это не доступно";
                return false;
            }
            if(pl.Role.Type != PlayerRoles.RoleTypeId.NtfCaptain && pl.Role.Type != PlayerRoles.RoleTypeId.NtfPrivate && pl.Role.Type != PlayerRoles.RoleTypeId.NtfSergeant && pl.Role.Type != PlayerRoles.RoleTypeId.NtfSpecialist)
            {
                response = "Вам это не доступно";
                return false;
            }
            if(pl.CurrentRoom.Type != RoomType.EzIntercom)
            {
                response = "Ошибка";
                return false;
            }
            if(Plugin.plugin.eventHandlers.IsRm)
            {
                response = "Удаленный доступ уже включен";
                return false;
            }
            Door.Get(DoorType.GateA).Lock(99999999f, DoorLockType.AdminCommand);
            Door.Get(DoorType.GateB).Lock(99999999f, DoorLockType.AdminCommand);
            Cassie.MessageTranslated("pitch_1 query for distance access .g1 .g1 .g1 .g1 .g1 .g1 .g1 .g1 .g1 . granted successfully . the facility number 97 now under control by MTFunit center . . all personnel . stay in safe area and wait when MTFUnit completed the operation", "<size=20> <b> pitch_20 Запрос на удаленный доступ | . . . | Получен успешно | Комплекс с номером <i>97</i> переходит под управление <color=blue> “Центра Мобильной Оперативной группы” </color>| Всему персоналу | Оставайтесь в безопасных местах и ожидайте когда<color=blue> Мобильная Оперативная группа</color> закончит операцию |");
            Plugin.plugin.eventHandlers.IsRm = true;
            response = "Успешно";
            return true;
        }
    }
}
