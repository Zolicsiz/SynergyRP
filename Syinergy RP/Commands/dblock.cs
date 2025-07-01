using CommandSystem;
using Exiled.API.Features.Doors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syinergy_RP.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class dblock : ICommand
    {
        public string Command => "dblock";

        public string[] Aliases => new string[] { };

        public string Description => "Управление дверьми Д блока";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(Plugin.plugin.eventHandlers.IsLockDBlock)
            {
                foreach(Door door in Door.List)
                {
                    if(door.Type == Exiled.API.Enums.DoorType.PrisonDoor)
                    {
                        door.Unlock();
                    }
                }
                Plugin.plugin.eventHandlers.IsLockDBlock = false;
                response = "Разблокированы";
                return true;
            }
            else
            {
                foreach (Door door in Door.List)
                {
                    if (door.Type == Exiled.API.Enums.DoorType.PrisonDoor)
                    {
                        door.Lock(99999999f, Exiled.API.Enums.DoorLockType.AdminCommand);
                    }
                }
                Plugin.plugin.eventHandlers.IsLockDBlock = true;
                response = "Заблокированы";
                return true;
            }
        }
    }
}
