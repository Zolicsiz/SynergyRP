using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using MapEditorReborn.API.Features.Objects;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syinergy_RP.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class rec173 : ICommand
    {
        public string Command => "rec173";

        public string[] Aliases => new string[] { };

        public string Description => "Реконтейм SCP 173";
        public bool SanitizeResponse => true;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(sender);
            Player scp = Player.List.Where(x => x.Role.Type == PlayerRoles.RoleTypeId.Scp173).FirstOrDefault();
            if (scp == null)
            {
                response = "SCP 173 не найден";
                return false;
            }
            if (pl.Role.Team != PlayerRoles.Team.ClassD && pl.Role.Team != PlayerRoles.Team.Dead && pl.Role.Team != PlayerRoles.Team.SCPs)
            {
                if (pl.CurrentRoom.Type == scp.CurrentRoom.Type)
                {
                    SchematicObject schematic = MapEditorReborn.API.Features.ObjectSpawner.SpawnSchematic("Jail173", scp.Position);

                    pl.Broadcast(20, "\n\n<size=32><b><color=orange>[RP]<color=white> Поднимаем Scp-173 С Помощью Домкрата<color=orange> [RP]</size>");
                    Timing.CallDelayed(20f, () =>
                    {
                        pl.Broadcast(10, "\n\n<size=32><b><color=orange>[RP]<color=white> Ставим Нижнюю Плиту Под Scp-173<color=orange> [RP]</size>");
                        Timing.CallDelayed(10f, () =>
                        {
                            pl.Broadcast(20, "\n\n<size=32><b><color=orange>[RP]<color=white> Ставим Нижнюю Плиту Под Scp-173<color=orange> [RP]</size>");
                            Timing.CallDelayed(20f, () =>
                            {
                                pl.Broadcast(30, "\n\n<size=32><b><color=orange>[RP]<color=white> Устанавливаем Прутья<color=orange> [RP]</size>");
                                Timing.CallDelayed(30f, () =>
                                {
                                    pl.Broadcast(15, "\n\n<size=32><b><color=orange>[RP]<color=white> Устанавливаем Верхнюю Плиту<color=orange> [RP]</size>");
                                    Timing.CallDelayed(15f, () =>
                                    {
                                        scp.Role.Set(PlayerRoles.RoleTypeId.Spectator);
                                        Cassie.Clear();
                                        Cassie.MessageTranslated("Bell_start pitch_0.98 Attention to all personnel .  SCP 1 7 3 class Euclid successfully.", "<size=21><b><color=#8B8B05>ВНИМАНИЕ</color> | Всему персоналу: <color=#9A1010>SCP-173</color> класса «<color=yellow>Евклид</color>» был успешно сдержан.");
                                    });
                                });
                            });
                        });

                    });
                    response = "Успешно";
                    return true;
                }
            }
            response = "Ошибка";
            return true;
        }
    }
}
