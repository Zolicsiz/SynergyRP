using CommandSystem;
using Exiled.API.Features;
using Syinergy_RP.API.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syinergy_RP.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class UnCuff : ICommand
    {
        public List<CDClass> usagers = new List<CDClass>();
        public string Command => "uncuff";

        public string[] Aliases => new string[] { };

        public string Description => "Попытаться снять стяжки.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(sender);
            CDClass usager2 = usagers.Where(x => x.userid == pl.UserId).FirstOrDefault();
            if (usager2 != null)
            {
                if ((DateTime.Now - usager2.LastUse).TotalSeconds < 20.0)
                {
                    response = "Слишком часто используешь комманду. Подожди...";
                    return false;
                }

                usagers.Remove(usager2);
            }

            usagers.Add(new CDClass
            {
                userid = pl.UserId,
                LastUse = DateTime.Now
            });
            var rnd = UnityEngine.Random.Range(0, 100);
            if(rnd < 69)
            {
                response = "Не повезло";
                return false;
            }
            pl.RemoveHandcuffs();
            response = "Повезло";
            return true;
        }
    }
}
