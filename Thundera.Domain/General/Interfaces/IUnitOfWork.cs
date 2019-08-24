using System;

namespace Thundera.Domain.General.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
