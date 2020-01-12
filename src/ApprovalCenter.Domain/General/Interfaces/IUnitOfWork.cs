using System;

namespace ApprovalCenter.Domain.General.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
