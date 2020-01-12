using System;
using ApprovalCenter.Domain.General.Interfaces;

namespace ApprovalCenter.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public bool Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
