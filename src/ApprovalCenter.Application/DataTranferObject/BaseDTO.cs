using System;
using System.ComponentModel.DataAnnotations;

namespace ApprovalCenter.Application.DataTranferObject
{
    public class BaseDTO
    {
        [Key]
        public Guid Id { get; set; }
    }
}
