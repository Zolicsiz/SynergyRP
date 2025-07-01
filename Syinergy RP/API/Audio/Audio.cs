using System;
using System.IO;
using Mirror;
using Exiled.API.Features;
using SCPSLAudioApi.AudioCore;
using Object = UnityEngine.Object;
using AudioInteract.Features;
using Exiled.API.Features.Roles;
using MEC;
using System.Xml.Linq;
using UnityEngine;
using PlayerRoles;
using VoiceChat;

namespace Syinergy_RP.API.Audio
{
    internal class Audio
    {
        public static ReferenceHub Dummy;
        /// <summary>Проиграть аудиофайл</summary>
        public static void PlayAudio(string name, RoleTypeId role, string path, VoiceChatChannel voicechat, int time)
        {
            var npc = AudioInteract.Features.API.CreateNPC(name, role).Play(path, voicechat);
            npc.LoggedType = LoggedType.Info;
            Timing.CallDelayed(time, () => {
                npc.Stop();
                
            });
        }
        /// <summary>Остановить прогирывание</summary>
        

    }
}
