using System.Collections.Generic;
using Verse;
using UnityEngine;
using HugsLib;
using HugsLib.Settings;
using RimWorld;

namespace EarlySpacerColonists
{
    public class EarlySpacerColonists : ModBase
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
                ApplySettings();
            }
        }

        public override void SettingsChanged()
        {
            ApplySettings();
            base.SettingsChanged();
        }

        public void ApplySettings()
        {
            if (shouldHaveSpacerTechLevel)
            {
                DefDatabase<FactionDef>.GetNamed("EarlySpacerColonists").techLevel = TechLevel.Spacer;
                Log.Message("[EarlySpacerColonists] Set the default techlevel to Spacer");
            }
            else
            {
                DefDatabase<FactionDef>.GetNamed("EarlySpacerColonists").techLevel = TechLevel.Industrial;
                Log.Message("[EarlySpacerColonists] Set the default techlevel to Industrial");
            }
        }
    }
}
