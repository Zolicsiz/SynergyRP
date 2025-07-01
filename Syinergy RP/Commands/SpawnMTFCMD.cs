using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syinergy_RP.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class SpawnMTFCMD : ICommand
    {
        public string Command => "blockspawnmtf";

        public string[] Aliases => new string[] { };

        public string Description => "Блокирует/разблокирует спавн мог";
        public bool SanitizeResponse => true;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(Plugin.plugin.eventHandlers.Mtf)
            {
                Plugin.plugin.eventHandlers.Mtf = false;
                response = "Заблокировано";
                return true;
            }
            else
            {
                Plugin.plugin.eventHandlers.Mtf = true;
                response = "Разблокировано";
                return true;
            }
        }
    }
}
