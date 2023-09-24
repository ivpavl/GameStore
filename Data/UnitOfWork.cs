using System;
using GameStore.Data.Entities;
using GameStore.Data.Repository;

namespace GameStore.Data.UOW;
public class UnitOfWork : IDisposable, IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IGameRepository Games { get; }

    public UnitOfWork(ApplicationDbContext context, IGameRepository _games)
    {
        _context = context;
        Games = _games;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _context.Dispose();
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