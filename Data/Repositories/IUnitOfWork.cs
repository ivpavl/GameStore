using System;
using GameStore.Data.Entities;
using GameStore.Data.Repository;

namespace GameStore.Data.UOW;
public interface IUnitOfWork
{
    public IGameRepository Games { get; }
    public void Save();
}