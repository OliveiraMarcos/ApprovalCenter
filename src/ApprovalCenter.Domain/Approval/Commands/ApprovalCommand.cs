using ApprovalCenter.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalCenter.Domain.Approval.Commands
{
    public abstract class ApprovalCommand : CommandIdentity
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public bool? IsApproval { get; set; }
        public string Justification { get; set; }
        public Guid CategoryId { get; set; }
        public string EmailApproval { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateApproval { get; set; }
        public DateTime? DateRead { get; set; }
    }
}
