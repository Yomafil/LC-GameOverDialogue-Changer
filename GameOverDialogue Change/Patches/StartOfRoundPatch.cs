using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOverDialogue_Change.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class StartOfRoundPatch
    {
        static int scrapMode = Plugin.CfgScrapMode;

        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        static void GameOverDialogueChange(ref DialogueSegment[] ___gameOverDialogue)
        {
            if (scrapMode == 0)
            {
                Plugin.Log.LogInfo("No text were changed.");
            }
            else if (scrapMode == 1)
            {
                Plugin.Log.LogInfo("Changed text to SAVE_COIN mode.");
                ___gameOverDialogue[1].bodyText = "The autopilot will now attempt to fly to the closest safe spaceport. Some of your items have been lost.";
            }
            else if (scrapMode == 2)
            {
                Plugin.Log.LogInfo("Changed text to SAVE_ALL mode.");
                ___gameOverDialogue[1].bodyText = "The autopilot will now attempt to fly to the closest safe spaceport. None of your items have been lost.";
            }
            else
            {
                Plugin.Log.LogError(scrapMode);
            }
        }
    }
}
