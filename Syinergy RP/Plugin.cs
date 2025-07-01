using Exiled.API.Features;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syinergy_RP
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin plugin;
        public EventHandlers eventHandlers;
        public override string Author => "Zolics";
        public override string Prefix => "sinergy_plugin";
        public override string Name => "Sinergy RP";
        public override Version Version => new Version(1, 1, 1);
        public Harmony harmony;
        public override void OnEnabled()
        {
            
            harmony = new Harmony($"Sinergy - {DateTime.Now.Ticks}");
            plugin = this;
            eventHandlers = new EventHandlers();
            base.OnEnabled();
        }
        public override void OnDisabled() 
        { 
            plugin = null;
            eventHandlers = null;
            base.OnDisabled();
        }
    }
}
