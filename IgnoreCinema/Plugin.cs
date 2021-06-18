using IPA;
using IPALogger = IPA.Logging.Logger;
using HarmonyLib;
using System.Reflection;
using UnityEngine.UI;

namespace IgnoreCinema
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        internal static Harmony harmony { get; private set; }

        [Init]
        public void Init(IPALogger logger)
        {
            Instance = this;
            Log = logger;
            harmony = new Harmony("com.headassbtw.ignorecinema");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
    [HarmonyPatch(typeof(StandardLevelDetailView))]
    [HarmonyPatch("RefreshContent", MethodType.Normal)]
    [HarmonyAfter("com.kyle1413.BeatSaber.SongCore")]
    internal class RequirementPatch
    {
        internal static void Postfix(StandardLevelDetailView __instance, ref IDifficultyBeatmap ____selectedDifficultyBeatmap, ref Button ____actionButton, ref Button ____practiceButton)
        {
            Plugin.Log.Notice("Fuckin Gamer");
            var diffData = SongCore.Collections.RetrieveDifficultyData(____selectedDifficultyBeatmap);

            for (int i = 0; i < diffData.additionalDifficultyData._requirements.Length; i++)
            {
                if (diffData.additionalDifficultyData._requirements[i].ToLower().Equals("cinema"))
                {
                    ____actionButton.interactable = true;
                    ____practiceButton.interactable = true;
                }
            }
        }

    }

}
