using ApprovalCenter.Domain.Category.Entities;
using ApprovalCenter.Domain.Core.Models;
using System;

namespace ApprovalCenter.Domain.Alert
{
    public class AlertEntity : Entity
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public CategoryEntity Category { get; set; }
        public Guid CategoryId { get; set; }
        public string Email { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateRead { get; set; }
    }
}
