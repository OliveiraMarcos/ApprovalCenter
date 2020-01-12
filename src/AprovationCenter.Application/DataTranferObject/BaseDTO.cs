using System;
using System.ComponentModel.DataAnnotations;

namespace AprovationCenter.Application.DataTranferObject
{
    public class BaseDTO
    {
        [Key]
        public Guid Id { get; set; }
    }
}
