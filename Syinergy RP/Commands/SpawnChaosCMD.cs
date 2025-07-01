using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syinergy_RP.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class SpawnChaosCMD : ICommand
    {
        public string Command => "blockspawnci";

        public string[] Aliases => new string[] { };

        public string Description => "Блокирует/разблокирует спавн пх";
        public bool SanitizeResponse => true;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (Plugin.plugin.eventHandlers.Chaos)
            {
                Plugin.plugin.eventHandlers.Chaos = false;
                response = "Заблокировано";
                return true;
            }
            else
            {
                Plugin.plugin.eventHandlers.Chaos = true;
                response = "Разблокировано";
                return true;
            }
        }
    }
}
