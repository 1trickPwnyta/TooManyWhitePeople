using Verse;
using HarmonyLib;

namespace TooManyWhitePeople
{
    public class TooManyWhitePeopleMod : Mod
    {
        public const string PACKAGE_ID = "toomanywhitepeople.1trickPonyta";
        public const string PACKAGE_NAME = "Too Many White People";

        public TooManyWhitePeopleMod(ModContentPack content) : base(content)
        {
            var harmony = new Harmony(PACKAGE_ID);
            harmony.PatchAll();

            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }
    }
}
