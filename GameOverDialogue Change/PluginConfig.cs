using BepInEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOverDialogue_Change
{
    public class PluginConfig
    {
        public readonly int scrapMode;

        public PluginConfig(Plugin BindingPlugin)
        {
            scrapMode = BindingPlugin.Config.Bind(Plugin.modGUID, "iScrapMode", 0, "Change the game over text for when the ship leaves a moon without a crew.\nSelect an int between 0 and 2.\n0 is SAVE_NONE, 1 is SAVE_COINFLIP, 2 is SAVE_ALL\nHost Required: Probably Yes").Value;
        }
    }
}
