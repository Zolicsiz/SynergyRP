using CommandSystem;
using Exiled.API.Extensions;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Syinergy_RP.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Cuff : ICommand
    {
        public string Command => "cuff";

        public string[] Aliases => new string[] { };

        public string Description => "Связать игрока перед вами.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            var ray = new Ray(player.CameraTransform.position + (player.CameraTransform.forward * 0.1f), player.CameraTransform.forward);
            if (!Physics.Raycast(ray, out RaycastHit hit, 3))
            {
                response = "Вы стоите слишком далеко";
                return false;
            }
            if(player.Role.Team == PlayerRoles.Team.Dead || player.Role.Team == PlayerRoles.Team.SCPs)
            {
                response = "Вам недоступно это";
                return false;
            }
            if(player.CurrentItem.Category != ItemCategory.Firearm)
            {
                response = "Возьмите оружие в руки";
                return false;
            }
            var target = Player.Get(hit.collider);
            if(target.IsCuffed)
            {
                response = "Он уже связан";
                return false;
            }
            target.Handcuff();
            target.DropItems();
            response = "Успешно";
            return true;
        }
    }
}
