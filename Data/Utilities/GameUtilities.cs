namespace GameStore.Data.Utilities;
public static class GameUtilities
{
    public static string GenerateUniqueAlias(string gameName)
    {
        return gameName.ToLower().Replace(" ", "-");
    }
    public static string GenerateGameFileName(string gameAlias)
    {
        return $"{gameAlias}_{DateTime.Now:ddMMyyyyHHmmss}.txt";
    }
}