using ApprovalCenter.Domain.Core.Commands;
using System;

namespace ApprovalCenter.Domain.Category.Commands
{
    public abstract class CategoryCommand : CommandIdentity
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime DateCreate { get; protected set; }
        public DateTime DateEdit { get; protected set; }
    }
}
