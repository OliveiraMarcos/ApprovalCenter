using System;

namespace AprovationCenter.Domain.General.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
