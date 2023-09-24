
namespace GameStore.Data.Exceptions;

public class GameAliasExistsException : Exception
{
    public GameAliasExistsException()
    {
    }

    public GameAliasExistsException(string message)
        : base(message)
    {
    }

    public GameAliasExistsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

}
