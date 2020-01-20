using ApprovalCenter.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalCenter.Domain.Approval.Entities
{
    public class CategoryEntity : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateEdit { get; set; }
    }
}
