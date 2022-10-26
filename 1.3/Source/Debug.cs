namespace TooManyWhitePeople
{
    public static class Debug
    {
        public static void Log(string message)
        {
#if DEBUG
            Verse.Log.Message($"[{TooManyWhitePeopleMod.PACKAGE_NAME}] {message}");
#endif
        }
    }
}
