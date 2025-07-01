using CommandSystem;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syinergy_RP.Commands.CassieCMD
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Virus : ICommand
    {
        public string Command => "ivirus";

        public string[] Aliases => new string[] { };

        public string Description => "Запустить вирус в интеркоме";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(sender);
            if(pl.Role.Team != PlayerRoles.Team.ChaosInsurgency)
            {
                response = "Вы не ПХ";
                return false;
            }
            if(pl.CurrentRoom.Type != Exiled.API.Enums.RoomType.EzIntercom)
            {
                response = "Вы не в интеркоме";
                return false;
            }
            if(Plugin.plugin.eventHandlers.IsVirus)
            {
                response = "Вирус уже загружен";
                return false;
            }
            Cassie.MessageTranslated("Attention . security jam_008_2 alert . . . jam_040_3 unauthorized pitch_0.7 access to jam_060_4 foundation . pitch_0.6 jam_050_5 security .g1 .g4 .g5 system . jam_005_3 core pitch_0.7 detected . pitch_8 allremaining . . pitch_1 jam_005_4 chaosinsurgency", "[П██дупр█жден█е сис██мы без█пасно██и █бнар█же█ н█сан██иони█ован█ый д█сту█ к ц██тра█ сист██ы █ез█пасно█ти П█вст█н█ы Х█ос█]");
            Map.TurnOffAllLights(99999999f);
            Plugin.plugin.eventHandlers.IsVirus = true;
            response = "Успешно";
            return true;
        }
    }
}
