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
    public class openDblock : ICommand, IUsageProvider
    {
        public string Command => "managedblock";

        public string[] Aliases => new string[] { };

        public string Description => "Открытие/Закрытие д блока";

        public string[] Usage => new string[] { "open/close"};

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(arguments.At(0) == "open")
            {
                foreach (Door door in Door.List)
                {
                    if (door.Type == Exiled.API.Enums.DoorType.PrisonDoor)
                    {
                        door.IsOpen = true;
                    }
                }
                response = "Успешно";
                return false;
            }
            else if(arguments.At(0) == "close")
            {
                foreach (Door door in Door.List)
                {
                    if (door.Type == Exiled.API.Enums.DoorType.PrisonDoor)
                    {
                        door.IsOpen = false;
                    }
                }
                response = "Успешно";
                return false;
            }
            else
            {
                response = "Ошибка";
                return false;
            }
        }
    }
}
