using System.Collections.Generic;
using Verse;
using UnityEngine;
using HugsLib;
using HugsLib.Settings;
using RimWorld;

namespace EarlySpacerColonists
{
    public class Settings : ModBase
    {
        public override string ModIdentifier
        {
            get { return "EarlySpacerColonists"; }
        }

        private SettingHandle<bool> shouldHaveSpacerTechLevel;

        public override void DefsLoaded()
        {
            if (ModIsActive)
            {
                shouldHaveSpacerTechLevel = Settings.GetHandle(
                    "shouldHaveSpacerTechLevel",
                    "shouldHaveSpacerTechLevel_title".Translate(),
                    "shouldHaveSpacerTechLevel_desc".Translate(),
                    false
                );
            }
        }

        public override void SettingsChanged()
        {
            if (shouldHaveSpacerTechLevel)
            {
                DefDatabase<FactionDef>.GetNamed("EarlySpacerColonists").techLevel = TechLevel.Spacer;
                Log.Message("Set the default techlevel to " + DefDatabase<FactionDef>.GetNamed("EarlySpacerColonists").techLevel);
            }
            else
            {
                DefDatabase<FactionDef>.GetNamed("EarlySpacerColonists").techLevel = TechLevel.Industrial;
                Log.Message("Set the default techlevel to " + DefDatabase<FactionDef>.GetNamed("EarlySpacerColonists").techLevel);
            }

            base.SettingsChanged();
        }
    }
}
