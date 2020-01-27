using System;

namespace ApprovalCenter.Domain.Core.Commands
{
    public abstract class CommandIdentity : Command
    {
        public Guid Id { get; protected set; }
    }
}
