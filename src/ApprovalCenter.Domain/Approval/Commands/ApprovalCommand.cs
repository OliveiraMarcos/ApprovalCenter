﻿using ApprovalCenter.Domain.Core.Commands;
using System;

namespace ApprovalCenter.Domain.Approval.Commands
{
    public abstract class ApprovalCommand : CommandIdentity
    {
        public string Subject { get;protected set; }
        public string Description { get; protected set; }
        public bool? IsApproval { get; protected set; }
        public string Justification { get; protected set; }
        public Guid CategoryId { get; protected set; }
        public string EmailApproval { get; protected set; }
        public DateTime DateCreate { get; protected set; }
        public DateTime? DateApproval { get; protected set; }
        public DateTime? DateRead { get; protected set; }
    }
}
