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
    public class inpocket : ICommand
    {
        public string Command => "inpocket";

        public string[] Aliases => new string[] { };

        public string Description => "Войти в измерение SCP 106 (SCP 106)";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(sender);
            if(pl.Role.Type != PlayerRoles.RoleTypeId.Scp106)
            {
                response = "Вам не доступно";
                return false;
            }
            if(Plugin.plugin.eventHandlers.InPocket)
            {
                response = "Вы в измерении уже";
                return false;
            }
            pl.EnableEffect(Exiled.API.Enums.EffectType.PocketCorroding, 2f);
            Plugin.plugin.eventHandlers.InPocket = true;
            response = "Успешно";
            return true;
        }
    }
}
