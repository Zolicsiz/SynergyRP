using CommandSystem;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syinergy_RP.Commands.SCP106CMD
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class outpocket : ICommand
    {
        public string Command => "outpocket";

        public string[] Aliases => new string[] { };

        public string Description => "Выйти из измерения SCP 106 (SCP 106)";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(sender);
            if (pl.Role.Type != PlayerRoles.RoleTypeId.Scp106)
            {
                response = "Вам не доступно";
                return false;
            }
            if (!Plugin.plugin.eventHandlers.InPocket)
            {
                response = "Вы не в измерении уже";
                return false;
            }
            pl.Teleport(Room.Get(Exiled.API.Enums.RoomType.Hcz106));
            Plugin.plugin.eventHandlers.InPocket = false;
            response = "Успешно";
            return true;
        }
    }
}
