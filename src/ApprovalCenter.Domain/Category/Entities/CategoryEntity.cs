using ApprovalCenter.Domain.Core.Models;
using System;

namespace ApprovalCenter.Domain.Category.Entities
{
    public class CategoryEntity : Entity
    {
        public CategoryEntity(Guid id, string name, string description, DateTime dateCreate, DateTime dateEdit)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.DateCreate = dateCreate;
            this.DateEdit = dateEdit;
        }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime DateCreate { get; protected set; }
        public DateTime DateEdit { get; protected set; }
    }
}
