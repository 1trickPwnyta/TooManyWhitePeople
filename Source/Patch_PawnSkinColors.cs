using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace TooManyWhitePeople
{
    [HarmonyPatch(typeof(PawnSkinColors))]
    [HarmonyPatch(nameof(PawnSkinColors.RandomMelanin))]
    public static class Patch_PawnSkinColors_RandomMelanin
	{
        public static void Postfix(ref float __result) 
        {
            __result = Rand.Value;
        }
    }

    [HarmonyPatch(typeof(PawnSkinColors))]
    [HarmonyPatch(nameof(PawnSkinColors.GetMelaninCommonalityFactor))]
    public static class Patch_PawnSkinColors_GetMelaninCommonalityFactor
    {
        public static void Postfix(ref float __result)
        {
            __result = 1f;
        }
    }

    [HarmonyPatch(typeof(PawnSkinColors))]
    [HarmonyPatch(nameof(PawnSkinColors.GetSkinColor))]
    public static class Patch_PawnSkinColors_GetSkinColor
    {
        private static readonly SkinColorData[] SkinColors = new SkinColorData[]
        {
            new SkinColorData(0f, new Color32(242, 237, 224, byte.MaxValue)),
            new SkinColorData(0.25f, new Color32(byte.MaxValue, 239, 189, byte.MaxValue)),
            new SkinColorData(0.5f, new Color32(228, 158, 90, byte.MaxValue)),
            new SkinColorData(0.75f, new Color32(130, 91, 48, byte.MaxValue)),
            new SkinColorData(1f, new Color32(99, 70, 36, byte.MaxValue))
        };

        private struct SkinColorData
        {
            public SkinColorData(float melanin, Color color)
            {
                this.melanin = melanin;
                this.color = color;
            }

            public float melanin;
            public Color color;
        }

        private static int GetSkinDataIndexOfMelanin(float melanin)
        {
            int result = 0;
            int num = 0;
            while (num < SkinColors.Length && melanin >= SkinColors[num].melanin)
            {
                result = num;
                num++;
            }
            return result;
        }

        public static void Postfix(ref Color __result, float melanin)
        {
            int skinDataIndexOfMelanin = GetSkinDataIndexOfMelanin(melanin);
            if (skinDataIndexOfMelanin == SkinColors.Length - 1)
            {
                __result = SkinColors[skinDataIndexOfMelanin].color;
            }
            else
            {
                float t = Mathf.InverseLerp(SkinColors[skinDataIndexOfMelanin].melanin, SkinColors[skinDataIndexOfMelanin + 1].melanin, melanin);
                __result = Color.Lerp(SkinColors[skinDataIndexOfMelanin].color, SkinColors[skinDataIndexOfMelanin + 1].color, t);
            }
        }
    }
}
