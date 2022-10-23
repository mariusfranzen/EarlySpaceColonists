using Verse;
using UnityEngine;
using RimWorld;

namespace EarlySpacerColonists
{
    public class EarlySpacerColonists : Mod
    {

        public EarlySpacerColonists(ModContentPack content) : base(content)
        {
            GetSettings<EarlySpacerColonists_Settings>();
        }

        public override string SettingsCategory()
        {
            return "Early Spacer Colonists";
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.Gap(12f);
            listingStandard.CheckboxLabeled(
                Translator.TranslateSimple("shouldHaveSpacerTechLevel_title"),
                ref EarlySpacerColonists_Settings.ShouldHaveSpacerTechLevel,
                Translator.TranslateSimple("shouldHaveSpacerTechLevel_desc")
            );

            listingStandard.End();

            base.DoSettingsWindowContents(inRect);
        }

        public override void WriteSettings()
        {
            if (EarlySpacerColonists_Settings.ShouldHaveSpacerTechLevel)
            {
                DefDatabase<FactionDef>.GetNamed("EarlySpacerColonists").techLevel = TechLevel.Spacer;
                Log.Message("Set the default techlevel to Spacer");
            }
            else
            {
                DefDatabase<FactionDef>.GetNamed("EarlySpacerColonists").techLevel = TechLevel.Industrial;
                Log.Message("Set the default techlevel to Industrial");
            }

            base.WriteSettings();
        }
    }
}
