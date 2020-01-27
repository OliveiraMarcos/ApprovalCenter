using ApprovalCenter.Domain.Core.Events;
using System;

namespace ApprovalCenter.Domain.Category.Events
{
    public class CategoryEvent : EventIdentity
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime DateCreate { get; protected set; }
        public DateTime DateEdit { get; protected set; }
    }
}
