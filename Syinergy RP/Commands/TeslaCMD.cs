using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syinergy_RP.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class TeslaCMD : ICommand
    {
        public string Command => "tesla";

        public string[] Aliases => new string[] { };

        public string Description => "Включение/Выключение Тесла-Врат.";
        public bool SanitizeResponse => true;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(Plugin.plugin.eventHandlers.tesla)
            {
                foreach (Exiled.API.Features.TeslaGate tesla in Exiled.API.Features.TeslaGate.List)
                {
                    tesla.TriggerRange = -1;
                    tesla.IdleRange = -1;
                }


                Plugin.plugin.eventHandlers.tesla = false;
                response = "Тесла выключены (false)";
                return true;
            }
            else
            {
                foreach (Exiled.API.Features.TeslaGate tesla in Exiled.API.Features.TeslaGate.List)
                {
                    tesla.TriggerRange = 5.1f;
                    tesla.IdleRange = 6.55f;

                }
                Plugin.plugin.eventHandlers.tesla = true;
                response = "Тесла включены (true)";
                return true;
            }
        }
    }
}
