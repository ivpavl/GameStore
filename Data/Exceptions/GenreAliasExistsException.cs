
namespace GameStore.Data.Exceptions;

public class GenreAliasExistsException : Exception
{
    public GenreAliasExistsException()
    {
    }

    public GenreAliasExistsException(string message)
        : base(message)
    {
    }

    public GenreAliasExistsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

}
