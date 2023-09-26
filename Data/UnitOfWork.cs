using System;
using GameStore.Data.Entities;
using GameStore.Data.Repository;

namespace GameStore.Data.UOW;
public class UnitOfWork : IDisposable, IUnitOfWork
{
    private readonly ApplicationDbContext Context;
    public IGameRepository Games { get; }
    public IGenreRepository Genres { get; }

    public UnitOfWork(ApplicationDbContext context, IGameRepository games, IGenreRepository genres)
    {
        Context = context;
        Games = games;
        Genres = genres;
    }

    public void Save()
    {
        Context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Context.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}