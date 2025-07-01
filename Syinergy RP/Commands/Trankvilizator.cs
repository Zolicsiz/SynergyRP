using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Syinergy_RP.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Trankvilizator : ICommand, IUsageProvider
    {
        public string Command => "trankadd";

        public string[] Aliases => new string[] { };

        public string Description => "Выдать себе транквилизатор.";

        public string[] Usage => new string[] { "049/939"};

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(sender);
            if(arguments.At(0) == null)
            {
                response = "Не указан вид транквилизатора";
                return false;
            }
            if(arguments.At(0) != "049" && arguments.At(0) != "939") 
            {
                response = "Такого транквилизатора нет!";
                return false;
            }
            if (arguments.At(0) == "049")
            {
                Firearm s049 = (Firearm)Item.Create(ItemType.GunCOM15);
                s049.Ammo = 3;
                pl.AddItem(s049);
                Plugin.plugin.eventHandlers.customweapons.Add(s049);
                
                response = "Успешно";
                return true;
            }
            else if(arguments.At(0) == "939")
            {
                Firearm s939 = (Firearm)Item.Create(ItemType.GunCOM18);
                s939.Ammo = 3;
                pl.AddItem(s939);
                Plugin.plugin.eventHandlers.customweapons.Add(s939);
                response = "Успешно";
                return true;
            }
            response = "False";
            return false;
        }
    }
}
