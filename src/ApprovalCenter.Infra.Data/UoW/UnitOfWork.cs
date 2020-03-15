using System;
using ApprovalCenter.Domain.General.Interfaces;
using ApprovalCenter.Infra.Data.Context;

namespace ApprovalCenter.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApprovalCenterContext _context;

        public UnitOfWork(ApprovalCenterContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
