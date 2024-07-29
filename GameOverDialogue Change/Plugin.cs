using BepInEx;
using BepInEx.Logging;
using GameNetcodeStuff;
using GameOverDialogue_Change.Patches;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOverDialogue_Change
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    { 
        public const string modGUID = "GameOverDialogueChanger";
        private const string modName = "GameOverDialogue Changer";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new(modGUID);

        public static Plugin Instance;

        internal static PluginConfig CFg { get; private set; } = null!;

        public static ManualLogSource Log => Instance.Logger;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            CFg = new(this);

            Log.LogInfo("GameOverDialogue Changer as been loaded!");

            harmony.PatchAll(typeof(StartOfRoundPatch));
        }
    }
}

