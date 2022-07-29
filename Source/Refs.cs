using HarmonyLib;
using RimWorld;
using System.Reflection;

namespace TooManyWhitePeople
{
    public static class Refs
    {
        public static MethodInfo m_ChildRelationUtility_GetMelaninSimilarityFactor = AccessTools.Method(typeof(ChildRelationUtility), "GetMelaninSimilarityFactor");
    }
}
