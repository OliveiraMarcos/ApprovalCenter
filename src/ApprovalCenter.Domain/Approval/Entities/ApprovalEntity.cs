using ApprovalCenter.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalCenter.Domain.Approval.Entities
{
    public class ApprovalEntity : Entity
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public bool? IsApproval { get; set; }
        public string Justification { get; set; }
        public CategoryEntity Category { get; set; }
        public Guid CategoryId { get; set; }
        public string EmailApproval { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateApproval { get; set; }
        public DateTime? DateRead { get; set; }
    }
}
