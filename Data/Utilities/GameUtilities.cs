namespace GameStore.Data.Utilities;
public static class GameUtilities
{
    public static string GenerateUniqueAlias(string gameName)
    {
        return gameName.ToLower().Replace(" ", "-");
    }
}