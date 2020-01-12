using System;
using AprovationCenter.Domain.General.Interfaces;

namespace AprovationCenter.Infra.Data.UoW
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
